using Godot;

namespace OtherworldHero;

public partial class Campfire : Node2D
{
	public float Radius = 105f;
	public override void _Draw()
	{
		DrawCircle(Vector2.Zero, Radius, new Color(1f, .48f, .08f, .09f));
		DrawCircle(Vector2.Zero, 18, new Color("7d3b1d"));
		DrawCircle(new Vector2(0, -5), 10, new Color("ffb52c"));
		DrawCircle(new Vector2(0, -7), 5, new Color("fff0a3"));
	}
}
