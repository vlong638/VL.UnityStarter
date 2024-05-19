using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using VL.Gaming.Common;
using VL.Gaming.Unity.Gaming.Content.Entities;
using VL.Gaming.Unity.Gaming.Ultis;

namespace VL.Gaming.Unity.Tools
{
    internal class VLGameCreator0517
    {
        class Item
        {
            public string Name;
            public string ImageSource;
            public string Description;
        }

        [MenuItem("Tools/InitSceneGaming/InitPlayerBox")]
        static void InitPlayerBox()
        {
            PlayerData data= new PlayerData();
            data.Name = "PlayerVL";
            data.UnitAttributes = new UnitAttributes()
            {
                Agility = 17,
                Charisma = 18,
                Constitution = 19,
                Intelligence = 20,
                Leadership = 21,
                Strength = 22,
                Willpower = 23,
                Luck = 24,
            };

            //检查已存在
            var check  = ResourceHelper.FindGameObjectByName("Prefab_Canvas_Gaming_PlayerBox");
            if (check != null)
                Undo.DestroyObjectImmediate(check);

            //添加 canvas
            GameObject Prefab_Canvas_Gaming_PlayerBox = VLCreator.CreateCanvas("Prefab_Canvas_Gaming_PlayerBox");
            //添加 Image_Mask
            var backgroundGO = VLCreator.CreateImage("Image_Mask");
            backgroundGO.SetParent(Prefab_Canvas_Gaming_PlayerBox);
            backgroundGO.SetColor(Color.grey, 0.5f);
            var rectTransform = backgroundGO.GetComponent<Image>().GetComponent<RectTransform>();
            rectTransform.SetStretch();
            //添加 Panel_Team
            var Panel_Team = VLCreator.CreatePanel("Panel_Team");
            Panel_Team.SetParent(Prefab_Canvas_Gaming_PlayerBox);
            Panel_Team.SetColor(MockHelper.MockColor(), 1f);
            rectTransform = Panel_Team.GetComponent<Image>().GetComponent<RectTransform>();
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1200);
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 100);
            rectTransform.anchoredPosition = new Vector2(0, 400);
            ////添加 Panel_Unit
            var Panel_Unit = VLCreator.CreatePanel("Panel_Unit");
            Panel_Unit.SetParent(Prefab_Canvas_Gaming_PlayerBox);
            Panel_Unit.SetColor(Color.white, 0.5f);
            rectTransform = Panel_Unit.GetComponent<Image>().GetComponent<RectTransform>();
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1600);
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 800);
            rectTransform.anchoredPosition = new Vector2(0, -50);
            //添加 Image_Left
            var Image_Left = VLCreator.CreateImage("Image_Left");
            Image_Left.SetParent(Panel_Unit);
            Image_Left.SetColor(MockHelper.MockColor(), 1f);
            rectTransform = Image_Left.GetComponent<Image>().GetComponent<RectTransform>();
            rectTransform.SetLeftDown(0, 0, 500, 800);
            //添加 Image_BottomMini
            var Image_BottomMini = VLCreator.CreateImage("Image_BottomMini");
            Image_BottomMini.SetParent(Panel_Unit);
            Image_BottomMini.SetColor(MockHelper.MockColor(), 1f);
            rectTransform = Image_BottomMini.GetComponent<Image>().GetComponent<RectTransform>();
            rectTransform.SetLeftDown(500, 0, 600, 100);
            //添加 Image_LeftMini
            var Image_LeftMini = VLCreator.CreateImage("Image_LeftMini");
            Image_LeftMini.SetParent(Panel_Unit);
            Image_LeftMini.SetColor(MockHelper.MockColor(), 1f);
            rectTransform = Image_LeftMini.GetComponent<Image>().GetComponent<RectTransform>();
            rectTransform.SetLeftDown(500, 100, 100, 600);
            //添加 Image_TopMini
            var Image_TopMini = VLCreator.CreateImage("Image_TopMini");
            Image_TopMini.SetParent(Panel_Unit);
            Image_TopMini.SetColor(MockHelper.MockColor(), 1f);
            rectTransform = Image_TopMini.GetComponent<Image>().GetComponent<RectTransform>();
            rectTransform.SetLeftDown(500, 700, 600, 100);
            //添加 Image_Portrait
            var Image_Portrait = VLCreator.CreateImage("Image_Portrait");
            Image_Portrait.SetParent(Panel_Unit);
            Image_Portrait.SetColor(MockHelper.MockColor(), 1f);
            rectTransform = Image_Portrait.GetComponent<Image>().GetComponent<RectTransform>();
            rectTransform.SetLeftDown(600, 100, 400, 600);
            //添加 Image_RightMini
            var Image_RightMini = VLCreator.CreateImage("Image_RightMini");
            Image_RightMini.SetParent(Panel_Unit);
            Image_RightMini.SetColor(MockHelper.MockColor(), 1f);
            rectTransform = Image_RightMini.GetComponent<Image>().GetComponent<RectTransform>();
            rectTransform.SetLeftDown(1000, 100, 100, 600);
            //添加 Image_Right
            var Image_Right = VLCreator.CreateImage("Image_Right");
            Image_Right.SetParent(Panel_Unit);
            Image_Right.SetColor(MockHelper.MockColor(), 1f);
            rectTransform = Image_Right.GetComponent<Image>().GetComponent<RectTransform>();
            rectTransform.SetLeftDown(1100, 0, 500, 800);

            Text text;
            #region Image_Left,属性栏
            var Image_PlayerName = VLCreator.CreateText("Image_PlayerName");
            Image_PlayerName.SetParent(Image_Left);
            rectTransform = Image_PlayerName.GetComponent<RectTransform>();
            rectTransform.SetLeftDown(200, 650, 100, 200);
            text = Image_PlayerName.GetComponent<Text>();
            text.text = data.Name;
            text.fontSize = 32;
            text.alignment = TextAnchor.MiddleCenter;
            text.color = Color.black;
            //小图标, 名称, 现值,附加值
            string[] attributes = new string[] { "力量", "敏捷", "体质", "智力", "意志", "魅力", "领导力", "幸运" };
            string[] values = new string[] { $"{data.UnitAttributes.Strength}", $"{data.UnitAttributes.Agility}", $"{data.UnitAttributes.Constitution}", $"{data.UnitAttributes.Intelligence}", $"{data.UnitAttributes.Willpower}", $"{data.UnitAttributes.Charisma}", $"{data.UnitAttributes.Leadership}", $"{data.UnitAttributes.Luck}" };
            for (int i = 0; i < 8; i++)
            {
                var Image_AttributeIcon = VLCreator.CreateImage("Image_AttributeIcon");
                Image_AttributeIcon.SetParent(Image_Left);
                rectTransform = Image_AttributeIcon.GetComponent<RectTransform>();
                rectTransform.SetLeftDown(60, 650 - i * 80, 60, 60);
                Image_AttributeIcon.SetColor(MockHelper.MockColor2(), 1f);

                var Image_AttributeDiscribe = VLCreator.CreateText("Image_AttributeDiscribe");
                Image_AttributeDiscribe.SetParent(Image_Left);
                rectTransform = Image_AttributeDiscribe.GetComponent<RectTransform>();
                rectTransform.SetLeftDown(140, 630 - i * 80, 100, 100);
                text = Image_AttributeDiscribe.GetComponent<Text>();
                text.text = attributes[i];
                text.fontSize = 32;
                text.alignment = TextAnchor.MiddleCenter;
                text.color = Color.black;

                var Image_AttributeValue = VLCreator.CreateText("Image_AttributeValue");
                Image_AttributeValue.SetParent(Image_Left);
                rectTransform = Image_AttributeValue.GetComponent<RectTransform>();
                rectTransform.SetLeftDown(240, 630 - i * 80, 100, 100);
                text = Image_AttributeValue.GetComponent<Text>();
                text.text = values[i];
                text.fontSize = 32;
                text.alignment = TextAnchor.MiddleCenter;
                text.color = Color.black;

                var Button_AttributeMinus = VLCreator.CreateButton("Button_AttributeMinus");
                Button_AttributeMinus.SetParent(Image_Left);
                rectTransform = Button_AttributeMinus.GetComponent<RectTransform>();
                rectTransform.SetLeftDown(360, 665 - i * 80, 30, 30);
                Button_AttributeMinus.SetColor(MockHelper.MockColor2(), 1f);

                var Button_AttributePlus = VLCreator.CreateButton("Button_AttributePlus");
                Button_AttributePlus.SetParent(Image_Left);
                rectTransform = Button_AttributePlus.GetComponent<RectTransform>();
                rectTransform.SetLeftDown(400, 665 - i * 80, 30, 30);
                Button_AttributePlus.SetColor(MockHelper.MockColor2(), 1f);
            }

            var Button_AttributeConfirm = VLCreator.CreateButton("Button_AttributeConfirm");
            Button_AttributeConfirm.SetParent(Image_Left);
            rectTransform = Button_AttributeConfirm.GetComponent<RectTransform>();
            rectTransform.SetLeftDown(355, 30, 80, 40);
            Button_AttributeConfirm.SetColor(MockHelper.MockColor2(), 1f);
            #endregion

            #region Image_Right,装备栏
            //上分类 全部,武器,衣服,药水,特殊
            GameObject ScrollView_Items = VLCreator.CreateScrollView("ScrollView_Items");
            ScrollView_Items.SetParent(Image_Right);
            rectTransform = ScrollView_Items.GetComponent<RectTransform>();
            rectTransform.SetLeftDown(0, 0, 500, 700);
            //rectTransform.SetStretch();

            #endregion

            #region Image_TopMini,快捷物品

            for (int i = 0; i < 6; i++)
            {
                var Button_FastItem = VLCreator.CreateButton("Button_FastItem");
                Button_FastItem.SetParent(Image_TopMini);
                rectTransform = Button_FastItem.GetComponent<RectTransform>();
                rectTransform.SetLeftDown(25 + i * 96, 20, 60, 60);
                Button_FastItem.SetColor(MockHelper.MockColor2(), 1f);
            }

            #endregion

            #region Image_LeftMini

            //状态,装备区
            //头           项链
            //胸           披风
            //护臂         护手
            //护腿         鞋子
            //左手持       右手持
            //戒指         戒指

            string[] equipmentsLeft = new string[] { "Helmet", "Armor", "ArmGuard", "LegArmor", "LeftHand", "LeftRing" };
            for (int i = 0; i < 6; i++)
            {
                var Button_Equipment = VLCreator.CreateButton("Button_Equipment_" + equipmentsLeft[i]);
                Button_Equipment.SetParent(Image_LeftMini);
                rectTransform = Button_Equipment.GetComponent<RectTransform>();
                rectTransform.SetLeftDown(20, 20 + i * 96, 60, 60);
                Button_Equipment.SetColor(MockHelper.MockColor2(), 1f);
            }

            #endregion

            #region Image_RightMini

            //状态,装备区
            //头           项链
            //胸           披风
            //护臂         护手
            //护腿         鞋子
            //左手持       右手持
            //戒指         戒指

            string[] equipmentsRight = new string[] { "Necklace", "Cloak", "Glove", "Boots", "RightHand", "RightRing" };
            for (int i = 0; i < 6; i++)
            {
                var Button_Equipment = VLCreator.CreateButton("Button_Equipment_" + equipmentsRight[i]);
                Button_Equipment.SetParent(Image_RightMini);
                rectTransform = Button_Equipment.GetComponent<RectTransform>();
                rectTransform.SetLeftDown(20, 20 + i * 96, 60, 60);
                Button_Equipment.SetColor(MockHelper.MockColor2(), 1f);
            }

            #endregion

            #region Image_BottomMini,快捷技能

            for (int i = 0; i < 6; i++)
            {
                var Button_FastSkill = VLCreator.CreateButton("Button_FastSkill");
                Button_FastSkill.SetParent(Image_BottomMini);
                rectTransform = Button_FastSkill.GetComponent<RectTransform>();
                rectTransform.SetLeftDown(25 + i * 96, 20, 60, 60);
                Button_FastSkill.SetColor(MockHelper.MockColor2(), 1f);
            }

            #endregion





            //#region init startGO
            //GameObject startGO;
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
            ////添加游戏对象收纳
            //startGO = new GameObject("startGO");
            ////添加摄像机
            //startCameraGO = VLCreator.CreateCamera("startCameraGO", startGO);
            //camera2D = startCameraGO.GetComponent<Camera>();
            //camera2D.orthographic = true;
            ////添加画布
            //startCanvasGO = VLCreator.CreateCanvas("start_BackgroundCanvas", startGO);
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
            //var gameObject = VLCreator.CreateButton("start", startCanvasGO);
            //gameObject.ToStartMenuButtonStyle();
            //text = gameObject.GetComponentInChildren<Text>();
            //text.text = "开始游戏";
            //rectTransform = gameObject.GetComponent<RectTransform>();
            //rectTransform.localPosition = new Vector3(0f, 200f, 0f);
            ////Load
            //gameObject = VLCreator.CreateButton("load", startCanvasGO);
            //gameObject.ToStartMenuButtonStyle();
            //text = gameObject.GetComponentInChildren<Text>();
            //text.text = "加载游戏";
            //rectTransform = gameObject.GetComponent<RectTransform>();
            //rectTransform.localPosition = new Vector3(0f, 100f, 0f);
            ////Config
            //gameObject = VLCreator.CreateButton("config", startCanvasGO);
            //gameObject.ToStartMenuButtonStyle();
            //text = gameObject.GetComponentInChildren<Text>();
            //text.text = "游戏设置";
            //rectTransform = gameObject.GetComponent<RectTransform>();
            //rectTransform.localPosition = new Vector3(0f, 0f, 0f);
            ////Quit
            //gameObject = VLCreator.CreateButton("end", startCanvasGO);
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

            ////添加Player from Prefab
            //GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Scripts/0316/Player.prefab"); 
            //GameObject playerGO = Instantiate(prefab, gamingGO.transform);
            //gaming0316.playerGO = playerGO;
            //gaming0316.canvasGO = gamingCanvasGO;

            Debug.Log($"Instantiate End");
        }

    }
}
