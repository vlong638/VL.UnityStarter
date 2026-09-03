using Godot;
using System.Collections.Generic;

namespace OtherworldHero;

/// <summary>Owns movement and the player's expandable inventory.</summary>
public partial class Player : Node2D
{
    public const float Speed = 245f;
    public Dictionary<ItemType, int> Inventory { get; } = new();
    public Vector2 Facing = Vector2.Down;

    public Player()
    {
        Inventory[ItemType.Wood] = 0; Inventory[ItemType.Stone] = 0; Inventory[ItemType.Berry] = 2;
    }

    public override void _Draw()
    {
        DrawCircle(Vector2.Zero, 15, new Color("f5d38b"));
        DrawCircle(new Vector2(0, -3), 9, new Color("4b7bbb"));
        DrawLine(Vector2.Zero, Facing * 22, Colors.White, 3);
    }

    public void Move(double delta, Rect2 bounds, bool canMove)
    {
        if (!canMove) return;
        Vector2 input = Input.GetVector("move_left", "move_right", "move_up", "move_down");
        if (input.LengthSquared() > 0)
        {
            Facing = input.Normalized();
            Position += Facing * Speed * (float)delta;
            Position = new Vector2(Mathf.Clamp(Position.X, bounds.Position.X + 18, bounds.End.X - 18), Mathf.Clamp(Position.Y, bounds.Position.Y + 18, bounds.End.Y - 18));
            QueueRedraw();
        }
    }

    public void Add(ItemType item, int amount) => Inventory[item] = Get(item) + amount;
    public int Get(ItemType item) => Inventory.TryGetValue(item, out int count) ? count : 0;
    public bool HasTool(ItemType tool) => Get(tool) > 0;
}
