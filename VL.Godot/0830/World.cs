#nullable enable
using Godot;
using System.Collections.Generic;

namespace OtherworldHeroTD;

public partial class World : Node2D
{
    public readonly Rect2 Bounds = new(18, 80, 1116, 550);
    public readonly List<ResourceNode> Resources = new();
    public readonly List<Campfire> Fires = new();
    public readonly List<DefenseTower> Towers = new();
    public override void _Draw()
    {
        DrawRect(Bounds, new Color("315f44"));
        DrawRect(Bounds, new Color("a7d17e"), false, 2);
        for (float x = Bounds.Position.X; x < Bounds.End.X; x += 48) DrawLine(new Vector2(x, Bounds.Position.Y), new Vector2(x, Bounds.End.Y), new Color(1,1,1,.025f));
    }
    public bool NearFire(Vector2 p) => Fires.Exists(x => x.Position.DistanceTo(p) < 110);
    public void Place(ItemType item, Vector2 p)
    {
        if (item == ItemType.Campfire) { var x = new Campfire { Position=p }; Fires.Add(x); AddChild(x); }
        if (item == ItemType.Tower) { var x = new DefenseTower { Position=p }; Towers.Add(x); AddChild(x); }
    }
}
