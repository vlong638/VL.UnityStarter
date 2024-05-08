using UnityEngine;

namespace VL.Gaming2D._0429
{
    public class Movement_WASDMove : MonoBehaviour
    {
        [SerializeField]
        public float MoveSpeed = 5f;

        void Start()
        {
        }

        void Update()
        {
            if (Input.GetKey(KeyCode.W))
            {
                Debug.Log($"Time.deltaTime:{Time.deltaTime}");
                transform.Translate(0, MoveSpeed * Time.deltaTime, 0);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(0, -MoveSpeed * Time.deltaTime, 0);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(-MoveSpeed * Time.deltaTime, 0, 0);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(MoveSpeed * Time.deltaTime, 0, 0);
            }
        }
    }
}
