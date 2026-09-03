using Godot;
using System.Collections.Generic;



/// <summary>Reusable left-portrait/right-text dialogue window.</summary>
public sealed class DialogueManager
{
    private readonly Panel _panel = new();
    private readonly Label _text = new();
    private readonly Queue<string> _lines = new();
    public DialogueManager(Control parent)
    {
        _panel.Position = new Vector2(130, 490); _panel.Size = new Vector2(1020, 160); _panel.Visible = false;
        var portrait = new ColorRect { Color = new Color("#8b5a2b"), Position = new Vector2(15, 15), Size = new Vector2(120, 130) };
        _text.Position = new Vector2(155, 20); _text.Size = new Vector2(840, 120); _text.AutowrapMode = TextServer.AutowrapMode.WordSmart;
        _panel.AddChild(portrait); _panel.AddChild(_text); parent.AddChild(_panel);
    }
    public void Start(IEnumerable<string> lines) { _lines.Clear(); foreach (var line in lines) _lines.Enqueue(line); _panel.Visible = true; Next(); }
    public bool Next() { if (_lines.Count == 0) { _panel.Visible = false; return false; } _text.Text = _lines.Dequeue(); return true; }
    public bool Visible => _panel.Visible;
}
