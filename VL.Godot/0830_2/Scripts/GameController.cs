using Godot;
using System;
using System.Collections.Generic;


/// <summary>Owns scene flow and the intentionally small, playable survival loop.</summary>

public partial class GameController : Node2D
{
    private enum Screen { Title, Difficulty, Loading, Playing, Dead }
    private Screen _screen = Screen.Title;
    private readonly PlayerState _player = new();
    private readonly MapGenerator _map = new();
    private InputMapper _input = null!;
    private Control _ui = null!;
    private Label _hud = null!;
    private Label _clock = null!;
    private Label _notice = null!;
    private Panel _inventory = null!;
    private DialogueManager _dialogue = null!;
    private GameGuide _guide = null!;
    private Vector2 _hero = new(640, 360);
    private float _timeOfDay = 5.67f;
    private float _loading;
    private bool _paused;
    private string _buildMode = ""; private readonly List<Control> _menuItems = new();

    public override void _Ready()
    {
        _input = new InputMapper();
        _ui = new Control { LayoutMode = 3, AnchorsPreset = (int)Control.LayoutPreset.FullRect, GrowHorizontal = Control.GrowDirection.Both, GrowVertical = Control.GrowDirection.Both };
        AddChild(_ui);
        _hud = MakeLabel(new Vector2(18, 18), new Vector2(370, 76), 18);
        _clock = MakeLabel(new Vector2(475, 18), new Vector2(360, 54), 18); _clock.HorizontalAlignment = HorizontalAlignment.Center;
        _notice = MakeLabel(new Vector2(18, 650), new Vector2(900, 45), 16);
        _dialogue = new DialogueManager(_ui); _guide = new GameGuide(_ui);
        ShowTitle();
    }

