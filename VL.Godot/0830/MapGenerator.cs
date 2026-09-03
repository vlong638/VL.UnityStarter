#nullable enable
using Godot;
using System.Collections.Generic;

namespace OtherworldHeroTD;

/// <summary>Generates resource batches separately so the loading UI can report each world-building step.</summary>
public sealed class MapGenerator
{
    private readonly RandomNumberGenerator rng = new();
    private readonly DifficultySettings settings;
    public MapGenerator(DifficultySettings settings) { this.settings = settings; rng.Randomize(); }
    public void GenerateBatch(World world, ItemType type, int divisor)
    {
        int count = settings.ResourceCount / divisor;
        for (int i=0; i<count; i++)
        {
            var node = new ResourceNode(type) { Position = new Vector2(rng.RandfRange(55,1095), rng.RandfRange(118,603)) };
            world.Resources.Add(node); world.AddChild(node);
        }
    }
    public Vector2 EnemySpawn() => new(rng.RandfRange(45,1105), rng.RandfRange(105,610));
}
