using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using VL.Gaming.Scripts.Common;
using VL.Gaming.Scripts.Gaming.Content.Entities;
using VL.Gaming.Scripts.Gaming.GameSystem;
using VL.Gaming.Scripts.Gaming.Tools;
using VL.Gaming.Scripts.Tools;
using VL.Gaming.Scripts.Utils;

namespace VL.Gaming.Scripts.UnityTools
{
    internal class Tools_Scene_InitPauseMenu
    {
        [MenuItem("Tools/Scene/InitPauseMenu")]
        static void InitPauseMenu()
        {
            //检查已存在
            VLResourceHelper.CheckExist("Canvas_PauseMenu");

            //依赖前置
            var Prefab_Button_PauseMenu_Normal = VLResourcePool.Prefab_Button_PauseMenu_Normal;

            //Canvas_PauseMenu
            var Canvas_PauseMenu = VLCreator.CreateCanvas("Canvas_PauseMenu");

            //Panel_Background
            var Panel_Background = VLCreator.CreatePanel("Panel_Background");
            Panel_Background.SetParent(Canvas_PauseMenu);
            Panel_Background.SetRectStretch();
            var image = Panel_Background.GetComponent<Image>();
            image.sprite  = VLResourcePool.Sprite_Background;
            image.color = new Color(0, 0, 0, 0.78f);
            image.type = Image.Type.Sliced;

            //Buttons
            var button = GameObject.Instantiate(Prefab_Button_PauseMenu_Normal);
            button.SetParent(Panel_Background);
            button.name = "Button_Continue";
            button.SetRectCenterTop(0, -100, 200, 40);
            button.SetTextContent("继续游戏");

            button = GameObject.Instantiate(Prefab_Button_PauseMenu_Normal);
            button.SetParent(Panel_Background);
            button.name = "Button_Save";
            button.SetRectCenterTop(0, -180, 200, 40);
            button.SetTextContent("保存 ");

            button = GameObject.Instantiate(Prefab_Button_PauseMenu_Normal);
            button.SetParent(Panel_Background);
            button.name = "Button_Load";
            button.SetRectCenterTop(0, -260, 200, 40);
            button.SetTextContent("加载 ");

            button = GameObject.Instantiate(Prefab_Button_PauseMenu_Normal);
            button.SetParent(Panel_Background);
            button.name = "Button_Quit";
            button.SetRectCenterTop(0, -340, 200, 40);
            button.SetTextContent("退出 ");

            Debug.Log($"Instantiate End");
        }

    }
}
