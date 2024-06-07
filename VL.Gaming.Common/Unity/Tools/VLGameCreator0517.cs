using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using VL.Gaming.Common;
using VL.Gaming.Unity.Common.Enums;
using VL.Gaming.Unity.Gaming.Content.Entities;
using VL.Gaming.Unity.Gaming.GameSystem;
using VL.Gaming.Unity.Gaming.Ultis;
using VL.Gaming.Unity.Ultis;

namespace VL.Gaming.Unity.Tools
{
    internal class VLGameCreator0517
    {
        #region Utils
        private static void CreateDirectory(string fileName)
        {
            string fullPath = Path.Combine(Application.dataPath, fileName);
            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
                Debug.Log("文件夹已创建： " + fullPath);
            }
            else
            {
                Debug.Log("文件夹已存在： " + fullPath);
            }
        }

        private static GameObject CheckExist(string name, bool deleteOnExit = true)
        {
            var check = ResourceHelper.FindGameObjectByName(name);
            if (check != null && deleteOnExit)
                Undo.DestroyObjectImmediate(check);
            return check;
        }
        #endregion

        [MenuItem("Tools/InitSceneGaming/InitNewProject")]
        static void InitNewProject()
        {
            CreateDirectory("Resources");
            CreateDirectory("Resources/Animations");
            CreateDirectory("Resources/Dialogues");
            CreateDirectory("Resources/Prefabs");
            CreateDirectory("Resources/Sprites");
            CreateDirectory("Sprites");
            Debug.Log($"Instantiate End");
        }

