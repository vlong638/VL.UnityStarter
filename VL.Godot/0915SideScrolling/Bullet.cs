using Godot;
using System;
using VL.Godot.SideScrolling;

public partial class Bullet : Node2D
{
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }

    Vector2 direction;
    [Export] public float speed = 10;
    internal void SetUp(Vector2 pos,Vector2 dir)
    {
        Position = pos;
        direction = dir;
    }
    public override void _PhysicsProcess(double delta)
    {
        Position += direction * speed * GameState.Instance.FPS * (float)delta;
    }

    internal void Explosion()
    {
        speed = 0;
        QueueFree();
    }
}
