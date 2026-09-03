using Godot;
using System.Collections.Generic;

namespace OtherworldHero;

/// <summary>Coordinates independent game systems and owns game-state transitions.</summary>
public partial class Main : Node2D
{
	private World world = null!;
	private Player player = null!;
	private GameUI ui = null!;
	private readonly SurvivalSystem survival = new();
	private readonly List<Enemy> enemies = new();
	private bool paused;
	private float enemySpawnTimer;

	public override void _Ready()
	{
		world = new World { Name = "World" }; AddChild(world);
		player = new Player { Name = "Player", Position = new Vector2(576, 355) }; AddChild(player);
		ui = new GameUI { Name = "GameUI" }; AddChild(ui);
		ui.CraftRequested += Craft;
		ui.RestartRequested += Restart;
		ui.ResumeRequested += Resume;
		ui.SetMessage("WASD 移动 · E 采集 · Tab 合成 · 左键放置篝火/食用浆果 · Esc 暂停");
	}

	public override void _Process(double delta)
	{
		if (survival.Dead) return;
		if (Input.IsActionJustPressed("pause")) { if (paused) Resume(); else Pause(); }
		if (Input.IsActionJustPressed("inventory") && !paused) ui.ToggleCraft();
		if (!paused)
		{
			player.Move(delta, world.PlayBounds, !ui.CraftVisible);
			if (Input.IsActionJustPressed("interact") && !ui.CraftVisible) HarvestNearest();
			if (Input.IsMouseButtonPressed(MouseButton.Left) && !ui.CraftVisible) UseItem();
			survival.Tick(delta, world.NearFire(player.Position));
			UpdateEnemies(delta);
		}
		ui.UpdateStatus(player, survival, paused);
		if (survival.Dead) { ui.ShowDeath(survival.Day); }
	}

	// Mouse holding should only trigger one item use per click.
	private bool mouseWasDown;
	private void UseItem()
	{
		if (mouseWasDown) return;
		mouseWasDown = true;
		if (player.Get(ItemType.Campfire) > 0)
		{
			player.Add(ItemType.Campfire, -1); world.PlaceFire(player.Position + player.Facing * 35);
			ui.SetMessage("篝火燃起：在光圈内可恢复体温。");
		}
		else if (player.Get(ItemType.Berry) > 0)
		{
			player.Add(ItemType.Berry, -1); survival.EatBerry(); ui.SetMessage("吃下浆果，饥饿恢复了。");
		}
	}
	public override void _Input(InputEvent input)
	{
		if (input is InputEventMouseButton mouse && mouse.ButtonIndex == MouseButton.Left && !mouse.Pressed) mouseWasDown = false;
	}

	private void HarvestNearest()
	{
		ResourceNode? closest = null; float distance = 54;
		foreach (ResourceNode node in world.Resources)
		{
			float d = player.Position.DistanceTo(node.Position);
			if (d < distance) { distance = d; closest = node; }
		}
		if (closest == null) { ui.SetMessage("附近没有可采集的资源。靠近树、岩石或浆果丛后按 E。"); return; }
		int yield = 1;
		if (closest.Item == ItemType.Wood && player.HasTool(ItemType.Axe)) yield = 2;
		if (closest.Item == ItemType.Stone && player.HasTool(ItemType.Pickaxe)) yield = 2;
		closest.Remaining--; player.Add(closest.Item, yield);
		ui.SetMessage($"获得 {GameData.ChineseName(closest.Item)} ×{yield}");
		if (closest.Remaining <= 0) { world.Resources.Remove(closest); closest.QueueFree(); }
	}

	private void Craft(Recipe recipe)
	{
		foreach (var cost in recipe.Cost)
			if (player.Get(cost.Key) < cost.Value) { ui.SetMessage($"材料不足，无法制作{recipe.Name}。"); return; }
		foreach (var cost in recipe.Cost) player.Add(cost.Key, -cost.Value);
		player.Add(recipe.Output, recipe.Amount);
		ui.SetMessage($"制作成功：{recipe.Name}。{(recipe.Output == ItemType.Campfire ? "在地图空地点击左键放置。" : "装备已生效。")}");
	}

	private void UpdateEnemies(double delta)
	{
		if (!survival.IsNight) return;
		enemySpawnTimer -= (float)delta;
		if (enemySpawnTimer <= 0 && enemies.Count < 5)
		{
			enemySpawnTimer = 9;
			var enemy = new Enemy { Position = world.RandomPosition() };
			enemies.Add(enemy); AddChild(enemy); ui.SetMessage("黑暗中传来低吼……");
		}
		foreach (Enemy enemy in enemies)
		{
			enemy.Chase(player, delta);
			if (enemy.Position.DistanceTo(player.Position) < 28 && enemy.AttackCooldown <= 0)
			{ survival.Health = Mathf.Max(0, survival.Health - 12); enemy.AttackCooldown = 1.2f; ui.SetMessage("怪物袭击了你！快靠近篝火或继续逃跑。"); }
		}
	}
	private void Pause() { paused = true; ui.ShowPause(); }
	private void Resume() { paused = false; ui.HideOverlay(); }
	private void Restart() { GetTree().ReloadCurrentScene(); }
}
