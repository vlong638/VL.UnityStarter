#nullable enable
using Godot;
using System.Collections.Generic;

namespace OtherworldHeroTD;

/// <summary>Owns high-level phases: difficulty selection, staged generation, then gameplay.</summary>
public partial class Main : Node2D
{
	private enum Phase { Setup, Loading, Playing, Paused, Dead }
	private Phase phase=Phase.Setup;
	private GameUI ui=null!; private World? world; private Player? player; private PlacementPreview? preview;
	private MapGenerator? generator; private DifficultySettings? settings;
	private readonly SurvivalSystem survival=new(); private readonly List<Enemy> enemies=new();
	private float loadTimer, enemyTimer; private int loadStep; private bool mouseDown;
	public override void _Ready()
	{
		ui=new GameUI(); AddChild(ui); ui.StartRequested+=BeginWorld; ui.CraftRequested+=Craft;
		ui.Hint("选择资源、敌人数量和敌人生命后，创建你的异世界。");
	}
	private void BeginWorld(DifficultySettings chosen)
	{
		settings=chosen; generator=new MapGenerator(chosen); world=new World(); AddChild(world); player=new Player{Position=new Vector2(576,360)};AddChild(player);preview=new PlacementPreview();AddChild(preview);
		phase=Phase.Loading; loadTimer=0; loadStep=0; ui.ShowLoading(4,"地貌初始化中…","grass");
	}
	public override void _Process(double delta)
	{
		if(phase==Phase.Loading){ AdvanceLoading((float)delta); return; }
		if(phase!=Phase.Playing || world==null || player==null || preview==null) return;
		if(InputMapper.PausePressed()){ phase=Phase.Paused;ui.Overlay("暂停","荒野静待你的归来。","继续",()=>{phase=Phase.Playing;ui.HideOverlay();});InputMapper.EndFrame();return; }
		if(InputMapper.InventoryPressed()) ui.ToggleCraft();
		player.Move(delta,world.Bounds,!ui.CraftVisible);
		preview.Follow(player);
		if(InputMapper.InteractPressed()&&!ui.CraftVisible) Harvest();
		UseClick(); survival.Tick(delta,world.NearFire(player.Position)); UpdateEnemies(delta);
		ui.Status(player,survival,preview.Pending.HasValue?$"| 待放置：{GameData.Name(preview.Pending.Value)}":"");
		if(survival.Dead) { phase=Phase.Dead;ui.Overlay("你倒在了异世界",$"本局存活：{survival.Day} 天","重新开始",()=>GetTree().ReloadCurrentScene()); }
		InputMapper.EndFrame();
	}
	private void AdvanceLoading(float dt)
	{
		loadTimer+=dt; if(loadTimer<.65f)return;loadTimer=0; if(world==null||generator==null)return;
		if(loadStep==0){generator.GenerateBatch(world,ItemType.Wood,3);ui.ShowLoading(30,"生成树木中…","tree");}
		else if(loadStep==1){generator.GenerateBatch(world,ItemType.Stone,3);ui.ShowLoading(60,"生成石块中…","stone");}
		else if(loadStep==2){generator.GenerateBatch(world,ItemType.Berry,3);ui.ShowLoading(88,"生成浆果中…","berry");}
		else {ui.ShowLoading(100,"世界创建完成！","player");phase=Phase.Playing;ui.EnterGame();ui.Hint("WASD/方向键移动 · E采集 · Tab合成 · 左键确认放置/食用浆果 · Esc暂停");}
		loadStep++;
	}
	private void Harvest()
	{
		if(world==null||player==null)return;ResourceNode? target=null;float best=52;
		foreach(var n in world.Resources){float d=player.Position.DistanceTo(n.Position);if(d<best){best=d;target=n;}}
		if(target==null){ui.Hint("靠近树木、石块或浆果后按 E 采集。");return;} int amount=1;
		if(target.Item==ItemType.Wood&&player.Get(ItemType.Axe)>0)amount=2;if(target.Item==ItemType.Stone&&player.Get(ItemType.Pickaxe)>0)amount=2;
		target.Remaining--;player.Add(target.Item,amount);ui.Hint($"获得 {GameData.Name(target.Item)} ×{amount}");
		if(target.Remaining<=0){world.Resources.Remove(target);target.QueueFree();}
	}
	private void Craft(Recipe recipe)
	{
		if(player==null||preview==null)return;foreach(var cost in recipe.Cost)if(player.Get(cost.Key)<cost.Value){ui.Hint("材料不足。");return;}
		foreach(var cost in recipe.Cost)player.Add(cost.Key,-cost.Value);player.Add(recipe.Output,1);
		if(recipe.Output is ItemType.Campfire or ItemType.Tower){preview.Set(recipe.Output);ui.Hint($"移动预览图标后点击左键放置{recipe.Name}。");}else ui.Hint($"制作成功：{recipe.Name}。");
	}
	private void UseClick()
	{
		if(!InputMapper.UsePressed()){mouseDown=false;return;} if(mouseDown)return;mouseDown=true;if(player==null||world==null||preview==null)return;
		if(preview.Pending.HasValue){var item=preview.Pending.Value;player.Add(item,-1);world.Place(item,preview.Position);preview.Set(null);ui.Hint("建筑已放置。");}
		else if(player.Get(ItemType.Berry)>0){player.Add(ItemType.Berry,-1);survival.Eat();ui.Hint("食用浆果，恢复饥饿。");}
	}
	private void UpdateEnemies(double delta)
	{
		if(!survival.Night||settings==null||generator==null||player==null||world==null)return;enemyTimer-=(float)delta;
		if(enemyTimer<=0&&enemies.Count<settings.EnemyLimit){enemyTimer=6;var e=new Enemy(settings.EnemyHp){Position=generator.EnemySpawn()};enemies.Add(e);AddChild(e);ui.Hint("夜幕中出现了敌对生物！");}
		foreach(var tower in world.Towers)tower.Defend(enemies,delta);enemies.RemoveAll(e=>e.Health<=0);
		foreach(var e in enemies){e.Chase(player,delta);if(e.CanAttack(player)){survival.Health=Mathf.Max(0,survival.Health-10);e.Attack();ui.Hint("敌人击中了你！防御塔会自动攻击范围内的敌人。");}}
	}
}
