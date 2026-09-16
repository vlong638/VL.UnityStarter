using Godot;
using System;

namespace VL.Godot.SideScrolling;

public partial class StartMenu : Control
{
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        var btnStart = GetNode<Button>("Button");//StartMenu实体即StartMenu根节点
        btnStart.Pressed += BtnStart_Pressed;
    }

    private void BtnStart_Pressed()
    {
        GetTree().ChangeSceneToFile("res://Assets/0915SideScrolling/Nodes//Game.tscn");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }

    public override void _PhysicsProcess(double delta)
    {
    }
}
