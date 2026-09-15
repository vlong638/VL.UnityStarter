using System.Collections.Generic;
using System;
using Godot;

namespace VL.Game0903;

public partial class ItemGenerator : Node2D
{
    // ✅ 可导出参数，方便在编辑器中调整
    [Export] private PackedScene scene = null!;
    [Export] public float spawnRangeX;  // 左右范围 ±192
    [Export] public float spawnRangeY;  // 上下范围 ±320

    private readonly List<Node2D> items = new();
    private readonly Random _random = new();

    public override void _Ready()
    {
    }

    /// <summary>
    /// 生成随机数量的 Item 实例
    /// </summary>
    public void GenerateItems(string tscnSrc, Rect2 range, int count, Node2D parent)
    {
        spawnRangeX = range.Size.X;
        spawnRangeY = range.Size.Y;
        scene = GD.Load<PackedScene>(tscnSrc);
        if (scene == null)
        {
            GD.PrintErr("❌ 无法加载 .tscn文件，请检查路径或设置 tscnSrc");
            return;
        }

        Clear();
        GD.Print($"📦 准备生成 {count} 个 Item");
        for (int i = 0; i < count; i++)
        {
            var node = GenerateSingle(i);
            parent.AddChild(node);
        }
        GD.Print($"✅ 成功生成 {items.Count} 个 Items");
    }

    /// <summary>
    /// 生成单个 实例
    /// </summary>
    private Node2D GenerateSingle(int index)
    {
        if (scene == null)
        {
            GD.PrintErr("❌ 场景未加载");
            return null;
        }

        try
        {
            // 实例化
            var item = scene.Instantiate() as Node2D;
            if (item == null)
            {
                GD.PrintErr($"❌ 第 {index} 个 实例化失败");
                return null;
            }

            // ✅ 设置随机位置（在指定范围内）
            float x = (float)(_random.NextDouble() * 2 - 1) * spawnRangeX;
            float y = (float)(_random.NextDouble() * 2 - 1) * spawnRangeY;
            item.Position = new Vector2(x, y);


            // ✅ 设置随机颜色（如果脚本支持）
            item.Modulate = new Color(
                (float)_random.NextDouble(),
                (float)_random.NextDouble(),
                (float)_random.NextDouble()
            );

            // 设置名称以便识别
            item.Name = $"Item{index}";
            items.Add(item);

            // 调试输出（可选，避免刷屏）
            if (index % 5 == 0 || index == 0)
            {
                GD.Print($"  📍 Item {index}: 位置({x:F1}, {y:F1})");
            }
            return item;
        }
        catch (System.Exception ex)
        {
            GD.PrintErr($"❌ 生成第 {index} 个 Item 时发生异常: {ex.Message}");
            return null;
        }
    }

    /// <summary>
    /// 清空所有
    /// </summary>
    public void Clear()
    {
        foreach (var item in items)
        {
            if (item != null && !item.IsQueuedForDeletion())
            {
                item.QueueFree();
            }
        }
        items.Clear();
        GD.Print("🗑️ 已清空所有 Item");
    }
}
