using UnityEngine;

namespace VL.Gaming.Unity.Gaming.GameSystem.Widgets
{
    public class HourGlassManager : MonoBehaviour
    {
        public GameObject topSand; // 上半部分沙粒的对象
        public GameObject bottomSand; // 下半部分沙粒的对象
        public CountDownTimer countdownTimer; // 倒计时组件
        private float initialSandVolume;

        void Start()
        {
            // 假设沙粒对象有一个组件用于控制其填充量，例如Scale、Volume等
            initialSandVolume = topSand.transform.localScale.y;
        }

        void Update()
        {
            UpdateSandVolume();
        }

        void UpdateSandVolume()
        {
            float normalizedTime = countdownTimer.currentTime / countdownTimer.countdownTime;
            float topSandVolume = Mathf.Lerp(0, initialSandVolume, normalizedTime);
            float bottomSandVolume = initialSandVolume - topSandVolume;

            // 更新沙粒的填充量
            topSand.transform.localScale = new Vector3(topSand.transform.localScale.x, topSandVolume, topSand.transform.localScale.z);
            bottomSand.transform.localScale = new Vector3(bottomSand.transform.localScale.x, bottomSandVolume, bottomSand.transform.localScale.z);
        }
    }
}
