using System.Numerics;
using Godot;
using VL.Godot.VLCommon;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Timer = Godot.Timer;
using Vector2 = Godot.Vector2;

namespace VL.Godot.SideScrolling;

public partial class Player : Node2D
{
    [Export] public float HorizontalSpeed = 100;
    [Export] public float JumpSpeed = 400;
    [Export] public float Gravity = 20;
    [Export] public float FPS = 60;
    [Export] public float JumpDuration = 0.2f;          // 跳跃持续时间

    CharacterBody2D body2D;
    Timer shootTimer;
    Timer jumpTimer;
    PackedScene bulletScene;
    Node2D bullets;

    public override void _Ready()
    {
        bulletScene = GD.Load<PackedScene>("res://Assets/0915SideScrolling/Nodes/Bullet.tscn");
        bullets = GetNode<Node2D>("Bullets");
        shootTimer = GetNode<Timer>("ShootTimer");
        shootTimer.WaitTime = 0.2;
        shootTimer.OneShot = true;
        jumpTimer = GetNode<Timer>("JumpTimer");
        jumpTimer.WaitTime = JumpDuration;
        jumpTimer.OneShot = true; ;
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
        //移动
        Vector2 input = Input.GetVector("MoveLeft", "MoveRight", "MoveUp", "MoveDown");
        direction = input.Normalized();
        body2D.Velocity = body2D.Velocity.SetX((direction * HorizontalSpeed * FPS * (float)delta).X);
        //跳跃
        float dt = (float)delta;
        if (body2D.IsOnFloor() && Input.IsActionJustPressed("Jump"))
        {
            jumpTimer.Start();
            GD.Print($"jump");
        }
        body2D.Velocity = body2D.Velocity.SetY(( (jumpTimer.TimeLeft > 0 ? -JumpSpeed : Gravity)) * FPS * (float)delta);
        //射击
        if (Input.IsActionJustPressed("Shoot"))
        {
            shootTimer.Start();
            var dir = GetLocalMousePosition().Normalized();
            var bullet = bulletScene.Instantiate() as Node2D;
            bullets.AddChild(bullet);
            (bullet as Bullet).SetUp(Position, dir);
            //GD.Print($"Shoot:{dir}");
        }
        //机制运行
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
