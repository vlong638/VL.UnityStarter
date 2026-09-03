using Godot;
using System.Collections.Generic;
using System.Text.Json;
using FileAccess = Godot.FileAccess;

namespace OtherworldHero0831;

/// <summary>Input is loaded from Data/InputMap.json; no Godot Input Map entries are required.</summary>
public static class InputMapper
{
    private static readonly Dictionary<string, Key[]> Bindings = new();
    public static void Load()
    {
        Bindings.Clear();
        var file = FileAccess.Open("res://Data/InputMap.json", FileAccess.ModeFlags.Read);
        if (file == null) return;
        var map = JsonSerializer.Deserialize<Dictionary<string, string[]>>(file.GetAsText());
        if (map == null) return;
        foreach (var (action, keys) in map)
        {
            var parsed = new List<Key>();
            foreach (var key in keys)
                if (System.Enum.TryParse<Key>(key, true, out var value)) parsed.Add(value);
            Bindings[action] = parsed.ToArray();
        }
    }
    public static bool Pressed(string action) => Bindings.TryGetValue(action, out var keys) && System.Array.Exists(keys, Input.IsKeyPressed);
    public static bool JustPressed(InputEvent e, string action)
    {
        return e is InputEventKey key && key.Pressed && !key.Echo && Bindings.TryGetValue(action, out var keys) && System.Array.Exists(keys, x => x == key.Keycode);
    }
    public static Vector2 GetMove()
    {
        return new Vector2((Pressed("MoveRight") ? 1 : 0) - (Pressed("MoveLeft") ? 1 : 0), (Pressed("MoveDown") ? 1 : 0) - (Pressed("MoveUp") ? 1 : 0)).Normalized();
    }
}
