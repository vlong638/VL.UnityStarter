using Godot;
using System;

namespace OtherworldHero0831;

/// <summary>Equivalent to a TileMap: compact 16px-color tile renderer for generated maps.</summary>
public partial class MapView : Node2D
{
    public Action<Vector2>? CellSelected;
    public MapData? Data { get; private set; }
    public Vector2 PlayerCell { get; private set; }
    public Vector2 TargetCell { get; private set; }
    public bool IsWorld { get; private set; }
    private const int Tile = 32;
    private readonly Vector2 _boardOrigin = new(460, 175);
    private bool _towerBuilt;
    private float _enemyTimer;
    private float _arrowTimer;
    private int _enemies;
    public void SetMap(MapData data, bool isWorld)
    {
        Data = data; IsWorld = isWorld; PlayerCell = new Vector2(data.Width / 2, data.Height / 2); TargetCell = PlayerCell; QueueRedraw();
    }
    public override void _Process(double delta)
    {
        if (Data == null) return;
        if (PlayerCell != TargetCell)
        {
            var direction = (TargetCell - PlayerCell).Sign();
            PlayerCell += direction;
        }
        if (_enemies > 0 && _towerBuilt)
        {
            _enemyTimer += (float)delta;
            if (_enemyTimer >= 3f) { _enemyTimer = 0; _enemies--; _arrowTimer = .35f; }
        }
        if (_arrowTimer > 0) _arrowTimer -= (float)delta;
        QueueRedraw();
    }
    public override void _UnhandledInput(InputEvent e)
    {
        if (Data == null || e is not InputEventMouseButton { ButtonIndex: MouseButton.Left, Pressed: true }) return;
        var local = GetLocalMousePosition() - _boardOrigin;
        var visibleW = Math.Min(Data.Width, 30); var visibleH = Math.Min(Data.Height, 20);
        if (local.X < 0 || local.Y < 0 || local.X >= visibleW * Tile || local.Y >= visibleH * Tile) return;
        var left = Math.Clamp(PlayerCell.X - visibleW / 2, 0, Math.Max(0, Data.Width - visibleW));
        var top = Math.Clamp(PlayerCell.Y - visibleH / 2, 0, Math.Max(0, Data.Height - visibleH));
        TargetCell = new Vector2(left + (int)(local.X / Tile), top + (int)(local.Y / Tile));
        CellSelected?.Invoke(TargetCell); QueueRedraw();
    }
    public bool IsAtBase() => Data != null && Data.Cells[(int)PlayerCell.X, (int)PlayerCell.Y] == CellType.Base;
    public bool IsNearBase() => Data != null && PlayerCell.DistanceTo(new Vector2(Data.Width / 2, Data.Height / 2)) <= 2;
    public CellType TargetType => Data == null ? CellType.Grass : Data.Cells[(int)TargetCell.X, (int)TargetCell.Y];
    public void MoveBy(Vector2 offset)
    {
        if (Data == null || offset == Vector2.Zero) return;
        var next = PlayerCell + offset;
        if (next.X < 0 || next.Y < 0 || next.X >= Data.Width || next.Y >= Data.Height || Data.Cells[(int)next.X, (int)next.Y] == CellType.Wall) return;
        PlayerCell = next; TargetCell = next; QueueRedraw();
    }
    public void BuildArcherTower() { _towerBuilt = true; QueueRedraw(); }
    public void StartNightWave() { _enemies = 3; _enemyTimer = 0; QueueRedraw(); }
    public override void _Draw()
    {
        if (Data == null) return;
        var visibleW = Math.Min(Data.Width, 30); var visibleH = Math.Min(Data.Height, 20);
        var left = Math.Clamp(PlayerCell.X - visibleW / 2, 0, Math.Max(0, Data.Width - visibleW));
        var top = Math.Clamp(PlayerCell.Y - visibleH / 2, 0, Math.Max(0, Data.Height - visibleH));
        DrawRect(new Rect2(_boardOrigin - new Vector2(6, 6), new Vector2(visibleW * Tile + 12, visibleH * Tile + 12)), new Color("1b2230"));
        for (var x = 0; x < visibleW; x++) for (var y = 0; y < visibleH; y++)
        {
            var cell = Data.Cells[(int)left + x, (int)top + y];
            var rect = new Rect2(_boardOrigin + new Vector2(x * Tile, y * Tile), new Vector2(Tile - 2, Tile - 2));
            DrawRect(rect, ColorFor(cell)); DrawRect(rect, new Color("161616"), false, 2);
            if (cell == CellType.Base) { DrawCircle(rect.GetCenter(), 8, new Color("d9a441")); DrawCircle(rect.GetCenter(), 3, Colors.White); }
        }
        var player = _boardOrigin + new Vector2((PlayerCell.X - left) * Tile + Tile / 2, (PlayerCell.Y - top) * Tile + Tile / 2);
        DrawCircle(player, 10, new Color("4cc9f0")); DrawCircle(player, 4, Colors.White);
        if (IsNearBase()) DrawString(ThemeDB.FallbackFont, _boardOrigin + new Vector2((Data.Width / 2 - left) * Tile - 30, (Data.Height / 2 - top) * Tile - 12), "按 E 进入 / 对话", HorizontalAlignment.Left, -1, 16, Colors.White);
        if (_towerBuilt)
        {
            var tower = _boardOrigin + new Vector2((Data.Width / 2 - left + 2) * Tile + 16, (Data.Height / 2 - top) * Tile + 16);
            DrawRect(new Rect2(tower - new Vector2(10, 10), new Vector2(20, 20)), new Color("b7d0ff"));
            if (_arrowTimer > 0) DrawLine(tower, tower + new Vector2(115, -35), new Color("ffd84d"), 3);
        }
        for (var i = 0; i < _enemies; i++) DrawCircle(_boardOrigin + new Vector2(visibleW * Tile - 30 - i * 25, 40 + i * 20), 9, new Color("ff3030"));
    }
    private static Color ColorFor(CellType cell) => cell switch
    {
        CellType.Forest => new Color("318d45"), CellType.Base => new Color("795530"), CellType.Stone => new Color("84909c"), CellType.Berry => new Color("d24669"),
        CellType.Wall => new Color("626975"), CellType.Corridor => new Color("c7b27b"), _ => new Color("5da85b")
    };
}
