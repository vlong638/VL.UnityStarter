using UnityEngine;

namespace VL.Gaming.Study.Unity
{
    internal class Study_Animator : MonoBehaviour
    {
        private Animator animator;

        void Start()
        {
            // 获取角色的 Animator 组件
            animator = GetComponent<Animator>();
        }

        void Update()
        {
            // 当按下空格键时播放跳跃动画
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // 触发跳跃动画
                animator.SetTrigger("Jump");
            }

            // 控制角色的移动
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            // 更新 Animator 中的移动参数
            animator.SetFloat("Speed", Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        }
    }
}
