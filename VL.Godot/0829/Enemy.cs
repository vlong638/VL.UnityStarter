using Godot;

namespace OtherworldHero;

/// <summary>Simple night creature: approaches the player and damages on contact.</summary>
public partial class Enemy : Node2D
{
	public float AttackCooldown;
	public override void _Draw()
	{
		DrawCircle(Vector2.Zero, 13, new Color("6d315d"));
		DrawCircle(new Vector2(-4, -2), 2, new Color("ffdf71"));
		DrawCircle(new Vector2(4, -2), 2, new Color("ffdf71"));
	}
	public void Chase(Player player, double delta)
	{
		Vector2 direction = player.Position - Position;
		if (direction.Length() > 22) Position += direction.Normalized() * 88 * (float)delta;
		AttackCooldown = Mathf.Max(0, AttackCooldown - (float)delta);
	}
}
