using System.Collections;
using UnityEngine;

namespace VL.Gaming.Unity.Gaming.GameSystem.ChessMove
{
    public class DisplayTransform : MonoBehaviour
    {
        public float moveSpeed = 5f; // 移动速度
        public float jumpHeight = 1f; // 跳跃高度
        private bool isMoving = false; // 是否正在移动

        // 移动并变化Scale
        public void Display(GameObject target, Vector3 targetPosition, float targetScale)
        {
            StartCoroutine(MoveAndScale(target, targetPosition, targetScale));
        }
        IEnumerator MoveAndScale(GameObject target, Vector3 targetPosition, float targetScale)
        {
            isMoving = true;
            float startTime = Time.time;
            float journeyLength = Vector3.Distance(target.transform.position, targetPosition);
            while (isMoving)
            {
                float distCovered = (Time.time - startTime) * moveSpeed;
                float fracJourney = distCovered / journeyLength;
                target.transform.position = Vector3.Lerp(target.transform.position, targetPosition, fracJourney);
                target.transform.localScale = Vector3.Lerp(target.transform.localScale, new Vector3(targetScale, targetScale, targetScale), fracJourney);
                if (fracJourney >= 1f)
                {
                    isMoving = false;
                }
                yield return null;
            }
        }
    }
}
