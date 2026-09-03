namespace OtherworldHero0831;

/// <summary>Controls the mandatory close delay for spotlight-style tutorial overlays.</summary>
public sealed class GameGuide
{
    public float Remaining { get; private set; }
    public string Message { get; private set; } = string.Empty;
    public bool CanClose => Remaining <= 0;
    public void Trigger(string message, float closeDelaySeconds = 1f) { Message = message; Remaining = closeDelaySeconds; }
    public void Tick(float delta) { Remaining = System.Math.Max(0, Remaining - delta); }
}
