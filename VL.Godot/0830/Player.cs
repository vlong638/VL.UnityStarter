#nullable enable
using Godot;
using System.Collections.Generic;

namespace OtherworldHeroTD;

public partial class Player : Node2D
{
    public readonly Dictionary<ItemType, int> Inventory = new() { {ItemType.Wood,0}, {ItemType.Stone,0}, {ItemType.Berry,2} };
    public Vector2 Facing = Vector2.Down;
    public override void _Ready() => ActorSprite.Add(this, "player", 2f);
    public void Move(double delta, Rect2 bounds, bool allowed)
    {
        if (!allowed) return;
        Vector2 direction = InputMapper.MoveDirection();
        if (direction != Vector2.Zero) { Facing = direction; Position += direction * 240 * (float)delta; }
        Position = new(Mathf.Clamp(Position.X, bounds.Position.X + 18, bounds.End.X - 18), Mathf.Clamp(Position.Y, bounds.Position.Y + 18, bounds.End.Y - 18));
    }
    public int Get(ItemType x) => Inventory.TryGetValue(x, out int amount) ? amount : 0;
    public void Add(ItemType x, int amount) => Inventory[x] = Get(x) + amount;
}
