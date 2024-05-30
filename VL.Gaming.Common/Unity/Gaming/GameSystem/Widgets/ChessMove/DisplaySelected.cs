using System.Collections;
using UnityEngine;

namespace VL.Gaming.Unity.Gaming.GameSystem.ChessMove
{
    public class DisplaySelected : MonoBehaviour
    {
        private Animator animator;
        private bool isSelected = false;

        void Start()
        {
            animator = GetComponent<Animator>();
        }

        void OnMouseDown()
        {
            Debug.Log("OnMouseDown");
            if (!isSelected)
            {
                Debug.Log("DisplaySelected");

                isSelected = true;
                // 开始播放动画A
                animator.Play("Light");
                // 也可以开始播放动画B，取决于你的逻辑
                // animator.Play("AnimationB");
            }
        }

        public void Attack(GameObject target)
        {
            if (isSelected)
            {
                // 播放攻击动画或处理攻击逻辑
                Debug.Log("Attacking " + target.name);
                // 你可以在这里添加攻击目标C的逻辑
            }
        }

        public void Deselect()
        {
            isSelected = false;
            // 停止动画或重置状态
            animator.Play("Idle");
        }
    }
}
