using System.Numerics;
using Godot;
using VL.Godot.VLCommon;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Vector2 = Godot.Vector2;

namespace VL.Godot.SideScrolling;

public partial class Player : Node2D
{
    [Export] public float HorizontalSpeed = 100;
    [Export] public float VerticalSpeed = 200;
    [Export] public float Gravity = 80;
    [Export] public float FPS = 60;
    [Export] public float JumpDuration = 0.2f;          // 跳跃持续时间
    private float jumpTimer = 0f;             // 跳跃剩余时间

    CharacterBody2D body2D;

    public override void _Ready()
    {

        animation = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
        body2D = GetNode<CharacterBody2D>("CharacterBody2D");
        Name = "Player";
    }

    public override void _Draw()
    {
    }

    Vector2 direction;
    AnimatedSprite2D animation;
    /// <summary>
    /// 物理移动（支持碰撞检测）
    /// Velocity 速率
    /// </summary>
    public void PhysicsMove(double delta, Game game)
    {
        Vector2 input = Input.GetVector("MoveLeft", "MoveRight", "MoveUp", "MoveDown");
        direction = input.Normalized();
        body2D.Velocity = body2D.Velocity.SetX((direction * HorizontalSpeed * FPS * (float)delta).X);

        float dt = (float)delta;
        bool onFloor = body2D.IsOnFloor();
        bool jumpPressed = Input.IsActionJustPressed("Jump");
        if (onFloor && jumpTimer <= 0f && jumpPressed)
        {
            jumpTimer = JumpDuration;     // 启动 1 秒跳跃
            GD.Print($"jump");
        }
        if (jumpTimer > 0f)
        {
            jumpTimer -= dt;
            GD.Print($"jumpTimer{jumpTimer}");
        }
        body2D.Velocity = body2D.Velocity.SetY((Gravity - (jumpTimer > 0f ? VerticalSpeed : 0)) * FPS * (float)delta);
        animate();
        body2D.MoveAndSlide();
        QueueRedraw();

        //GD.Print($"body2D.Velocity:{(Gravity - (jumpTimer > 0f ? VerticalSpeed : 0))}");
        //GD.Print($"body2D.Velocity:{body2D.Velocity}");
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
