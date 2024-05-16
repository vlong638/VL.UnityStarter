using UnityEngine;
using UnityEngine.UI;
using VL.Gaming.Common;

namespace VL.Gaming.Unity.Tools
{
    public enum SortingOrder
    {
        None = 0,
        Floor = 3,
        Item = 5,
        Creature = 9,
        AboveAll = 10,
    }
    public static class VLCreator
    {
        public static GameObject CreateCanvas(string name = "", GameObject parent = null)
        {
            GameObject gameObject = new GameObject(name);
            if (parent) gameObject.transform.SetParent(parent.transform);
            Canvas canvas = gameObject.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            gameObject.AddComponent<CanvasScaler>();
            gameObject.AddComponent<GraphicRaycaster>();
            return gameObject;
        }
        public static GameObject CreateCamera(string name = "", GameObject parent = null)
        {
            GameObject gameObject = new GameObject(name);
            if (parent) gameObject.transform.SetParent(parent.transform);
            Camera camera = gameObject.AddComponent<Camera>();
            camera.clearFlags = CameraClearFlags.SolidColor;
            camera.backgroundColor = Color.gray;
            return gameObject;
        }
        public static GameObject CreateText(string name = "", GameObject parent = null)
        {
            GameObject gameObject = new GameObject(name);
            if (parent) gameObject.transform.SetParent(parent.transform);
            Text textComponent = gameObject.AddComponent<Text>();
            textComponent.text = "Hello, World!";
            textComponent.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            textComponent.fontSize = 32;
            textComponent.color = Color.white;
            textComponent.alignment = TextAnchor.MiddleCenter;
            textComponent.rectTransform.anchoredPosition = Vector2.zero;
            textComponent.rectTransform.sizeDelta = Vector2.one * 100f;
            return gameObject;
        }
        public static GameObject CreateSprite(Sprite sprite, string name = "", GameObject parent = null)
        {
            GameObject gameObject = CreateSprite(name, parent);
            var image = gameObject.GetComponent<SpriteRenderer>();
            image.sprite = sprite;
            image.sortingOrder = 3;
            return gameObject;
        }
        public static GameObject CreateSprite(string name = "", GameObject parent = null)
        {
            GameObject gameObject = new GameObject(name);
            if (parent) gameObject.transform.SetParent(parent.transform);
            gameObject.AddComponent<SpriteRenderer>();
            return gameObject;
        }
        public static GameObject CreateImage(Sprite sprite, string name = "", GameObject parent = null)
        {
            GameObject gameObject = CreateImage(name, parent);
            var image = gameObject.GetComponent<Image>();
            image.sprite = sprite;
            return gameObject;
        }
        public static GameObject CreateImage(string name = "", GameObject parent = null)
        {
            GameObject gameObject = new GameObject(name);
            if (parent) gameObject.transform.SetParent(parent.transform);
            gameObject.AddComponent<Image>();
            return gameObject;
        }
        public static GameObject CreateButton(string name = "", GameObject parent = null)
        {
            GameObject gameObject = new GameObject(name);
            if (parent) gameObject.transform.SetParent(parent.transform);
            gameObject.AddComponent<Image>();
            gameObject.AddComponent<Button>();
            var text = CreateText("", gameObject);
            var rectTransform = text.GetComponent<RectTransform>();
            rectTransform.anchorMin = new Vector2(0f, 0f);
            rectTransform.anchorMax = new Vector2(1f, 1f);
            rectTransform.offsetMin = new Vector2(0f, 0f);
            rectTransform.offsetMax = new Vector2(0f, 0f);
            return gameObject;
        }
        public static GameObject CreateScrollView(string name = "", GameObject parent = null)
        {
            GameObject gameObject = new GameObject(name);
            if (parent) gameObject.transform.SetParent(parent.transform);
            gameObject.AddComponent<Image>();
            gameObject.AddComponent<ScrollRect>();
            return gameObject;
        }
        public static GameObject CreateAudioSource(string name = "", GameObject parent = null)
        {
            GameObject gameObject = new GameObject(name);
            if (parent) gameObject.transform.SetParent(parent.transform);
            gameObject.AddComponent<AudioSource>();
            return gameObject;
        }
    }
    public static class VLCreaterPlus
    {
        public static GameObject CreateDialogue(string name = "dialogue", GameObject parent = null)
        {
            //Canvas
            var canvasGO = VLCreator.CreateCanvas(name, parent);
            var canvas = canvasGO.GetComponent<Canvas>();
            canvas.renderMode = RenderMode.WorldSpace;
            canvas.sortingOrder = (int)SortingOrder.AboveAll;
            var trans = canvasGO.GetComponent<RectTransform>();
            trans.anchorMin = new Vector3(0, 0);
            trans.anchorMax = new Vector3(0, 0);
            trans.anchoredPosition = new Vector2(0, 0.3f);
            trans.sizeDelta = new Vector2(1, 0.5f);
            if (parent) canvasGO.transform.SetParent(parent.transform);
            //Image
            var imageGO = VLCreator.CreateImage("dialogueImage", canvasGO);
            trans = imageGO.GetComponent<RectTransform>();
            trans.anchorMin = new Vector3(0, 0);
            trans.anchorMax = new Vector3(1, 1);
            trans.offsetMin = Vector2.zero;
            trans.offsetMax = Vector2.zero;
            trans.localPosition = Vector3.zero;
            var image = imageGO.GetComponent<Image>();
            image.color = "#050505".ToColor();
            var canvasGroup = imageGO.AddComponent<CanvasGroup>();
            canvasGroup.alpha = 0.8f;
            //Text
            var textGO = VLCreator.CreateText("dialogueText", imageGO);
            trans = textGO.GetComponent<RectTransform>();
            trans.anchorMin = new Vector3(0, 1);
            trans.anchorMax = new Vector3(0, 1);
            trans.sizeDelta = new Vector2(100, 0);
            trans.pivot = Vector3.zero;
            trans.localScale = new Vector3(0.01f, 0.01f);
            var text = textGO.GetComponent<Text>();
            text.color = Color.white;
            text.text = "123456789012345678901234567890123456";
            text.fontSize = 14;
            text.verticalOverflow = VerticalWrapMode.Overflow;
            text.alignment = TextAnchor.UpperLeft;
            canvasGO.SetActive(true);
            return canvasGO;
        }
    }
}
