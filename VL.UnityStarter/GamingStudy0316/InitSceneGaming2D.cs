using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace VL.UnityStarter.GamingStudy0316
{
    //�༭ģʽ��Ч,����֧�ֱ༭ʱ�ýű����Ƴ���
    [ExecuteInEditMode]
    public class InitSceneGaming2D : MonoBehaviour
    {
        GameObject startGO;
        GameObject assetGO;
        GameObject gamingGO;
        GameObject settingGO;
        GameObject soundManagerGO;

        GameObject startCameraGO;
        GameObject startCanvasGO;

        GameObject gamingCameraGO;
        GameObject gamingCanvasGO;

        GameObject settingCameraGO;
        GameObject settingCanvasGO;

        void Start()
        {
            Debug.Log($"Instantiate Start");

            RectTransform rectTransform;
            Camera camera2D;
            Button button;
            Image image;
            Text text;
            GameObject game0316 = new GameObject("game0316");

            #region init startGO
            //�����Ϸ��������
            startGO = new GameObject("startGO");
            //��������
            startCameraGO = VLCreator.CreateCamera("startCameraGO", startGO);
            camera2D = startCameraGO.GetComponent<Camera>();
            camera2D.orthographic = true;
            //��ӻ���
            startCanvasGO = VLCreator.CreateCanvas("start_BackgroundCanvas", startGO);
            //��ӱ���
            var backgroundGO = new GameObject("backgroundGO");
            backgroundGO.SetParent(startCanvasGO);
            image = backgroundGO.AddComponent<Image>();
            image.sprite = Resources.Load<Sprite>("xDRpfI");
            rectTransform = image.GetComponent<RectTransform>();
            rectTransform.anchorMin = new Vector2(0f, 0f);
            rectTransform.anchorMax = new Vector2(1f, 1f);
            rectTransform.offsetMin = new Vector2(0f, 0f);
            rectTransform.offsetMax = new Vector2(0f, 0f);
            rectTransform.localPosition = new Vector3(0f, 0f, 0f);
            //��Ӱ�ť
            //Start
            var gameObject = VLCreator.CreateButton("start", startCanvasGO);
            gameObject.ToStartMenuButtonStyle();
            text = gameObject.GetComponentInChildren<Text>();
            text.text = "��ʼ��Ϸ";
            rectTransform = gameObject.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(0f, 200f, 0f);
            button = gameObject.GetComponent<Button>();
            //Load
            gameObject = VLCreator.CreateButton("load", startCanvasGO);
            gameObject.ToStartMenuButtonStyle();
            text = gameObject.GetComponentInChildren<Text>();
            text.text = "������Ϸ";
            rectTransform = gameObject.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(0f, 100f, 0f);
            button = gameObject.GetComponent<Button>();
            //Config
            gameObject = VLCreator.CreateButton("config", startCanvasGO);
            gameObject.ToStartMenuButtonStyle();
            text = gameObject.GetComponentInChildren<Text>();
            text.text = "��Ϸ����";
            rectTransform = gameObject.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(0f, 0f, 0f);
            button = gameObject.GetComponent<Button>();
            //Quit
            gameObject = VLCreator.CreateButton("end", startCanvasGO);
            gameObject.ToStartMenuButtonStyle();
            text = gameObject.GetComponentInChildren<Text>();
            text.text = "�˳�";
            rectTransform = gameObject.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(0f, -100f, 0f);
            button = gameObject.GetComponent<Button>();

            #endregion

            assetGO = new GameObject("assetGO");
            gamingGO = new GameObject("gamingGO");
            settingGO = new GameObject("settingGO");
            soundManagerGO = new GameObject("soundManagerGO");

            #region init gamingGO

            ////��������
            //gamingCameraGO = VLCreator.CreateCamera("gamingCameraGO", gamingGO);
            //camera2D = gamingCameraGO.GetComponent<Camera>();
            //camera2D.orthographic = true;
            ////��ӻ���Canvas
            //gamingCanvasGO = VLCreator.CreateCanvas("gaming_BackgroundCanvas", gamingGO);
            ////��ӱ���Image
            //backgroundImageGO = VLCreator.CreateImage("gaming_BackgroundImage", gamingCanvasGO);
            //image = backgroundImageGO.GetComponent<Image>();
            //if (ColorUtility.TryParseHtmlString("#095B00", out Color c))
            //{
            //    image.color = c;
            //}
            //rectTransform = image.GetComponent<RectTransform>();
            //rectTransform.anchorMin = new Vector2(0f, 0f);
            //rectTransform.anchorMax = new Vector2(1f, 1f);
            //rectTransform.offsetMin = new Vector2(0f, 0f);
            //rectTransform.offsetMax = new Vector2(0f, 0f);
            //rectTransform.localPosition = new Vector3(0f, 0f, 0f);
            #endregion

            startGO.SetParent(game0316);
            assetGO.SetParent(game0316);
            gamingGO.SetParent(game0316);
            settingGO.SetParent(game0316);
            soundManagerGO.SetParent(game0316);

            //��ӽű�
            game0316.AddComponent<Gaming0316>();
            soundManagerGO.AddComponent<SoundManager>();

            ////���Player from Prefab
            //GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Scripts/0316/Player.prefab"); 
            //GameObject playerGO = Instantiate(prefab, gamingGO.transform);
            //gaming0316.playerGO = playerGO;
            //gaming0316.canvasGO = gamingCanvasGO;

            Debug.Log($"Instantiate End");
        }
    }
}