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
    [Export] public float HorizontalSpeed = 200f;
    [Export] public float FPS = 60f;
    [Export] public bool ExternalDriven = false;

    // ===== 节点引用 =====
    private CharacterBody2D _character;
    private AnimationTree _animationTree_BlendSpace2D;
    private AnimationTree _animationTree_StateMachine;
    private AnimationNodeStateMachinePlayback _playback;
    // ===== 状态 =====
    private WorkState _workState = WorkState.None;
    private Vector2 _direction;
    private StringName _lastAnimState = "";

    public override void _Ready()
    {
        Name = "Player";

        _character = GetNode<CharacterBody2D>("CharacterBody2D");
        _animationTree_BlendSpace2D = GetNode<AnimationTree>("CharacterBody2D/AnimationTree_BlendSpace2D");
        _animationTree_StateMachine = GetNode<AnimationTree>("CharacterBody2D/AnimationTree_StateMachine");
        _playback = (AnimationNodeStateMachinePlayback)_animationTree_StateMachine.Get("parameters/playback");
        _playback.StateFinished += Playback_StateFinished;

        ExternalDriven = GetParent() is Game;

        if (ExternalDriven) return;
        VLInputMapper.Load();
    }

    bool StateFinished;
    private void Playback_StateFinished(StringName state)
    {
        GD.Print($"state:{state}");
        StateFinished = true;
    }

    // 只有"非外部驱动"时才自己跑
    public override void _PhysicsProcess(double delta)
    {
        if (ExternalDriven) return;

        Tick(delta);
    }

    Vector2 direction;
    /// <summary>
    /// 物理移动（支持碰撞检测）
    /// Velocity 速率
    /// </summary>
    public void PhysicsMove(double delta, Game game)
    {
        Tick(delta);
    }

    private void Tick(double delta)
    {
        UpdateVelocity(delta);
        UpdateState();
        _character.MoveAndSlide();
        QueueRedraw();
    }


    private void UpdateVelocity(double delta)
    {
        Vector2 input = Input.GetVector("MoveLeft", "MoveRight", "MoveUp", "MoveDown");
        if (input.LengthSquared() < 0.01f)
            input = Vector2.Zero;

        _direction = input.Normalized();

        // 左右移动速度略有差异（保留你原来的设计）
        float speedX = _direction.X > 0 ? 1f : 0.8f;

        // 注意：Velocity 就是"每秒速度"，不要再乘 delta * FPS
        _character.Velocity = _direction * HorizontalSpeed * speedX;
    }

    private void UpdateState()
    {
        //参数更新
        _animationTree_StateMachine.Set(
            "parameters/BlendSpace2D/blend_position",
            _character.Velocity.Normalized()
        );

        bool isInteract = Input.IsActionPressed("Interact");

        if (isInteract)
        {
            _workState = WorkState.Mining;
            GD.Print("Mining");
            EmitSignal(nameof(OnToolUseEventHandler).ToGDSignal(), (int)ToolType.Draft, _character.Position);
        }
        else if (_direction.LengthSquared() < 0.01f)
        {
            _workState = WorkState.Idle;
        }
        else if (Mathf.Abs(_direction.X) > Mathf.Abs(_direction.Y))
        {
            _workState = _direction.X > 0 ? WorkState.MoveRight : WorkState.MoveLeft;
        }
        else
        {
            _workState = _direction.Y > 0 ? WorkState.MoveDown : WorkState.MoveUp;
        }

        // 状态名必须和动画树里的节点名完全一致（大小写敏感）
        StringName targetState = _workState switch
        {
            WorkState.Mining => "mine", 
            _ => "BlendSpace2D",
        };

        if (_playback.GetCurrentNode() != targetState)
            _playback.Travel(targetState);
    }

    [Signal]
    public delegate void OnToolUseEventHandler(ToolType toolType, Vector2 position);
}

public enum ToolType
{
    None,
    Axe,
    Draft,
    Shovel,
}
public enum WorkState
{
    None,
    Idle,
    MoveUp,
    MoveDown,
    MoveLeft,
    MoveRight,
    Mining,
}
