using UnityEngine;

namespace VL.Gaming.Scripts.GamingV2.Systems
{
    /// <summary>
    /// 遍历所有 KeyCode 可能影响性能（尤其是每帧执行）。
    /// 使用 Input.inputString 监听字符输入，并仅监听常用按键（如 WASD、空格等）：
    /// </summary>
    internal class VLBaseSystemV2 : MonoBehaviour
    {
        private KeyCode[] monitoredKeys = { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.Space };

        void Update()
        {
            // 监听键盘按键
            CheckKeyboardInput();

            // 监听鼠标点击
            CheckMouseClick();

            //// 监听鼠标移动和滚轮
            //CheckMouseMovement();
        }

        private void CheckKeyboardInput()
        {
            foreach (KeyCode key in monitoredKeys)
            {
                if (Input.GetKeyDown(key))
                {
                    Debug.Log($"监听到按键: {key}");
                }
            }
        }

        private void CheckMouseClick()
        {
            for (int i = 0; i < 3; i++) // 0-左键, 1-右键, 2-中键
            {
                if (Input.GetMouseButtonDown(i))
                {
                    Debug.Log($"鼠标按键按下: 按钮{i}");
                }
            }
        }

        private void CheckMouseMovement()
        {
            // 监听鼠标移动
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            if (mouseX != 0 || mouseY != 0)
            {
                Debug.Log($"鼠标移动: X={mouseX}, Y={mouseY}");
            }
            // 监听滚轮滚动
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            if (scroll != 0)
            {
                Debug.Log($"滚轮滚动: {scroll}");
            }
        }
    }
}
