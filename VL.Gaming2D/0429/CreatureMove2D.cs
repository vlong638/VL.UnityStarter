using UnityEngine;

namespace VL.Gaming2D._0429
{
    public class CreatureMove2D
    {
        public static float StepX = 0.16f;
        public static float StepY = 0.16f;

        public int X, Y;
        public float XLength { get { return X * StepX; } }
        public float YLength { get { return Y * StepY; } }

        public Vector2 startPosition;
        public Vector2 targetPosition;
        public float moveStartTime = 0f;

        public CreatureMove2D(int x, int y)
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
            CalculateColliderMovement(position);
        }
    }
}
