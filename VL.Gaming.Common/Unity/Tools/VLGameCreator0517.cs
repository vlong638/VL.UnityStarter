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

namespace VL.Gaming.Unity.Tools
{
    internal class VLGameCreator0517
    {
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

        [MenuItem("Tools/InitSceneGaming/InitGameBoard")]
        static void InitGameBoard()
        {
            //检查已存在
            var check = ResourceHelper.FindGameObjectByName("PreBattle");
            if (check != null)
                Undo.DestroyObjectImmediate(check);
            check = ResourceHelper.FindGameObjectByName("InBattle");
            if (check != null)
                Undo.DestroyObjectImmediate(check);

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
            Text.SetSizeDelta(90, 50);
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
            Text.SetSizeDelta(120, 50);
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
            var check = ResourceHelper.FindGameObjectByName("Prefab_Canvas_Gaming_PlayerBox");
            if (check != null)
                Undo.DestroyObjectImmediate(check);

            //添加 canvas
            GameObject Prefab_Canvas_Gaming_PlayerBox = VLCreator.CreateCanvas("Prefab_Canvas_Gaming_PlayerBox");
            //添加 Image_Mask
            var backgroundGO = VLCreator.CreateImage("Image_Mask");
            backgroundGO.SetParent(Prefab_Canvas_Gaming_PlayerBox);
            backgroundGO.SetColor(Color.grey, 0.5f);
            var rectTransform = backgroundGO.GetComponent<Image>().GetComponent<RectTransform>();
            rectTransform.SetRectStretch();
            //添加 Panel_Team
            var Panel_Team = VLCreator.CreatePanel("Panel_Team");
            Panel_Team.SetParent(Prefab_Canvas_Gaming_PlayerBox);
            Panel_Team.SetColor(MockHelper.MockColorForBackground(), 1f);
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
            Image_Left.SetColor(MockHelper.MockColorForBackground(), 1f);
            rectTransform = Image_Left.GetComponent<Image>().GetComponent<RectTransform>();
            rectTransform.SetRectLeftDown(0, 0, 500, 800);
            //添加 Image_BottomMini
            var Image_BottomMini = VLCreator.CreateImage("Image_BottomMini");
            Image_BottomMini.SetParent(Panel_Unit);
            Image_BottomMini.SetColor(MockHelper.MockColorForBackground(), 1f);
            rectTransform = Image_BottomMini.GetComponent<Image>().GetComponent<RectTransform>();
            rectTransform.SetRectLeftDown(500, 0, 600, 100);
            //添加 Image_LeftMini
            var Image_LeftMini = VLCreator.CreateImage("Image_LeftMini");
            Image_LeftMini.SetParent(Panel_Unit);
            Image_LeftMini.SetColor(MockHelper.MockColorForBackground(), 1f);
            rectTransform = Image_LeftMini.GetComponent<Image>().GetComponent<RectTransform>();
            rectTransform.SetRectLeftDown(500, 100, 100, 600);
            //添加 Image_TopMini
            var Image_TopMini = VLCreator.CreateImage("Image_TopMini");
            Image_TopMini.SetParent(Panel_Unit);
            Image_TopMini.SetColor(MockHelper.MockColorForBackground(), 1f);
            rectTransform = Image_TopMini.GetComponent<Image>().GetComponent<RectTransform>();
            rectTransform.SetRectLeftDown(500, 700, 600, 100);
            //添加 Image_Portrait
            var Image_Portrait = VLCreator.CreateImage("Image_Portrait");
            Image_Portrait.SetParent(Panel_Unit);
            Image_Portrait.SetColor(MockHelper.MockColorForBackground(), 1f);
            rectTransform = Image_Portrait.GetComponent<Image>().GetComponent<RectTransform>();
            rectTransform.SetRectLeftDown(600, 100, 400, 600);
            //添加 Image_RightMini
            var Image_RightMini = VLCreator.CreateImage("Image_RightMini");
            Image_RightMini.SetParent(Panel_Unit);
            Image_RightMini.SetColor(MockHelper.MockColorForBackground(), 1f);
            rectTransform = Image_RightMini.GetComponent<Image>().GetComponent<RectTransform>();
            rectTransform.SetRectLeftDown(1000, 100, 100, 600);
            //添加 Image_Right
            var Image_Right = VLCreator.CreateImage("Image_Right");
            Image_Right.SetParent(Panel_Unit);
            Image_Right.SetColor(MockHelper.MockColorForBackground(), 1f);
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
                Image_AttributeIcon.SetColor(MockHelper.MockColorForItem(), 1f);

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
                Button_AttributeMinus.SetColor(MockHelper.MockColorForItem(), 1f);

                var Button_AttributePlus = VLCreator.CreateButton("Button_AttributePlus");
                Button_AttributePlus.SetParent(Image_Left);
                rectTransform = Button_AttributePlus.GetComponent<RectTransform>();
                rectTransform.SetRectLeftDown(400, 665 - i * 80, 30, 30);
                Button_AttributePlus.SetColor(MockHelper.MockColorForItem(), 1f);
            }

