using Godot;



/// <summary>Dark overlay used to focus the player's attention on the survival HUD.</summary>
public sealed class GameGuide
{
    private readonly ColorRect _overlay;
    private readonly Label _message;
    public GameGuide(Control parent)
    {
        _overlay = new ColorRect { Color = new Color(0, 0, 0, .72f), Size = new Vector2(1280, 720), Visible = false, MouseFilter = Control.MouseFilterEnum.Stop };
        _message = new Label { Position = new Vector2(360, 330), Size = new Vector2(560, 90), HorizontalAlignment = HorizontalAlignment.Center, AutowrapMode = TextServer.AutowrapMode.WordSmart };
        _overlay.AddChild(_message); parent.AddChild(_overlay);
    }
    public void Show(string message) { _message.Text = message; _overlay.Visible = true; }
    public void Close() => _overlay.Visible = false;
    public bool Visible => _overlay.Visible;
}
