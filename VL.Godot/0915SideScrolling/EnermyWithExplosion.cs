using Godot;
using System;
using VL.Godot.VLCommon;
using VL.Godot.VLShader;

namespace VL.Godot.SideScrolling;
public partial class EnermyWithExplosion : Node2D
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

        ////测试用
        //animatedSprite2D.Visible = false;
        //SpawnExplosion(Position);
    }

    private void Area2D_BodyEntered(Node2D body)
    {
        var bParent = body.GetParent();
        GD.Print($"Area2D_BodyEntered:{body.GetParent().Name}");
        if (bParent is Bullet)
        {
            (bParent as Bullet).Explosion();
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        HP -= 1;
        GD.Print($"{Name} take damage");
        if (HP == 0)
        {
            GD.Print($"SpawnExplosion Start");
            animatedSprite2D.Visible = false;
            SpawnExplosion(Position);
        }
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }


    /// <summary>在指定世界坐标处生成一次粒子爆炸。</summary>
    private void SpawnExplosion(Vector2 position)
    {
        var sprite = animatedSprite2D.BakeFrameTexture("default", 1);
        SpriteParticleExplosion.StartExplosion(new Vector2(), sprite, this);

        // 用一个 Timer 在 2 秒后把节点删掉，避免残留一堆空节点
        var timer = GetTree().CreateTimer(2.0f);
        timer.Timeout += () =>
        {
            QueueFree();
        };
        GD.Print($"SpawnExplosion End");
    }

}
