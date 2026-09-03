using Godot;
using System.Collections.Generic;

namespace OtherworldHero0831;

public enum CellType { Grass, Forest, Base, Stone, Berry, Wall, Corridor }
public sealed class MapData
{
    public readonly int Width; public readonly int Height; public readonly CellType[,] Cells;
    public MapData(int width, int height) { Width = width; Height = height; Cells = new CellType[width, height]; }
}

/// <summary>Deterministic reusable world and block-area generator.</summary>
public sealed class MapGenerator
{
    private readonly RandomNumberGenerator _random = new();
    public MapGenerator() => _random.Seed = 831;
    public MapData GenerateWorld(int sizeX = 100, int sizeY = 100)
    {
        var map = new MapData(sizeX, sizeY);
        for (var x = 0; x < sizeX; x++) for (var y = 0; y < sizeY; y++) map.Cells[x, y] = _random.Randf() < .2f ? CellType.Forest : CellType.Grass;
        var cx = sizeX / 2; var cy = sizeY / 2;
        map.Cells[cx, cy] = CellType.Base;
        for (var x = cx - 5; x <= cx + 5; x++) for (var y = cy - 5; y <= cy + 5; y++)
            if (x >= 0 && y >= 0 && x < sizeX && y < sizeY && map.Cells[x, y] != CellType.Base) map.Cells[x, y] = CellType.Forest;
        return map;
    }
    public MapData GenerateBlockArea(int sizeX = 20, int sizeY = 20)
    {
        var map = new MapData(sizeX, sizeY);
        for (var x = 0; x < sizeX; x++) for (var y = 0; y < sizeY; y++)
        {
            var edge = x == 0 || y == 0 || x == sizeX - 1 || y == sizeY - 1;
            map.Cells[x, y] = edge ? CellType.Wall : CellType.Grass;
        }
        var midX = sizeX / 2; var midY = sizeY / 2;
        for (var i = -2; i < 2; i++) { map.Cells[midX + i, 0] = CellType.Corridor; map.Cells[midX + i, sizeY - 1] = CellType.Corridor; map.Cells[0, midY + i] = CellType.Corridor; map.Cells[sizeX - 1, midY + i] = CellType.Corridor; }
        for (var i = 0; i < 10; i++) map.Cells[_random.RandiRange(2, sizeX - 3), _random.RandiRange(2, sizeY - 3)] = i < 4 ? CellType.Forest : i < 7 ? CellType.Stone : CellType.Berry;
        map.Cells[midX, midY] = CellType.Base;
        return map;
    }
}
