#nullable enable
using Godot;

namespace OtherworldHeroTD;

public static class ActorSprite
{
	public static Sprite2D Add(Node owner, string asset, float scale = 2f, float alpha = 1f)
	{
		var sprite = new Sprite2D { Texture = GD.Load<Texture2D>($"res://Assets/{asset}.png"), Scale = Vector2.One * scale, Modulate = new Color(1, 1, 1, alpha) };
		owner.AddChild(sprite); return sprite;
	}
}
