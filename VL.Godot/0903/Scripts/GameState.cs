using Godot;

namespace VL.Game0903;
public class GameState
{
    public static GameState Instance = new GameState();

    public int Score { get; set; } = 0;
}