        [MenuItem("Tools/InitSceneGaming/InitGameBoard")]
        static void InitGameBoard()
        {
            //检查已存在
            CheckExist("PreBattle");
            CheckExist("InBattle");

            //依赖前置
            var sprite = VLResource.Sprite_Rectangle;
            sprite = VLResource.Sprite_Player;
            sprite = VLResource.Sprite_Enermy;
            sprite = VLResource.Sprite_VS;
            sprite = VLResource.Sprite_Rectangle;
            sprite = VLResource.Sprite_Circle;
            var gameObject = VLResource.Prefab_Chess;
            gameObject = VLResource.Prefab_ChessPlaceHolder;

            //PreBattle
            var PreBattle = new GameObject("PreBattle");
            PreBattle.SetActive(false);
            //背景 云顶,天空,悬浮,流云效果
            var Sprite_Background = VLCreator.CreateSprite("Sprite_Background");
            Sprite_Background.SetParent(PreBattle);
            Sprite_Background.SetPosition(0, 0, 0);
            Sprite_Background.SetScale(34.2f, 19.2f, 1);
            var SpriteRenderer = Sprite_Background.GetComponent<SpriteRenderer>();
            SpriteRenderer.sprite = VLResource.Sprite_Rectangle;
            SpriteRenderer.sortingOrder = SortingOrderEnum.Floor.ToInt();
            //Player
            var Sprite_Player = VLCreator.CreateSprite("Sprite_Player");
            Sprite_Player.SetParent(PreBattle);
            Sprite_Player.SetPosition(-5, 0, 0);
            SpriteRenderer = Sprite_Player.GetComponent<SpriteRenderer>();
            SpriteRenderer.sprite = VLResource.Sprite_Player;
            SpriteRenderer.sortingOrder = SortingOrderEnum.Unit.ToInt();
            //Enermy
            var Sprite_Enermy = VLCreator.CreateSprite("Sprite_Enermy");
            Sprite_Enermy.SetParent(PreBattle);
            Sprite_Enermy.SetPosition(5, 0, 0);
            SpriteRenderer = Sprite_Enermy.GetComponent<SpriteRenderer>();
            SpriteRenderer.sprite = VLResource.Sprite_Enermy;
            SpriteRenderer.sortingOrder = SortingOrderEnum.Unit.ToInt();
            //VS
            var Sprite_VS = VLCreator.CreateSprite("Sprite_VS");
            Sprite_VS.SetParent(PreBattle);
            Sprite_VS.SetPosition(0, 0, 0);
            SpriteRenderer = Sprite_VS.GetComponent<SpriteRenderer>();
            SpriteRenderer.sprite = VLResource.Sprite_VS;
            SpriteRenderer.sortingOrder = SortingOrderEnum.Unit.ToInt();

            //InBattle
            var InBattle = new GameObject("InBattle");
            InBattle.SetActive(true);
            //Canvas
            var Canvas_Main = VLCreator.CreateCanvas("Canvas_Main");
            Canvas_Main.SetParent(InBattle);
            //背景 云顶,天空,悬浮,流云效果
            Sprite_Background = VLCreator.CreateSprite("Sprite_Background");
            Sprite_Background.SetParent(InBattle);
            Sprite_Background.SetPosition(0, 0, 0);
            Sprite_Background.SetScale(34.2f, 19.2f, 1);
            SpriteRenderer = Sprite_Background.GetComponent<SpriteRenderer>();
            SpriteRenderer.sprite = VLResource.Sprite_Rectangle;
            SpriteRenderer.sortingOrder = SortingOrderEnum.Floor.ToInt();
            //棋盘
            var Sprite_Board = VLCreator.CreateSprite("Sprite_Board");
            Sprite_Board.SetParent(InBattle);
            Sprite_Board.SetPosition(0, 0, 0);
            Sprite_Board.SetScale(20f, 10f, 1);
            SpriteRenderer = Sprite_Board.GetComponent<SpriteRenderer>();
            SpriteRenderer.sprite = VLResource.Sprite_Circle;
            SpriteRenderer.sortingOrder = SortingOrderEnum.Floor.ToInt();
            SpriteRenderer.color = Color.green;
            //计时器,漏斗
            var Sprite_HourGlass = VLCreator.CreateSprite("Sprite_HourGlass");
            Sprite_HourGlass.SetParent(InBattle);
            //SpriteRenderer = Sprite_HourGlass.GetComponent<SpriteRenderer>();
            //SpriteRenderer.sprite = VLResource.Sprite_HourGlass;
            //SpriteRenderer.sortingOrder = SortingOrderEnum.Item.ToInt();
            var Canvas = VLCreator.CreateCanvas("Canvas");
            Canvas.SetParent(Sprite_HourGlass);
            Canvas.SetPosition(0, 0, 0);
            var canvas = Canvas.GetComponent<Canvas>();
            canvas.renderMode = RenderMode.WorldSpace;
            canvas.sortingOrder = VLSortingOrder.Foreground.ToInt();
            var Text = VLCreator.CreateText("Text");
            Text.SetParent(Canvas);
            Text.SetRectSizeDelta(90, 50);
            Text.SetScale(0.02f, 0.02f, 1);
            Text.SetPosition(0.08f, 0, 0);
            var text = Text.GetComponent<Text>();
            text.fontSize = 36;
            text.text = "00:00";
            text.color = Color.black;
            Sprite_HourGlass.SetPosition(-9, 0, 0);
            //当前回合说明
            var Sprite_CurrentTurn = VLCreator.CreateSprite("Sprite_CurrentTurn");
            Sprite_CurrentTurn.SetParent(InBattle);
            //SpriteRenderer = Sprite_CurrentTurn.GetComponent<SpriteRenderer>();
            //SpriteRenderer.sprite = VLResource.Sprite_PlayerTurn;
            //SpriteRenderer.sortingOrder = SortingOrderEnum.Item.ToInt();
            Canvas = VLCreator.CreateCanvas("Canvas");
            Canvas.SetParent(Sprite_CurrentTurn);
            Canvas.SetPosition(0, 0, 0);
            canvas = Canvas.GetComponent<Canvas>();
            canvas.renderMode = RenderMode.WorldSpace;
            canvas.sortingOrder = VLSortingOrder.Foreground.ToInt();
            Text = VLCreator.CreateText("Text");
            Text.SetParent(Canvas);
            Text.SetRectSizeDelta(120, 50);
            Text.SetScale(0.02f, 0.02f, 1);
            Text.SetPosition(0, 0, 0);
            text = Text.GetComponent<Text>();
            text.fontSize = 30;
            text.text = "我方回合";
            text.color = Color.black;
            Sprite_CurrentTurn.SetPosition(-8.88f, 0.64f, 0);

            //行列
            float[] columns = new float[] { -7, -3.5f, 0, 3.5f, 7 };
            float[] rows = new float[] { 3.3f, 1.3f, -1f, -3f };
            //Player
            var player = GameObject.Instantiate(VLResource.Prefab_Chess);
            player.SetParent(InBattle);
            player.transform.position = new Vector3(columns[2], rows[3], 0);
            player.layer = VLLayerMask.PlayerUnit.ToInt();
            player.AddComponent<BoxCollider2D>();
            player.AddComponent<Animator>();
            //Enermy
            var enermy = GameObject.Instantiate(VLResource.Prefab_Chess);
            enermy.SetParent(InBattle);
            enermy.transform.position = new Vector3(columns[2], rows[0], 0);
            enermy.layer = VLLayerMask.EnermyUnit.ToInt();
            enermy.AddComponent<BoxCollider2D>();
            enermy.AddComponent<Animator>();
            //棋子位置(星空战旗)
            for (int r = 0; r < rows.Length; r++)
            {
                for (int c = 0; c < columns.Length; c++)
                {
                    var chess = GameObject.Instantiate(VLResource.Prefab_ChessPlaceHolder);
                    chess.SetParent(InBattle);
                    chess.transform.position = new Vector3(columns[c], rows[r], 0);
                    chess.layer = r >= 2 ? VLLayerMask.PlayerUnit.ToInt() : VLLayerMask.EnermyUnit.ToInt();
                    chess.AddComponent<BoxCollider2D>();
                    chess.AddComponent<Animator>();
                }
            }
            //生成Player+Enermy
            //开场动画 左右 街霸气势对抗,叫嚣
            //Player+Enermy归位

            //初始化棋子
            //注入灵魂

            //玩家回合开始

            //选择英雄技能
            //选择目标

            //敌人
        }

