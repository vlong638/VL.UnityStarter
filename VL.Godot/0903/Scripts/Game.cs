using System.Collections.Generic;
using Godot;
using Timer = Godot.Timer;
namespace VL.Game0903;

public partial class Game : Node2D
{
    private Player player = null!;
    public Rect2 playBounds = new(0, 0, 192*2, 320*2);
    private bool paused = false;

    public override void _Ready()
    {
        //配置映射内容
        InputMapper.Load();
        //timer
        timer = GetNodeOrNull<Timer>("Timer");
        if (timer == null) GD.PrintErr("❌ 无效的timer对象");
        timer.Start();
        //配置Car
        if (carScene == null)
        {
            carScene = GD.Load<PackedScene>("res://Assets/Nodes/Car.tscn");
            if (carScene == null)
            {
                GD.PrintErr("❌ 无法加载 Car.tscn 文件！");
                return;
            }
        }
        //配置Player
        player = GetNodeOrNull<Player>("Player");
        if (player == null)
        {
            var playerScene = GD.Load<PackedScene>("res://Assets/Nodes/Player.tscn");
            if (playerScene == null)
            {
                GD.PrintErr("❌ 无法加载 Player.tscn 文件！");
                return;
            }

            player = playerScene.Instantiate<Player>();
            player.Name = "Player";
            player.Position = new Vector2(0, 0);
            AddChild(player);
            GD.Print("创建了玩家");
        }
        //配置Player
        // ✅ 创建 BoxGenerator 并生成 Box
        var _boxGenerator = new BoxGenerator();
        _boxGenerator.Name = "BoxGenerator";
        _boxGenerator._spawnRangeX = 192;
        _boxGenerator._spawnRangeY = 320;
        AddChild(_boxGenerator);
        _boxGenerator.GenerateBoxes(30);
    }

    public override void _Process(double delta)
    {
        //if (!paused)
        //{
        //    player.NoPhysicsMove(delta, playBounds, canMove: true);
        //}
    }

    public override void _PhysicsProcess(double delta)
    {
        if (!paused)
        {
            player.PhysicsMove(delta, playBounds, true,this);
        }
    }

    Timer timer;
    PackedScene carScene;
    void _on_timer_timeout()
    {
        GD.Print("_on_timer_timeout");
        var car = carScene.Instantiate();
        AddChild(car);
        GD.Print("创建了小汽车");
    }
}
