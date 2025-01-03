using Assets.Scenes.VLGamingStudy;
using UnityEngine;
using UnityEngine.UI;

namespace VL.UnityStarter.VLGamingStudy0316
{
    //编辑模式生效,可以支持编辑时用脚本控制场景
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
            //添加游戏对象收纳
            startGO = new GameObject("startGO");
            //添加摄像机
            startCameraGO = VLCreater.CreateCamera("startCameraGO", startGO);
            camera2D = startCameraGO.GetComponent<Camera>();
            camera2D.orthographic = true;
            //添加画布
            startCanvasGO = VLCreater.CreateCanvas("start_BackgroundCanvas", startGO);
            //添加背景
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
            //添加按钮
            //Start
            var gameObject = VLCreater.CreateButton("start", startCanvasGO);
            gameObject.ToStartMenuButtonStyle();
            text = gameObject.GetComponentInChildren<Text>();
            text.text = "开始游戏";
            rectTransform = gameObject.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(0f, 200f, 0f);
            button = gameObject.GetComponent<Button>();
            //Load
            gameObject = VLCreater.CreateButton("load", startCanvasGO);
            gameObject.ToStartMenuButtonStyle();
            text = gameObject.GetComponentInChildren<Text>();
            text.text = "加载游戏";
            rectTransform = gameObject.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(0f, 100f, 0f);
            button = gameObject.GetComponent<Button>();
            //Config
            gameObject = VLCreater.CreateButton("config", startCanvasGO);
            gameObject.ToStartMenuButtonStyle();
            text = gameObject.GetComponentInChildren<Text>();
            text.text = "游戏设置";
            rectTransform = gameObject.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(0f, 0f, 0f);
            button = gameObject.GetComponent<Button>();
            //Quit
            gameObject = VLCreater.CreateButton("end", startCanvasGO);
            gameObject.ToStartMenuButtonStyle();
            text = gameObject.GetComponentInChildren<Text>();
            text.text = "退出";
            rectTransform = gameObject.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(0f, -100f, 0f);
            button = gameObject.GetComponent<Button>();

            #endregion

            assetGO = new GameObject("assetGO");
            gamingGO = new GameObject("gamingGO");
            settingGO = new GameObject("settingGO");
            soundManagerGO = new GameObject("soundManagerGO");

            #region init gamingGO

            ////添加摄像机
            //gamingCameraGO = VLCreator.CreateCamera("gamingCameraGO", gamingGO);
            //camera2D = gamingCameraGO.GetComponent<Camera>();
            //camera2D.orthographic = true;
            ////添加画布Canvas
            //gamingCanvasGO = VLCreator.CreateCanvas("gaming_BackgroundCanvas", gamingGO);
            ////添加背景Image
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

            //添加脚本
            game0316.AddComponent<Gaming0316>();
            soundManagerGO.AddComponent<SoundManager>();

            ////添加Player from Prefab
            //GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Scripts/0316/Player.prefab"); 
            //GameObject playerGO = Instantiate(prefab, gamingGO.transform);
            //gaming0316.playerGO = playerGO;
            //gaming0316.canvasGO = gamingCanvasGO;

            Debug.Log($"Instantiate End");
        }
    }
}