using System;
using System.Collections.Generic;
using System.Text.Json;
using Godot;
using FileAccess = Godot.FileAccess;

namespace VL.Godot.VLCommon;

public static class VLInputMapper
{
    // 一个动作可能同时绑定键盘键和鼠标键
    private static readonly Dictionary<string, InputBinding> Bindings = new();

    // 用一个小类把键盘和鼠标分开存
    private class InputBinding
    {
        public List<Key> Keys = new();
        public List<MouseButton> MouseButtons = new();
    }

    public static void Load()
    {
        Bindings.Clear();
        var file = FileAccess.Open("res://Assets/Configs/InputMap.json", FileAccess.ModeFlags.Read);
        if (file == null)
        {
            GD.PrintErr("无法加载 InputMap.json 文件！");
            return;
        }

        var jsonText = file.GetAsText();
        var map = JsonSerializer.Deserialize<Dictionary<string, string[]>>(jsonText);
        if (map == null)
        {
            GD.PrintErr("InputMap.json 格式错误！");
            return;
        }

        foreach (var (action, entries) in map)
        {
            var binding = new InputBinding();
            foreach (var entry in entries)
            {
                // 鼠标：以 "Mouse:" 开头，例如 "Mouse:Left"
                if (entry.StartsWith("Mouse:", StringComparison.OrdinalIgnoreCase))
                {
                    var mouseName = entry.Substring("Mouse:".Length);
                    if (Enum.TryParse<MouseButton>(mouseName, true, out var mb))
                    {
                        binding.MouseButtons.Add(mb);
                        GD.Print($"绑定: {action} -> Mouse:{mouseName} (MouseButton: {mb})");
                    }
                    else
                    {
                        GD.PrintErr($"无法解析鼠标按键: {entry} (Action: {action})");
                    }
                }
                // 键盘：直接按 Key 解析
                else
                {
                    if (Enum.TryParse<Key>(entry, true, out var key))
                    {
                        binding.Keys.Add(key);
                        GD.Print($"绑定: {action} -> {entry} (KeyCode: {key})");
                    }
                    else
                    {
                        GD.PrintErr($"无法解析按键: {entry} (Action: {action})");
                    }
                }
            }

            Bindings[action] = binding;
        }

        GD.Print($"InputMapper 加载完成，共 {Bindings.Count} 个动作绑定");
        RegisterToGodot();
    }
    private static void RegisterToGodot()
    {
        GD.Print("🔄 正在更新 Godot Input Map...");

        foreach (var (action, binding) in Bindings)
        {
            if (!InputMap.HasAction(action))
            {
                InputMap.AddAction(action);
                GD.Print($"  📝 创建新动作: {action}");
            }
            else
            {
                // 清除已有绑定，避免重复
                InputMap.ActionGetEvents(action).Clear();
                GD.Print($"  🔄 更新动作: {action}");
            }

            // 键盘
            foreach (var key in binding.Keys)
            {
                var inputEvent = new InputEventKey { Keycode = key };
                InputMap.ActionAddEvent(action, inputEvent);
                GD.Print($"    ⌨️ 绑定: {key}");
            }

            // 鼠标
            foreach (var mb in binding.MouseButtons)
            {
                var inputEvent = new InputEventMouseButton { ButtonIndex = mb };
                InputMap.ActionAddEvent(action, inputEvent);
                GD.Print($"    🖱️ 绑定: {mb}");
            }
        }

        GD.Print("✅ Godot Input Map 更新完成");
    }

    public static bool Pressed(string action)
    {
        if (!Bindings.TryGetValue(action, out var binding))
            return false;

        foreach (var key in binding.Keys)
        {
            if (Input.IsKeyPressed(key)) return true;
        }

        foreach (var mb in binding.MouseButtons)
        {
            if (Input.IsMouseButtonPressed(mb)) return true;
        }

        return false;
    }

    public static bool JustPressed(InputEvent e, string action)
    {
        if (!Bindings.TryGetValue(action, out var binding))
            return false;

        // 键盘
        if (e is InputEventKey key && key.Pressed && !key.Echo)
        {
            foreach (var k in binding.Keys)
            {
                if (k == key.Keycode) return true;
            }
        }

        // 鼠标
        if (e is InputEventMouseButton mb && mb.Pressed)
        {
            foreach (var m in binding.MouseButtons)
            {
                if (m == mb.ButtonIndex) return true;
            }
        }

        return false;
    }

    public static Vector2 GetMove()
    {
        var moveX = (Pressed("MoveRight") ? 1 : 0) - (Pressed("MoveLeft") ? 1 : 0);
        var moveY = (Pressed("MoveDown") ? 1 : 0) - (Pressed("MoveUp") ? 1 : 0);
        var direction = new Vector2(moveX, moveY);

        // ✅ 防止返回 NaN
        return direction.LengthSquared() > 0 ? direction.Normalized() : Vector2.Zero;
    }

    // 可选：添加调试方法
    public static void PrintBindings()
    {
        GD.Print("=== 当前按键绑定 ===");
        foreach (var (action, binding) in Bindings)
        {
            var keyNames = string.Join(", ", binding.Keys);
            var mouseNames = string.Join(", ", binding.MouseButtons);
            GD.Print($"{action}: Keys=[{keyNames}] Mouse=[{mouseNames}]");
        }
    }
}
