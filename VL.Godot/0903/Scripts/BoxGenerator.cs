using System.Collections.Generic;
using System;
using Godot;

namespace VL.Game0903;

public partial class BoxGenerator : Node2D
{
    // ✅ 可导出参数，方便在编辑器中调整
    [Export] private PackedScene _boxScene = null!;
    [Export] public float _spawnRangeX = 192f;  // 左右范围 ±192
    [Export] public float _spawnRangeY = 320f;  // 上下范围 ±320

    private readonly List<Node2D> _boxes = new();
    private readonly Random _random = new();

    public override void _Ready()
    {
        // 检查 Box 场景是否已加载
        if (_boxScene == null)
        {
            // 尝试从默认路径加载
            _boxScene = GD.Load<PackedScene>("res://Assets/Nodes/Box.tscn");
            if (_boxScene == null)
            {
                GD.PrintErr("❌ 无法加载 Box.tscn，请检查路径或设置 _boxScene");
                return;
            }
        }
    }

    /// <summary>
    /// 生成随机数量的 Box 实例
    /// </summary>
    public void GenerateBoxes(int count)
    {
        ClearBoxes();
        GD.Print($"📦 准备生成 {count} 个 Box");
        for (int i = 0; i < count; i++)
        {
            GenerateSingleBox(i);
        }
        GD.Print($"✅ 成功生成 {_boxes.Count} 个 Box");
    }

    /// <summary>
    /// 生成单个 Box 实例
    /// </summary>
    private void GenerateSingleBox(int index)
    {
        if (_boxScene == null)
        {
            GD.PrintErr("❌ Box 场景未加载");
            return;
        }

        try
        {
            // 实例化 Box
            var box = _boxScene.Instantiate() as Node2D;
            if (box == null)
            {
                GD.PrintErr($"❌ 第 {index} 个 Box 实例化失败");
                return;
            }

            // ✅ 设置随机位置（在指定范围内）
            float x = (float)(_random.NextDouble() * 2 - 1) * _spawnRangeX;
            float y = (float)(_random.NextDouble() * 2 - 1) * _spawnRangeY;
            box.Position = new Vector2(x, y);


            // ✅ 设置随机颜色（如果 Box 脚本支持）
            box.Modulate = new Color(
                (float)_random.NextDouble(),
                (float)_random.NextDouble(),
                (float)_random.NextDouble()
            );

            // 设置名称以便识别
            box.Name = $"Box_{index:D3}";

            // 添加到场景
            AddChild(box);
            _boxes.Add(box);

            // 调试输出（可选，避免刷屏）
            if (index % 5 == 0 || index == 0)
            {
                GD.Print($"  📍 Box {index}: 位置({x:F1}, {y:F1})");
            }
        }
        catch (System.Exception ex)
        {
            GD.PrintErr($"❌ 生成第 {index} 个 Box 时发生异常: {ex.Message}");
        }
    }

    /// <summary>
    /// 清空所有 Box
    /// </summary>
    public void ClearBoxes()
    {
        foreach (var box in _boxes)
        {
            if (box != null && !box.IsQueuedForDeletion())
            {
                box.QueueFree();
            }
        }
        _boxes.Clear();
        GD.Print("🗑️ 已清空所有 Box");
    }

    /// <summary>
    /// 获取所有 Box 的数量
    /// </summary>
    public int GetBoxCount() => _boxes.Count;

    /// <summary>
    /// 获取所有 Box 的位置信息（调试用）
    /// </summary>
    public void PrintBoxPositions()
    {
        GD.Print("=== Box 位置信息 ===");
        for (int i = 0; i < _boxes.Count; i++)
        {
            var box = _boxes[i];
            if (box != null)
            {
                GD.Print($"Box {i:D3}: 位置({box.Position.X:F1}, {box.Position.Y:F1})");
            }
        }
    }
}
