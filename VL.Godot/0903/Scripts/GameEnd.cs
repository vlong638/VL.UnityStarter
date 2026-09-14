using Godot;
using System;
namespace VL.Game0903;

public partial class GameEnd : Control
{
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        var label = GetNode<Label>("Label2");
        label.Text = GameState.Instance.Score > 0 ? $"High score:{GameState.Instance.Score}" : "";

    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }

    public override void _PhysicsProcess(double delta)
    {
        if (Input.IsKeyPressed(Key.Space))
        {
            GetTree().ChangeSceneToFile("res://Assets/Nodes/Game.tscn");
        }
    }
}
