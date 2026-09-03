using Godot;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VL.Game0903;

public partial class Player : CharacterBody2D
{
    [Export] public float Speed { get; set; }

    public override void _Ready()
    {
        Speed = 5000;
    }

    public override void _Draw()
    {
    }

    public void PhysicsMove(double delta, Rect2 bounds, bool canMove, Game game)
    {
        if (!canMove) return;
        Vector2 input = Input.GetVector("MoveLeft", "MoveRight", "MoveUp", "MoveDown");
        Vector2 direction = input.Normalized();
        Velocity = direction * Speed * (float)delta;
        MoveAndSlide();
        QueueRedraw();
    }
}
