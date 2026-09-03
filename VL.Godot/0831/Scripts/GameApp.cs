using Godot;
using System;
using System.Collections.Generic;

namespace OtherworldHero0831;

/// <summary>Application coordinator. Systems remain in dedicated generators, services and managers.</summary>
public partial class GameApp : Node
{
    private CanvasLayer _canvas = null!;
    private Control _ui = null!;
    private MapView _map = null!;
    private Control? _modal;
    private Label? _resourceLabel;
    private Label? _timeLabel;
    private Label? _questLabel;
    private ProgressBar? _actionProgress;
    private GameState _state = new();
    private readonly MapGenerator _generator = new();
    private readonly QuestManager _quests = new();
    private readonly DialogueManager _dialogues = new();
    private readonly GameGuide _guide = new();
    private bool _playing;
    private bool _gathering;
    private float _gatherTime;
    private float _guideTime;
    private float _moveTime;

    public override void _Ready()
    {
        InputMapper.Load();
        _canvas = new CanvasLayer(); AddChild(_canvas);
        _map = new MapView { Name = "GeneratedTileMap" }; AddChild(_map);
        _ui = new Control { Name = "Interface", MouseFilter = Control.MouseFilterEnum.Pass }; _canvas.AddChild(_ui);
        ShowMainMenu();
    }

    public override void _Process(double delta)
    {
        if (!_playing || _state.Paused) return;
        var scaled = (float)delta * _state.Speed;
        _moveTime += scaled;
        var move = InputMapper.GetMove();
        if (move != Vector2.Zero && _moveTime >= .16f)
        {
            _map.MoveBy(new Vector2(Math.Sign(move.X), Math.Sign(move.Y))); _moveTime = 0;
        }
        _state.DayMinutes += scaled * 4;
        _state.Hunger = Math.Max(0, _state.Hunger - scaled * .015f);
        if (_gathering)
        {
            _gatherTime += scaled;
            if (_actionProgress != null) _actionProgress.Value = _gatherTime / 2.5f * 100;
            if (_gatherTime >= 2.5f) FinishGathering();
        }
        if (_guideTime > 0) { _guide.Tick(scaled); _guideTime = _guide.Remaining; if (_modal != null) UpdateGuideText(); }
        RefreshHud();
    }

    public override void _UnhandledInput(InputEvent e)
    {
        if (!_playing) return;
        if (_modal != null)
        {
            if (_modal.HasMeta("guide") && _guideTime <= 0 && e is InputEventKey or InputEventMouseButton) CloseModal();
            return;
        }
        if (InputMapper.JustPressed(e, "Pause")) { ShowPause(); GetViewport().SetInputAsHandled(); return; }
        if (InputMapper.JustPressed(e, "Inventory")) { ShowInventory(); GetViewport().SetInputAsHandled(); return; }
        if (InputMapper.JustPressed(e, "Build")) { ShowBuild(); GetViewport().SetInputAsHandled(); return; }
        if (InputMapper.JustPressed(e, "Interact")) { Interact(); GetViewport().SetInputAsHandled(); }
    }