            var Button_AttributeConfirm = VLCreator.CreateButton("Button_AttributeConfirm");
            Button_AttributeConfirm.SetParent(Image_Left);
            rectTransform = Button_AttributeConfirm.GetComponent<RectTransform>();
            rectTransform.SetRectLeftDown(355, 30, 80, 40);
            Button_AttributeConfirm.SetColor(MockHelper.MockColorForItem(), 1f);

            #endregion

            #region Image_Right,物品栏

            //上分类: 全部,武器,衣服,药水,其他
            for (int i = 0; i < 5; i++)
            {
                var Button_ItemCategory = VLCreator.CreateButton("Button_ItemCategory");
                Button_ItemCategory.SetParent(Image_Right);
                rectTransform = Button_ItemCategory.GetComponent<RectTransform>();
                rectTransform.SetRectLeftTop(0 + i * 100, 0, 100, 100);
                Button_ItemCategory.SetColor(MockHelper.MockColorForItem(), 1f);
            }
            //滚动栏
            GameObject ScrollView_Items = VLCreator.CreateScrollView("ScrollView_Items");
            ScrollView_Items.SetParent(Image_Right);
            rectTransform = ScrollView_Items.GetComponent<RectTransform>();
            rectTransform.SetRectLeftDown(0, 0, 500, 700);
            var ScrollViewContent = ScrollView_Items.ScrollViewGetContent();
            ScrollViewContent.SetSizeDelta(new Vector2(500, 700));
            //物品
            int itemPerLine = 5;
            for (int i = 0; i < playerData.Items.Count; i++)
            {
                int row = Mathf.FloorToInt(i / 5f);
                var Button_Item = VLCreator.CreateButton("Button_Item");
                Button_Item.SetParent(ScrollViewContent);
                rectTransform = Button_Item.GetComponent<RectTransform>();
                rectTransform.SetRectLeftTop(20 + i % itemPerLine * 90, -(20 + row * 90), 80, 80);
                Button_Item.SetColor(MockHelper.MockColorForItem(), 1f);
            }
            //物品栏滚动支持
            int rowCount = Mathf.FloorToInt(playerData.Items.Count / 5f);
            ScrollViewContent.SetSizeDelta(new Vector2(480, 20 * 2 + rowCount * 90));

            #endregion

            #region Image_TopMini,快捷物品

            //快捷物品
            for (int i = 0; i < 6; i++)
            {
                var Button_FastItem = VLCreator.CreateButton("Button_FastItem");
                Button_FastItem.SetParent(Image_TopMini);
                rectTransform = Button_FastItem.GetComponent<RectTransform>();
                rectTransform.SetRectLeftDown(25 + i * 96, 20, 60, 60);
                Button_FastItem.SetColor(MockHelper.MockColorForItem(), 1f);
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
                Button_Equipment.SetColor(MockHelper.MockColorForItem(), 1f);
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
                Button_Equipment.SetColor(MockHelper.MockColorForItem(), 1f);
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
                Button_FastSkill.SetColor(MockHelper.MockColorForItem(), 1f);
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
                Button_Teammate.SetColor(MockHelper.MockColorForItem(), 1f);
            }

            #endregion

            Debug.Log($"Instantiate End");
        }

