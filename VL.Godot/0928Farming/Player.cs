using System.Collections.Generic;
using System.Numerics;
using Godot;
using VL.Godot.VLCommon;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Timer = Godot.Timer;
using Vector2 = Godot.Vector2;

namespace VL.Godot.Farming;
public partial class Player : Node2D
{
    float crossHairLength;
    float horizontalSpeed;
    float _FPS;
    CharacterBody2D character;
    AnimationTree animationTree_BlendSpace2D;
    AnimationTree animationTree_StateMachine;
    AnimationNodeStateMachinePlayback playback;

    public override void _Ready()
    {
        character = GetNode<CharacterBody2D>("CharacterBody2D");
        animationTree_BlendSpace2D = GetNode<AnimationTree>("CharacterBody2D/AnimationTree_BlendSpace2D");
        animationTree_StateMachine = GetNode<AnimationTree>("CharacterBody2D/AnimationTree_StateMachine");
        Name = "Player";
        horizontalSpeed = 200;
        _FPS = 60;

        playback = (AnimationNodeStateMachinePlayback)animationTree_StateMachine.Get("parameters/playback");
        playback.StateFinished += Playback_StateFinished;
    }

    bool StateFinished;
    private void Playback_StateFinished(StringName state)
    {
        GD.Print($"state:{state}");
        StateFinished = true;
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
        //GD.Print($"direction:{direction}");
        float speedX = direction.X > 0 ? 1 : 0.8f;
        var velocity = direction.SetX((direction * horizontalSpeed * speedX * _FPS * (float)delta).X);
        character.Velocity = velocity;
        //GD.Print($"character.Velocity:{character.Velocity}");

        //BlendSpace2D方案
        //通过position方向控制,具体参数可查文件
        //animationTree_BlendSpace2D.Set("parameters/blend_position", character.Velocity.Normalized());

        //StateMachine方案
        animationTree_StateMachine.Set("parameters/BlendSpace2D/blend_position", character.Velocity.Normalized());

        UpdateState();

        //机制运行
        animate();
        character.MoveAndSlide();
        QueueRedraw();
    }

    private void UpdateState()
    {
        //animationTree_StateMachine.Set("parameters/conditions/IsIdling", !isInteract);
        //animationTree_StateMachine.Set("parameters/conditions/IsMining", isInteract);

        var isInteract = Input.IsActionPressed("Interact");
        if (isInteract)
            playback.Travel("mine");
        else
            playback.Travel("BlendSpace2D");
    }

    void animate()
    {
    }
}
