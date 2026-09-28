using Godot;
using VL.Godot.VLCommon;
using Timer = Godot.Timer;

namespace VL.Godot.EmptyProject;
public partial class Player : Node2D
{
    [Export] public float HorizontalSpeed = 200f;
    [Export] public float FPS = 60f;
    [Export] public bool ExternalDriven = false;

    // ===== 节点引用 =====
    private CharacterBody2D _character;
    // ===== 状态 =====
    private WorkState _workState = WorkState.None;
    private Vector2 _direction;
    private StringName _lastAnimState = "";

    public override void _Ready()
    {
        Name = "Player";

        _character = GetNode<CharacterBody2D>("CharacterBody2D");

        ExternalDriven = GetParent() is Game;
        if (ExternalDriven) return;
        VLInputMapper.Load();
    }

    public override void _PhysicsProcess(double delta)
    {
        if (ExternalDriven) return;
        Tick(delta);
    }

    public void PhysicsMove(double delta, Game game)
    {
        Tick(delta);
    }

    private void Tick(double delta)
    {
        UpdateMove(delta);
        UpdateState();
        _character.MoveAndSlide();
        QueueRedraw();
    }


    private void UpdateMove(double delta)
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
        bool isInteract = Input.IsActionPressed("Interact");
        if (isInteract)
        {
            _workState = WorkState.Mining;
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
    }
}

enum WorkState
{
    None,
    Idle,
    MoveUp,
    MoveDown,
    MoveLeft,
    MoveRight,
    Mining,
}
