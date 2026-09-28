using Godot;
using System;

namespace VL.Godot.SideScrolling;
public partial class Enermy : Node2D
{
    Area2D area2D;
    Area2D area2DTracing;
    AnimatedSprite2D animatedSprite2D;
    public int HP = 2;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        area2D = GetNode<Area2D>("Area2D");
        area2D.BodyEntered += Area2D_BodyEntered;
        area2DTracing = GetNode<Area2D>("Area2DTracing");
        area2DTracing.BodyEntered += Area2DTracing_BodyEntered; ;
        animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
        animatedSprite2D.Play("default");
        animatedSprite2D.SpriteFrames.SetAnimationLoopMode("explosion", SpriteFrames.LoopMode.None);
    }

    private void Area2DTracing_BodyEntered(Node2D body)
    {
        var bParent = body.GetParent();
        if (bParent is Player)
        {
            (bParent as Bullet).Explosion();
            TakeDamage();
        }
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
            animatedSprite2D.AnimationFinished += AnimatedSprite2D_AnimationFinished;
            animatedSprite2D.Play("explosion");
        }
    }

    public int ExplosionRange = 50;
    private void AnimatedSprite2D_AnimationFinished()
    {
        animatedSprite2D.AnimationFinished -= AnimatedSprite2D_AnimationFinished;
        foreach (Enermy e in GetTree().GetNodesInGroup("Enermies"))
        {
            if (e.Position.DistanceTo(this.Position)<ExplosionRange)
            {
                e.TakeDamage();
            }
        }
        QueueFree();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }
}
