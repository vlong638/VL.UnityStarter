using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using VL.Gaming.Unity.Tools;

namespace VL.Gaming.Unity.Gaming.Tools
{
    public enum CellType
    {
        CellGrass,
        CellBuilding,
        CellCity,
        CellEvent,
        CellTree,
        CellRock,
        CellTreeFruit,
    }
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
        public static List<GameObject> CellBuilding = new List<GameObject>();
        public static List<GameObject> CellCity = new List<GameObject>();
        public static List<GameObject> CellEvent = new List<GameObject>();
        public static List<GameObject> CellTree = new List<GameObject>();
        public static List<GameObject> CellRock = new List<GameObject>();
        public static List<GameObject> CellTreeFruit = new List<GameObject>();

        public static GameObject GetRandomCell(CellType cellType, int index = -1)
        {
            List<GameObject> cellList = null;
            switch (cellType)
            {
                case CellType.CellGrass:
                    cellList = CellGrass;
                    break;
                case CellType.CellBuilding:
                    cellList = CellBuilding;
                    break;
                case CellType.CellCity:
                    cellList = CellCity;
                    break;
                case CellType.CellEvent:
                    cellList = CellEvent;
                    break;
                case CellType.CellTree:
                    cellList = CellTree;
                    break;
                case CellType.CellRock:
                    cellList = CellRock;
                    break;
                case CellType.CellTreeFruit:
                    cellList = CellTreeFruit;
                    break;
                default:
                    break;
            }
            if (index == -1)
                return cellList[Random.Range(0, cellList.Count - 1)];
            return cellList[index];
        }

