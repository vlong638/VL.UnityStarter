using System.Collections;
using System.Collections.Generic;
using Assets.Scenes.VLGamingStudy;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
namespace VL.UnityStarter.VLGamingStudy0311
{
    //�༭ģʽ��Ч,����֧�ֱ༭ʱ�ýű����Ƴ���
    [ExecuteInEditMode]
    public class InitSceneGaming2D : MonoBehaviour
    {
        GameObject gamingGO;
        GameObject cameraGO;
        GameObject canvasGO;

        void Start()
        {
            Debug.Log($"Instantiate Start");
            //�����Ϸ��������
            gamingGO = new GameObject("2DGaming");
            //��������
            cameraGO = VLCreater.CreateCamera("Camera2D", gamingGO);
            var camera2D = cameraGO.GetComponent<Camera>();
            camera2D.orthographic = true;
            //��ӻ���Canvas
            canvasGO = VLCreater.CreateCanvas("BackgroundCanvas", gamingGO);
            //��ӱ���Image
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
            ////���Player
            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Scripts/0311/Player.prefab");
            GameObject playerGO = Instantiate(prefab, gamingGO.transform);
            //��ӽű�
            var gaming0311 = gamingGO.AddComponent<Gaming0311>();
            gaming0311.canvasGO = canvasGO;
            gaming0311.playerGO = playerGO;
            Debug.Log($"Instantiate End");
        }
    }
}