    private void StartNew()
    {
        _state = new GameState(); _playing = true; _map.Visible = true;
        _map.SetMap(_generator.GenerateBlockArea(), false);
        BuildHud();
        ShowToast("你在初始据点醒来。靠近中央据点并按 E 与矮人奥尔菲交谈。", 3);
    }
    private void Continue()
    {
        _state = SaveService.Load(); _playing = true; _map.Visible = true;
        _map.SetMap(_state.InWorldMap ? _generator.GenerateWorld() : _generator.GenerateBlockArea(), _state.InWorldMap);
        BuildHud(); ShowToast("已加载上次游玩内容。", 2);
    }
    private void ShowMainMenu()
    {
        _playing = false; _map.Visible = false; ClearUi();
        var background = new ColorRect { Color = new Color("17233a"), Position = Vector2.Zero, Size = new Vector2(1920, 1080), MouseFilter = Control.MouseFilterEnum.Ignore }; _ui.AddChild(background);
        AddLabel(_ui, "异世界小侠传0831", new Vector2(650, 220), new Vector2(650, 80), 50, Colors.White, HorizontalAlignment.Center);
        AddLabel(_ui, "生存 · 探索 · 建造 · 塔防", new Vector2(650, 300), new Vector2(650, 40), 22, new Color("b8c7df"), HorizontalAlignment.Center);
        var y = 410;
        AddButton(_ui, "开始游戏", new Vector2(780, y), StartNew); y += 70;
        AddButton(_ui, "继续游戏", new Vector2(780, y), Continue, SaveService.Exists()); y += 70;
        AddButton(_ui, "配置", new Vector2(780, y), ShowSettings); y += 70;
        AddButton(_ui, "退出游戏", new Vector2(780, y), () => GetTree().Quit());
        AddLabel(_ui, "异世界小侠传会是一款有趣的游戏，请更好地在异世界活下去吧。\n作者正在努力丰富游戏内容", new Vector2(1210, 60), new Vector2(620, 100), 18, new Color("d8e4f5"));
        AddLabel(_ui, "v0.0.1", new Vector2(1700, 1010), new Vector2(160, 35), 18, new Color("c0ccdc"), HorizontalAlignment.Right);
    }
    private void BuildHud()
    {
        ClearUi();
        var top = new ColorRect { Color = new Color("101827cc"), Position = Vector2.Zero, Size = new Vector2(1920, 130), MouseFilter = Control.MouseFilterEnum.Ignore }; _ui.AddChild(top);
        _resourceLabel = AddLabel(_ui, "", new Vector2(28, 22), new Vector2(390, 70), 22, Colors.White);
        _timeLabel = AddLabel(_ui, "", new Vector2(640, 18), new Vector2(650, 36), 24, Colors.White, HorizontalAlignment.Center);
        var daybar = new ProgressBar { Position = new Vector2(750, 67), Size = new Vector2(430, 23), MinValue = 0, MaxValue = 1440, Value = _state.DayMinutes, ShowPercentage = false }; _ui.AddChild(daybar); daybar.Name = "SunMoonTimeBar";
        AddLabel(_ui, "☀ 黎明                    ☾ 夜晚", new Vector2(754, 92), new Vector2(425, 22), 14, new Color("dde6f5"), HorizontalAlignment.Center);
        _questLabel = AddLabel(_ui, "", new Vector2(1540, 145), new Vector2(330, 85), 18, new Color("fff0a6"));
        var speedY = 985;
        AddButton(_ui, "暂停", new Vector2(700, speedY), () => SetSpeed(0), true, new Vector2(105, 42));
        AddButton(_ui, "1 倍速", new Vector2(815, speedY), () => SetSpeed(1), true, new Vector2(105, 42));
        AddButton(_ui, "2 倍速", new Vector2(930, speedY), () => SetSpeed(2), true, new Vector2(105, 42));
        AddButton(_ui, "4 倍速", new Vector2(1045, speedY), () => SetSpeed(4), true, new Vector2(105, 42));
        _actionProgress = new ProgressBar { Position = new Vector2(840, 935), Size = new Vector2(240, 22), Visible = false, ShowPercentage = false }; _ui.AddChild(_actionProgress);
        RefreshHud();
    }
    private void RefreshHud()
    {
        if (_resourceLabel == null || _timeLabel == null || _questLabel == null) return;
        _resourceLabel.Text = $"金币 {_state.Gold}    食物 {_state.Food}    木材 {_state.Wood}    石头 {_state.Stone}\n饥饿值 {MathF.Ceiling(_state.Hunger)} / 10";
        var minute = (int)_state.DayMinutes % 1440; var hour = minute / 60; var min = minute % 60;
        _timeLabel.Text = $"第1年第1月第1日 {(hour >= 18 || hour < 6 ? "夜晚" : "黎明")}  {hour:00}:{min:00}";
        _questLabel.Text = $"！ 主线任务\n{_quests.CurrentName(_state)}\n点击查看任务详情";
        var timebar = _ui.GetNodeOrNull<ProgressBar>("SunMoonTimeBar"); if (timebar != null) timebar.Value = _state.DayMinutes % 1440;
    }
    private void SetSpeed(float speed) { _state.Speed = speed; _state.Paused = speed == 0; }
    private void Interact()
    {
        if (_gathering) { ShowConfirm("打断当前行为？", () => { _gathering = false; if (_actionProgress != null) _actionProgress.Visible = false; }); return; }
        if (_state.InWorldMap)
        {
            if (_map.IsNearBase()) { _state.InWorldMap = false; _map.SetMap(_generator.GenerateBlockArea(), false); ShowToast("进入初始据点区域。", 2); }
            else { _state.InWorldMap = false; _map.SetMap(_generator.GenerateBlockArea(100, 100), false); ShowToast("进入无尽森林区块：四向通道已生成。", 2); }
            return;
        }
        if (_map.IsNearBase()) { ShowDialogue(); return; }
        StartGathering();
    }
    private void StartGathering()
    {
        _gathering = true; _gatherTime = 0;
        if (_actionProgress != null) { _actionProgress.Value = 0; _actionProgress.Visible = true; }
        ShowToast("正在采集… 再按 E 可打断。", 2);
    }
    private void FinishGathering()
    {
        _gathering = false; if (_actionProgress != null) _actionProgress.Visible = false;
        var cell = _map.TargetType;
        if (cell == CellType.Stone) _state.Stone += 2;
        else if (cell == CellType.Berry) _state.Food += 2;
        else _state.Wood += 2;
        ShowToast("采集完成，资源已加入左上角素材栏。", 2);
    }
    private void ShowDialogue()
    {
        var panel = OpenModal();
        var session = _dialogues.StartNpcQuest("矮人奥尔菲", _state, _quests);
        AddLabel(panel, $"{session.Speaker}  ！", new Vector2(95, 70), new Vector2(1320, 50), 30, new Color("ffd166"));
        var portrait = new ColorRect { Color = new Color("b88745"), Position = new Vector2(80, 150), Size = new Vector2(250, 500) }; panel.AddChild(portrait);
        AddLabel(panel, "矮人\n奥尔菲", new Vector2(100, 400), new Vector2(210, 100), 28, Colors.White, HorizontalAlignment.Center);
        var lines = string.Join("\n", session.Lines);
        AddLabel(panel, lines, new Vector2(380, 180), new Vector2(1000, 420), 24, Colors.White);
        AddButton(panel, $"接受任务：{_quests.CurrentName(_state)}", new Vector2(720, 680), CompleteDialogue, true, new Vector2(300, 55));
        AddButton(panel, "关闭", new Vector2(1040, 680), CloseModal, true, new Vector2(150, 55));
    }
    private void CompleteDialogue()
    {
        var reward = _quests.Reward(_state); var guide = _quests.Guide(_state); _quests.Complete(_state);
        CloseModal(); ShowReward(reward, guide);
    }
    private void ShowReward(string reward, string guide)
    {
        var panel = OpenModal();
        AddLabel(panel, "任务结算", new Vector2(650, 250), new Vector2(620, 60), 42, new Color("ffe58a"), HorizontalAlignment.Center);
        AddLabel(panel, $"获得物品\n{reward}", new Vector2(570, 360), new Vector2(780, 130), 28, Colors.White, HorizontalAlignment.Center);
        AddButton(panel, "确认", new Vector2(835, 550), () => { CloseModal(); ShowGuide(guide); }, true, new Vector2(250, 60));
    }
    private void ShowGuide(string message)
    {
        var panel = OpenModal(new Color("000000c8")); _guide.Trigger(message); _guideTime = _guide.Remaining;
        var text = AddLabel(panel, "", new Vector2(500, 430), new Vector2(920, 120), 32, Colors.White, HorizontalAlignment.Center); text.Name = "GuideText";
        AddLabel(panel, "强调引导区域", new Vector2(770, 220), new Vector2(380, 70), 22, new Color("ffe58a"), HorizontalAlignment.Center);
        panel.SetMeta("message", message); panel.SetMeta("guide", true);
        panel.GuiInput += e => { if (_guideTime <= 0 && e is InputEventMouseButton { Pressed: true }) CloseModal(); };
        UpdateGuideText();
    }
    private void UpdateGuideText()
    {
        if (_modal == null) return; var label = _modal.GetNodeOrNull<Label>("GuideText");
        if (label != null) label.Text = _guideTime > 0 ? $"{_modal.GetMeta("message")}\n请稍候 {MathF.Ceiling(_guideTime)} 秒" : $"{_modal.GetMeta("message")}\n点击任意鼠标键或按键关闭";
    }
    private void ShowInventory()
    {
        var panel = OpenModal(); AddLabel(panel, "物品栏（左键选择，拖动至左右手装备栏）", new Vector2(420, 160), new Vector2(1080, 50), 30, Colors.White, HorizontalAlignment.Center);
        var itemText = _state.Inventory.Count == 0 ? "空" : string.Join("     ", _state.Inventory);
        AddLabel(panel, itemText, new Vector2(430, 340), new Vector2(1060, 120), 30, new Color("fde047"), HorizontalAlignment.Center);
        AddLabel(panel, "左手装备栏                 右手装备栏", new Vector2(570, 560), new Vector2(780, 45), 25, new Color("b8d8ff"), HorizontalAlignment.Center);
        AddButton(panel, "关闭", new Vector2(835, 690), CloseModal, true, new Vector2(250, 55));
    }
    private void ShowBuild()
    {
        var panel = OpenModal(); AddLabel(panel, "建筑栏", new Vector2(690, 180), new Vector2(540, 60), 38, Colors.White, HorizontalAlignment.Center);
        AddLabel(panel, "防御塔按 Enemy.json / Buildings_DefenseTowers.json / CombatUnits.json 配置工作。", new Vector2(410, 280), new Vector2(1100, 50), 20, new Color("cbd5e1"), HorizontalAlignment.Center);
        AddButton(panel, "建造一级弓箭防御塔", new Vector2(650, 410), () => { _map.BuildArcherTower(); CloseModal(); ShowToast("弓箭塔已建造；夜晚会自动发射箭矢。", 2); }, true, new Vector2(360, 55));
        AddButton(panel, "模拟夜间敌袭", new Vector2(650, 490), () => { _map.StartNightWave(); CloseModal(); ShowToast("第一波食尸鬼来袭。", 2); }, true, new Vector2(360, 55));
        AddButton(panel, "关闭", new Vector2(760, 610), CloseModal, true, new Vector2(140, 50));
    }
    private void ShowPause()
    {
        _state.Paused = true; var panel = OpenModal(); AddLabel(panel, "暂停菜单", new Vector2(720, 230), new Vector2(480, 60), 40, Colors.White, HorizontalAlignment.Center);
        AddButton(panel, "继续游戏", new Vector2(785, 350), () => { _state.Paused = false; if (_state.Speed == 0) _state.Speed = 1; CloseModal(); });
        AddButton(panel, "保存游戏", new Vector2(785, 420), () => { SaveService.Save(_state); ShowToast("游戏已保存。", 2); });
        AddButton(panel, "配置", new Vector2(785, 490), ShowSettings);
        AddButton(panel, "退出到主菜单", new Vector2(785, 560), () => { SaveService.Save(_state); CloseModal(); ShowMainMenu(); });
    }
    private void ShowSettings()
    {
        var wasPlaying = _playing; var panel = OpenModal(); AddLabel(panel, "配置", new Vector2(730, 260), new Vector2(460, 60), 42, Colors.White, HorizontalAlignment.Center);
        AddLabel(panel, "语言（从 Language_CN.json 加载）：", new Vector2(620, 380), new Vector2(330, 45), 24, Colors.White);
        var language = new OptionButton { Position = new Vector2(960, 376), Size = new Vector2(260, 46) }; language.AddItem("中文"); panel.AddChild(language);
        AddLabel(panel, "打断当前行为时是否提示：是", new Vector2(620, 450), new Vector2(650, 45), 22, new Color("d8e4f5"));
        AddButton(panel, "返回", new Vector2(820, 560), () =>
        {
            CloseModal();
            if (!wasPlaying) ShowMainMenu();
            else if (_state.Paused) ShowPause();
        }, true, new Vector2(230, 55));
    }
    private void ShowConfirm(string message, Action yes)
    {
        var panel = OpenModal(); AddLabel(panel, message, new Vector2(650, 400), new Vector2(620, 60), 30, Colors.White, HorizontalAlignment.Center);
        AddButton(panel, "确认", new Vector2(740, 500), () => { yes(); CloseModal(); }, true, new Vector2(180, 55)); AddButton(panel, "取消", new Vector2(1000, 500), CloseModal, true, new Vector2(180, 55));
    }
    private Control OpenModal(Color? dim = null)
    {
        CloseModal();
        var panel = new ColorRect { Color = dim ?? new Color("111827f2"), Position = Vector2.Zero, Size = new Vector2(1920, 1080), MouseFilter = Control.MouseFilterEnum.Stop };
        _ui.AddChild(panel); _modal = panel; return panel;
    }
    private void CloseModal()
    {
        if (_modal == null) return;
        _modal.QueueFree(); _modal = null;
    }
    private void ShowToast(string text, float seconds)
    {
        var label = AddLabel(_ui, text, new Vector2(510, 135), new Vector2(900, 48), 21, Colors.White, HorizontalAlignment.Center);
        label.AddThemeColorOverride("font_outline_color", Colors.Black); label.AddThemeConstantOverride("outline_size", 5);
        var timer = GetTree().CreateTimer(seconds); timer.Timeout += () => { if (IsInstanceValid(label)) label.QueueFree(); };
    }
    private static Label AddLabel(Control parent, string text, Vector2 position, Vector2 size, int fontSize, Color color, HorizontalAlignment align = HorizontalAlignment.Left)
    {
        var label = new Label { Text = text, Position = position, Size = size, AutowrapMode = TextServer.AutowrapMode.WordSmart, HorizontalAlignment = align, VerticalAlignment = VerticalAlignment.Center };
        label.AddThemeFontSizeOverride("font_size", fontSize); label.AddThemeColorOverride("font_color", color); parent.AddChild(label); return label;
    }
    private static Button AddButton(Control parent, string text, Vector2 position, Action action, bool enabled = true, Vector2? size = null)
    {
        var button = new Button { Text = text, Position = position, Size = size ?? new Vector2(360, 55), Disabled = !enabled };
        button.AddThemeFontSizeOverride("font_size", 22);
        var normal = new StyleBoxFlat { BgColor = new Color("2d5a87"), CornerRadiusTopLeft = 8, CornerRadiusTopRight = 8, CornerRadiusBottomLeft = 8, CornerRadiusBottomRight = 8 };
        var hover = new StyleBoxFlat { BgColor = new Color("3e78ae"), CornerRadiusTopLeft = 8, CornerRadiusTopRight = 8, CornerRadiusBottomLeft = 8, CornerRadiusBottomRight = 8 };
        button.AddThemeStyleboxOverride("normal", normal); button.AddThemeStyleboxOverride("hover", hover); button.Pressed += action; parent.AddChild(button); return button;
    }
    private void ClearUi()
    {
        foreach (var child in _ui.GetChildren()) child.QueueFree();
        _modal = null; _resourceLabel = null; _timeLabel = null; _questLabel = null; _actionProgress = null;
    }
}
