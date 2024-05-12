using UnityEngine;

namespace VL.Gaming.Unity.Gaming.MovementManage
{
    public class WASDMove : MonoBehaviour
    {
        private Vector3 targetDirection;
        [SerializeField]
        public float moveSpeed = 5f;
        [SerializeField]
        private float speedMultiplier = 1f;

        void Update()
        {
            targetDirection = new Vector3(0, 0);
            speedMultiplier = Input.GetKey(KeyCode.LeftShift) ? 2 : 1;
            if (Input.GetKey(KeyCode.W))
            {
                targetDirection += new Vector3(0, moveSpeed * speedMultiplier * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S))
            {
                targetDirection += new Vector3(0, -moveSpeed * speedMultiplier * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A))
            {
                targetDirection += new Vector3(-moveSpeed * speedMultiplier * Time.deltaTime, 0);
            }
            if (Input.GetKey(KeyCode.D))
            {
                targetDirection += new Vector3(moveSpeed * speedMultiplier * Time.deltaTime, 0);
            }
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                transform.Translate(targetDirection);
            }
        }
    }
}
