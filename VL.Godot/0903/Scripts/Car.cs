using Godot;
using System;

public partial class Car : Node2D
{
    // Called when the node enters the scene tree for the first time.
    Area2D area;
    Vector2 direction ;
    float speed ;
    static IMGResourceManager images;

    static Car()
    {
        //图片
        images = new IMGResourceManager();
        images.Load("res://Assets/Images/red.png", "res://Assets/Images/yellow.png");
    }

    public override void _Ready()
    {
        area = GetNodeOrNull<Area2D>("Area2D");
        if (area == null)
        {
            GD.PushError("❌ 无效的area对象");
            SetProcess(false);
            return;   // ✅ 必须 return
        }
        direction = Vector2.Left;
        speed = 2;
        //信号检测
        Name = "car" + (int)(GD.Randi() % 256);
        //Texture
        var sprite2D = GetNodeOrNull<Sprite2D>("Sprite2D");
        sprite2D.Texture = images.GetRandomOne();

        ////方案1 非推荐
        //this.Connect("body_entered", new Callable(this,nameof(OnBodyEntered)));
        //方案2 强类型
        area.BodyEntered += OnBodyEntered;

        //碰撞层级设定
        area.SetCollisionLayerValue(2, true);
        area.SetCollisionMaskValue(1, true);
    }

    public void OnBodyEntered(Node2D body)
    {
        GD.Print($"碰撞,{Name} vs {body.Name}");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        Position += direction * speed;
    }
}
