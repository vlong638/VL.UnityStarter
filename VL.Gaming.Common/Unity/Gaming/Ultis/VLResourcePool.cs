using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using VL.Gaming.Unity.Tools;

namespace VL.Gaming.Unity.Gaming.Ultis
{
    public static class VLResourcePool
    {
        public static Sprite Sprite_Rectangle { get { return Resources.Load<Sprite>("Sprites/Rectangle"); } }
        public static Sprite Sprite_Circle { get { return Resources.Load<Sprite>("Sprites/Circle"); } }
        public static Sprite Sprite_Background { get { return AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/Background.psd"); } }
        public static Sprite Sprite_UIMask { get { return AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/UIMask.psd"); } }
        public static Sprite Sprite_UISprite { get { return AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/UISprite.psd"); } }
        public static Sprite Sprite_Player { get { return Resources.Load<Sprite>("Sprites/DialogueTest_小红帽"); } }
        public static Sprite Sprite_Enermy { get { return Resources.Load<Sprite>("Sprites/DialogueTest_大灰狼"); } }
        public static Sprite Sprite_VS { get { return Resources.Load<Sprite>("Sprites/DialogueBoxBackground"); } }
        public static Sprite Sprite_HourGlass { get { return Resources.Load<Sprite>("Sprites/hourglass"); } }
        public static Sprite Sprite_PlayerTurn { get { return Resources.Load<Sprite>("Sprites/DialogueTest_小红帽"); } }
        public static Sprite Sprite_EnermyTurn { get { return Resources.Load<Sprite>("Sprites/DialogueTest_大灰狼"); } }

        public static GameObject Prefab_Chess { get { return Resources.Load<GameObject>("Prefabs/Prefab_Chess"); ; } }
        public static GameObject Prefab_ChessPlaceHolder { get { return Resources.Load<GameObject>("Prefabs/Prefab_ChessPlaceHolder"); } }

        #region StartMenu
        public static GameObject Prefab_Button_StartMenu_MiniButton { get { return Resources.Load<GameObject>("Prefabs/Prefab_Button_StartMenu_MiniButton"); } }
        public static GameObject Prefab_Button_StartMenu_Normal { get { return Resources.Load<GameObject>("Prefabs/Prefab_Button_StartMenu_Normal"); } }
        public static GameObject Prefab_Canvas_StartMenu_Declaration { get { return Resources.Load<GameObject>("Prefabs/Prefab_Canvas_StartMenu_Declaration"); } }
        #endregion

        #region GameInit
        public static GameObject Prefab_Toggle_GameInit_MainCategory { get { return Resources.Load<GameObject>("Prefabs/Prefab_Toggle_GameInit_MainCategory"); } }
        public static GameObject Prefab_Toggle_GameInit_SubCategory { get { return Resources.Load<GameObject>("Prefabs/Prefab_Toggle_GameInit_SubCategory"); } }
        public static GameObject Prefab_Button_GameInit_Normal { get { return Resources.Load<GameObject>("Prefabs/Prefab_Button_GameInit_Normal"); } } 
        public static GameObject Prefab_InputField_GameInit_Normal { get { return Resources.Load<GameObject>("Prefabs/Prefab_InputField_GameInit_Normal"); } }
        #endregion

        public static RuntimeAnimatorController Controller_Rotate { get { return Resources.Load<RuntimeAnimatorController>("Animations/Rotate"); } }

        public static List<GameObject> CellGrass = new List<GameObject>();
        public static List<GameObject> CellRock= new List<GameObject>();
        public static List<GameObject> CellSand = new List<GameObject>();
        public static List<GameObject> CellSea = new List<GameObject>();
        public static List<GameObject> CellWater = new List<GameObject>();

        public static List<GameObject> BuildingType1 = new List<GameObject>();

        public static bool IsResourceReady = false;
        public static void LoadResource(GameObject assetsGO)
        {
            CellGrass.Add(VLCreator.CreateSprite("Ground", Resources.Load<Sprite>("Sprites/grass_60"), assetsGO));
            BuildingType1.Add(VLCreator.CreateSprite("BuildingType1", Resources.Load<Sprite>("Sprites/Buildings/Building1"), assetsGO));
            BuildingType1.Add(VLCreator.CreateSprite("BuildingType1", Resources.Load<Sprite>("Sprites/Buildings/Building2"), assetsGO));
            BuildingType1.Add(VLCreator.CreateSprite("BuildingType1", Resources.Load<Sprite>("Sprites/Buildings/Building3"), assetsGO));
            BuildingType1.Add(VLCreator.CreateSprite("BuildingType1", Resources.Load<Sprite>("Sprites/Buildings/Building4"), assetsGO));
            BuildingType1.Add(VLCreator.CreateSprite("BuildingType1", Resources.Load<Sprite>("Sprites/Buildings/Building5"), assetsGO));
            BuildingType1.Add(VLCreator.CreateSprite("BuildingType1", Resources.Load<Sprite>("Sprites/Buildings/Building6"), assetsGO));
            BuildingType1.Add(VLCreator.CreateSprite("BuildingType1", Resources.Load<Sprite>("Sprites/Buildings/Building7"), assetsGO));

            var sprites = Resources.LoadAll<Sprite>("Sprites/Ground");
            //CellGrass.Add(VLCreator.CreateSprite("Ground", sprites[0], assetsGO));
            //CellGrass.Add(VLCreator.CreateSprite("Ground", sprites[1], assetsGO));
            //CellGrass.Add(VLCreator.CreateSprite("Ground", sprites[2], assetsGO));
            CellRock.Add(VLCreator.CreateSprite("Ground", sprites[4], assetsGO));
            CellRock.Add(VLCreator.CreateSprite("Ground", sprites[5], assetsGO));
            CellSand.Add(VLCreator.CreateSprite("Ground", sprites[6], assetsGO));
            CellSand.Add(VLCreator.CreateSprite("Ground", sprites[7], assetsGO));
            CellSand.Add(VLCreator.CreateSprite("Ground", sprites[8], assetsGO));
            CellSea.Add(VLCreator.CreateSprite("Ground", sprites[9], assetsGO));
            CellSea.Add(VLCreator.CreateSprite("Ground", sprites[10], assetsGO));
            CellSea.Add(VLCreator.CreateSprite("Ground", sprites[11], assetsGO));
            CellWater.Add(VLCreator.CreateSprite("Ground", sprites[12], assetsGO));
            CellWater.Add(VLCreator.CreateSprite("Ground", sprites[13], assetsGO));
            IsResourceReady = true;
        }

        public static GameObject GetCellGrass(int index = -1)
        {
            if (index == -1)
                return CellGrass[Random.Range(0, CellGrass.Count - 1)];
            return CellGrass[index];
        }
        public static GameObject GetCellRock(int index = -1)
        {
            if (index == -1)
                return CellRock[Random.Range(0, CellRock.Count)];
            return CellRock[index];
        }
        public static GameObject GetCellSand(int index = -1)
        {
            if (index == -1)
                return CellSand[Random.Range(0, CellSand.Count)];
            return CellSand[index];
        }
        public static GameObject GetCellSea(int index = -1)
        {
            if (index == -1)
                return CellSea[Random.Range(0, CellSea.Count)];
            return CellSea[index];
        }
        public static GameObject GetCellWater(int index = -1)
        {
            if (index == -1)
                return CellWater[Random.Range(0, CellWater.Count)];
            return CellWater[index];
        }
        public static GameObject GetBuildingType1(int index = -1)
        {
            if (index == -1)
                return BuildingType1[Random.Range(0, BuildingType1.Count - 1)];
            return BuildingType1[index];
        }
    }
}
