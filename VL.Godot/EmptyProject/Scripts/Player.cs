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
    // ===== 状态+值 =====
    private WorkState _workState = WorkState.None;
    private Vector2 _direction;

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
        float speedX = _direction.X > 0 ? 1f : 0.8f;
        _character.Velocity = _direction * HorizontalSpeed * speedX;
    }

    private void UpdateState()
    {
        bool isInteract = Input.IsActionPressed("Interact");
        if (isInteract)
        {
            _workState = WorkState.Interact;
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

        StringName targetState = _workState switch
        {
            WorkState.Interact => "Interact", 
            _ => "Idle",
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
    Interact,
}
