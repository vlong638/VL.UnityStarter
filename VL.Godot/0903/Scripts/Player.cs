using Godot;

namespace VL.Game0903;

public partial class Player : Node2D
{
    public static float speed = 100;
    public Vector2 facing = Vector2.Down;

    public Player()
    {
    }

    public override void _Draw()
    {
    }

    public void Move(double delta, Rect2 bounds, bool canMove)
    {
        if (!canMove) return;
        Vector2 input = Input.GetVector("MoveLeft", "MoveRight", "MoveUp", "MoveDown");
        if (input.LengthSquared() > 0)
        {
            facing = input.Normalized();
            Position += facing * speed * (float)delta;
            // ✅ 调试输出：显示移动信息
            GD.Print($"原始输入: X={input.X:F2}, Y={input.Y:F2}, 长度={input.Length():F2} 移动方向: {facing}, 速度: {speed}, 位置: {Position}, Name: {Name}");
            //Position = new Vector2(Mathf.Clamp(Position.X, bounds.Position.X + 18, bounds.End.X - 18), Mathf.Clamp(Position.Y, bounds.Position.Y + 18, bounds.End.Y - 18));
            QueueRedraw();
        }
    }
}
