#nullable enable
using Godot;
namespace OtherworldHeroTD;

/// <summary>Transparent icon shown before confirming a building placement.</summary>
public partial class PlacementPreview : Node2D
{
    private Sprite2D? sprite;
    public ItemType? Pending;
    public void Set(ItemType? item)
    {
        Pending=item; if(sprite!=null) sprite.QueueFree(); sprite=null;
        if(item.HasValue) sprite=ActorSprite.Add(this,GameData.Asset(item.Value),2.5f,.45f);
    }
    public void Follow(Player p) { Visible=Pending.HasValue; if(Visible) Position=p.Position+p.Facing*45; }
}
