#nullable enable
using Godot;
using System;
using System.Collections.Generic;

namespace OtherworldHeroTD;

public partial class GameUI : CanvasLayer
{
	private readonly ColorRect screen = new() { Color = new Color(.03f,.05f,.10f,.90f) };
	private readonly Label title = LabelAt(0,135,1152,50,34,"异世界小侠传_塔防",HorizontalAlignment.Center);
	private readonly Label detail = LabelAt(0,198,1152,34,18,"选择本局异世界的危险程度",HorizontalAlignment.Center);
	private readonly OptionButton resources = SelectAt(430,252,"地图资源：中");
	private readonly OptionButton enemies = SelectAt(430,305,"敌人数量：中");
	private readonly OptionButton health = SelectAt(430,358,"敌人生命：中");
	private readonly Button start = new() { Text="创建异世界", Position=new Vector2(476,426), Size=new Vector2(200,52) };
	private readonly ProgressBar progress = new() { Position=new Vector2(326,330), Size=new Vector2(500,28), MinValue=0, MaxValue=100, ShowPercentage=true };
	private readonly TextureRect loadingIcon = new() { Position=new Vector2(544,235), Size=new Vector2(64,64), ExpandMode=TextureRect.ExpandModeEnum.IgnoreSize, StretchMode=TextureRect.StretchModeEnum.KeepAspectCentered };
	private readonly Label loadingText = LabelAt(0,375,1152,30,20,"准备生成世界…",HorizontalAlignment.Center);
	private readonly Label hud = LabelAt(18,15,830,54,21);
	private readonly Label hint = LabelAt(18,592,800,30,18);
	private readonly Panel craft = new() { Position=new Vector2(846,92), Size=new Vector2(275,270), Visible=false };
	public Action<DifficultySettings>? StartRequested;
	public Action<Recipe>? CraftRequested;
	public Action? RestartRequested;
	public Action? ResumeRequested;
	private Action? overlayAction;
	public bool CraftVisible => craft.Visible;

	public override void _Ready()
	{
		AddChild(screen); screen.SetAnchorsAndOffsetsPreset(Control.LayoutPreset.FullRect);
		foreach(var node in new Node[]{title,detail,resources,enemies,health,start,progress,loadingIcon,loadingText}) screen.AddChild(node);
		progress.Visible=false; loadingIcon.Visible=false; loadingText.Visible=false;
		start.Pressed += () =>
		{
			if (overlayAction != null) { var action=overlayAction; overlayAction=null; action(); }
			else StartRequested?.Invoke(new DifficultySettings((Density)resources.Selected,(Density)enemies.Selected,(Density)health.Selected));
		};
		AddChild(hud); AddChild(hint); AddChild(craft);
		craft.AddChild(LabelAt(12,8,245,28,20,"合成背包 (Tab)")); int y=44;
		foreach(var recipe in GameData.Recipes) { var r=recipe; var b=new Button{Text=$"制作 {r.Name}\n{Cost(r)}",Position=new Vector2(10,y),Size=new Vector2(255,51)};b.Pressed+=()=>CraftRequested?.Invoke(r);craft.AddChild(b);y+=55; }
	}
	public void ShowLoading(float value, string text, string asset)
	{
		title.Visible=false; detail.Visible=false; resources.Visible=false; enemies.Visible=false; health.Visible=false; start.Visible=false;
		progress.Visible=true; loadingIcon.Visible=true; loadingText.Visible=true; progress.Value=value; loadingText.Text=text;
		loadingIcon.Texture=GD.Load<Texture2D>($"res://Assets/{asset}.png");
	}
	public void EnterGame() { screen.Visible=false; }
	public void ToggleCraft() => craft.Visible=!craft.Visible;
	public void Status(Player p, SurvivalSystem s, string suffix="") => hud.Text=$"第 {s.Day} 天 | 生命 {s.Health:0}  饥饿 {s.Hunger:0}  体温 {s.Temperature:0}\n{(s.Night?"夜晚：寒冷与怪物来袭":"白天：探索与采集")} | 木材 {p.Get(ItemType.Wood)}  石块 {p.Get(ItemType.Stone)}  浆果 {p.Get(ItemType.Berry)} {suffix}";
	public void Hint(string text) => hint.Text=text;
	public void Overlay(string titleText, string detailText, string buttonText, Action action)
	{
		screen.Visible=true; foreach(Node n in screen.GetChildren()) if(n is CanvasItem c) c.Visible=false;
		title.Text=titleText;detail.Text=detailText;start.Text=buttonText; title.Visible=true;detail.Visible=true;start.Visible=true;overlayAction=action;
	}
	public void HideOverlay() { screen.Visible=false; }
	private static Label LabelAt(float x,float y,float w,float h,int size,string text="",HorizontalAlignment align=HorizontalAlignment.Left) { var l=new Label{Text=text,Position=new Vector2(x,y),Size=new Vector2(w,h),HorizontalAlignment=align};l.AddThemeFontSizeOverride("font_size",size);return l; }
	private static OptionButton SelectAt(float x,float y,string label) { var b=new OptionButton{Position=new Vector2(x,y),Size=new Vector2(292,38)};b.AddItem(label.Replace("中","少"));b.AddItem(label);b.AddItem(label.Replace("中","多"));b.Selected=1;return b; }
	private static string Cost(Recipe r) { var t="";foreach(var x in r.Cost)t+=$"{GameData.Name(x.Key)}×{x.Value} ";return t; }
}
