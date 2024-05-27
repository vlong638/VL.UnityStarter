using UnityEngine;
using UnityEngine.UI;

namespace VL.Gaming.Unity.Gaming.GameSystem.Widgets
{
    public class CountDownTimer : MonoBehaviour
    {
        public float countdownTime = 60f; // 倒计时时间，单位：秒
        public Text timerText; // 用于显示倒计时的UI文本
        public float currentTime;

        void Start()
        {
            currentTime = countdownTime;
        }

        void Update()
        {
            currentTime -= Time.deltaTime;
            if (currentTime < 0)
            {
                currentTime = 0;
            }

            DisplayTime(currentTime);
        }

        void DisplayTime(float timeToDisplay)
        {
            float minutes = Mathf.FloorToInt(timeToDisplay / 60);
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
