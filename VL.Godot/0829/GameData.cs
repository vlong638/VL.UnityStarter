using Godot;
using System.Collections.Generic;

namespace OtherworldHero;

public enum ItemType { Wood, Stone, Berry, Axe, Pickaxe, Campfire }

public record Recipe(string Name, ItemType Output, int Amount, Dictionary<ItemType, int> Cost);

public static class GameData
{
    public static readonly Recipe[] Recipes =
    {
        new("篝火", ItemType.Campfire, 1, new() { { ItemType.Wood, 6 }, { ItemType.Stone, 3 } }),
        new("石斧", ItemType.Axe, 1, new() { { ItemType.Wood, 3 }, { ItemType.Stone, 4 } }),
        new("石镐", ItemType.Pickaxe, 1, new() { { ItemType.Wood, 2 }, { ItemType.Stone, 5 } })
    };
    public static string ChineseName(ItemType item) => item switch
    {
        ItemType.Wood => "木材", ItemType.Stone => "石头", ItemType.Berry => "浆果",
        ItemType.Axe => "石斧", ItemType.Pickaxe => "石镐", ItemType.Campfire => "篝火", _ => item.ToString()
    };
}
