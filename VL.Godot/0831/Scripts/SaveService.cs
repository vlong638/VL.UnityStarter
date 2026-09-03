using Godot;
using System.Text.Json;
using FileAccess = Godot.FileAccess;

namespace OtherworldHero0831;

public static class SaveService
{
    private const string SavePath = "user://otherworldhero0831.save.json";
    public static bool Exists() => FileAccess.FileExists(SavePath);
    private static readonly JsonSerializerOptions serializer = new () { WriteIndented = true };
    public static void Save(GameState state)
    {
        using var file = FileAccess.Open(SavePath, FileAccess.ModeFlags.Write);
        file.StoreString(JsonSerializer.Serialize(state, serializer ));
    }
    public static GameState Load()
    {
        if (!Exists()) return new GameState();
        using var file = FileAccess.Open(SavePath, FileAccess.ModeFlags.Read);
        return JsonSerializer.Deserialize<GameState>(file.GetAsText()) ?? new GameState();
    }
}



