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
    internal class Tools_Scene_InitGameSetup
    {
        [MenuItem("Tools/Scene/InitGameSetup")]
        static void InitGameSetup()
        {
            //检查已存在
            VLResourceHelper.CheckExist("GameInitManager");
            VLResourceHelper.CheckExist("Canvas");
            VLResourceHelper.CheckExist("EventSystem");

            //依赖前置
            var EventSystem = VLCreator.CreateEventSystem("EventSystem");
            var Prefab_Toggle_GameInit_MainCategory = VLResourcePool.Prefab_Toggle_GameInit_MainCategory;
            var Prefab_Toggle_GameInit_SubCategory = VLResourcePool.Prefab_Toggle_GameInit_SubCategory;
            var Prefab_Button_GameInit_Normal = VLResourcePool.Prefab_Button_GameInit_Normal;
            var Prefab_InputField_GameInit_Normal = VLResourcePool.Prefab_InputField_GameInit_Normal;
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
