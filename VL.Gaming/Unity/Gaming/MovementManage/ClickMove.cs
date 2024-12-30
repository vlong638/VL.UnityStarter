using UnityEngine;

namespace VL.Gaming.Unity.Gaming.MovementManage
{
    public class ClickMove : MonoBehaviour
    {
        private Vector3 targetPosition;
        private bool isMoving = false;
        [SerializeField]
        public float moveSpeed = 5f;
        [SerializeField]
        private float speedMultiplier = 1f;

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                isMoving = true;
            }
            if (Input.GetMouseButtonUp(0))
            {
                isMoving = false;
            }
            if (isMoving)
            {
                //持续移动
                targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                targetPosition.z = 0; // 保证 z 轴为0，如果是2D场景
                //加速
                speedMultiplier = Input.GetKey(KeyCode.LeftShift) ? 2 : 1;

                MoveToTarget();

                //停止
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    isMoving = false;
                }
            }
        }

        void MoveToTarget()
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * speedMultiplier * Time.deltaTime);

            //// 如果到达目标位置
            //if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            //{
            //}
        }
    }
}
