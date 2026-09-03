#nullable enable
using Godot;
namespace OtherworldHeroTD;

public partial class Enemy : Node2D
{
    public float Health;
    private float attackCooldown;
    public Enemy(float health) { Health = health; }
    public override void _Ready() => ActorSprite.Add(this, "enemy", 2.0f);
    public void Chase(Player player, double delta)
    {
        Vector2 d = player.Position - Position;
        if (d.Length() > 24) Position += d.Normalized() * 82 * (float)delta;
        attackCooldown = Mathf.Max(0, attackCooldown - (float)delta);
    }
    public bool CanAttack(Player player) => Position.DistanceTo(player.Position)<27 && attackCooldown<=0;
    public void Attack() => attackCooldown = 1.15f;
    public void TakeDamage(float damage) { Health -= damage; if (Health <= 0) QueueFree(); }
}
