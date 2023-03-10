using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        textComponent.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        textComponent.fontSize = 32;
        textComponent.color = Color.white;
        textComponent.alignment = TextAnchor.MiddleCenter;
        textComponent.rectTransform.anchoredPosition = Vector2.zero;
        textComponent.rectTransform.sizeDelta = Vector2.one * 100f;
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
        gameObject.AddComponent<Button>();
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
}