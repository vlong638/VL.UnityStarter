#nullable enable
using Godot;
using System.Collections.Generic;
namespace OtherworldHeroTD;

public partial class DefenseTower : Node2D
{
    private float cooldown;
    public override void _Ready() => ActorSprite.Add(this, "tower", 2.3f);
    public void Defend(IReadOnlyList<Enemy> enemies, double delta)
    {
        cooldown -= (float)delta; if (cooldown > 0) return;
        Enemy? target = null; float nearest = 145;
        foreach (var enemy in enemies) { float d = Position.DistanceTo(enemy.Position); if (d < nearest) {nearest=d; target=enemy;} }
        if (target != null) { target.TakeDamage(15); cooldown = .65f; }
    }
}
