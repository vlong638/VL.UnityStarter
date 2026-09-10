using Godot;
using System;

public partial class Car : Node2D
{
    // Called when the node enters the scene tree for the first time.
    Area2D area;
    Vector2 direction ;
    float speed ;
    public override void _Ready()
    {
        area = GetNodeOrNull<Area2D>("Area2D");
        if (area == null) GD.PrintErr("❌ 无效的area对象");
        direction = Vector2.Left;
        speed = 2;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        Position += direction * speed;
    }
}
