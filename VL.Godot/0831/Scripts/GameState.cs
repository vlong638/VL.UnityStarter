using System.Collections.Generic;

namespace OtherworldHero0831;

public sealed class GameState
{
    public int Gold { get; set; } = 25;
    public int Food { get; set; } = 10;
    public int Wood { get; set; }
    public int Stone { get; set; }
    public float Hunger { get; set; } = 10;
    public float DayMinutes { get; set; } = 340;
    public float Speed { get; set; } = 1;
    public bool Paused { get; set; }
    public int QuestId { get; set; } = 1;
    public bool InWorldMap { get; set; }
    public List<string> Inventory { get; set; } = new();
    public List<string> CompletedQuests { get; set; } = new();
}
