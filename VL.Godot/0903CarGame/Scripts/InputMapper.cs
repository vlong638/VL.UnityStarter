using System.Collections.Generic;
using System.Text.Json;
using Godot;
using FileAccess = Godot.FileAccess;

namespace VL.Game0903;

public static class InputMapper
{
    private static readonly Dictionary<string, Key[]> Bindings = new();

    public static void Load()
    {
        Bindings.Clear();
        var file = FileAccess.Open("res://Assets/Data/InputMap.json", FileAccess.ModeFlags.Read);
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

        foreach (var (action, keys) in map)
        {
            var parsed = new List<Key>();
            foreach (var key in keys)
            {
                if (System.Enum.TryParse<Key>(key, true, out var value))
                {
                    parsed.Add(value);
                    GD.Print($"绑定: {action} -> {key} (KeyCode: {value})");
                }
                else
                {
                    GD.PrintErr($"无法解析按键: {key} (Action: {action})");
                }
            }
            Bindings[action] = parsed.ToArray();
        }

        GD.Print($"InputMapper 加载完成，共 {Bindings.Count} 个动作绑定");
        RegisterToGodot();
    }
    private static void RegisterToGodot()
    {
        GD.Print("🔄 正在更新 Godot Input Map...");

        // 可选：清除所有已有的输入动作（谨慎使用）
        // 如果只想覆盖特定动作，可以注释掉这行
        // ClearAllGodotInputs();

        foreach (var (action, keys) in Bindings)
        {
            // 如果动作不存在，创建它
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

            // 添加按键绑定
            foreach (var key in keys)
            {
                var inputEvent = new InputEventKey
                {
                    Keycode = key
                };
                InputMap.ActionAddEvent(action, inputEvent);
                GD.Print($"    ⌨️ 绑定: {key}");
            }
        }

        GD.Print("✅ Godot Input Map 更新完成");
    }

    public static bool Pressed(string action)
    {
        return Bindings.TryGetValue(action, out var keys) &&
               System.Array.Exists(keys, Input.IsKeyPressed);
    }

    public static bool JustPressed(InputEvent e, string action)
    {
        return e is InputEventKey key &&
               key.Pressed &&
               !key.Echo &&
               Bindings.TryGetValue(action, out var keys) &&
               System.Array.Exists(keys, x => x == key.Keycode);
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
        foreach (var (action, keys) in Bindings)
        {
            var keyNames = string.Join(", ", keys);
            GD.Print($"{action}: [{keyNames}]");
        }
    }
}
