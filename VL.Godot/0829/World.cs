using Godot;
using System.Collections.Generic;

namespace OtherworldHero;

public partial class World : Node2D
{
    public Rect2 PlayBounds = new(18, 80, 1116, 550);
    public readonly List<ResourceNode> Resources = new();
    public readonly List<Campfire> Fires = new();
    private readonly RandomNumberGenerator random = new();

    public override void _Ready()
    {
        random.Randomize();
        for (int i = 0; i < 33; i++)
        {
            ItemType type = i % 3 == 0 ? ItemType.Berry : (i % 2 == 0 ? ItemType.Stone : ItemType.Wood);
            var node = new ResourceNode(type) { Position = RandomPosition() };
            Resources.Add(node); AddChild(node);
        }
        QueueRedraw();
    }
    public override void _Draw()
    {
        DrawRect(PlayBounds, new Color("315f44"));
        for (float x = PlayBounds.Position.X; x < PlayBounds.End.X; x += 48)
            DrawLine(new Vector2(x, PlayBounds.Position.Y), new Vector2(x, PlayBounds.End.Y), new Color(1, 1, 1, .025f));
        DrawRect(PlayBounds, new Color("a7d17e"), false, 3);
    }
    public Vector2 RandomPosition() => new(random.RandfRange(55, 1095), random.RandfRange(118, 603));
    public bool NearFire(Vector2 point) => Fires.Exists(f => f.Position.DistanceTo(point) <= f.Radius);
    public void PlaceFire(Vector2 position) { var fire = new Campfire { Position = position }; Fires.Add(fire); AddChild(fire); }
}
