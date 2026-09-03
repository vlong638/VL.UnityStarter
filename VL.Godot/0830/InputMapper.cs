#nullable enable
using Godot;
using System.Collections.Generic;

namespace OtherworldHeroTD;

/// <summary>Central keyboard configuration. This project deliberately does not use Godot Input Map actions.</summary>
public static class InputMapper
{
    public static Vector2 MoveDirection()
    {
        float x = (Down(Key.D) || Down(Key.Right) ? 1 : 0) - (Down(Key.A) || Down(Key.Left) ? 1 : 0);
        float y = (Down(Key.S) || Down(Key.Down) ? 1 : 0) - (Down(Key.W) || Down(Key.Up) ? 1 : 0);
        return new Vector2(x, y).LimitLength();
    }
    public static bool InteractPressed() => Pressed(Key.E);
    public static bool InventoryPressed() => Pressed(Key.Tab);
    public static bool PausePressed() => Pressed(Key.Escape);
    public static bool UsePressed() => Input.IsMouseButtonPressed(MouseButton.Left);
    private static bool Down(Key key) => Input.IsKeyPressed(key);
    private static bool Pressed(Key key) => Input.IsKeyPressed(key) && !wasDown.Contains(key);
    private static readonly HashSet<Key> wasDown = new();
    public static void EndFrame()
    {
        Track(Key.E); Track(Key.Tab); Track(Key.Escape);
    }
    private static void Track(Key key) { if (Input.IsKeyPressed(key)) wasDown.Add(key); else wasDown.Remove(key); }
}
