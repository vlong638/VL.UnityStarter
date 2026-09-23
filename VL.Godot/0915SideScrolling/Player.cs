using System.Collections.Generic;
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

    CharacterBody2D character;
    Sprite2D upperBody;
    Timer shootTimer;
    Timer jumpTimer;
    PackedScene bulletScene;
    Node2D bullets;
    Sprite2D crossHair;
    float crossHairLength;
    AnimatedSprite2D lowerBodyAnimation;
    AnimationPlayer crossHairAnimation;

    private readonly Dictionary<Vector2I, int> gunDirections = new Dictionary<Vector2I, int>
    {
        { new Vector2I(1, 0), 0 },
        { new Vector2I(1, 1), 1 },
        { new Vector2I(0, 1), 2 },
        { new Vector2I(-1, 1), 3 },
        { new Vector2I(-1, 0), 4 },
        { new Vector2I(-1, -1), 5 },
        { new Vector2I(0, -1), 6 },
        { new Vector2I(1, -1), 7 }
    };


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
        character = GetNode<CharacterBody2D>("CharacterBody2D");
        lowerBodyAnimation = GetNode<AnimatedSprite2D>("CharacterBody2D/AnimatedSprite2D");
        crossHairAnimation = GetNode<AnimationPlayer>("CrossHairAnimationPlayer");
        upperBody = GetNode<Sprite2D>("CharacterBody2D/UpperBodySprite2D");
        crossHair = GetNode<Sprite2D>("CrossHairSprite2D");
        crossHairLength = (crossHair.Position - character.Position).Length();
        Name = "Player";
    }

    public override void _Draw()
    {
    }

    Vector2 direction;
    /// <summary>
    /// 物理移动（支持碰撞检测）
    /// Velocity 速率
    /// </summary>
    public void PhysicsMove(double delta, Game game)
    {
        //移动
        Vector2 input = Input.GetVector("MoveLeft", "MoveRight", "MoveUp", "MoveDown");
        if (input.LengthSquared() < 0.01f) input = Vector2.Zero;
        direction = input.Normalized();
        float speedX = direction.X > 0 ? 1 : 0.8f;
        character.Velocity = character.Velocity.SetX((direction * HorizontalSpeed * speedX * FPS * (float)delta).X);
        //跳跃
        float dt = (float)delta;
        if (character.IsOnFloor() && Input.IsActionJustPressed("Jump"))
        {
            jumpTimer.Start();
            GD.Print($"jump");
        }
        character.Velocity = character.Velocity.SetY(( (jumpTimer.TimeLeft > 0 ? -JumpSpeed : Gravity)) * FPS * (float)delta);
        //GD.Print($"body2D.Velocity:{character.Velocity}");
        //躯干朝向
        var dir = character.GetLocalMousePosition().Normalized();
        var adjustDirection = dir.ToRound();
        upperBody.Frame = gunDirections[adjustDirection];
        //十字准心
        crossHair.Position = character.Position + dir * crossHairLength;
        //射击
        if (Input.IsActionJustPressed("Shoot"))
        {
            GD.Print($"adjustDirection:{adjustDirection}");
            shootTimer.Start();
            var bullet = bulletScene.Instantiate() as Node2D;
            bullets.AddChild(bullet);
            (bullet as Bullet).SetUp(character.Position, dir);
            crossHairAnimation.Play("fire");
            //GD.Print($"Shoot:{dir}");
        }
        //机制运行
        animate();
        character.MoveAndSlide();
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
        if (!character.IsOnFloor())
        {
            lowerBodyAnimation.Play("jump");
        }
        else if (direction.X > 0)
        {
            lowerBodyAnimation.Play("walkright");
        }
        else if (direction.X < 0)
        {
            lowerBodyAnimation.Play("walkleft");
        }
        else
        {
            lowerBodyAnimation.Play("idle");
        }
    }
}
