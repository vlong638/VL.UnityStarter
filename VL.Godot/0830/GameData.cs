#nullable enable
using Godot;
using System.Collections.Generic;

namespace OtherworldHeroTD;

public enum Density { Low, Medium, High }
public enum ItemType { Wood, Stone, Berry, Axe, Pickaxe, Campfire, Tower }
public sealed record DifficultySettings(Density Resources, Density Enemies, Density EnemyHealth)
{
    public int ResourceCount => Resources == Density.Low ? 22 : Resources == Density.Medium ? 40 : 62;
    public int EnemyLimit => Enemies == Density.Low ? 3 : Enemies == Density.Medium ? 6 : 10;
    public float EnemyHp => EnemyHealth == Density.Low ? 28 : EnemyHealth == Density.Medium ? 50 : 84;
}
public sealed record Recipe(string Name, ItemType Output, Dictionary<ItemType, int> Cost);
public static class GameData
{
    public static readonly Recipe[] Recipes =
    {
        new("篝火", ItemType.Campfire, new() {{ItemType.Wood, 6}, {ItemType.Stone, 3}}),
        new("石斧", ItemType.Axe, new() {{ItemType.Wood, 3}, {ItemType.Stone, 4}}),
        new("石镐", ItemType.Pickaxe, new() {{ItemType.Wood, 2}, {ItemType.Stone, 5}}),
        new("防御塔", ItemType.Tower, new() {{ItemType.Wood, 10}, {ItemType.Stone, 8}})
    };
    public static string Name(ItemType x) => x switch { ItemType.Wood=>"木材", ItemType.Stone=>"石块", ItemType.Berry=>"浆果", ItemType.Axe=>"石斧", ItemType.Pickaxe=>"石镐", ItemType.Campfire=>"篝火", ItemType.Tower=>"防御塔", _=>x.ToString() };
    public static string Asset(ItemType x) => x switch { ItemType.Wood=>"tree", ItemType.Stone=>"stone", ItemType.Berry=>"berry", ItemType.Campfire=>"fire", ItemType.Tower=>"tower", _=>"player" };
}
