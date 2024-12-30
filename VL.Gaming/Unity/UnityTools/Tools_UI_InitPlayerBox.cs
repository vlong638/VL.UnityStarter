using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using VL.Gaming.Common;
using VL.Gaming.Unity.Gaming.Content.Entities;
using VL.Gaming.Unity.Gaming.Tools;
using VL.Gaming.Unity.Tools;

namespace VL.Gaming.Unity.UnityTools
{
    public class Tools_UI_InitPlayerBox
    {
        [MenuItem("Tools/UI/InitPlayerBox")]
        public static void InitPlayerBox()
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
            VLResourceHelper.CheckExist("Prefab_Canvas_Gaming_PlayerBox");

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
    }
}
