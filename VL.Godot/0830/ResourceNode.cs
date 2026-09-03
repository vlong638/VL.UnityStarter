#nullable enable
using Godot;

namespace OtherworldHeroTD;

public partial class ResourceNode : Node2D
{
    public ItemType Item;
    public int Remaining = 3;
    public ResourceNode(ItemType item) { Item = item; }
    public override void _Ready() => ActorSprite.Add(this, GameData.Asset(Item), Item==ItemType.Wood ? 2.1f : 1.8f);
}
