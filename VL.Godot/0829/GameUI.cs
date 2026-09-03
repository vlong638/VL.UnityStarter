#nullable enable
using Godot;
using System;

namespace OtherworldHero;

public partial class GameUI : CanvasLayer
{
	private readonly Label stats = NewLabel(20, 15, 820, 55, 22);
	private readonly Label message = NewLabel(20, 590, 760, 35, 19);
	private readonly Panel craftPanel = new();
	private readonly ColorRect overlay = new();
	public Action<Recipe>? CraftRequested;
	public Action? RestartRequested;
	public Action? ResumeRequested;
	public bool CraftVisible => craftPanel.Visible;

	public override void _Ready()
	{
		AddChild(stats); AddChild(message);
		craftPanel.Position = new Vector2(830, 85); craftPanel.Size = new Vector2(295, 240); craftPanel.Visible = false;
		craftPanel.AddChild(NewLabel(14, 10, 260, 26, 20, "合成背包 (Tab)"));
		int y = 47;
		foreach (Recipe recipe in GameData.Recipes)
		{
			var button = new Button { Text = $"制作 {recipe.Name}\n{CostText(recipe)}", Position = new Vector2(14, y), Size = new Vector2(266, 52) };
			button.Pressed += () => CraftRequested?.Invoke(recipe); craftPanel.AddChild(button); y += 59;
		}
		AddChild(craftPanel);
		overlay.SetAnchorsAndOffsetsPreset(Control.LayoutPreset.FullRect); overlay.Visible = false;
		overlay.Modulate = new Color(1, 1, 1, 1); AddChild(overlay);
	}
	public void UpdateStatus(Player player, SurvivalSystem survival, bool paused)
	{
		string phase = survival.IsNight ? "夜晚（严寒与怪物来袭）" : "白天（适合探索）";
		stats.Text = $"第 {survival.Day} 天  |  生命 {survival.Health:0}  饥饿 {survival.Hunger:0}  体温 {survival.Temperature:0}\n{phase}  |  木材 {player.Get(ItemType.Wood)}  石头 {player.Get(ItemType.Stone)}  浆果 {player.Get(ItemType.Berry)}";
		if (paused) message.Text = "游戏已暂停（Esc 继续）";
	}
	public void ToggleCraft() => craftPanel.Visible = !craftPanel.Visible;
	public void SetMessage(string text) => message.Text = text;
	public void ShowDeath(int days) => ShowOverlay("你倒在了异世界", $"本局存活：{days} 天", "重新开始", () => RestartRequested?.Invoke());
	public void ShowPause() => ShowOverlay("暂停", "休息一下，再继续冒险。", "继续", () => ResumeRequested?.Invoke());
	public void HideOverlay() => overlay.Visible = false;
	private void ShowOverlay(string title, string detail, string buttonText, Action action)
	{
		foreach (Node child in overlay.GetChildren()) child.QueueFree();
		overlay.Visible = true; overlay.Color = new Color(.04f, .06f, .12f, .88f);
		overlay.AddChild(NewLabel(0, 190, 1152, 50, 34, title, HorizontalAlignment.Center));
		overlay.AddChild(NewLabel(0, 255, 1152, 35, 21, detail, HorizontalAlignment.Center));
		var b = new Button { Text = buttonText, Position = new Vector2(476, 320), Size = new Vector2(200, 54) }; b.Pressed += action; overlay.AddChild(b);
	}
	private static Label NewLabel(float x, float y, float width, float height, int size, string text = "", HorizontalAlignment alignment = HorizontalAlignment.Left)
	{
		var label = new Label { Text = text, Position = new Vector2(x, y), Size = new Vector2(width, height), HorizontalAlignment = alignment };
		// This method is supported by Godot 4 .NET and avoids depending on generated override properties.
		label.AddThemeFontSizeOverride("font_size", size);
		return label;
	}
	private static string CostText(Recipe recipe) { var s = ""; foreach (var cost in recipe.Cost) s += $"{GameData.ChineseName(cost.Key)}×{cost.Value} "; return s; }
}
