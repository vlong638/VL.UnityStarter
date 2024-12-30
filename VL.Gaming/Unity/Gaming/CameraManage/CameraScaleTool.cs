using UnityEngine;

namespace VL.Gaming.Unity.Gaming.CameraManage
{
    internal class CameraScaleTool : MonoBehaviour
    {
        public float zoomSpeed = 2f; // 缩放速度
        public float minZoom = -12f; // 最小缩放值
        public float maxZoom = -5f; // 最大缩放值

        void Update()
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            if (Mathf.Approximately(scroll, 0f))
                return;
            float newZoom = transform.position.z + scroll * zoomSpeed;
            newZoom = Mathf.Clamp(newZoom, minZoom, maxZoom);
            transform.position = new Vector3(transform.position.x, transform.position.y, newZoom);
        }
    }
}
