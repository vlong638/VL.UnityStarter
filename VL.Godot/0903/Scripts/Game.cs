using System.Collections.Generic;
using Godot;
using Timer = Godot.Timer;
namespace VL.Game0903;

public partial class Game : Node2D
{
    private Player player = null!;
    public Rect2 playBounds = new(-192, -320, 192 * 2, 320 * 2);
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
        cars = GetNodeOrNull<Node2D>("Cars");
        if (cars == null) GD.PrintErr("❌ 无效的cars对象");
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
        //非物理性移动,纯图片
        //if (!paused)
        //{
        //    player.NoPhysicsMove(delta, playBounds, canMove: true);
        //}

        //小汽车越界销毁
        foreach (Node2D car in cars.GetChildren())
        {
            //GD.Print($"{playBounds}HasPoint Position:{car.Position}");
            //GD.Print($"{playBounds}HasPoint GlobalPosition:{car.GlobalPosition}");
            if (!playBounds.HasPoint(car.Position))
            {
                car.QueueFree();
                GD.Print($"小汽车销毁于GlobalPosition:{car.GlobalPosition}");
            }
        }
    }

    public override void _PhysicsProcess(double delta)
    {
        if (!paused)
        {
            player.PhysicsMove(delta, playBounds, true, this);
        }
    }

    Timer timer;
    PackedScene carScene;
    Node2D cars;
    void _on_timer_timeout()
    {
        GD.Print("_on_timer_timeout");
        var car = carScene.Instantiate();
        cars.AddChild(car);
        GD.Print("创建了小汽车");
    }
}
