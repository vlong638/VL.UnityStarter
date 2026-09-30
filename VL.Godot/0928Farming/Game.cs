using System.Collections.Generic;
using System.Linq;
using Godot;
using VL.Godot.VLCommon;
using Timer = Godot.Timer;

namespace VL.Godot.Farming;
public partial class Game : Node2D
{
    private Player player = null!;
    private bool paused = false;

    public override void _Ready()
    {
        //配置映射内容
        VLInputMapper.Load();
        //SoilLayer
        SoilLayer = GetNodeOrNull<TileMapLayer>("Layers/SoilLayer");
        if (SoilLayer == null)
            GD.PrintErr("❌ 无法加载SoilLayer对象！");
        //配置Player
        player = GetNodeOrNull<Player>("Player");
        if (player == null)
        {
            var playerScene = GD.Load<PackedScene>("res://Assets/0928Farming/Nodes/Player.tscn");
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
        GD.Print("玩家准备就绪");
    }


    public override void _Process(double delta)
    {
    }

    public override void _PhysicsProcess(double delta)
    {
        if (!paused)
        {
            player.PhysicsMove(delta, this);
        }
    }

    private TileMapLayer SoilLayer;
    public void _on_player_on_tool_use(ToolType toolType, Vector2 position)
    {
        GD.Print($"_on_player_on_tool_use,{toolType},{position}");
        var gridPosition = position.ToGDGrid();
        if (toolType==ToolType.Draft)
        {
            SoilLayer.SetCellsTerrainConnect([gridPosition], terrainSet: 0, terrain: 0);
        }
    }
}
