using UnityEngine;
using UnityEngine.UI;
using VL.Gaming.Unity.Gaming.GameSystem.Widgets;

namespace VL.Gaming.Unity.Gaming.GameSystem.Widgets
{
    internal class CountDownTextManager : MonoBehaviour
    {
        Text uiText;
        CountDownTimer CountDownTimer;
        TextColorFader TextColorFader;

        void Start()
        {
            if (uiText == null)
            {
                uiText = this.GetComponentInChildren<Text>();
                CountDownTimer = this.gameObject.AddComponent<CountDownTimer>();
                TextColorFader = this.gameObject.AddComponent<TextColorFader>();
                CountDownTimer.OnTriggerEffect += () =>
                {
                    TextColorFader.Start(1, 3);
                };
                CountDownTimer.Start(5, 3);
            }
        }
    }
}