        [MenuItem("Tools/InitSceneGaming/InitStartMenu")]
        static void InitStartMenu()
        {
            //检查已存在
            var check = ResourceHelper.FindGameObjectByName("GameSystemManager");
            if (check != null)
                Undo.DestroyObjectImmediate(check);
            check = ResourceHelper.FindGameObjectByName("Canvas_StartMenu");
            if (check != null)
                Undo.DestroyObjectImmediate(check);


            //需求资源
            var Prefab_Button_StartMenu_Normal = VLResource.Prefab_Button_StartMenu_Normal;
            var Prefab_Canvas_StartMenu_Declaration = VLResource.Prefab_Canvas_StartMenu_Declaration;

            //GameSystemManager
            GameObject gameSystemManager = new GameObject("GameSystemManager");
            gameSystemManager.AddComponent<GameSystemManager>();
            //Canvas_StartMenu
            var Canvas_StartMenu = VLCreator.CreateCanvas("Canvas_StartMenu");
            //Panel
            var Panel = VLCreator.CreatePanel("Panel");
            Panel.SetParent(Canvas_StartMenu);
            Panel.SetRectStretch();
            Panel.SetImageColor(MockHelper.MockColorForBackground());
            //Image_Title
            var Image_Title = VLCreator.CreateImage("Image_Title");
            Image_Title.SetParent(Panel);
            Image_Title.SetRectLeftTop(100, -50, 200, 400);
            Image_Title.SetImageColor(MockHelper.MockColorForItem());

            //Prefab_Button_StartMenu
            GameObject Prefab_Button_StartMenu = GameObject.Instantiate(Prefab_Button_StartMenu_Normal);
            Prefab_Button_StartMenu.SetParent(Panel);
            Prefab_Button_StartMenu.transform.Find("Text").GetComponent<Text>().text = "开始";
            Prefab_Button_StartMenu.SetRectLeftTop(100, -600, 200, 40);
            //Prefab_Button_LoadData
            GameObject Prefab_Button_LoadData = GameObject.Instantiate(Prefab_Button_StartMenu_Normal);
            Prefab_Button_LoadData.SetParent(Panel);
            Prefab_Button_LoadData.transform.Find("Text").GetComponent<Text>().text = "继续";
            Prefab_Button_LoadData.SetRectLeftTop(100, -680, 200, 40);
            //Prefab_Button_Setting
            GameObject Prefab_Button_Setting = GameObject.Instantiate(Prefab_Button_StartMenu_Normal);
            Prefab_Button_Setting.SetParent(Panel);
            Prefab_Button_Setting.transform.Find("Text").GetComponent<Text>().text = "设置";
            Prefab_Button_Setting.SetRectLeftTop(100, -760, 200, 40);
            //Prefab_Button_Quit
            GameObject Prefab_Button_Quit = GameObject.Instantiate(Prefab_Button_StartMenu_Normal);
            Prefab_Button_Quit.SetParent(Panel);
            Prefab_Button_Quit.transform.Find("Text").GetComponent<Text>().text = "退出";
            Prefab_Button_Quit.SetRectLeftTop(100, -840, 200, 40);

            //Panel_BulletinBoard
            var Panel_BulletinBoard = VLCreator.CreatePanel("Panel_BulletinBoard");
            Panel_BulletinBoard.SetParent(Panel);
            Panel_BulletinBoard.SetRectLeftTop(1400, -100, 420, 300);
            Panel_BulletinBoard.SetImageColor("#FFCB00C8".ToColor());
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
            Prefab_Panel_Declaration.GetTextObject().GetComponent<Text>().text = "抵制不良游戏，拒绝盗版游戏。注意自我保护，谨防受骗上当。适度游戏益脑，沉迷游戏伤身。合理安排时间，享受健康生活。";
            //Prefab_Panel_Version
            GameObject Prefab_Panel_Version = GameObject.Instantiate(Prefab_Canvas_StartMenu_Declaration);
            Prefab_Panel_Version.SetParent(Panel);
            Prefab_Panel_Version.SetRectLeftDown(1720, 0, 200, 40);
            Prefab_Panel_Version.GetTextObject().GetComponent<Text>().text = "alpha 0.1.0";

            Debug.Log($"Instantiate End");
        }
    }
}
