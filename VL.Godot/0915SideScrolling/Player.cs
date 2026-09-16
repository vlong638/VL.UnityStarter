using System.Numerics;
using Godot;
using VL.Godot.VLCommon;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Vector2 = Godot.Vector2;

namespace VL.Godot.SideScrolling;

public partial class Player : Node2D
{
    [Export] public float HorizontalSpeed { get; set; }
    [Export] public float VerticalSpeed { get; set; }
    [Export] public float Gravity { get; set; }

    CharacterBody2D body2D;

    public override void _Ready()
    {
        HorizontalSpeed = 100 * 60;
        VerticalSpeed = 200 * 60;
        Gravity = 100 * 60;
        animation = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
        body2D = GetNode<CharacterBody2D>("CharacterBody2D");
        Name = "Player";
    }

    public override void _Draw()
    {
    }

    Vector2 direction;
    AnimatedSprite2D animation;
    private float jumpTimer = 0f;                 // 跳跃剩余时间
    private const float JumpDuration = 1.0f;      // 跳跃持续 1 秒
    /// <summary>
    /// 物理移动（支持碰撞检测）
    /// Velocity 速率
    /// </summary>
    public void PhysicsMove(double delta, Game game)
    {
        Vector2 input = Input.GetVector("MoveLeft", "MoveRight", "MoveUp", "MoveDown");
        direction = input.Normalized();
        body2D.Velocity = body2D.Velocity.SetX((direction * HorizontalSpeed * (float)delta).X);
        var isJump = Input.GetActionStrength("Jump");
        body2D.Velocity = body2D.Velocity.SetY((Gravity - 1 * isJump * VerticalSpeed) * (float)delta);
        animate();
        body2D.MoveAndSlide();
        QueueRedraw();
        //GD.Print($"input:{input}");
        //GD.Print($"direction:{direction}");
        //GD.Print($"HorizontalSpeed:{HorizontalSpeed}");
        //GD.Print($"(direction * HorizontalSpeed * (float)delta).X:{(direction * HorizontalSpeed * (float)delta).X}");
        //GD.Print($"body2D.Velocity:{new Vector2((direction * HorizontalSpeed * (float)delta).X, body2D.Velocity.Y)}");
        //GD.Print($"body2D.Velocity:{body2D.Velocity}");
        //GD.Print($"body2D.Velocity:{body2D.Velocity}");
    }

    void animate()
    {
        //方案2 +FlipH 免去了walkright
        animation.FlipH = direction.X > 0;
        if (direction.X != 0)
        {
            animation.Play("walkleft");
        }
        else
        {
            animation.Play("idle");
        }
    }
}
