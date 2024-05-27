using System.Collections;
using UnityEngine;

namespace VL.Gaming.Unity.Gaming.GameSystem.ChessMove
{
    public class DisplayCrash : MonoBehaviour
    {
        private static DisplayCrash instance;
        public static DisplayCrash Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameObject("DisplayCrash").AddComponent<DisplayCrash>();
                }
                return instance;
            }
        }

        public float moveSpeed = 5f; // 移动速度
        public float jumpHeight = 1f; // 跳跃高度
        public bool isMoving = false; // 是否正在移动

        // 移动、模拟跳跃撞击然后返回原位置
        public void Display(GameObject currentObject, GameObject targetObject)
        {
            orientPosition = currentObject.transform.position;
            targetPosition = targetObject.transform.position;
            StartCoroutine(MoveCrashReturn(currentObject, targetPosition));
        }
        private Vector3 targetPosition; // 初始位置
        private Vector3 orientPosition; // 初始位置
        IEnumerator MoveCrashReturn(GameObject currentObjecct, Vector3 targetPosition)
        {
            isMoving = true;
            float startTime = Time.time;
            float journeyLength = Vector3.Distance(currentObjecct.transform.position, targetPosition);
            while (isMoving)
            {
                float distCovered = (Time.time - startTime) * moveSpeed;
                float fracJourney = distCovered / journeyLength;
                if (fracJourney < 0.5f) // 前半段模拟跳跃
                {
                    float fracJump = (fracJourney) / 0.5f;
                    currentObjecct.transform.position = Vector3.Lerp(orientPosition, targetPosition, fracJump);
                }
                else // 后半段返回原位置
                {
                    float fracReturn = (fracJourney - 0.5f) / 0.5f;
                    currentObjecct.transform.position = Vector3.Lerp(targetPosition, orientPosition, fracReturn);
                }
                if (fracJourney >= 1f)
                {
                    isMoving = false;
                }
                yield return null;
            }
        }
    }
}
