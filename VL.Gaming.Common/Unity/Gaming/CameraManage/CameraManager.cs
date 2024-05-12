using UnityEngine;

namespace VL.Gaming.Unity.Gaming.CameraManage
{
    internal class CameraManager : MonoBehaviour
    {
        Vector3 offsetZ = new Vector3(0, 0, -10);

        void Update()
        {
            // 检测F键的按下事件
            if (Input.GetKeyDown(KeyCode.F))
            {
                var player = GameObject.Find("Square_Player");
                if (player != null)
                {
                    // 将摄像头位置设置为玩家位置
                    transform.position = player.transform.position + offsetZ;
                }
            }
        }
    }
}
