using Godot;
namespace VL.Game0903;

public partial class Game : Node2D
{
    private Player player = null!;
    public Rect2 playBounds = new(18, 80, 1116, 550);
    private bool paused = false;

    public override void _Ready()
    {
        InputMapper.Load();
        player = GetNodeOrNull<Player>("Player");
        if (player == null)
        {
            var playerScene = GD.Load<PackedScene>("res://Assets/Nodes/Player/Player.tscn");
            if (playerScene == null)
            {
                GD.PrintErr("❌ 无法加载 Player.tscn 文件！");
                return;
            }

            player = playerScene.Instantiate<Player>();
            player.Name = "Player";
            player.Position = new Vector2(0, 0);
            AddChild(player);
            GD.Print("✅ 从 Player.tscn 创建了玩家");
        }
    }

    public override void _Process(double delta)
    {
        if (!paused)
        {
            player.Move(delta, playBounds, canMove: true);
        }
    }
}
