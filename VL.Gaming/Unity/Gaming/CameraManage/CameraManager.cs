using UnityEngine;

namespace VL.Gaming.Unity.Gaming.CameraManage
{
    internal class CameraManager : MonoBehaviour
    {
        void Update()
        {
            // 检测F键的按下事件
            if (Input.GetKeyDown(KeyCode.F))
            {
                var player = GameObject.Find("Square_Player");
                if (player != null)
                {
                    // 将摄像头位置设置为玩家位置
                    transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
                }
            }
        }
    }
}
