using UnityEngine;
using VL.Gaming.Common;
using VL.Gaming.Unity.Common.Enums;
using VL.Gaming.Unity.Gaming.Utils;
using VL.Gaming.Unity.Tools;

namespace VL.Gaming.Unity.Gaming.GameSystem.Generator
{
    internal class QuadGameBoard : MonoBehaviour
    {
        private static QuadGameBoard instance;
        public static QuadGameBoard Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameObject("QuadGameBoard").AddComponent<QuadGameBoard>();
                }
                return instance;
            }
        }

        public static float Width = 1920;
        public static float Height = 1080;
        public static int XSteps = 60;
        public static int YSteps = 40;
        public static float StepX = 1f;
        public static float StepY = 1f;

        public Floor[,] Floors = new Floor[XSteps, YSteps];
        //public Building[,] Buildings = new Building[XSteps, YSteps];

        internal GameObject GameboardGO { set; get; }

        public Object GenerateFloors(GameObject floorsGO)
        {
            for (int x = 0; x < XSteps; x++)
            {
                for (int y = 0; y < YSteps; y++)
                {
                    var sprite = Instantiate(VLResourcePool.GetRandomCell(CellType.CellGrass, 0));
                    var name = $"Floor{x}_{y}";
                    Floors[x, y] = new Floor(name, sprite, FloorType.Grass);
                    sprite.name = name;
                    sprite.transform.position = new Vector2((x - XSteps / 2) * StepX, (y - YSteps / 2) * StepY);
                    sprite.SetParent(floorsGO);
                }
            }
            return null;
        }

        public Object GenerateRocks(GameObject buildingsGO)
        {
            VLSeedRandom random = new VLSeedRandom(60, 1);
            var offset = 2;
            for (int x = offset; x < XSteps - offset; x++)
            {
                for (int y = offset; y < YSteps - offset; y++)
                {
                    if (Floors[x, y].Building != null)
                        continue;
                    if (random.GetNext() == 0)
                        continue;
                    var sprite = Instantiate(VLResourcePool.GetRandomCell(CellType.CellRock));
                    var name = $"Builidng{x}_{y}";
                    Floors[x, y].Building = new Building(name, sprite, BuildingType.Rock);
                    sprite.name = name;
                    sprite.transform.position = new Vector2((x - XSteps / 2) * StepX, (y - YSteps / 2) * StepY);
                    sprite.SetParent(buildingsGO);
                }
            }
            return null;
        }
        public Object GenerateTrees(GameObject buildingsGO)
        {
            VLSeedRandom random = new VLSeedRandom(30, 1);
            var offset = 2;
            for (int x = offset; x < XSteps - offset; x++)
            {
                for (int y = offset; y < YSteps - offset; y++)
                {
                    if (Floors[x, y].Building != null)
                        continue;
                    if (random.GetNext() == 0)
                        continue;
                    var sprite = Instantiate(VLResourcePool.GetRandomCell(CellType.CellTree));
                    var name = $"Builidng{x}_{y}";
                    Floors[x, y].Building = new Building(name, sprite, BuildingType.Tree);
                    sprite.name = name;
                    sprite.transform.position = new Vector2((x - XSteps / 2) * StepX, (y - YSteps / 2) * StepY);
                    sprite.SetParent(buildingsGO);
                }
            }
            return null;
        }
        public Object GenerateTreeFruits(GameObject buildingsGO)
        {
            VLSeedRandom random = new VLSeedRandom(100, 1);
            var offset = 2;
            for (int x = offset; x < XSteps - offset; x++)
            {
                for (int y = offset; y < YSteps - offset; y++)
                {
                    if (Floors[x, y].Building != null)
                        continue;
                    if (random.GetNext() == 0)
                        continue;
                    var sprite = Instantiate(VLResourcePool.GetRandomCell(CellType.CellTreeFruit));
                    var name = $"Builidng{x}_{y}";
                    Floors[x, y].Building = new Building(name, sprite, BuildingType.Tree);
                    sprite.name = name;
                    sprite.transform.position = new Vector2((x - XSteps / 2) * StepX, (y - YSteps / 2) * StepY);
                    sprite.SetParent(buildingsGO);
                }
            }
            return null;
        }
        public Object GenerateBuildings(GameObject buildingsGO)
        {
            VLSeedRandom random = new VLSeedRandom(200, 1);
            var offset = 10;
            for (int x = offset; x < XSteps - offset; x++)
            {
                for (int y = offset; y < YSteps - offset; y++)
                {
                    if (Floors[x, y].Building != null)
                        continue;
                    if (random.GetNext() == 0)
                        continue;
                    var sprite = Instantiate(VLResourcePool.GetRandomCell(CellType.CellBuilding));
                    var name = $"Builidng{x}_{y}";
                    Floors[x, y].Building = new Building(name, sprite, BuildingType.City);
                    sprite.name = name;
                    sprite.transform.position = new Vector2((x - XSteps / 2) * StepX, (y - YSteps / 2) * StepY);
                    sprite.SetParent(buildingsGO);
                }
            }
            return null;
        }
        public Object GenerateEvents(GameObject buildingsGO)
        {
            VLSeedRandom random = new VLSeedRandom(300, 1);
            var offset = 10;
            for (int x = offset; x < XSteps - offset; x++)
            {
                for (int y = offset; y < YSteps - offset; y++)
                {
                    if (Floors[x, y].Building != null)
                        continue;
                    if (random.GetNext() == 0)
                        continue;
                    var sprite = Instantiate(VLResourcePool.GetRandomCell(CellType.CellEvent));
                    var name = $"Builidng{x}_{y}";
                    Floors[x, y].Building = new Building(name, sprite, BuildingType.City);
                    sprite.name = name;
                    sprite.transform.position = new Vector2((x - XSteps / 2) * StepX, (y - YSteps / 2) * StepY);
                    sprite.SetParent(buildingsGO);
                }
            }
            return null;
        }
        public Object GenerateCities(GameObject buildingsGO)
        {
            VLSeedRandom random = new VLSeedRandom(500, 1);
            var offset = 10;
            for (int x = offset; x < XSteps - offset; x++)
            {
                for (int y = offset; y < YSteps - offset; y++)
                {
                    if (Floors[x, y].Building != null)
                        continue;
                    if (random.GetNext() == 0)
                        continue;
                    var sprite = Instantiate(VLResourcePool.GetRandomCell(CellType.CellCity));
                    var name = $"Builidng{x}_{y}";
                    Floors[x, y].Building = new Building(name, sprite, BuildingType.City);
                    sprite.name = name;
                    sprite.transform.position = new Vector2((x - XSteps / 2) * StepX, (y - YSteps / 2) * StepY);
                    sprite.SetParent(buildingsGO);
                }
            }
            return null;
        }
    }
    public class UnityObject
    {
        public GameObject SpriteGO { set; get; }
        public string Name;
        public int X;
        public int Y;

        public UnityObject(string name, GameObject spriteGO)
        {
            Name = name;
            SpriteGO = spriteGO;
        }
    }
    public class Item : UnityObject
    {
        public Item(string name, GameObject spriteGO) : base(name, spriteGO)
        {
            this.SpriteGO.GetComponent<SpriteRenderer>().sortingOrder = Common.Enums.SortingOrder.Item.ToInt();
        }

        public Item Clone()
        {
            return new Item(Name, Object.Instantiate(SpriteGO));
        }
    }
    public class Floor : UnityObject
    {
        public FloorType FloorType;
        public Building Building;

        public Floor(string name, GameObject spriteGO, FloorType floorType) : base(name, spriteGO)
        {
            this.FloorType = floorType;
            this.SpriteGO.GetComponent<SpriteRenderer>().sortingOrder = Common.Enums.SortingOrder.Background.ToInt();
        }

        public Floor Clone()
        {
            return new Floor(Name, Object.Instantiate(SpriteGO), this.FloorType);
        }
    }
    public enum FloorType
    {
        None = 0,
        Grass,
        Rock,
        Sand,
        Sea,
        Water,
    }
    public class Building : UnityObject
    {
        public BuildingType BuildingType;

        public Building(string name, GameObject spriteGO, BuildingType BuildingType) : base(name, spriteGO)
        {
            this.BuildingType = BuildingType;
            this.SpriteGO.GetComponent<SpriteRenderer>().sortingOrder = Common.Enums.SortingOrder.Building.ToInt();
        }

        public Building Clone()
        {
            return new Building(Name, Object.Instantiate(SpriteGO), this.BuildingType);
        }
    }
    public enum BuildingType
    {
        None = 0,
        City,
        Rock,
        Tree,
    }
}
