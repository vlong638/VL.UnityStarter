#nullable enable
using Godot;
namespace OtherworldHeroTD;

public sealed class SurvivalSystem
{
    public float Health=100, Hunger=100, Temperature=100, Time=.25f;
    public int Day=1;
    public bool Night => Time >= .70f || Time < .20f;
    public bool Dead => Health <= 0;
    public void Tick(double delta, bool nearFire)
    {
        float dt=(float)delta; Time+=dt/110; if(Time>=1){Time-=1;Day++;}
        Hunger=Mathf.Max(0,Hunger-dt*.48f); Temperature=Mathf.MoveToward(Temperature, nearFire?100:(Night?18:78),dt*(nearFire?35:7));
        if(Hunger<=0) Health-=dt*5; if(Temperature<25) Health-=dt*4; Health=Mathf.Clamp(Health,0,100);
    }
    public void Eat() { Hunger=Mathf.Min(100,Hunger+26); }
}
