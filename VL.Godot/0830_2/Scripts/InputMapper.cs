using Godot;
using System.Collections.Generic;
using System.Text.Json;



/// <summary>Loads keyboard bindings without using Godot's project Input Map.</summary>
public sealed class InputMapper
{
    private readonly Dictionary<string, Key> _keys = new();
    public InputMapper()
    {
        var text = Godot.FileAccess.GetFileAsString("res://Data/InputMap.json");
        if (!string.IsNullOrEmpty(text))
        {
            var bindings = JsonSerializer.Deserialize<Dictionary<string, string>>(text);
            if (bindings != null) foreach (var pair in bindings)
                if (System.Enum.TryParse<Key>(pair.Value, true, out var key)) _keys[pair.Key] = key;
        }
    }
    public bool Pressed(string action) => _keys.TryGetValue(action, out var key) && Input.IsKeyPressed(key);
    public bool Matches(InputEventKey e, string action) => _keys.TryGetValue(action, out var key) && e.Keycode == key;
}