    private Label MakeLabel(Vector2 pos, Vector2 size, int fontSize)
    {
        var label = new Label { Position = pos, Size = size };
        _ui.AddChild(label); return label;
    }
    private void ClearMenu()
    {
        foreach (var item in _menuItems) if (IsInstanceValid(item)) item.QueueFree();
        _menuItems.Clear();
    }
    private Label MakeMenuLabel(Vector2 pos, Vector2 size, int fontSize)
    {
        var label = MakeLabel(pos, size, fontSize); _menuItems.Add(label); return label;
    }
    private Button MakeButton(string text, Vector2 pos, Action click)
    {
        var button = new Button { Text = text, Position = pos, Size = new Vector2(220, 52) };
        button.Pressed += click; _ui.AddChild(button); _menuItems.Add(button); return button;
    }
    private void ShowTitle()
    {
        _screen = Screen.Title; _hud.Visible = _clock.Visible = _notice.Visible = false; ClearMenu();
        var title = MakeMenuLabel(new Vector2(340, 130), new Vector2(600, 70), 36); title.Text = "异世界小侠传_RPG"; title.HorizontalAlignment = HorizontalAlignment.Center;
        var description = MakeMenuLabel(new Vector2(900, 30), new Vector2(340, 150), 16); description.Text = "异世界小侠传是一款具有挑战性的探索、生存、塔防、策略游戏。\n请更好地在异世界活下去吧。\n作者正在努力丰富游戏内容。"; description.AutowrapMode = TextServer.AutowrapMode.WordSmart;
        var x = 530; MakeButton("开始游戏", new Vector2(x, 260), ShowDifficulty); MakeButton("继续游戏", new Vector2(x, 322), StartLoading); MakeButton("配置", new Vector2(x, 384), ShowOptions); MakeButton("退出", new Vector2(x, 446), Quit);
        var version = MakeMenuLabel(new Vector2(1080, 680), new Vector2(170, 30), 16); version.Text = "v0.0.1";
    }
    private void ShowOptions()
    {
        ClearMenu(); var text = MakeMenuLabel(new Vector2(390, 150), new Vector2(500, 250), 24); text.Text = "配置\n\n语言：Chinese（language_CN.json）\n快捷键：WASD移动 / E交互 / I背包 / C建造 / Esc暂停";
        MakeButton("返回", new Vector2(530, 470), ShowTitle);
    }
    private void ShowDifficulty()
    {
        ClearMenu(); var text = MakeMenuLabel(new Vector2(400, 140), new Vector2(480, 100), 28); text.Text = "选择世界难度"; text.HorizontalAlignment = HorizontalAlignment.Center;
        MakeButton("资源：中  敌人：中  敌人生命：中", new Vector2(470, 290), StartLoading); MakeButton("返回", new Vector2(530, 370), ShowTitle);
    }
    private void StartLoading()
    {
        ClearMenu(); _paused = false; _screen = Screen.Loading; _loading = 0; _notice.Visible = true; _notice.Position = new Vector2(460, 480); _notice.Text = "正在生成树木中...";
    }
    private void BeginGame()
    {
        _map.GenerateWorld(); _hero = new Vector2(640, 360); _screen = Screen.Playing; _hud.Visible = _clock.Visible = _notice.Visible = true; _notice.Position = new Vector2(18, 650); _notice.Text = "任务：饮食 — 按 I 打开物品栏并使用菌菇汤。";
        _dialogue.Start(new[] { "可怜的人族，老奥尔菲看见你晕倒在这里了。", "主角：...", "主角：（内心活动：大胡子老头，好矮，但看起来十分有力气）", "你是从哪里来的？", "主角：蓝星。", "没听过的地方，也不奇怪，奥尔菲可没去过十公里外的地方。", "你看起来很虚弱，来尝尝奥尔菲的菌菇汤。", "主角：谢谢。" });
        _guide.Show("你饿了，饥饿值会随着时间掉落，为0会饿死。点击任意键关闭。"); QueueRedraw();
    }
    public override void _Process(double delta)
    {
        if (_screen == Screen.Loading) { _loading += (float)delta; _notice.Text = _loading < 1 ? "生成树木中..." : _loading < 2 ? "生成石块中..." : "生成浆果中..."; QueueRedraw(); if (_loading > 3) BeginGame(); return; }
        if (_screen != Screen.Playing || _paused || _guide.Visible || _dialogue.Visible) return;
        var direction = Vector2.Zero;
        if (_input.Pressed("MoveUp") || Input.IsKeyPressed(Key.Up)) direction.Y -= 1;
        if (_input.Pressed("MoveDown") || Input.IsKeyPressed(Key.Down)) direction.Y += 1;
        if (_input.Pressed("MoveLeft") || Input.IsKeyPressed(Key.Left)) direction.X -= 1;
        if (_input.Pressed("MoveRight") || Input.IsKeyPressed(Key.Right)) direction.X += 1;
        if (direction != Vector2.Zero) _hero = (_hero + direction.Normalized() * 160 * (float)delta).Clamp(new Vector2(22, 105), new Vector2(1255, 630));
        _timeOfDay = (_timeOfDay + (float)delta * .12f) % 24f; _player.Hunger -= (float)delta * .22f;
        if (_player.Hunger <= 0) ShowDeath();
        UpdateHud(); QueueRedraw();
    }
    private void UpdateHud()
    {
        _hud.Text = $"生命 {_player.Health}/100\n饥饿 {Math.Max(0, _player.Hunger):0}/100  体温 {_player.Temperature:0}°\n木材 {_player.Resources["wood"]}  石头 {_player.Resources["stone"]}  浆果 {_player.Resources["berry"]}";
        var phase = _timeOfDay < 6 ? "黎明" : _timeOfDay < 18 ? "白昼" : "夜晚"; _clock.Text = $"第1年第1月第1日 {phase}  {(int)_timeOfDay:D2}:{(int)((_timeOfDay % 1) * 60):D2}\n◐ ━━━━━━━━━━━ ☾";
    }
    public override void _Input(InputEvent e)
    {
        if (e is not InputEventKey key || !key.Pressed || key.Echo) return;
        if (_guide.Visible) { _guide.Close(); return; }
        if (_dialogue.Visible) { _dialogue.Next(); return; }
        if (_screen != Screen.Playing) return;
        if (_input.Matches(key, "Pause")) { TogglePause(); return; }
        if (_input.Matches(key, "Inventory")) { ToggleInventory(); return; }
        if (_input.Matches(key, "Build")) { _buildMode = _buildMode == "" ? "篝火" : ""; _notice.Text = _buildMode == "" ? "已取消建造" : "建造模式：在角色相邻一格点击放置篝火"; return; }
        if (_input.Matches(key, "Interact")) GatherNearest();
    }
    private void GatherNearest()
    {
        WorldResource? nearest = null; foreach (var resource in _map.Resources) if (!resource.Collected && resource.Kind <= ResourceKind.Berry && _hero.DistanceTo(resource.Position) < 44) { nearest = resource; break; }
        if (nearest == null) { _notice.Text = "附近没有可采集资源。"; return; }
        nearest.Collected = true; var id = nearest.Kind == ResourceKind.Tree ? "wood" : nearest.Kind == ResourceKind.Stone ? "stone" : "berry"; _player.Resources[id]++; _notice.Text = $"采集完成：{(id == "wood" ? "木材" : id == "stone" ? "石头" : "浆果")} +1";
    }
    private void ToggleInventory()
    {
        if (_inventory != null && IsInstanceValid(_inventory)) { _inventory.QueueFree(); return; }
        _inventory = new Panel { Position = new Vector2(260, 150), Size = new Vector2(760, 420) }; _ui.AddChild(_inventory);
        var title = new Label { Text = "物品栏（8 × 6）— 右键可操作；快速整理", Position = new Vector2(20, 16), Size = new Vector2(700, 38) }; _inventory.AddChild(title);
        var y = 65; foreach (var pair in _player.Resources) { var button = new Button { Text = $"{pair.Key}  × {pair.Value}", Position = new Vector2(25, y), Size = new Vector2(210, 44) }; var captured = pair.Key; button.Pressed += () => UseItem(captured); _inventory.AddChild(button); y += 50; }
        var sort = new Button { Text = "快速整理", Position = new Vector2(510, 350), Size = new Vector2(200, 45) }; sort.Pressed += () => _notice.Text = "物品已按类别整理。"; _inventory.AddChild(sort);
    }
    private void UseItem(string id)
    {
        if (id == "mushroom_soup" && _player.Resources[id] > 0) { _player.Resources[id]--; _player.Hunger = Math.Min(100, _player.Hunger + 70); _notice.Text = "使用菌菇汤，饥饿度恢复。任务「饮食」完成！获得铁斧。"; }
        else _notice.Text = $"选择了 {id}。";
    }
    private void TogglePause()
    {
        _paused = !_paused; if (!_paused) { if (_inventory != null && IsInstanceValid(_inventory)) _inventory.QueueFree(); return; }
        _inventory = new Panel { Position = new Vector2(470, 245), Size = new Vector2(340, 230) }; _ui.AddChild(_inventory);
        var text = new Label { Text = "暂停菜单", Position = new Vector2(110, 18), Size = new Vector2(150, 40) }; _inventory.AddChild(text);
        var restart = new Button { Text = "重新开始", Position = new Vector2(60, 80), Size = new Vector2(220, 45) }; restart.Pressed += StartLoading; _inventory.AddChild(restart);
        var resume = new Button { Text = "继续游戏", Position = new Vector2(60, 135), Size = new Vector2(220, 45) }; resume.Pressed += TogglePause; _inventory.AddChild(resume);
    }
    private void ShowDeath() { _screen = Screen.Dead; ClearMenu(); _notice.Text = "你因饥饿倒下了。"; MakeButton("重新开始", new Vector2(530, 330), StartLoading); }
    private void Quit() => GetTree().Quit();
    public override void _Draw()
    {
        if (_screen == Screen.Title) { DrawRect(new Rect2(Vector2.Zero, new Vector2(1280, 720)), new Color("#18212b")); return; }
        if (_screen == Screen.Loading) { DrawRect(new Rect2(Vector2.Zero, new Vector2(1280, 720)), new Color("#1b1b24")); var colors = new[] { new Color("#ffff00"), new Color("#ff0000"), new Color("#8b0000") }; DrawCircle(new Vector2(640, 310), 35, colors[(int)(_loading * 4) % 3]); DrawRect(new Rect2(390, 410, Math.Min(500, _loading / 3 * 500), 24), new Color("#ffff00")); return; }
        DrawRect(new Rect2(Vector2.Zero, new Vector2(1280, 720)), new Color(_timeOfDay < 18 && _timeOfDay > 6 ? "#4d854b" : "#18324a"));
        foreach (var r in _map.Resources) { if (r.Collected) continue; var color = r.Kind == ResourceKind.Tree ? new Color("#176b32") : r.Kind == ResourceKind.Stone ? new Color("#777777") : r.Kind == ResourceKind.Berry ? new Color("#b00080") : r.Kind == ResourceKind.Base ? new Color("#8b5a2b") : new Color("#ffff00"); DrawRect(new Rect2(r.Position - new Vector2(8, 8), new Vector2(16, 16)), color); }
        DrawCircle(_hero, 11, new Color("#eaeaea")); DrawCircle(_hero, 4, new Color("#4444ff"));
    }
}
