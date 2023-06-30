using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace VL.UnityStarter.VLGaming2D
{
    public static class InitSceneGaming2D
    {

        [MenuItem("Tools/InitSceneGaming3D")]
        static void Init()
        {
            Debug.Log($"Instantiate Start");

            GameObject entitiesGO;
            GameObject assetGO;

            entitiesGO = new GameObject(nameof(entitiesGO));
            //var ground1 = VLCreater063025D.CreateGround("ground1",entitiesGO);
            //var player = VLCreater

            //assetGO = new GameObject(nameof(assetGO));

            //entitiesGO




            //GameObject startGO ;
            //GameObject assetGO;
            //GameObject gameboardGO;
            //GameObject settingGO;
            //GameObject soundManagerGO;
            //GameObject startCameraGO;
            //GameObject startCanvasGO;
            //RectTransform rectTransform;
            //Camera camera2D;
            //Image image;
            //Text text;
            //GameObject gameManager = new GameObject("gameManager");

            //#region init startGO
            ////添加游戏对象收纳
            //startGO = new GameObject("startGO");
            ////添加摄像机
            //startCameraGO = VLCreater.CreateCamera("startCameraGO", startGO);
            //camera2D = startCameraGO.GetComponent<Camera>();
            //camera2D.orthographic = true;
            ////添加画布
            //startCanvasGO = VLCreater.CreateCanvas("start_BackgroundCanvas", startGO);
            ////添加背景
            //var backgroundGO = new GameObject("backgroundGO");
            //backgroundGO.SetParent(startCanvasGO);
            //image = backgroundGO.AddComponent<Image>();
            //image.sprite = Resources.Load<Sprite>("xDRpfI");
            //rectTransform = image.GetComponent<RectTransform>();
            //rectTransform.anchorMin = new Vector2(0f, 0f);
            //rectTransform.anchorMax = new Vector2(1f, 1f);
            //rectTransform.offsetMin = new Vector2(0f, 0f);
            //rectTransform.offsetMax = new Vector2(0f, 0f);
            //rectTransform.localPosition = new Vector3(0f, 0f, 0f);
            ////添加按钮
            ////Start
            //var gameObject = VLCreater.CreateButton("start", startCanvasGO);
            //gameObject.ToStartMenuButtonStyle();
            //text = gameObject.GetComponentInChildren<Text>();
            //text.text = "开始游戏";
            //rectTransform = gameObject.GetComponent<RectTransform>();
            //rectTransform.localPosition = new Vector3(0f, 200f, 0f);
            ////Load
            //gameObject = VLCreater.CreateButton("load", startCanvasGO);
            //gameObject.ToStartMenuButtonStyle();
            //text = gameObject.GetComponentInChildren<Text>();
            //text.text = "加载游戏";
            //rectTransform = gameObject.GetComponent<RectTransform>();
            //rectTransform.localPosition = new Vector3(0f, 100f, 0f);
            ////Config
            //gameObject = VLCreater.CreateButton("config", startCanvasGO);
            //gameObject.ToStartMenuButtonStyle();
            //text = gameObject.GetComponentInChildren<Text>();
            //text.text = "游戏设置";
            //rectTransform = gameObject.GetComponent<RectTransform>();
            //rectTransform.localPosition = new Vector3(0f, 0f, 0f);
            ////Quit
            //gameObject = VLCreater.CreateButton("end", startCanvasGO);
            //gameObject.ToStartMenuButtonStyle();
            //text = gameObject.GetComponentInChildren<Text>();
            //text.text = "退出";
            //rectTransform = gameObject.GetComponent<RectTransform>();
            //rectTransform.localPosition = new Vector3(0f, -100f, 0f);

            //#endregion

            //assetGO = new GameObject("assetGO");
            //gameboardGO = new GameObject("gameboardGO");
            //settingGO = new GameObject("settingGO");
            //soundManagerGO = new GameObject("soundManagerGO");

            //startGO.SetParent(gameManager);
            //assetGO.SetParent(gameManager);
            //gameboardGO.SetParent(gameManager);
            //settingGO.SetParent(gameManager);
            //soundManagerGO.SetParent(gameManager);

            ////添加脚本
            //gameManager.AddComponent<GameManager>();
            //soundManagerGO.AddComponent<SoundManager>();

            ////添加Player from Prefab
            //GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Scripts/0316/Player.prefab"); 
            //GameObject playerGO = Instantiate(prefab, gamingGO.transform);
            //gaming0316.playerGO = playerGO;
            //gaming0316.canvasGO = gamingCanvasGO;

            Debug.Log($"Instantiate End");
        }
    }
}