using Godot;

namespace OtherworldHero;

/// <summary>Simulation values are kept separate from visual and input concerns.</summary>
public class SurvivalSystem
{
    public float Health = 100, Hunger = 100, Temperature = 100;
    public float WorldTime = 0.25f;
    public int Day = 1;
    public bool IsNight => WorldTime >= .70f || WorldTime < .20f;
    public bool Dead => Health <= 0;

    public void Tick(double delta, bool nearFire)
    {
        float dt = (float)delta;
        WorldTime += dt / 115f;
        if (WorldTime >= 1) { WorldTime -= 1; Day++; }
        Hunger = Mathf.Max(0, Hunger - dt * 0.48f);
        float targetTemperature = IsNight ? 18 : 78;
        if (nearFire) targetTemperature = 100;
        Temperature = Mathf.MoveToward(Temperature, targetTemperature, dt * (nearFire ? 36 : 7));
        if (Hunger <= 0) Health -= dt * 5;
        if (Temperature < 25) Health -= dt * 4;
        Health = Mathf.Clamp(Health, 0, 100);
    }
    public void EatBerry() { if (Hunger < 100) Hunger = Mathf.Min(100, Hunger + 24); }
}
