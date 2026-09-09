using Godot;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VL.Game0903;

public partial class Player : CharacterBody2D
{
    [Export] public float Speed { get; set; }

    public override void _Ready()
    {
        Speed = 5000;
        animation = GetNodeOrNull<AnimatedSprite2D>("AnimatedSprite2D");

    }

    public override void _Draw()
    {
    }

    Vector2 direction;
    AnimatedSprite2D animation;
    /// <summary>
    /// 物理移动（支持碰撞检测）
    /// </summary>
    public void PhysicsMove(double delta, Rect2 bounds, bool canMove, Game game)
    {
        if (!canMove) return;
        Vector2 input = Input.GetVector("MoveLeft", "MoveRight", "MoveUp", "MoveDown");
        direction = input.Normalized();
        Velocity = direction * Speed * (float)delta;
        animate();
        MoveAndSlide();
        QueueRedraw();
    }

    void animate()
    {
        if (direction.X < 0)
        {
            animation.Play("walkleft");
        }
        else if (direction.X > 0)
        {
            animation.Play("walkright");
        }
        else if (direction.Y > 0)
        {
            animation.Play("walkdown");
        }
        else if (direction.Y < 0)
        {
            animation.Play("walkup");
        }
        else
        {
            animation.Play("idle");
        }
    }
}
