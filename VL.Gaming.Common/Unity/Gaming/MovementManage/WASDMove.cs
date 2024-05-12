using UnityEngine;

namespace VL.Gaming.Unity.Gaming.MovementManage
{
    public class WASDMove : MonoBehaviour
    {
        private Vector3 targetDirection;
        [SerializeField]
        public float moveSpeed = 0.2f;
        [SerializeField]
        private float speedMultiplier = 3f;

        void Update()
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                targetDirection = new Vector3(0, 0);
            }
            if (Input.GetKey(KeyCode.W))
            {
                targetDirection += new Vector3(0, moveSpeed * (Input.GetKey(KeyCode.LeftShift) ? speedMultiplier : 1) * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S))
            {
                speedMultiplier = Input.GetKey(KeyCode.LeftShift) ? 2 : 1;
                targetDirection += new Vector3(0, -moveSpeed * (Input.GetKey(KeyCode.LeftShift) ? speedMultiplier : 1) * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A))
            {
                speedMultiplier = Input.GetKey(KeyCode.LeftShift) ? 2 : 1;
                targetDirection += new Vector3(-moveSpeed * (Input.GetKey(KeyCode.LeftShift) ? speedMultiplier : 1) * Time.deltaTime, 0);
            }
            if (Input.GetKey(KeyCode.D))
            {
                speedMultiplier = Input.GetKey(KeyCode.LeftShift) ? 2 : 1;
                targetDirection += new Vector3(moveSpeed * (Input.GetKey(KeyCode.LeftShift) ? speedMultiplier : 1) * Time.deltaTime, 0);
            }
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                transform.Translate(targetDirection);
            }
        }
    }
}
