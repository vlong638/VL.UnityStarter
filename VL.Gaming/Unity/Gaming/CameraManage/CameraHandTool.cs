using UnityEngine;

namespace VL.Gaming.Unity.Gaming.CameraManage
{
    internal class CameraHandTool : MonoBehaviour
    {
        [SerializeField]
        public float moveSpeed = 0.01f;
        Vector3 lastMousePosition;

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                lastMousePosition = Input.mousePosition;
            }

            if (Input.GetMouseButton(0))
            {
                Vector3 delta = Input.mousePosition - lastMousePosition;
                // 根据需要调整移动速度
                transform.Translate(-delta * moveSpeed);
                lastMousePosition = Input.mousePosition;
            }
        }
    }
}
