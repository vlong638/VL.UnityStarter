using System.Collections;
using System.Collections.Generic;
using Assets.Scenes.VLGamingStudy;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
namespace VL.UnityStarter.VLGamingStudy0311
{
    //编辑模式生效,可以支持编辑时用脚本控制场景
    [ExecuteInEditMode]
    public class InitSceneGaming2D : MonoBehaviour
    {
        GameObject gamingGO;
        GameObject cameraGO;
        GameObject canvasGO;

        void Start()
        {
            Debug.Log($"Instantiate Start");
            //添加游戏对象收纳
            gamingGO = new GameObject("2DGaming");
            //添加摄像机
            cameraGO = VLCreater.CreateCamera("Camera2D", gamingGO);
            var camera2D = cameraGO.GetComponent<Camera>();
            camera2D.orthographic = true;
            //添加画布Canvas
            canvasGO = VLCreater.CreateCanvas("BackgroundCanvas", gamingGO);
            //添加背景Image
            var backgroundImageGO = VLCreater.CreateImage("BackgroundImage", canvasGO);
            var image = backgroundImageGO.GetComponent<Image>();
            if (ColorUtility.TryParseHtmlString("#095B00", out Color c))
            {
                image.color = c;
            }
            RectTransform rectTransform = image.GetComponent<RectTransform>();
            rectTransform.anchorMin = new Vector2(0f, 0f);
            rectTransform.anchorMax = new Vector2(1f, 1f);
            rectTransform.offsetMin = new Vector2(0f, 0f);
            rectTransform.offsetMax = new Vector2(0f, 0f);
            rectTransform.localPosition = new Vector3(0f, 0f, 0f);
            ////添加Player
            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Scripts/0311/Player.prefab");
            GameObject playerGO = Instantiate(prefab, gamingGO.transform);
            //添加脚本
            var gaming0311 = gamingGO.AddComponent<Gaming0311>();
            gaming0311.canvasGO = canvasGO;
            gaming0311.playerGO = playerGO;
            Debug.Log($"Instantiate End");
        }
    }
}