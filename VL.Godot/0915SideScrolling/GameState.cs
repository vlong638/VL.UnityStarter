using Godot;

namespace VL.Godot.SideScrolling;
public class GameState
{
    public static GameState Instance = new GameState();

    public int FPS { get; set; } = 60;
}