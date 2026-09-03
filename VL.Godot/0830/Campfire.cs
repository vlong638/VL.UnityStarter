#nullable enable
using Godot;
namespace OtherworldHeroTD;
public partial class Campfire : Node2D { public override void _Ready() => ActorSprite.Add(this, "fire", 2.1f); }