        [MenuItem("Tools/InitSceneGaming/InitPlayerBox")]
        static void InitPlayerBox()
        {
            PlayerData playerData = new PlayerData();
            playerData.Name = "PlayerVL";
            playerData.UnitAttributes = new UnitAttributes()
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
            playerData.Items = new List<ItemData>()
            {
                new ItemData(){ Name="木剑",Count=1,Description="一柄木制的剑",ImageResource=""},
                new ItemData(){ Name="布衣",Count=1,Description="布制衣物"},
                new ItemData(){ Name="小瓶治疗药剂",Count=3,Description="闪耀着红色光芒的药剂,"},
                new ItemData(){ Name="小石头",Count=3,Description="锐利的石头,投掷可以造成一些伤害"},
                new ItemData(){ Name="草",Count=3,Description="随处可见的杂草"},
                new ItemData(){ Name="铁矿石",Count=7,Description="铁矿原石,闪耀着黑色"},
                new ItemData(){ Name="铜矿石",Count=8,Description="铜矿原石,闪耀着棕黄色"},
            };
            List<ItemData> items = new List<ItemData>();
            for (int i = 0; i < 8; i++)
            {
                playerData.Items.ForEach(c => items.Add(new ItemData() { Name = c.Name }));
            }
            playerData.Items = items;

            //检查已存在
            CheckExist("Prefab_Canvas_Gaming_PlayerBox");

            //依赖前置

            //添加 canvas
            var Prefab_Canvas_Gaming_PlayerBox = VLCreator.CreateCanvas("Prefab_Canvas_Gaming_PlayerBox");
            //添加 Image_Mask
            var backgroundGO = VLCreator.CreateImage("Image_Mask");
            backgroundGO.SetParent(Prefab_Canvas_Gaming_PlayerBox);
            backgroundGO.SetColor(Color.grey, 0.5f);
            var rectTransform = backgroundGO.GetComponent<Image>().GetComponent<RectTransform>();
            rectTransform.SetRectStretch();
            //添加 Panel_Team
            var Panel_Team = VLCreator.CreatePanel("Panel_Team");
            Panel_Team.SetParent(Prefab_Canvas_Gaming_PlayerBox);
            Panel_Team.SetColor(VLGenerater.MockColorForBackground(), 1f);
            rectTransform = Panel_Team.GetComponent<Image>().GetComponent<RectTransform>();
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1200);
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 100);
            rectTransform.anchoredPosition = new Vector2(0, 400);
            //添加 Panel_Unit
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
            Image_Left.SetColor(VLGenerater.MockColorForBackground(), 1f);
            rectTransform = Image_Left.GetComponent<Image>().GetComponent<RectTransform>();
            rectTransform.SetRectLeftDown(0, 0, 500, 800);
            //添加 Image_BottomMini
            var Image_BottomMini = VLCreator.CreateImage("Image_BottomMini");
            Image_BottomMini.SetParent(Panel_Unit);
            Image_BottomMini.SetColor(VLGenerater.MockColorForBackground(), 1f);
            rectTransform = Image_BottomMini.GetComponent<Image>().GetComponent<RectTransform>();
            rectTransform.SetRectLeftDown(500, 0, 600, 100);
            //添加 Image_LeftMini
            var Image_LeftMini = VLCreator.CreateImage("Image_LeftMini");
            Image_LeftMini.SetParent(Panel_Unit);
            Image_LeftMini.SetColor(VLGenerater.MockColorForBackground(), 1f);
            rectTransform = Image_LeftMini.GetComponent<Image>().GetComponent<RectTransform>();
            rectTransform.SetRectLeftDown(500, 100, 100, 600);
            //添加 Image_TopMini
            var Image_TopMini = VLCreator.CreateImage("Image_TopMini");
            Image_TopMini.SetParent(Panel_Unit);
            Image_TopMini.SetColor(VLGenerater.MockColorForBackground(), 1f);
            rectTransform = Image_TopMini.GetComponent<Image>().GetComponent<RectTransform>();
            rectTransform.SetRectLeftDown(500, 700, 600, 100);
            //添加 Image_Portrait
            var Image_Portrait = VLCreator.CreateImage("Image_Portrait");
            Image_Portrait.SetParent(Panel_Unit);
            Image_Portrait.SetColor(VLGenerater.MockColorForBackground(), 1f);
            rectTransform = Image_Portrait.GetComponent<Image>().GetComponent<RectTransform>();
            rectTransform.SetRectLeftDown(600, 100, 400, 600);
            //添加 Image_RightMini
            var Image_RightMini = VLCreator.CreateImage("Image_RightMini");
            Image_RightMini.SetParent(Panel_Unit);
            Image_RightMini.SetColor(VLGenerater.MockColorForBackground(), 1f);
            rectTransform = Image_RightMini.GetComponent<Image>().GetComponent<RectTransform>();
            rectTransform.SetRectLeftDown(1000, 100, 100, 600);
            //添加 Image_Right
            var Image_Right = VLCreator.CreateImage("Image_Right");
            Image_Right.SetParent(Panel_Unit);
            Image_Right.SetColor(VLGenerater.MockColorForBackground(), 1f);
            rectTransform = Image_Right.GetComponent<Image>().GetComponent<RectTransform>();
            rectTransform.SetRectLeftDown(1100, 0, 500, 800);

            Text text;

            #region Image_Left,属性栏

            var Image_PlayerName = VLCreator.CreateText("Image_PlayerName");
            Image_PlayerName.SetParent(Image_Left);
            rectTransform = Image_PlayerName.GetComponent<RectTransform>();
            rectTransform.SetRectLeftDown(200, 650, 100, 200);
            text = Image_PlayerName.GetComponent<Text>();
            text.text = playerData.Name;
            text.fontSize = 32;
            text.alignment = TextAnchor.MiddleCenter;
            text.color = Color.black;
            //小图标, 名称, 现值,附加值
            string[] attributes = new string[] { "力量", "敏捷", "体质", "智力", "意志", "魅力", "领导力", "幸运" };
            string[] values = new string[] { $"{playerData.UnitAttributes.Strength}", $"{playerData.UnitAttributes.Agility}", $"{playerData.UnitAttributes.Constitution}", $"{playerData.UnitAttributes.Intelligence}", $"{playerData.UnitAttributes.Willpower}", $"{playerData.UnitAttributes.Charisma}", $"{playerData.UnitAttributes.Leadership}", $"{playerData.UnitAttributes.Luck}" };
            for (int i = 0; i < 8; i++)
            {
                var Image_AttributeIcon = VLCreator.CreateImage("Image_AttributeIcon");
                Image_AttributeIcon.SetParent(Image_Left);
                rectTransform = Image_AttributeIcon.GetComponent<RectTransform>();
                rectTransform.SetRectLeftDown(60, 650 - i * 80, 60, 60);
                Image_AttributeIcon.SetColor(VLGenerater.MockColorForItem(), 1f);

                var Image_AttributeDiscribe = VLCreator.CreateText("Image_AttributeDiscribe");
                Image_AttributeDiscribe.SetParent(Image_Left);
                rectTransform = Image_AttributeDiscribe.GetComponent<RectTransform>();
                rectTransform.SetRectLeftDown(140, 630 - i * 80, 100, 100);
                text = Image_AttributeDiscribe.GetComponent<Text>();
                text.text = attributes[i];
                text.fontSize = 32;
                text.alignment = TextAnchor.MiddleCenter;
                text.color = Color.black;

                var Image_AttributeValue = VLCreator.CreateText("Image_AttributeValue");
                Image_AttributeValue.SetParent(Image_Left);
                rectTransform = Image_AttributeValue.GetComponent<RectTransform>();
                rectTransform.SetRectLeftDown(240, 630 - i * 80, 100, 100);
                text = Image_AttributeValue.GetComponent<Text>();
                text.text = values[i];
                text.fontSize = 32;
                text.alignment = TextAnchor.MiddleCenter;
                text.color = Color.black;

                var Button_AttributeMinus = VLCreator.CreateButton("Button_AttributeMinus");
                Button_AttributeMinus.SetParent(Image_Left);
                rectTransform = Button_AttributeMinus.GetComponent<RectTransform>();
                rectTransform.SetRectLeftDown(360, 665 - i * 80, 30, 30);
                Button_AttributeMinus.SetColor(VLGenerater.MockColorForItem(), 1f);

                var Button_AttributePlus = VLCreator.CreateButton("Button_AttributePlus");
                Button_AttributePlus.SetParent(Image_Left);
                rectTransform = Button_AttributePlus.GetComponent<RectTransform>();
                rectTransform.SetRectLeftDown(400, 665 - i * 80, 30, 30);
                Button_AttributePlus.SetColor(VLGenerater.MockColorForItem(), 1f);
            }

            var Button_AttributeConfirm = VLCreator.CreateButton("Button_AttributeConfirm");
            Button_AttributeConfirm.SetParent(Image_Left);
            rectTransform = Button_AttributeConfirm.GetComponent<RectTransform>();
            rectTransform.SetRectLeftDown(355, 30, 80, 40);
            Button_AttributeConfirm.SetColor(VLGenerater.MockColorForItem(), 1f);

            #endregion

            #region Image_Right,物品栏

            //上分类: 全部,武器,衣服,药水,其他
            for (int i = 0; i < 5; i++)
            {
                var Button_ItemCategory = VLCreator.CreateButton("Button_ItemCategory");
                Button_ItemCategory.SetParent(Image_Right);
                rectTransform = Button_ItemCategory.GetComponent<RectTransform>();
                rectTransform.SetRectLeftTop(0 + i * 100, 0, 100, 100);
                Button_ItemCategory.SetColor(VLGenerater.MockColorForItem(), 1f);
            }
            //滚动栏
            GameObject ScrollView_Items = VLCreator.CreateScrollView("ScrollView_Items");
            ScrollView_Items.SetParent(Image_Right);
            rectTransform = ScrollView_Items.GetComponent<RectTransform>();
            rectTransform.SetRectLeftDown(0, 0, 500, 700);
            var ScrollViewContent = ScrollView_Items.ScrollViewGetContent();
            ScrollViewContent.SetRectSizeDelta(new Vector2(500, 700));
            //物品
            int itemPerLine = 5;
            for (int i = 0; i < playerData.Items.Count; i++)
            {
                int row = Mathf.FloorToInt(i / 5f);
                var Button_Item = VLCreator.CreateButton("Button_Item");
                Button_Item.SetParent(ScrollViewContent);
                rectTransform = Button_Item.GetComponent<RectTransform>();
                rectTransform.SetRectLeftTop(20 + i % itemPerLine * 90, -(20 + row * 90), 80, 80);
                Button_Item.SetColor(VLGenerater.MockColorForItem(), 1f);
            }
            //物品栏滚动支持
            int rowCount = Mathf.FloorToInt(playerData.Items.Count / 5f);
            ScrollViewContent.SetRectSizeDelta(new Vector2(480, 20 * 2 + rowCount * 90));

            #endregion

            #region Image_TopMini,快捷物品

            //快捷物品
            for (int i = 0; i < 6; i++)
            {
                var Button_FastItem = VLCreator.CreateButton("Button_FastItem");
                Button_FastItem.SetParent(Image_TopMini);
                rectTransform = Button_FastItem.GetComponent<RectTransform>();
                rectTransform.SetRectLeftDown(25 + i * 96, 20, 60, 60);
                Button_FastItem.SetColor(VLGenerater.MockColorForItem(), 1f);
            }

            #endregion

            #region Image_LeftMini,装备栏

            //状态,装备区
            //头           项链
            //胸           披风
            //护臂         护手
            //护腿         鞋子
            //左手持       右手持
            //戒指         戒指

            //状态,装备区
            string[] equipmentsLeft = new string[] { "Helmet", "Armor", "ArmGuard", "LegArmor", "LeftHand", "LeftRing" };
            for (int i = 0; i < 6; i++)
            {
                var Button_Equipment = VLCreator.CreateButton("Button_Equipment_" + equipmentsLeft[i]);
                Button_Equipment.SetParent(Image_LeftMini);
                rectTransform = Button_Equipment.GetComponent<RectTransform>();
                rectTransform.SetRectLeftDown(20, 20 + i * 96, 60, 60);
                Button_Equipment.SetColor(VLGenerater.MockColorForItem(), 1f);
            }

            #endregion

            #region Image_RightMini,装备栏

            //状态,装备区
            //头           项链
            //胸           披风
            //护臂         护手
            //护腿         鞋子
            //左手持       右手持
            //戒指         戒指

            //状态,装备区
            string[] equipmentsRight = new string[] { "Necklace", "Cloak", "Glove", "Boots", "RightHand", "RightRing" };
            for (int i = 0; i < 6; i++)
            {
                var Button_Equipment = VLCreator.CreateButton("Button_Equipment_" + equipmentsRight[i]);
                Button_Equipment.SetParent(Image_RightMini);
                rectTransform = Button_Equipment.GetComponent<RectTransform>();
                rectTransform.SetRectLeftDown(20, 20 + i * 96, 60, 60);
                Button_Equipment.SetColor(VLGenerater.MockColorForItem(), 1f);
            }

            #endregion

            #region Image_BottomMini,快捷技能

            //快捷技能
            for (int i = 0; i < 6; i++)
            {
                var Button_FastSkill = VLCreator.CreateButton("Button_FastSkill");
                Button_FastSkill.SetParent(Image_BottomMini);
                rectTransform = Button_FastSkill.GetComponent<RectTransform>();
                rectTransform.SetRectLeftDown(25 + i * 96, 20, 60, 60);
                Button_FastSkill.SetColor(VLGenerater.MockColorForItem(), 1f);
            }

            #endregion

            #region Panel_Team,队伍栏

            //队伍栏
            for (int i = 0; i < 6; i++)
            {
                var Button_Teammate = VLCreator.CreateButton("Button_Teammate");
                Button_Teammate.SetParent(Panel_Team);
                rectTransform = Button_Teammate.GetComponent<RectTransform>();
                rectTransform.SetRectLeftDown(10 + i * 90, 10, 80, 80);
                Button_Teammate.SetColor(VLGenerater.MockColorForItem(), 1f);
            }

            #endregion

            Debug.Log($"Instantiate End");
        }

        [MenuItem("Tools/InitSceneGaming/InitStartMenu")]
        static void InitStartMenu()
        {
            //检查已存在
            CheckExist("GameSystemManager");
            CheckExist("Canvas_StartMenu");
            CheckExist("EventSystem");

            //依赖前置
            var EventSystem = VLCreator.CreateEventSystem("EventSystem");
            var Prefab_Button_StartMenu_Normal = VLResource.Prefab_Button_StartMenu_Normal;
            var Prefab_Canvas_StartMenu_Declaration = VLResource.Prefab_Canvas_StartMenu_Declaration;

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

        [MenuItem("Tools/InitSceneGaming/InitGameInit")]
        static void InitGameInit()
        {
            //检查已存在
            CheckExist("GameInitManager");
            CheckExist("Canvas");
            CheckExist("EventSystem");

            //依赖前置
            var EventSystem = VLCreator.CreateEventSystem("EventSystem");
            var Prefab_Toggle_GameInit_MainCategory = VLResource.Prefab_Toggle_GameInit_MainCategory;
            var Prefab_Toggle_GameInit_SubCategory = VLResource.Prefab_Toggle_GameInit_SubCategory;
            var Prefab_Button_GameInit_Normal = VLResource.Prefab_Button_GameInit_Normal;
            var Prefab_InputField_GameInit_Normal = VLResource.Prefab_InputField_GameInit_Normal;
            var Races = new List<RaceData> {
                new RaceData("人族"),
                new RaceData("精灵"),
                new RaceData("兽人"),
                new RaceData("矮人"),
            };
            var Professions = new List<ProfessionData> {
                new ProfessionData("战士"),
                new ProfessionData("猎人"),
                new ProfessionData("法师"),
                new ProfessionData("牧师"),
            };
            var UnitAttributes = new UnitAttributes()
            {
                Agility = 5,
                Charisma = 5,
                Constitution = 5,
                Intelligence = 5,
                Leadership = 5,
                Luck = 5,
                Strength = 5,
                Willpower = 5,
            };

            //GameInitManager
            GameObject gameInitManager = new GameObject("GameInitManager");
            gameInitManager.AddComponent<GameInitManager>();
            //Canvas
            var Canvas = VLCreator.CreateCanvas("Canvas");

            #region Panel_Settings

            //Panel_Settings
            var Panel_Settings = VLCreator.CreatePanel("Panel_Settings");
            Panel_Settings.SetParent(Canvas);
            Panel_Settings.SetRectStretch();
            Panel_Settings.SetColor(VLGenerater.MockColorForBackground());

            //Image_Portrait
            var Image_Portrait = VLCreator.CreateImage("Image_Portrait");
            Image_Portrait.SetParent(Panel_Settings);
            Image_Portrait.SetRectRightTop(-40, -40, 1000, 1000);
            Image_Portrait.SetColor(VLGenerater.MockColorForItem());

            #region Panel_MainCategory

            //Panel_MainCategory
            var Panel_MainCategory = VLCreator.CreatePanel("Panel_MainCategory");
            Panel_MainCategory.SetParent(Panel_Settings);
            Panel_MainCategory.SetRectLeftTop(0, 0, 200, 1080);
            Panel_MainCategory.SetColor(VLGenerater.MockColorForBackground());
            //ToggleGroup
            var ToggleGroup = VLCreator.CreateToggleGroup("ToggleGroup");
            ToggleGroup.SetParent(Panel_MainCategory);
            var toggleGroup = ToggleGroup.GetComponent<ToggleGroup>();
            //Prefab_Toggle_MainCategory_Race
            GameObject Prefab_Toggle_MainCategory_Race = GameObject.Instantiate(Prefab_Toggle_GameInit_MainCategory);
            Prefab_Toggle_MainCategory_Race.name = "Toggle_Race";
            Prefab_Toggle_MainCategory_Race.SetParent(Panel_MainCategory);
            Prefab_Toggle_MainCategory_Race.SetRectLeftTop(0, 0, 200, 80);
            Prefab_Toggle_MainCategory_Race.SetToggleGroup(toggleGroup);
            Prefab_Toggle_MainCategory_Race.SetTextContent("种族");
            //Prefab_Toggle_MainCategory_Profession
            GameObject Prefab_Toggle_MainCategory_Profession = GameObject.Instantiate(Prefab_Toggle_GameInit_MainCategory);
            Prefab_Toggle_MainCategory_Profession.name = "Toggle_Profession";
            Prefab_Toggle_MainCategory_Profession.SetParent(Panel_MainCategory);
            Prefab_Toggle_MainCategory_Profession.SetRectLeftTop(0, -80, 200, 80);
            Prefab_Toggle_MainCategory_Profession.SetToggleGroup(toggleGroup);
            Prefab_Toggle_MainCategory_Profession.SetTextContent("职业");
            //Prefab_Toggle_MainCategory_Attributes
            GameObject Prefab_Toggle_MainCategory_Attributes = GameObject.Instantiate(Prefab_Toggle_GameInit_MainCategory);
            Prefab_Toggle_MainCategory_Attributes.name = "Toggle_Attributes";
            Prefab_Toggle_MainCategory_Attributes.SetParent(Panel_MainCategory);
            Prefab_Toggle_MainCategory_Attributes.SetRectLeftTop(0, -160, 200, 80);
            Prefab_Toggle_MainCategory_Attributes.SetToggleGroup(toggleGroup);
            Prefab_Toggle_MainCategory_Attributes.SetTextContent("属性");
            //Prefab_Toggle_MainCategory_MapSettings
            GameObject Prefab_Toggle_MainCategory_MapSettings = GameObject.Instantiate(Prefab_Toggle_GameInit_MainCategory);
            Prefab_Toggle_MainCategory_MapSettings.name = "Toggle_MapSettings";
            Prefab_Toggle_MainCategory_MapSettings.SetParent(Panel_MainCategory);
            Prefab_Toggle_MainCategory_MapSettings.SetRectLeftTop(0, -240, 200, 80);
            Prefab_Toggle_MainCategory_MapSettings.SetToggleGroup(toggleGroup);
            Prefab_Toggle_MainCategory_MapSettings.SetTextContent("地图设定");
            #endregion

            #region Panel_SubCategory_Race

            //Panel_SubCategory_Race 种族
            var Panel_SubCategory_Race = VLCreator.CreatePanel("Panel_SubCategory_Race");
            Panel_SubCategory_Race.SetParent(Panel_Settings);
            Panel_SubCategory_Race.SetRectLeftTop(220, -20, 600, 800);
            Panel_SubCategory_Race.SetColor(VLGenerater.MockColorForItem());
            //Panel_SubCategoryType 种族标题区域
            var Panel_SubCategoryType = VLCreator.CreatePanel("Panel_SubCategoryType");
            Panel_SubCategoryType.SetParent(Panel_SubCategory_Race);
            Panel_SubCategoryType.SetRectLeftTop(0, 0, 600, 50);
            var Background = VLCreator.CreateImage("Background");
            Background.SetParent(Panel_SubCategoryType);
            Background.SetRectStretch();
            Background.SetColor(VLGenerater.MockColorForItem());
            var Text = VLCreator.CreateText("Text");
            Text.SetParent(Panel_SubCategoryType);
            Text.SetRectLeftTop(220, -5, 160, 40);
            var text = Text.GetText();
            text.text = "种族";
            text.fontSize = 32;
            text.alignment = TextAnchor.MiddleCenter;
            for (int x = 1; x <= Races.Count; x++)
            {
                var y = (x - 1) / 4 + 1;
                var race = Races[x - 1];

                var prefab_Toggle_GameInit_SubCategory = GameObject.Instantiate(Prefab_Toggle_GameInit_SubCategory);
                prefab_Toggle_GameInit_SubCategory.SetParent(Panel_SubCategory_Race);
                prefab_Toggle_GameInit_SubCategory.SetRectLeftTop((x - 1) * 150, -50 - (y - 1) * 150, 150, 150);
                prefab_Toggle_GameInit_SubCategory.SetTextContent(race.Name);
            }
            //Panel_RaceType_Details
            var Panel_RaceType_Details = VLCreator.CreatePanel("Panel_RaceType_Details");
            Panel_RaceType_Details.SetParent(Panel_SubCategory_Race);
            Panel_RaceType_Details.SetRectLeftTop(0, -350, 600, 450);
            Panel_RaceType_Details.SetColor(VLGenerater.MockColorForItem());
            //Text_RaceType
            var Text_RaceType = VLCreator.CreateText("Text_RaceType");
            Text_RaceType.SetParent(Panel_RaceType_Details);
            Text_RaceType.SetRectLeftTop(220, -30, 160, 40);
            text = Text_RaceType.GetText();
            text.fontSize = 32;
            text.alignment = TextAnchor.MiddleCenter;
            text.text = "子类型";
            //Text_RaceTypeDetails
            var Text_RaceTypeDetails = VLCreator.CreateText("Text_RaceTypeDetails");
            Text_RaceTypeDetails.SetParent(Panel_RaceType_Details);
            Text_RaceTypeDetails.SetRectLeftTop(30, -80, 540, 370);
            text = Text_RaceTypeDetails.GetText();
            text.fontSize = 24;
            text.alignment = TextAnchor.UpperLeft;
            text.text = "子类型介绍";

            #endregion

            #region Panel_SubCategory_Profession

            //Panel_SubCategory_Profession 职业
            var Panel_SubCategory_Profession = VLCreator.CreatePanel("Panel_SubCategory_Profession");
            Panel_SubCategory_Profession.SetParent(Panel_Settings);
            Panel_SubCategory_Profession.SetRectLeftTop(220, -20, 600, 800);
            Panel_SubCategory_Profession.SetColor(VLGenerater.MockColorForItem());
            Panel_SubCategory_Profession.SetActive(false);
            //Panel_SubCategory_ProfessionType 职业标题区域
            var Panel_SubCategory_ProfessionType = VLCreator.CreatePanel("Panel_SubCategory_ProfessionType");
            Panel_SubCategory_ProfessionType.SetParent(Panel_SubCategory_Profession);
            Panel_SubCategory_ProfessionType.SetRectLeftTop(0, 0, 600, 50);
            Background = VLCreator.CreateImage("Background");
            Background.SetParent(Panel_SubCategory_ProfessionType);
            Background.SetRectStretch();
            Background.SetColor(VLGenerater.MockColorForItem());
            Text = VLCreator.CreateText("Text");
            Text.SetParent(Panel_SubCategory_ProfessionType);
            Text.SetRectLeftTop(220, -5, 160, 40);
            text = Text.GetText();
            text.text = "职业";
            text.fontSize = 32;
            text.alignment = TextAnchor.MiddleCenter;
            for (int x = 1; x <= Professions.Count; x++)
            {
                var y = (x - 1) / 4 + 1;
                var profession = Professions[x - 1];

                var prefab_Toggle_GameInit_SubCategory = GameObject.Instantiate(Prefab_Toggle_GameInit_SubCategory);
                prefab_Toggle_GameInit_SubCategory.SetParent(Panel_SubCategory_Profession);
                prefab_Toggle_GameInit_SubCategory.SetRectLeftTop((x - 1) * 150, -50 - (y - 1) * 150, 150, 150);
                prefab_Toggle_GameInit_SubCategory.SetTextContent(profession.Name);
            }
            //Panel_ProfessionType_Details
            var Panel_ProfessionType_Details = VLCreator.CreatePanel("Panel_ProfessionType_Details");
            Panel_ProfessionType_Details.SetParent(Panel_SubCategory_Profession);
            Panel_ProfessionType_Details.SetRectLeftTop(0, -350, 600, 450);
            Panel_ProfessionType_Details.SetColor(VLGenerater.MockColorForItem());
            //Text_ProfessionType
            var Text_ProfessionType = VLCreator.CreateText("Text_ProfessionType");
            Text_ProfessionType.SetParent(Panel_ProfessionType_Details);
            Text_ProfessionType.SetRectLeftTop(220, -30, 160, 40);
            text = Text_ProfessionType.GetText();
            text.fontSize = 32;
            text.alignment = TextAnchor.MiddleCenter;
            text.text = "子类型";
            //Text_ProfessionTypeDetails
            var Text_ProfessionTypeDetails = VLCreator.CreateText("Text_ProfessionTypeDetails");
            Text_ProfessionTypeDetails.SetParent(Panel_ProfessionType_Details);
            Text_ProfessionTypeDetails.SetRectLeftTop(30, -80, 540, 370);
            text = Text_ProfessionTypeDetails.GetText();
            text.fontSize = 24;
            text.alignment = TextAnchor.UpperLeft;
            text.text = "子类型介绍";

            #endregion

            #region Panel_SubCategory_Attributes

            //Panel_SubCategory_Attributes 属性
            var Panel_SubCategory_Attributes = VLCreator.CreatePanel("Panel_SubCategory_Attributes");
            Panel_SubCategory_Attributes.SetParent(Panel_Settings);
            Panel_SubCategory_Attributes.SetRectLeftTop(220, -20, 600, 800);
            Panel_SubCategory_Attributes.SetColor(VLGenerater.MockColorForItem());
            Panel_SubCategory_Attributes.SetActive(false);

            #endregion

            #region Panel_SubCategory_MapSettings

            //Panel_SubCategory_MapSettings 地图配置
            var Panel_SubCategory_MapSettings = VLCreator.CreatePanel("Panel_SubCategory_MapSettings");
            Panel_SubCategory_MapSettings.SetParent(Panel_Settings);
            Panel_SubCategory_MapSettings.SetRectLeftTop(220, -20, 600, 800);
            Panel_SubCategory_MapSettings.SetColor(VLGenerater.MockColorForItem());
            Panel_SubCategory_MapSettings.SetActive(false);

            #endregion

            //Prefab_Button_GameInit_Normal_Continue
            GameObject Button_Continue = GameObject.Instantiate(Prefab_Button_GameInit_Normal);
            Button_Continue.SetParent(Panel_Settings);
            Button_Continue.name = "Button_Continue";
            Button_Continue.SetRectLeftDown(220, 20, 240, 40);
            Button_Continue.SetTextContent("继续");

            #endregion

            #region Panel_Ready

            //Panel_Ready
            var Panel_Ready = VLCreator.CreatePanel("Panel_Ready");
            Panel_Ready.SetParent(Canvas);
            Panel_Ready.SetRectStretch();
            Panel_Ready.SetColor(VLGenerater.MockColorForBackground());
            Panel_Ready.SetActive(false);
            //Image_Portrait
            Image_Portrait = VLCreator.CreateImage("Image_Portrait");
            Image_Portrait.SetParent(Panel_Ready);
            Image_Portrait.SetRectStretch();
            Image_Portrait.SetColor(VLGenerater.MockColorForItem());
            //Text1
            var Text1 = VLCreator.CreateText("Text1");
            Text1.SetParent(Panel_Ready);
            Text1.SetRectCenter(0, 450, 400, 100);
            text = Text1.GetText();
            text.text = "启  程";
            text.fontSize = 73;
            text.alignment = TextAnchor.MiddleCenter;
            //Text2
            var Text2 = VLCreator.CreateText("Text2");
            Text2.SetParent(Panel_Ready);
            Text2.SetRectCenter(0, -390, 400, 100);
            text = Text2.GetText();
            text.text = "请输入角色名称";
            text.fontSize = 32;
            text.alignment = TextAnchor.MiddleCenter;
            //InputField_Name
            var InputField_Name = GameObject.Instantiate(Prefab_InputField_GameInit_Normal);
            InputField_Name.SetParent(Panel_Ready);
            InputField_Name.name = "InputField_Name";
            InputField_Name.SetRectCenter(0, -440, 300, 40);
            InputField_Name.SetTextContent("输入名称");
            //Placeholder
            //Text
            //Prefab_Button_GameInit_Normal_Back
            var Button_Back = GameObject.Instantiate(Prefab_Button_GameInit_Normal);
            Button_Back.SetParent(Panel_Ready);
            Button_Back.name = "Button_Back";
            Button_Back.SetRectCenter(-80, -500, 140, 40);
            Button_Back.SetColor("#ADADAD".ToColor());
            Button_Back.SetTextContent("返回");

            //Prefab_Button_GameInit_Normal_Confirm
            var Button_Confirm = GameObject.Instantiate(Prefab_Button_GameInit_Normal);
            Button_Confirm.SetParent(Panel_Ready);
            Button_Confirm.name = "Button_Confirm";
            Button_Confirm.SetRectCenter(80, -500, 140, 40);
            Button_Confirm.SetColor("#24FF00".ToColor());
            Button_Confirm.SetTextContent("确认");

            #endregion

            //Image_Curtain
            var Image_Curtain = VLCreator.CreateImage("Image_Curtain");
            Image_Curtain.SetParent(Canvas);
            Image_Curtain.SetRectStretch();
            Image_Curtain.SetColor(Color.black);
            Image_Curtain.SetActive(false);

            Debug.Log($"Instantiate End");
        }
    }
}