        public static bool IsResourceReady = false;
        public static void LoadResource(GameObject assetsGO)
        {
            CellGrass.Add(VLCreator.CreateSprite("CellGrass", Resources.Load<Sprite>("Sprites/grass_60"), assetsGO));

            CellBuilding.Add(VLCreator.CreateSprite("CellBuildings", Resources.Load<Sprite>("Sprites/Buildings/Building1"), assetsGO));
            CellBuilding.Add(VLCreator.CreateSprite("CellBuildings", Resources.Load<Sprite>("Sprites/Buildings/Building2"), assetsGO));
            CellBuilding.Add(VLCreator.CreateSprite("CellBuildings", Resources.Load<Sprite>("Sprites/Buildings/Building3"), assetsGO));
            CellBuilding.Add(VLCreator.CreateSprite("CellBuildings", Resources.Load<Sprite>("Sprites/Buildings/Building4"), assetsGO));
            CellBuilding.Add(VLCreator.CreateSprite("CellBuildings", Resources.Load<Sprite>("Sprites/Buildings/Building5"), assetsGO));
            CellBuilding.Add(VLCreator.CreateSprite("CellBuildings", Resources.Load<Sprite>("Sprites/Buildings/Building6"), assetsGO));
            CellBuilding.Add(VLCreator.CreateSprite("CellBuildings", Resources.Load<Sprite>("Sprites/Buildings/Building7"), assetsGO));
            CellBuilding.Add(VLCreator.CreateSprite("CellBuildings", Resources.Load<Sprite>("Sprites/Buildings/Building8"), assetsGO));
            CellBuilding.Add(VLCreator.CreateSprite("CellBuildings", Resources.Load<Sprite>("Sprites/Buildings/Building9"), assetsGO));
            CellBuilding.Add(VLCreator.CreateSprite("CellBuildings", Resources.Load<Sprite>("Sprites/Buildings/Building10"), assetsGO));

            CellCity.Add(VLCreator.CreateSprite("CellCities", Resources.Load<Sprite>("Sprites/Cities/City1"), assetsGO));
            CellCity.Add(VLCreator.CreateSprite("CellCities", Resources.Load<Sprite>("Sprites/Cities/City2"), assetsGO));
            CellCity.Add(VLCreator.CreateSprite("CellCities", Resources.Load<Sprite>("Sprites/Cities/City3"), assetsGO));
            CellCity.Add(VLCreator.CreateSprite("CellCities", Resources.Load<Sprite>("Sprites/Cities/City4"), assetsGO));

            CellEvent.Add(VLCreator.CreateSprite("CellEvents", Resources.Load<Sprite>("Sprites/Events/Event1"), assetsGO));
            CellEvent.Add(VLCreator.CreateSprite("CellEvents", Resources.Load<Sprite>("Sprites/Events/Event2"), assetsGO));
            CellEvent.Add(VLCreator.CreateSprite("CellEvents", Resources.Load<Sprite>("Sprites/Events/Event3"), assetsGO));
            CellEvent.Add(VLCreator.CreateSprite("CellEvents", Resources.Load<Sprite>("Sprites/Events/Event4"), assetsGO));
            CellEvent.Add(VLCreator.CreateSprite("CellEvents", Resources.Load<Sprite>("Sprites/Events/Event5"), assetsGO));
            CellEvent.Add(VLCreator.CreateSprite("CellEvents", Resources.Load<Sprite>("Sprites/Events/Event6"), assetsGO));
            CellEvent.Add(VLCreator.CreateSprite("CellEvents", Resources.Load<Sprite>("Sprites/Events/Event7"), assetsGO));
            CellEvent.Add(VLCreator.CreateSprite("CellEvents", Resources.Load<Sprite>("Sprites/Events/Event8"), assetsGO));

            CellTree.Add(VLCreator.CreateSprite("CellTrees", Resources.Load<Sprite>("Sprites/Trees/Tree1"), assetsGO));
            CellTree.Add(VLCreator.CreateSprite("CellTrees", Resources.Load<Sprite>("Sprites/Trees/Tree2"), assetsGO));
            CellTree.Add(VLCreator.CreateSprite("CellTrees", Resources.Load<Sprite>("Sprites/Trees/Tree3"), assetsGO));
            CellTree.Add(VLCreator.CreateSprite("CellTrees", Resources.Load<Sprite>("Sprites/Trees/Tree4"), assetsGO));
            CellTree.Add(VLCreator.CreateSprite("CellTrees", Resources.Load<Sprite>("Sprites/Trees/Tree5"), assetsGO));
            CellTree.Add(VLCreator.CreateSprite("CellTrees", Resources.Load<Sprite>("Sprites/Trees/Tree6"), assetsGO));
            CellTree.Add(VLCreator.CreateSprite("CellTrees", Resources.Load<Sprite>("Sprites/Trees/Tree7"), assetsGO));
            CellTree.Add(VLCreator.CreateSprite("CellTrees", Resources.Load<Sprite>("Sprites/Trees/Tree8"), assetsGO));
            CellTree.Add(VLCreator.CreateSprite("CellTrees", Resources.Load<Sprite>("Sprites/Trees/Tree9"), assetsGO));

            CellRock.Add(VLCreator.CreateSprite("CellRocks", Resources.Load<Sprite>("Sprites/Rocks/Rock1"), assetsGO));
            CellRock.Add(VLCreator.CreateSprite("CellRocks", Resources.Load<Sprite>("Sprites/Rocks/Rock2"), assetsGO));
            CellRock.Add(VLCreator.CreateSprite("CellRocks", Resources.Load<Sprite>("Sprites/Rocks/Rock3"), assetsGO));
            CellRock.Add(VLCreator.CreateSprite("CellRocks", Resources.Load<Sprite>("Sprites/Rocks/Rock4"), assetsGO));
            CellRock.Add(VLCreator.CreateSprite("CellRocks", Resources.Load<Sprite>("Sprites/Rocks/Rock5"), assetsGO));
            CellRock.Add(VLCreator.CreateSprite("CellRocks", Resources.Load<Sprite>("Sprites/Rocks/Rock6"), assetsGO));
            CellRock.Add(VLCreator.CreateSprite("CellRocks", Resources.Load<Sprite>("Sprites/Rocks/Rock7"), assetsGO));
            CellRock.Add(VLCreator.CreateSprite("CellRocks", Resources.Load<Sprite>("Sprites/Rocks/Rock8"), assetsGO));
            CellRock.Add(VLCreator.CreateSprite("CellRocks", Resources.Load<Sprite>("Sprites/Rocks/Rock9"), assetsGO));

            CellTreeFruit.Add(VLCreator.CreateSprite("CellTreeFruits", Resources.Load<Sprite>("Sprites/TreeFruits/TreeFruit1"), assetsGO));
            CellTreeFruit.Add(VLCreator.CreateSprite("CellTreeFruits", Resources.Load<Sprite>("Sprites/TreeFruits/TreeFruit2"), assetsGO));

            //var sprites = Resources.LoadAll<Sprite>("Sprites/Ground");
            //CellGrass.Add(VLCreator.CreateSprite("Ground", sprites[0], assetsGO));
            //CellGrass.Add(VLCreator.CreateSprite("Ground", sprites[1], assetsGO));
            //CellGrass.Add(VLCreator.CreateSprite("Ground", sprites[2], assetsGO));
            //CellRock.Add(VLCreator.CreateSprite("Ground", sprites[4], assetsGO));
            //CellRock.Add(VLCreator.CreateSprite("Ground", sprites[5], assetsGO));
            //CellSand.Add(VLCreator.CreateSprite("Ground", sprites[6], assetsGO));
            //CellSand.Add(VLCreator.CreateSprite("Ground", sprites[7], assetsGO));
            //CellSand.Add(VLCreator.CreateSprite("Ground", sprites[8], assetsGO));
            //CellSea.Add(VLCreator.CreateSprite("Ground", sprites[9], assetsGO));
            //CellSea.Add(VLCreator.CreateSprite("Ground", sprites[10], assetsGO));
            //CellSea.Add(VLCreator.CreateSprite("Ground", sprites[11], assetsGO));
            //CellWater.Add(VLCreator.CreateSprite("Ground", sprites[12], assetsGO));
            //CellWater.Add(VLCreator.CreateSprite("Ground", sprites[13], assetsGO));

            IsResourceReady = true;
        }

    }
}
