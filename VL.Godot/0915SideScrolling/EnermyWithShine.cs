using Godot;
using System;
using VL.Godot.VLCommon;
using VL.Godot.VLShaders;

namespace VL.Godot.SideScrolling;
public partial class EnermyWithShine : Node2D
{
    Area2D area2D;
    AnimatedSprite2D animatedSprite2D;
    public int HP = 2;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        area2D = GetNode<Area2D>("Area2D");
        area2D.BodyEntered += Area2D_BodyEntered;
        animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
        animatedSprite2D.Play("default");
        animatedSprite2D.SpriteFrames.SetAnimationLoopMode("explosion", SpriteFrames.LoopMode.None);
    }

    private void Area2D_BodyEntered(Node2D body)
    {
        var bParent = body.GetParent();
        GD.Print($"Area2D_BodyEntered:{body.GetParent().Name}");
        if (bParent is Bullet)
        {
            (bParent as Bullet).Explosion();
            TakeDamage();

            var shine = animatedSprite2D.GetNode<ShineAnimatedSprite2D>("Node2D");
            shine.SetColor(Colors.Red);
            shine.SetSpeed(5f);
            shine.ToggleAxis();          // 切水平/垂直
            shine.PlayOnce(1.0f);        // 扫一次后关闭
            GD.Print("启用ShineAnimatedSprite2D");
        }
    }

    private void TakeDamage()
    {
        HP -= 1;
        GD.Print($"{Name} take damage");
        if (HP == 0)
        {
            animatedSprite2D.Play("explosion");
            QueueFree();
        }
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }
}
