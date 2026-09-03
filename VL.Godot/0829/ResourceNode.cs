using Godot;

namespace OtherworldHero;

/// <summary>Harvestable node. Tools improve yield but never block the player.</summary>
public partial class ResourceNode : Node2D
{
    public ItemType Item;
    public int Remaining = 3;
    public string DisplayName = "资源";

    public ResourceNode(ItemType item)
    {
        Item = item;
        DisplayName = GameData.ChineseName(item);
    }

    public override void _Draw()
    {
        if (Item == ItemType.Wood)
        {
            DrawRect(new Rect2(-5, 0, 10, 19), new Color("795548"));
            DrawCircle(new Vector2(0, -9), 17, new Color("3f8048"));
        }
        else if (Item == ItemType.Stone)
            DrawCircle(Vector2.Zero, 14, new Color("9a9ca4"));
        else
        {
            DrawCircle(Vector2.Zero, 13, new Color("5b9b4b"));
            DrawCircle(new Vector2(-5, -3), 4, new Color("d75267"));
            DrawCircle(new Vector2(5, 3), 4, new Color("d75267"));
        }
    }
}
