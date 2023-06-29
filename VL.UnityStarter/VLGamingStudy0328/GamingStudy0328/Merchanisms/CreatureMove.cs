using UnityEngine;

namespace Assets.Scenes.VLGamingStudy0328
{
    public class CreatureMove
    {
        public int X, Y;
        public float XLength { get { return X * GameBoard.StepX; } }
        public float YLength { get { return Y * GameBoard.StepY; } }

        public Vector2 startPosition;
        public Vector2 targetPosition;
        public float moveStartTime = 0f;

        public CreatureMove(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public void CalculateMovement(Vector3 startPosition)
        {
            var targetPosition = new Vector2(startPosition.x + this.XLength, startPosition.y + this.YLength);
            this.startPosition = startPosition;
            this.targetPosition = targetPosition;
            this.moveStartTime = Time.time;
        }
        public void CalculateColliderMovement(Vector3 startPosition)
        {
            var targetPosition = new Vector2(startPosition.x + this.XLength / 3, startPosition.y + this.YLength / 3);
            this.startPosition = startPosition;
            this.targetPosition = targetPosition;
            this.moveStartTime = Time.time;
        }
        internal void CalculateAttectMovement(Vector3 position)
        {
            //TODO 暂时使用碰撞移动表示攻击
            CalculateColliderMovement(position);
        }
    }
}
