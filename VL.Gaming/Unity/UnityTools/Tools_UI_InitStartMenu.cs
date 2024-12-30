using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using VL.Gaming.Common;
using VL.Gaming.Unity.Gaming.Content.Entities;
using VL.Gaming.Unity.Gaming.GameSystem;
using VL.Gaming.Unity.Gaming.Tools;
using VL.Gaming.Unity.Tools;
using VL.Gaming.Unity.Utils;

namespace VL.Gaming.Unity.UnityTools
{
    public class Tools_UI_InitStartMenu
    {
        [MenuItem("Tools/UI/InitStartMenu")]
        static void InitStartMenu()
        {
            //检查已存在
            VLResourceHelper.CheckExist("GameSystemManager");
            VLResourceHelper.CheckExist("Canvas_StartMenu");
            VLResourceHelper.CheckExist("EventSystem");

            //依赖前置
            var EventSystem = VLCreator.CreateEventSystem("EventSystem");
            var Prefab_Button_StartMenu_Normal = VLResourcePool.Prefab_Button_StartMenu_Normal;
            var Prefab_Canvas_StartMenu_Declaration = VLResourcePool.Prefab_Canvas_StartMenu_Declaration;

            //GameSystemManager
            GameObject gameSystemManager = new GameObject("GameSystemManager");
            gameSystemManager.AddComponent<GameSystemManager>();
            //Canvas
            var Canvas = VLCreator.CreateCanvas("Canvas");
            //Panel
            var Panel = VLCreator.CreatePanel("Panel");
            Panel.SetParent(Canvas);
            Panel.SetRectStretch();
            Panel.SetColor(VLGenerater.MockColorForBackground());
            //Image_Title
            var Image_Title = VLCreator.CreateImage("Image_Title");
            Image_Title.SetParent(Panel);
            Image_Title.SetRectLeftTop(100, -50, 200, 400);
            Image_Title.SetColor(VLGenerater.MockColorForItem());

            //Button_Start
            GameObject Prefab_Button_StartMenu = GameObject.Instantiate(Prefab_Button_StartMenu_Normal);
            Prefab_Button_StartMenu.name = VLDictionaries.VLButtonsDic[VLButtons.StartGame];
            Prefab_Button_StartMenu.SetParent(Panel);
            Prefab_Button_StartMenu.transform.Find("Text").GetComponent<Text>().text = "开始";
            Prefab_Button_StartMenu.SetRectLeftTop(100, -600, 200, 40);
            //Button_Load
            GameObject Prefab_Button_LoadData = GameObject.Instantiate(Prefab_Button_StartMenu_Normal);
            Prefab_Button_LoadData.name = VLDictionaries.VLButtonsDic[VLButtons.Load];
            Prefab_Button_LoadData.SetParent(Panel);
            Prefab_Button_LoadData.transform.Find("Text").GetComponent<Text>().text = "继续";
            Prefab_Button_LoadData.SetRectLeftTop(100, -680, 200, 40);
            //Button_Setting
            GameObject Prefab_Button_Setting = GameObject.Instantiate(Prefab_Button_StartMenu_Normal);
            Prefab_Button_Setting.name = VLDictionaries.VLButtonsDic[VLButtons.Config];
            Prefab_Button_Setting.SetParent(Panel);
            Prefab_Button_Setting.transform.Find("Text").GetComponent<Text>().text = "设置";
            Prefab_Button_Setting.SetRectLeftTop(100, -760, 200, 40);
            //Button_Quit
            GameObject Prefab_Button_Quit = GameObject.Instantiate(Prefab_Button_StartMenu_Normal);
            Prefab_Button_Quit.name = VLDictionaries.VLButtonsDic[VLButtons.Quit];
            Prefab_Button_Quit.SetParent(Panel);
            Prefab_Button_Quit.transform.Find("Text").GetComponent<Text>().text = "退出";
            Prefab_Button_Quit.SetRectLeftTop(100, -840, 200, 40);
            //Panel_BulletinBoard
            var Panel_BulletinBoard = VLCreator.CreatePanel("Panel_BulletinBoard");
            Panel_BulletinBoard.SetParent(Panel);
            Panel_BulletinBoard.SetRectLeftTop(1400, -100, 420, 300);
            Panel_BulletinBoard.SetColor("#FFCB00C8".ToColor());
            //Panel_BulletinBoard_Text
            var Text = VLCreator.CreateText("Text");
            Text.SetParent(Panel_BulletinBoard);
            Text.SetRectStretch();
            var text = Text.GetComponent<Text>();
            text.fontSize = 24;
            text.color = Color.black;
            text.text = @"
  来自开发者的话:
  很高兴,这款游戏终于能够与大家见面.
  这是这款游戏的试玩版本.
  我会持续的推进这个游戏的更新.
  敬请期待...";
            //Prefab_Panel_Declaration
            GameObject Prefab_Panel_Declaration = GameObject.Instantiate(Prefab_Canvas_StartMenu_Declaration);
            Prefab_Panel_Declaration.SetParent(Panel);
            Prefab_Panel_Declaration.SetRectLeftDown(360, 0, 1200, 40);
            Prefab_Panel_Declaration.SetTextContent("抵制不良游戏，拒绝盗版游戏。注意自我保护，谨防受骗上当。适度游戏益脑，沉迷游戏伤身。合理安排时间，享受健康生活。");
            //Prefab_Panel_Version
            GameObject Prefab_Panel_Version = GameObject.Instantiate(Prefab_Canvas_StartMenu_Declaration);
            Prefab_Panel_Version.SetParent(Panel);
            Prefab_Panel_Version.SetRectLeftDown(1720, 0, 200, 40);
            Prefab_Panel_Version.SetTextContent("alpha 0.1.0");

            Debug.Log($"Instantiate End");
        }
    }
}
