using Godot;
using System;
using System.Collections.Generic;



public enum ResourceKind { Tree, Stone, Berry, Base, ForestExit }
public sealed class WorldResource { public Vector2 Position; public ResourceKind Kind; public bool Collected; }

/// <summary>Builds a finite grid world and exposes reusable block-area generation.</summary>
public sealed class MapGenerator
{
    public readonly List<WorldResource> Resources = new();
    private readonly Random _random = new(830);
    public void GenerateWorld(int sizeX = 100, int sizeY = 100)
    {
        Resources.Clear();
        Resources.Add(new WorldResource { Position = new Vector2(sizeX / 2 * 16, sizeY / 2 * 16), Kind = ResourceKind.Base });
        Resources.Add(new WorldResource { Position = new Vector2(sizeX / 2 * 16 + 160, sizeY / 2 * 16), Kind = ResourceKind.ForestExit });
        GenerateBlockArea(sizeX, sizeY, Vector2.Zero);
    }
    /// <summary>Generates gatherable contents in a block. Corridors/borders may be layered on later.</summary>
    public void GenerateBlockArea(int sizeX, int sizeY, Vector2 origin)
    {
        for (int i = 0; i < Math.Max(18, sizeX * sizeY / 160); i++)
        {
            var kind = (ResourceKind)_random.Next(0, 3);
            Resources.Add(new WorldResource { Position = origin + new Vector2(_random.Next(2, sizeX - 2) * 16, _random.Next(2, sizeY - 2) * 16), Kind = kind });
        }
    }
}
