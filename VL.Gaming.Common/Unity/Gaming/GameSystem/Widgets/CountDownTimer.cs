using System;
using UnityEngine;
using UnityEngine.UI;

namespace VL.Gaming.Unity.Gaming.GameSystem.Widgets
{
    public class CountDownTimer : MonoBehaviour
    {
        public float countdownTime = 10f;
        public Text timerText;
        public float currentTime;

        public event Action OnTimerEnd;
        private bool hasFiredEvent = false;
        bool isStart = false;

        void Start()
        {
            timerText = this.GetComponentInChildren<Text>();
            currentTime = countdownTime;
        }

        void Update()
        {
            if (!isStart)
                return;

            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            {
                currentTime = 0;
                isStart = false;
            }
            if (currentTime <= effectTriggerTime && !hasTriggeredEffect)
            {
                // 倒计时结束，调用事件
                hasTriggeredEffect = true;
                OnTriggerEffect?.Invoke();
            }
            if (currentTime <= 0 && !hasFiredEvent)
            {
                // 倒计时结束，调用事件
                OnTimerEnd?.Invoke();
                hasFiredEvent = true;
            }

            DisplayTime(currentTime);
        }

        void DisplayTime(float timeToDisplay)
        {
            float minutes = Mathf.FloorToInt(timeToDisplay / 60);
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }

        float effectTriggerTime = 3f;
        bool hasTriggeredEffect = false;
        public event Action OnTriggerEffect;

        public void Start(float countdownTime = 10, float effectTriggerTime = 3)
        {
            this.countdownTime = countdownTime;
            this.effectTriggerTime = effectTriggerTime;
            isStart = true;
            hasTriggeredEffect = OnTriggerEffect == null;
        }
    }
}
