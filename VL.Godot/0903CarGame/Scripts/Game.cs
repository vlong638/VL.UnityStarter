using System.Collections.Generic;
using System.Linq;
using Godot;
using VL.Godot.VLCommon;
using Timer = Godot.Timer;
namespace VL.Game0903;

public partial class Game : Node2D
{
    private Player player = null!;
    public Rect2 playBounds = new(-192, -320, 192 * 2, 320 * 2);
    public Rect2 carBounds;
    private bool paused = false;
    List<Vector2> markerPositions = [];
    private Label _timerLabel;
    private double _elapsedTime = 0.0;

    public override void _Ready()
    {
        //Label
        _timerLabel = GetNode<Label>("CanvasLayer/Label");
        //配置映射内容
        VLInputMapper.Load();
        //timer
        timer = GetNodeOrNull<Timer>("Timer");
        if (timer == null) GD.PrintErr("❌ 无效的timer对象");
        timer.Start();
        //配置Car
        if (carScene == null)
        {
            carScene = GD.Load<PackedScene>("res://Assets/0903CarGame/Nodes/Car.tscn");
            if (carScene == null)
            {
                GD.PrintErr("❌ 无法加载 Car.tscn 文件！");
                return;
            }
        }
        cars = GetNodeOrNull<Node2D>("Cars");
        if (cars == null) GD.PrintErr("❌ 无效的cars对象");
        //配置Player
        player = GetNodeOrNull<Player>("/root/Game/YSortNode/Player");
        if (player == null)
        {
            var playerScene = GD.Load<PackedScene>("res://Assets/0903CarGame/Nodes/Player.tscn");
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
        //配置Box
        //// ✅ 创建 BoxGenerator 并生成 Box
        //var _boxGenerator = new BoxGenerator();
        //_boxGenerator.Name = "BoxGenerator";
        //_boxGenerator._spawnRangeX = 192;
        //_boxGenerator._spawnRangeY = 320;
        //AddChild(_boxGenerator);
        //_boxGenerator.GenerateBoxes(30);

        //通用方案
        //配置Box
        var itemGenerator = new ItemGenerator();
        itemGenerator.GenerateItems("res://Assets/0903CarGame/Nodes/Box.tscn", playBounds, 30, this);
        //配置Tree
        var trees = GetNodeOrNull<Node2D>("YSortNode");
        if (trees == null) GD.PrintErr("❌ 无效的trees对象");
        itemGenerator.GenerateItems("res://Assets/0903CarGame/Nodes/Tree.tscn", playBounds, 40, trees);
        //PositionMarkers
        carBounds = playBounds.Grow(10);
        GD.Print($"carBounds:{carBounds}");
        var markers = GetNodeOrNull<Node2D>("Markers");
        foreach (Marker2D marker in markers.GetChildren())
        {
            markerPositions.Add(marker.Position);
        }
        GD.Print($"markerPositions:{markerPositions.ToPrint()}");
        //配置家
        var home = GetNodeOrNull<Node2D>("Home");
        home.GetNode<Area2D>("Area2D").BodyEntered += Game_BodyEntered;
    }

    private void Game_BodyEntered(Node2D body)
    {
        GD.Print("Game_BodyEntered");
        if (body is Player)
        {
            GameState.Instance.Score = score;
            CallDeferred(nameof(ChangeScene));
        }
    }

    private void ChangeScene()
    {
        GetTree().ChangeSceneToFile("res://Assets/0903CarGame/Nodes/GameEnd.tscn");
    }

    public override void _Process(double delta)
    {
        //小汽车越界销毁
        foreach (Node2D car in cars.GetChildren())
        {
            if (!carBounds.HasPoint(car.Position))
            {
                car.QueueFree();
                //GD.Print($"小汽车销毁于GlobalPosition:{car.GlobalPosition}");
            }
        }
    }

    public override void _PhysicsProcess(double delta)
    {
        if (!paused)
        {
            player.PhysicsMove(delta, playBounds, true, this);

            _elapsedTime += delta;
            UpdateLabel();
        }
    }

    private void UpdateLabel()
    {
        if (_timerLabel == null) return;

        int totalSeconds = (int)_elapsedTime;
        int hours = totalSeconds / 3600;
        int minutes = (totalSeconds % 3600) / 60;
        int seconds = totalSeconds % 60;


        string text = $"剩余时间:{100 - totalSeconds}";
        score = 100 - totalSeconds;
        _timerLabel.Text = text;
    }
    int score;
    Timer timer;
    PackedScene carScene;
    Node2D cars;
    void _on_timer_timeout()
    {
        //GD.Print("_on_timer_timeout");
        Node2D? car = carScene.Instantiate() as Node2D;
        cars.AddChild(car);
        car.Position = markerPositions.PickRandom();
        var carEntity = car as Car;
        carEntity.Direction = car.Position.X < 0 ? Vector2.Right : Vector2.Left;
        //GD.Print($"创建小汽车{car.Position},Direction:{carEntity.Direction}");
    }
}
