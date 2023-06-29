using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scenes.VLGamingStudy
{
    public static partial class VLDecorator
    {
        public static void ToStartMenuButtonStyle(this GameObject startGameBtn)
        {
            var image = startGameBtn.GetComponent<Image>();
            image.color = Color.black;
            var canvasGroup = startGameBtn.AddComponent<CanvasGroup>();
            canvasGroup.alpha = 0.6f;
            var text = startGameBtn.GetComponentInChildren<Text>();
            text.color = Color.white;
            text.fontSize = 50;
            var rectTransform = startGameBtn.GetComponent<RectTransform>();
            rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
            rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
            rectTransform.localPosition = new Vector3(0f, 0f, 0f);
            rectTransform.sizeDelta = new Vector2(320, 60);
        }
    }
}
