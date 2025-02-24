using UnityEngine;

namespace VL.Gaming.Scripts.GamingV2
{
    internal class VLBaseSystem : MonoBehaviour
    {
        void Update()
        {
            // 监听键盘按键
            CheckKeyboardInput();

            // 监听鼠标点击
            CheckMouseClick();

            // 监听鼠标移动和滚轮
            CheckMouseMovement();
        }

        private void CheckKeyboardInput()
        {
            if (Input.anyKeyDown)
            {
                // 遍历所有可能的按键
                foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKeyDown(keyCode))
                    {
                        Debug.Log($"键盘按键按下: {keyCode}");
                    }
                }
            }

            // 监听字符输入（如 Shift+A 会输出 'A'）
            string inputChars = Input.inputString;
            if (!string.IsNullOrEmpty(inputChars))
            {
                foreach (char c in inputChars)
                {
                    Debug.Log($"字符输入: {c}");
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
