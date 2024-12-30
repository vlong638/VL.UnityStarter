using UnityEngine;
using UnityEngine.UI;

namespace VL.Gaming.Unity.Gaming.GameSystem.Widgets
{
    public class TextColorFader : MonoBehaviour
    {
        public Text uiText;
        private float timeElapsed;
        private float cycleDuration = 1f;
        private float totalDuration = 6f;
        private bool isStarted = false;

        void Start()
        {
            if (uiText == null)
            {
                uiText = this.GetComponentInChildren<Text>();
            }
        }

        void Update()
        {
            if (!isStarted)
                return;

            timeElapsed += Time.deltaTime;
            float alpha = Mathf.PingPong(timeElapsed / cycleDuration, 1f);
            uiText.color = new Color(1f, 0f, 0f, alpha);
            if (timeElapsed >= totalDuration)
            {
                timeElapsed = 0f;
                isStarted = false;
            }
        }

        public void Start(float cycleDuration = 1f, float totalDuration = 6f)
        {
            this.cycleDuration = cycleDuration;
            this.totalDuration = totalDuration;
            isStarted = true;
        }
    }
}
