using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace VL.UnityStarter.GamingStudy0316
{
    public static class Dictionaries
    {
        public static Dictionary<string, Color> ColorDic = new Dictionary<string, Color>()
        {
            { nameof(FastItem.FastItemBlock), Color.black},
            { nameof(Creature), "#FF0F00".ToColor()},
            { nameof(Floor), "#BC9401".ToColor()},
            { nameof(ItemType.DoubleAttack), "#DC00E7".ToColor()},
            { nameof(ItemType.DoubleDefend), Color.yellow},
            { nameof(ItemType.DoubleSpeed), Color.blue},
        };
        public static Dictionary<ItemType, KeyValuePair<Buff, int>> BuffDic = new Dictionary<ItemType, KeyValuePair<Buff, int>>()
        {
            { ItemType.DoubleAttack, new KeyValuePair<Buff, int>(Buff.DoubleAttack,8) },
            { ItemType.DoubleDefend, new KeyValuePair<Buff, int>(Buff.DoubleDefend,8) },
            { ItemType.DoubleSpeed, new KeyValuePair<Buff, int>(Buff.DoubleSpeed,8) },
        };
    }

    enum SpriteType
    {
        None = 0,
        Floor = 3,
        Item = 5,
        Creature = 9,
    }

    public static partial class ValueEx
    {
        public static Color ToColor(this string s)
        {
            ColorUtility.TryParseHtmlString(s, out var c);
            return c;
        }
        public static void SetParent(this GameObject go, GameObject parent)
        {
            go.transform.parent = parent.transform;
        }
    }
    public class CloneHelper
    {
        public static GameObject Clone(GameObject gameObject)
        {
            return Gaming0316.Instantiate(gameObject);
        }
    }

    public class Gaming0316 : MonoBehaviour
    {
        internal GameObject startGO { set; get; }
        internal GameObject assetGO { set; get; }
        internal GameObject gamingGO { set; get; }
        internal GameObject settingGO { set; get; }

        GameBoard GameBoard;


        #region Unity Mehtod
        void Start()
        {
            Debug.Log($"Start");

            startGO = GameObject.Find("startGO");
            assetGO = GameObject.Find("assetGO");
            gamingGO = GameObject.Find("gamingGO");
            settingGO = GameObject.Find("settingGO");
            //start
            var gameObject = GameObject.Find("start");
            var button = gameObject.GetComponent<Button>();
            button.onClick.AddListener(StartGame);
            //load
            gameObject = GameObject.Find("load");
            button = gameObject.GetComponent<Button>();
            button.onClick.AddListener(Load);
            //end
            gameObject = GameObject.Find("end");
            button = gameObject.GetComponent<Button>();
            button.onClick.AddListener(EndGame);

            //预处理
            GameBoard = new GameBoard(this);
            GameBoard.GamingGO = gamingGO;
            StartCoroutine(nameof(SetupGameBoard), GameBoard);

            Debug.Log($"Started");
        }

        void Update()
        {
            if (GameBoard == null || GameBoard.Player == null)
                return;
            GameBoard.PlayerOperation();
            GameBoard.EnermyOperation();
        }

        private void LateUpdate()
        {
            if (GameBoard == null || GameBoard.CameraGO == null)
                return;
            GameBoard.CameraGO.transform.position = GameBoard.Player.PlayerGO.transform.position + GameBoard.Player.CameraOffSet;
            GameBoard.CameraGO.transform.rotation = GameBoard.Player.PlayerGO.transform.rotation;
            Debug.Log($"LateUpdate");
        }
        #endregion

        private void Load()
        {
            Debug.Log($"Load Ended");
        }
        private void EndGame()
        {
            Debug.Log($"Game Ended");
        }
        private void StartGame()
        {
            if (!isStarting)
            {
                StartCoroutine(StartingGame());
            }
        }


        #region StartGame

        private bool isStarting = false;
        IEnumerator StartingGame()
        {
            if (!GameBoard.IsResourceReady)
            {
                Debug.Log("资源尚未加载");
                Invoke(nameof(StartingGame), 0.5f);
                yield return null;
            }

            Debug.Log($"StartingGame");
            isStarting = true;
            startGO.SetActive(false);
            gamingGO.SetActive(true);
            assetGO.SetActive(false);
            settingGO.SetActive(false);
            GameBoard.PreInit();
            GameBoard.DisplayText("开始生成地形");
            yield return GameBoard.InitFloors();
            GameBoard.DisplayText("开始生成树木");
            yield return GameBoard.InitTrees();
            GameBoard.DisplayText("开始生成城镇");
            yield return GameBoard.InitTowns();
            GameBoard.DisplayText("开始生成矿坑");
            yield return GameBoard.InitMines();
            GameBoard.DisplayText("开始生成道路");
            yield return GameBoard.InitRoads();
            GameBoard.DisplayText("开始生成河流");
            yield return GameBoard.InitRivers();
            GameBoard.DisplayText("开始生成玩家");
            yield return GameBoard.InitPlayer();
            GameBoard.DisplayText("开始生成摄像头");
            yield return GameBoard.InitCamera();
            //yield return new WaitForSeconds(1f); // 模拟长时间运行

            isStarting = false;
        }

        #endregion

        private void SetupGameBoard(GameBoard gameBoard)
        {
            GameBoard.IsResourceReady = false;
            //地形
            var sprite = Resources.LoadAll<Sprite>("16x16-mini-world-sprites/Ground/Grass");
            GameBoard.Resource_Grounds = new List<Floor>();
            GameBoard.Resource_Grounds.Add(new Floor(VLCreator.CreateSprite(sprite.First(c => c.name == "Grass_1"), "Grass_1", assetGO), FloorType.Grassland));
            GameBoard.Resource_Grounds.Add(new Floor(VLCreator.CreateSprite(sprite.First(c => c.name == "Grass_2"), "Grass_2", assetGO), FloorType.Grassland));
            sprite = Resources.LoadAll<Sprite>("16x16-mini-world-sprites/Ground/TexturedGrass");
            GameBoard.Resource_Grounds.Add(new Floor(VLCreator.CreateSprite(sprite.First(c => c.name == "TexturedGrass_1"), "TexuredGrass_1", assetGO), FloorType.Grassland));
            GameBoard.Resource_Grounds.Add(new Floor(VLCreator.CreateSprite(sprite.First(c => c.name == "TexturedGrass_2"), "TexuredGrass_2", assetGO), FloorType.Grassland));
            GameBoard.Resource_Grounds.Add(new Floor(VLCreator.CreateSprite(sprite.First(c => c.name == "TexturedGrass_4"), "TexuredGrass_4", assetGO), FloorType.Grassland));
            GameBoard.Resource_Grounds.Add(new Floor(VLCreator.CreateSprite(sprite.First(c => c.name == "TexturedGrass_5"), "TexuredGrass_5", assetGO), FloorType.Grassland));
            GameBoard.Resource_Waters = new List<Floor>();
            sprite = Resources.LoadAll<Sprite>("16x16-mini-world-sprites/Ground/Shore");
            GameBoard.Resource_Waters.Add(new Floor(VLCreator.CreateSprite(sprite.First(c => c.name == "Shore_4"), "Shore_4", assetGO), FloorType.River));
            GameBoard.Resource_GradientWaters = new List<Floor>();
            GameBoard.Resource_GradientWaters.Add(new Floor(VLCreator.CreateSprite(sprite.First(c => c.name == "Shore_0"), "Shore_0", assetGO), FloorType.Shore));
            GameBoard.Resource_GradientWaters.Add(new Floor(VLCreator.CreateSprite(sprite.First(c => c.name == "Shore_1"), "Shore_1", assetGO), FloorType.Shore));
            GameBoard.Resource_GradientWaters.Add(new Floor(VLCreator.CreateSprite(sprite.First(c => c.name == "Shore_2"), "Shore_2", assetGO), FloorType.Shore));
            GameBoard.Resource_GradientWaters.Add(new Floor(VLCreator.CreateSprite(sprite.First(c => c.name == "Shore_3"), "Shore_3", assetGO), FloorType.Shore));
            GameBoard.Resource_Roads = new List<Floor>();
            GameBoard.Resource_Mountains_Stone = new List<Floor>();
            sprite = Resources.LoadAll<Sprite>("16x16-mini-world-sprites/Ground/Cliff");
            GameBoard.Resource_Mountains_Stone.Add(new Floor(VLCreator.CreateSprite(sprite.First(c => c.name == "Cliff_0"), "Cliff_0", assetGO), FloorType.Mountain));
            GameBoard.Resource_Mountains_Stone.Add(new Floor(VLCreator.CreateSprite(sprite.First(c => c.name == "Cliff_1"), "Cliff_1", assetGO), FloorType.Mountain));
            GameBoard.Resource_Mountains_Stone.Add(new Floor(VLCreator.CreateSprite(sprite.First(c => c.name == "Cliff_2"), "Cliff_2", assetGO), FloorType.Mountain));
            GameBoard.Resource_Mountains_Stone.Add(new Floor(VLCreator.CreateSprite(sprite.First(c => c.name == "Cliff_5"), "Cliff_5", assetGO), FloorType.Mountain));
            GameBoard.Resource_Mountains_Stone.Add(new Floor(VLCreator.CreateSprite(sprite.First(c => c.name == "Cliff_6"), "Cliff_6", assetGO), FloorType.Mountain));
            GameBoard.Resource_Mountains_Stone.Add(new Floor(VLCreator.CreateSprite(sprite.First(c => c.name == "Cliff_7"), "Cliff_7", assetGO), FloorType.Mountain));
            GameBoard.Resource_Mountains_Stone.Add(new Floor(VLCreator.CreateSprite(sprite.First(c => c.name == "Cliff_10"), "Cliff_10", assetGO), FloorType.Mountain));
            GameBoard.Resource_Mountains_Stone.Add(new Floor(VLCreator.CreateSprite(sprite.First(c => c.name == "Cliff_11"), "Cliff_11", assetGO), FloorType.Mountain));
            GameBoard.Resource_Mountains_Stone.Add(new Floor(VLCreator.CreateSprite(sprite.First(c => c.name == "Cliff_12"), "Cliff_12", assetGO), FloorType.Mountain));
            GameBoard.Resource_Mountains_StoneMine = new Entrance(VLCreator.CreateSprite(sprite.First(c => c.name == "Cliff_9"), "Cliff_9", assetGO), FloorType.Mountain);
            GameBoard.Resource_Mountains_Copper = new List<Floor>();
            GameBoard.Resource_Mountains_Copper.Add(new Floor(VLCreator.CreateSprite(sprite.First(c => c.name == "Cliff_38"), "Cliff_38", assetGO), FloorType.Mountain));
            GameBoard.Resource_Mountains_Copper.Add(new Floor(VLCreator.CreateSprite(sprite.First(c => c.name == "Cliff_39"), "Cliff_39", assetGO), FloorType.Mountain));
            GameBoard.Resource_Mountains_Copper.Add(new Floor(VLCreator.CreateSprite(sprite.First(c => c.name == "Cliff_40"), "Cliff_40", assetGO), FloorType.Mountain));
            GameBoard.Resource_Mountains_Copper.Add(new Floor(VLCreator.CreateSprite(sprite.First(c => c.name == "Cliff_41"), "Cliff_41", assetGO), FloorType.Mountain));
            GameBoard.Resource_Mountains_Copper.Add(new Floor(VLCreator.CreateSprite(sprite.First(c => c.name == "Cliff_42"), "Cliff_42", assetGO), FloorType.Mountain));
            GameBoard.Resource_Mountains_Copper.Add(new Floor(VLCreator.CreateSprite(sprite.First(c => c.name == "Cliff_43"), "Cliff_43", assetGO), FloorType.Mountain));
            GameBoard.Resource_Mountains_Copper.Add(new Floor(VLCreator.CreateSprite(sprite.First(c => c.name == "Cliff_48"), "Cliff_48", assetGO), FloorType.Mountain));
            GameBoard.Resource_Mountains_Copper.Add(new Floor(VLCreator.CreateSprite(sprite.First(c => c.name == "Cliff_49"), "Cliff_49", assetGO), FloorType.Mountain));
            GameBoard.Resource_Mountains_Copper.Add(new Floor(VLCreator.CreateSprite(sprite.First(c => c.name == "Cliff_50"), "Cliff_50", assetGO), FloorType.Mountain));
            GameBoard.Resource_Mountains_CopperMine = new Entrance(VLCreator.CreateSprite(sprite.First(c => c.name == "Cliff_8"), "Cliff_8", assetGO), FloorType.Mountain);
            GameBoard.Resource_Mountains_StoneOre = new BlockItem(VLCreator.CreateSprite(sprite.First(c => c.name == "Cliff_4"), "Cliff_4", assetGO), BlockType.Stone);
            GameBoard.Resource_Mountains_CutterOre = new BlockItem(VLCreator.CreateSprite(sprite.First(c => c.name == "Cliff_3"), "Cliff_3", assetGO), BlockType.Stone);
            GameBoard.Resource_Mountains_BigOre = new List<BlockItem>();
            GameBoard.Resource_Mountains_BigOre.Add(new BlockItem(VLCreator.CreateSprite(sprite.First(c => c.name == "Cliff_15"), "Cliff_15", assetGO), BlockType.Stone));
            GameBoard.Resource_Mountains_BigOre.Add(new BlockItem(VLCreator.CreateSprite(sprite.First(c => c.name == "Cliff_16"), "Cliff_16", assetGO), BlockType.Stone));
            GameBoard.Resource_Mountains_BigOre.Add(new BlockItem(VLCreator.CreateSprite(sprite.First(c => c.name == "Cliff_22"), "Cliff_22", assetGO), BlockType.Stone));
            GameBoard.Resource_Mountains_BigOre.Add(new BlockItem(VLCreator.CreateSprite(sprite.First(c => c.name == "Cliff_23"), "Cliff_23", assetGO), BlockType.Stone));
            //地点
            //物品
            //玩家
            sprite = Resources.LoadAll<Sprite>("16x16-mini-world-sprites/Characters/Champions/Gangblanc");
            GameBoard.Resource_Player = new Creature(VLCreator.CreateSprite(sprite[0], "Player"));
            //生物
            GameBoard.IsResourceReady = true;
        }
    }
    class Movement
    {
        public int X, Y;
        public float XLength { get { return X * GameBoard.StepX; } }
        public float YLength { get { return Y * GameBoard.StepY; } }

        public Vector2 startPosition;
        public Vector2 targetPosition;
        public float moveStartTime = 0f;
        public float moveDuration = 0.2f;

        public Movement(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
    class GameBoard
    {
        public static float Width = 2560;
        public static float Height = 1440;
        public static int XSteps = 160;
        public static int YSteps = 90;
        public static float StepX = 0.16f;
        public static float StepY = 0.16f;
        public Floor[,] Floors;
        internal float floorPaddingX;
        internal float floorPaddingY;
        internal float floorWidth;
        internal float floorHeight;
        internal float itemWidth;
        internal float itemHeight;
        internal float enemyWidth;
        internal float enemyHeight;
        internal Player Player;
        internal Movement movement;

        public GameObject ScrollViewGO { get; set; }
        public GameObject ScrollTextGO { get; set; }
        public Text ScrollText { get; set; }
        public List<Floor> Resource_Grounds { get; internal set; }
        public List<Floor> Resource_Waters { get; internal set; }
        public List<Floor> Resource_Roads { get; internal set; }
        public List<Floor> Resource_GradientWaters { get; internal set; }
        public List<Floor> Resource_Mountains_Stone { get; internal set; }
        public Entrance Resource_Mountains_StoneMine { get; internal set; }
        public BlockItem Resource_Mountains_StoneOre { get; internal set; }
        public BlockItem Resource_Mountains_CutterOre { get; internal set; }
        public Entrance Resource_Mountains_CopperMine { get; internal set; }
        public List<Floor> Resource_Mountains_Copper { get; internal set; }
        public List<BlockItem> Resource_Mountains_BigOre { get; internal set; }
        public bool IsResourceReady { get; internal set; }
        public Creature Resource_Player { get; internal set; }
        public GameObject CameraGO { get; internal set; }
        public Camera Camera { get; internal set; }
        public GameObject GamingGO { get; internal set; }

        private Gaming0316 Mono;

        public GameBoard(Gaming0316 gaming0316)
        {
            this.Mono = gaming0316;
            Floors = new Floor[XSteps, YSteps];
        }

        public void PlayerOperation()
        {
            if (!Player.OperationData.IsOperating)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    Player.OperationData.IsMovingSetup = true;
                    movement = new Movement(0, 1);
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    Player.OperationData.IsMovingSetup = true;
                    movement = new Movement(0, -1);
                }
                else if (Input.GetKey(KeyCode.A))
                {
                    Player.OperationData.IsMovingSetup = true;
                    movement = new Movement(-1, 0);
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    Player.OperationData.IsMovingSetup = true;
                    movement = new Movement(1, 0);
                }
                else if (Input.GetKeyDown(KeyCode.Space))
                {
                    Player.OperationData.IsCollecttingSetup = true;
                }
                else if (Input.GetKeyDown(KeyCode.F))
                {
                    Player.OperationData.IsAttackingSetup = true;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    Player.UseFastItem("1");
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    Player.UseFastItem("2");
                }
                else if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    Player.UseFastItem("3");
                }
                else if (Input.GetKeyDown(KeyCode.Alpha4))
                {
                    Player.UseFastItem("4");
                }
                else if (Input.GetKeyDown(KeyCode.Alpha5))
                {
                    Player.UseFastItem("5");
                }
            }
            if (Player.OperationData.IsMovingSetup)
            {
                Player.OperationData.IsMoving = true;
                Player.OperationData.IsMovingSetup = false;
                movement = CalculateMovement();
                Player.Move(movement);
                Player.UpdateBuffs();
            }
            if (Player.OperationData.IsMoving)
            {
                Player.DisplaySmoothMove(Player.PlayerGO, movement);
            }
            if (Player.OperationData.IsCollecttingSetup)
            {
                Player.OperationData.IsCollecttingSetup = false;
                Player.Collect(Floors);
            }
            if (Player.OperationData.IsAttackingSetup)
            {
                Player.OperationData.IsAttackingSetup = false;
                Player.Attack(Floors);
                Player.UpdateBuffs();
            }
        }

        public Movement CalculateMovement()
        {
            var startPosition = Player.PlayerGO.transform.position;
            var targetPosition = new Vector2(startPosition.x + movement.XLength, startPosition.y + movement.YLength);
            movement.startPosition = startPosition;
            movement.targetPosition = targetPosition;
            movement.moveStartTime = Time.time;
            return movement;
        }

        public void EnermyOperation()
        {
        }

        internal Object PreInit()
        {
            //分层管理
            FloorsGO = new GameObject("Floors"); FloorsGO.SetParent(Mono.gamingGO);
            ItemsGO = new GameObject("Items"); ItemsGO.SetParent(Mono.gamingGO);
            CreaturesGO = new GameObject("Creatures"); CreaturesGO.SetParent(Mono.gamingGO);
            //创建文本输出框
            ScrollViewGO = VLCreator.CreateScrollView("TextDisplay", Mono.gamingGO);
            var rect = ScrollViewGO.GetComponent<RectTransform>();
            rect.anchorMin = new Vector2(0, 0);
            rect.anchorMax = new Vector2(0, 0);
            rect.pivot = new Vector2(0, 0);
            rect.sizeDelta = new Vector2(800, 800);
            rect.anchoredPosition = new Vector2(0, 0);
            var canvasGroup = ScrollViewGO.AddComponent<CanvasGroup>();
            canvasGroup.alpha = 0.6f;
            ScrollTextGO = VLCreator.CreateText("ScrollText", ScrollViewGO);
            rect = ScrollTextGO.GetComponent<RectTransform>();
            rect.anchorMin = new Vector2(0, 0);
            rect.anchorMax = new Vector2(1, 1);
            rect.offsetMin = new Vector2(0f, 0f);
            rect.offsetMax = new Vector2(0f, 0f);
            rect.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0f, rect.rect.width);
            rect.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Right, 0f, rect.rect.width);
            rect.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0f, rect.rect.height);
            rect.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, 0f, rect.rect.height);
            ScrollText = ScrollTextGO.GetComponent<Text>();
            ScrollText.fontSize = 32;
            ScrollText.color = Color.black;
            ScrollText.alignment = TextAnchor.UpperLeft;

            return null;
        }

        public GameObject FloorsGO;
        public GameObject ItemsGO;
        public GameObject CreaturesGO;

        public Object InitFloors()
        {
            floorWidth = StepX;
            floorHeight = StepY;
            for (int i = 0; i < XSteps; i++)
            {
                for (int j = 0; j < YSteps; j++)
                {
                    var f = Resource_Grounds[Random.Range(0, Resource_Grounds.Count)].Clone();
                    Floors[i, j] = f;
                    var sprite = f.SpriteGO.GetComponent<SpriteRenderer>();
                    sprite.transform.position = new Vector2(i * StepX, j * StepY);
                    f.SpriteGO.SetParent(FloorsGO);
                }
            }
            return null;
        }

        //internal void Init()
        //{
        //    //创建地面
        //    floorPaddingX = StepX / 10;
        //    floorPaddingY = StepY / 10;
        //    floorWidth = StepX - floorPaddingX * 2;
        //    floorHeight = StepY - floorPaddingY * 2;
        //    for (int i = 0; i < XSteps; i++)
        //    {
        //        for (int j = 0; j < YSteps; j++)
        //        {
        //            var image = VLCreator.CreateImage("floor" + i + j, CanvasGO).GetComponent<Image>();
        //            image.color = Dictionaries.ColorDic[nameof(Floor)];
        //            image.rectTransform.anchorMin = new Vector2(0f, 0f);
        //            image.rectTransform.anchorMax = new Vector2(0f, 0f);
        //            image.rectTransform.pivot = new Vector2(0f, 0f);
        //            image.rectTransform.sizeDelta = new Vector2(floorWidth, floorHeight);
        //            image.rectTransform.anchoredPosition = new Vector2(i * StepX + floorPaddingX, j * StepY + floorPaddingY);
        //            Floors[i, j] = new Floor(image);
        //        }
        //    }
        //    //生成道具
        //    itemWidth = Mathf.Max(StepX / 4, 30);
        //    itemHeight = Mathf.Max(StepY / 4, 30);
        //    ItemType[] itemTypes = { ItemType.DoubleAttack, ItemType.DoubleDefend, ItemType.DoubleSpeed };
        //    for (int i = 0; i < XSteps; i++)
        //    {
        //        for (int j = 0; j < YSteps; j++)
        //        {
        //            if (Random.Range(0, 100) < 90)
        //                continue;
        //            var imageGO = VLCreator.CreateImage("item" + i + j, CanvasGO);
        //            var image= imageGO.GetComponent<Image>();
        //            var itemType = itemTypes[Random.Range(0, 3)];
        //            switch (itemType)
        //            {
        //                case ItemType.None:
        //                    break;
        //                case ItemType.DoubleAttack:
        //                    image.color = Dictionaries.ColorDic[nameof(ItemType.DoubleAttack)];
        //                    break;
        //                case ItemType.DoubleDefend:
        //                    image.color = Dictionaries.ColorDic[nameof(ItemType.DoubleDefend)];
        //                    break;
        //                case ItemType.DoubleSpeed:
        //                    image.color = Dictionaries.ColorDic[nameof(ItemType.DoubleSpeed)];
        //                    break;
        //                default:
        //                    break;
        //            }
        //            image.rectTransform.anchorMin = new Vector2(0f, 0f);
        //            image.rectTransform.anchorMax = new Vector2(0f, 0f);
        //            image.rectTransform.pivot = new Vector2(0f, 0f);
        //            image.rectTransform.sizeDelta = new Vector2(itemWidth, itemHeight);
        //            image.rectTransform.anchoredPosition = new Vector2(i * StepX + floorPaddingX, j * StepY + floorPaddingY);
        //            Floors[i, j].Items.Add(new Item(imageGO)
        //            {
        //                Name = image.name,
        //                ItemType = itemType,
        //            });
        //        }
        //    }
        //    //生成敌人
        //    enemyWidth = Mathf.Max(StepX / 4, 50);
        //    enemyHeight = Mathf.Max(StepY / 4, 50);
        //    for (int i = 0; i < XSteps; i++)
        //    {
        //        for (int j = 0; j < YSteps; j++)
        //        {
        //            if (Random.Range(0, 100) < 95)
        //                continue;
        //            var image = VLCreator.CreateImage("Creature" + i + j, CanvasGO).GetComponent<Image>();
        //            image.color = Dictionaries.ColorDic[nameof(Creature)];
        //            image.rectTransform.anchorMin = new Vector2(0f, 0f);
        //            image.rectTransform.anchorMax = new Vector2(0f, 0f);
        //            image.rectTransform.pivot = new Vector2(0f, 0f);
        //            image.rectTransform.sizeDelta = new Vector2(enemyWidth, enemyHeight);
        //            image.rectTransform.anchoredPosition = new Vector2(i * StepX + floorPaddingX + floorWidth - enemyWidth
        //                , j * StepY + floorPaddingY + floorHeight - enemyHeight);
        //            Floors[i, j].Creatures.Add(new Creature(image)
        //            {
        //                Name = image.name,
        //                Attr_HP = Random.Range(15, 50),
        //                Attr_AttackMax = Random.Range(7, 10),
        //                Attr_AttackMin = Random.Range(4, 7),
        //                Attr_Defend = Random.Range(3, 6),
        //            }); ;
        //        }
        //    }
        //    //创建Player
        //    Player.PlayerGO.transform.parent = CanvasGO.transform;
        //    Player.PlayerGO.SetActive(true);
        //    RectTransform rect = Player.PlayerGO.GetComponent<RectTransform>();
        //    rect.anchorMin = new Vector2(0f, 0f);
        //    rect.anchorMax = new Vector2(0f, 0f); 
        //    rect.pivot = new Vector2(0f, 0f);
        //    rect.anchoredPosition = new Vector2(floorPaddingX, floorPaddingY + floorHeight / 2 - 20);
        //    Player.Name = Player.PlayerGO.GetComponentInChildren<Text>().text;
        //    //创建文本输出框
        //    ScrollViewGO = VLCreator.CreateScrollView("TextDisplay", CanvasGO);
        //    ScrollRect = ScrollViewGO.GetComponent<ScrollRect>();
        //    rect = ScrollViewGO.GetComponent<RectTransform>();
        //    rect.anchorMin = new Vector2(0, 0);
        //    rect.anchorMax = new Vector2(0, 0);
        //    rect.pivot = new Vector2(0, 0);
        //    rect.sizeDelta = new Vector2(800, 800);
        //    rect.anchoredPosition = new Vector2(0, 0);
        //    var canvasGroup = ScrollViewGO.AddComponent<CanvasGroup>();
        //    canvasGroup.alpha = 0.6f;
        //    ScrollTextGO = VLCreator.CreateText("ScrollText", ScrollViewGO);
        //    rect = ScrollTextGO.GetComponent<RectTransform>();
        //    rect.anchorMin = new Vector2(0, 0);
        //    rect.anchorMax = new Vector2(1, 1);
        //    rect.offsetMin = new Vector2(0f, 0f);
        //    rect.offsetMax = new Vector2(0f, 0f);
        //    rect.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0f, rect.rect.width);
        //    rect.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Right, 0f, rect.rect.width);
        //    rect.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0f, rect.rect.height);
        //    rect.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, 0f, rect.rect.height);
        //    ScrollText = ScrollTextGO.GetComponent<Text>();
        //    ScrollText.fontSize = 32;
        //    ScrollText.color = Color.black;
        //    ScrollText.alignment = TextAnchor.UpperLeft;
        //    //生成道具栏
        //    for (int i = 1; i <= 5; i++)
        //    {
        //        var fastItemBlockGO = new GameObject("FastItemBlock" + i);
        //        fastItemBlockGO.transform.parent = CanvasGO.transform;

        //        var imageGO = VLCreator.CreateImage("FastItemBlockImage" + i, fastItemBlockGO);
        //        var image = imageGO.GetComponent<Image>();
        //        image.color = Dictionaries.ColorDic[nameof(FastItem.FastItemBlock)];
        //        image.rectTransform.anchorMin = new Vector2(0f, 0f);
        //        image.rectTransform.anchorMax = new Vector2(0f, 0f);
        //        image.rectTransform.pivot = new Vector2(0f, 0f);
        //        image.rectTransform.sizeDelta = new Vector2(100, 100);

        //        var x = rect.sizeDelta.x + i * 240;
        //        var y = 120;
        //        image.rectTransform.anchoredPosition = new Vector2(x, y);
        //        canvasGroup = imageGO.AddComponent<CanvasGroup>();
        //        canvasGroup.alpha = 0.8f;
        //        Player.FastItems.Add(new FastItem(imageGO)
        //        {
        //            Name = image.name,
        //            Key = i.ToString(),
        //            FastItemBlockX = x,
        //            FastItemBlockY = y,
        //            Parent = fastItemBlockGO,
        //        }); ;
        //    }
        //    //调整对象位置
        //    Player.X = 0;
        //    Player.Y = 0;
        //    movement = new Movement(12, 6);
        //    movement = CalculateMovement();
        //    Player.Move(movement);
        //    Player.OperationData.IsMoving = true;
        //    Player.OperationData.IsMovingSetup = false;
        //}

        public void DisplayText(string message)
        {
            var texts = ScrollText.text.Split('\n').ToList();
            texts.Add(message);
            if (texts.Count > 20)
                texts.RemoveAt(0);
            ScrollText.text = string.Join("\n", texts);
        }

        internal object InitTrees()
        {
            return null;
        }

        internal object InitMines()
        {
            return null;
        }

        internal object InitTowns()
        {
            return null;
        }

        internal object InitRoads()
        {
            return null;
        }

        internal object InitRivers()
        {
            return null;
        }

        internal object InitPlayer()
        {
            Player = new Player(Resource_Player.SpriteGO);
            Player.PlayerGO.transform.position = new Vector2(Player.X * StepX, Player.X * StepY);
            Player.SpriteGO.SetParent(GamingGO);
            return null;
        }

        internal object InitCamera()
        {
            var cameraGO = VLCreator.CreateCamera("Camera_Player", GamingGO);
            var camera2D = cameraGO.GetComponent<Camera>();
            var transform = camera2D.transform;
            transform.position = Player.PlayerGO.transform.position + Player.CameraOffSet;
            transform.rotation = Player.PlayerGO.transform.rotation;
            camera2D.backgroundColor = Color.black;
            CameraGO = cameraGO;
            Camera = camera2D;
            return null;
        }
    }
    class FastItem
    {
        public GameObject Parent;
        public GameObject FastItemBlock;
        public Item Item;
        public string Name;
        public string Key;

        public FastItem(GameObject imageGO)
        {
            this.FastItemBlock = imageGO;
        }

        public float FastItemBlockX { get; internal set; }
        public float FastItemBlockY { get; internal set; }

        internal void AddItem(Item item)
        {
            var imageGO = VLCreator.CreateImage("FastItemImage", Parent);
            var image = imageGO.GetComponent<Image>();
            image.color = Dictionaries.ColorDic[item.ItemType.ToString()];
            image.rectTransform.anchorMin = new Vector2(0f, 0f);
            image.rectTransform.anchorMax = new Vector2(0f, 0f);
            image.rectTransform.pivot = new Vector2(0f, 0f);
            image.rectTransform.sizeDelta = new Vector2(40, 40);
            image.rectTransform.anchoredPosition = new Vector2(FastItemBlockX + 20, FastItemBlockY + 20);
            image.rectTransform.localScale = new Vector3(1.5f, 1.5f, 0);
            item.SpriteGO = imageGO;
            Item = item;
        }

        internal void UseItem()
        {
            Gaming0316.Destroy(Item.SpriteGO);
            Item = null;
        }
    }

    enum EntranceType
    {
        None = 0,
        StoneMine,
        CopperMine,
        House,
        Town,
    }

    class Entrance : Floor
    {
        public EntranceType EntranceType;
        public Entrance(GameObject imageGO, FloorType floorType) : base(imageGO, floorType)
        {
        }
    }


    class Floor : UnityObject
    {
        public int X;
        public int Y;
        public List<Item> Items = new List<Item>();
        public List<Creature> Creatures = new List<Creature>();
        public FloorType FloorType;

        public Floor(GameObject spriteGO) : base(spriteGO)
        {
        }
        public Floor(GameObject spriteGO, FloorType floorType) : base(spriteGO)
        {
            FloorType = floorType;
            var sprite = spriteGO.GetComponent<SpriteRenderer>();
            sprite.sortingOrder = (int)SpriteType.Floor;
        }

        public Floor Clone()
        {
            Floor clone = new Floor(CloneHelper.Clone(SpriteGO));
            return clone;
        }
    }
    enum FloorType
    {
        None = 0,
        Plain,
        Grassland,
        Forest,
        Mountain,
        River,
        Shore,
    }
    public enum ItemType
    {
        None = 0,

        DoubleAttack = 1,
        DoubleDefend = 2,
        DoubleSpeed = 3,
    }
    public enum BlockType
    {
        None = 0,
        Stone = 1,
        Tree = 2,
        Creature = 3,
    }
    class BlockItem : Item
    {
        public bool IsBlock = true;
        public BlockType BlockType;


        public BlockItem(GameObject imageGO, BlockType blockType) : base(imageGO)
        {
            BlockType = blockType;
        }
    }

    class UnityObject
    {
        public GameObject SpriteGO;

        public UnityObject(GameObject imageGO)
        {
            SpriteGO = imageGO;
        }
    }
    class Item : UnityObject
    {
        public string Name;
        public ItemType ItemType;

        public Item(GameObject spriteGO) : base(spriteGO)
        {
            var sprite = spriteGO.GetComponent<SpriteRenderer>();
            sprite.sortingOrder = (int)SpriteType.Item;
        }
    }
    class Creature : UnityObject, AttackableCreature
    {
        public string Name;

        public Creature(GameObject spriteGO) : base(spriteGO)
        {
            var sprite = spriteGO.GetComponent<SpriteRenderer>();
            sprite.sortingOrder = (int)SpriteType.Creature;
        }

        #region AttackableCreature
        public int Attr_HP { set; get; }
        public int Attr_AttackMax { set; get; }
        public int Attr_AttackMin { set; get; }
        public int Attr_Defend { set; get; }
        public Dictionary<Buff, int> Buffs { set; get; } = new Dictionary<Buff, int>();
        public AttackResult Attack(AttackableCreature creature, Dictionary<Buff, int> buffs)
        {
            AttackResult result = new AttackResult();
            var real_AttackMin = buffs.Keys.Any(c => c == Buff.DoubleAttack) ? Attr_AttackMin * 2 : Attr_AttackMin;
            var real_AttackMax = buffs.Keys.Any(c => c == Buff.DoubleAttack) ? Attr_AttackMax * 2 : Attr_AttackMax;
            var real_Defend = Buffs.Keys.Any(c => c == Buff.DoubleDefend) ? Attr_Defend * 2 : Attr_Defend;
            result.ChangedHP = Mathf.Max(0, Random.Range(real_AttackMin, real_AttackMax) - creature.Attr_Defend);
            creature.Attr_HP -= result.ChangedHP;
            result.IsDead = creature.Attr_HP <= 0;
            return result;
        }
        public string GetAttackableCreatureDiscription()
        {
            var real_AttackMin = Buffs.Keys.Any(c => c == Buff.DoubleAttack) ? Attr_AttackMin * 2 : Attr_AttackMin;
            var real_AttackMax = Buffs.Keys.Any(c => c == Buff.DoubleAttack) ? Attr_AttackMax * 2 : Attr_AttackMax;
            var real_Defend = Buffs.Keys.Any(c => c == Buff.DoubleDefend) ? Attr_Defend * 2 : Attr_Defend;
            return $@"当前状态<生命:{Attr_HP},攻击:{real_AttackMin}-{real_AttackMax},防御:{real_Defend}>";
        }
        #endregion
    }
    class OperationData
    {
        public bool IsOperating { get { return IsMovingSetup | IsMoving | IsCollecttingSetup | IsAttackingSetup; } }


        public bool IsAttackingSetup = false;
        public bool IsMovingSetup = false;
        public bool IsMoving = false;
        public bool IsCollecttingSetup = false;
    }

    public enum Buff
    {
        None = 0,
        DoubleAttack = 1,
        DoubleDefend = 2,
        DoubleSpeed = 3,
    }
    class Player : Creature
    {
        public GameBoard GameBoard { get; internal set; }
        public Vector3 CameraOffSet { get; internal set; }

        public GameObject PlayerGO;
        public OperationData OperationData = new OperationData();
        public int X;
        public int Y;
        public List<Item> Items = new List<Item>();
        public List<FastItem> FastItems = new List<FastItem>();

        public Player(GameObject imageGO) : base(imageGO)
        {
            Name = "Player";
            PlayerGO = imageGO;
            CameraOffSet = new Vector3(0, 0, -2);
        }

        public void DisplaySmoothMove(GameObject go, Movement m)
        {
            float elapsedTime = Time.time - m.moveStartTime;
            float clampTime = Mathf.Clamp01(elapsedTime / m.moveDuration);
            Vector2 newPosition = Vector2.Lerp(m.startPosition, m.targetPosition, clampTime);
            go.transform.position = newPosition;
            VLDebug.DelegateDebug(() =>
            {
                Debug.Log($"DisplaySmoothMove X:{newPosition.x},Y:{newPosition.y}");
            });
            if (clampTime >= 1.0f)
            {
                OperationData.IsMoving = false;
                OperationData.IsMovingSetup = false;
            }
        }

        internal void Move(Movement movement)
        {
            X += movement.X;
            Y += movement.Y;
            VLDebug.DelegateDebug(() =>
            {
                Debug.Log($"Move X:{X},Y:{Y}");
            });
        }

        internal void UpdateBuffs()
        {
            foreach (var key in Buffs.Keys)
            {
                Buffs[key]--;
                if (Buffs[key] == 0)
                {
                    Buffs.Remove(key);
                    GameBoard.DisplayText($"{key.ToString()},不再生效");
                }
                else
                {
                    GameBoard.DisplayText($"{key.ToString()},剩余({ Buffs[key]})回合");
                }
            }
        }

        internal void Collect(Floor[,] floors)
        {
            GameBoard.DisplayText($"---拾取---");
            if (floors[X, Y].Items.Count == 0)
            {
                GameBoard.DisplayText($"{Name}捡了一把空气");
                return;
            }
            for (int i = floors[X, Y].Items.Count - 1; i >= 0; i--)
            {
                var item = floors[X, Y].Items[i];
                Items.Add(item);
                floors[X, Y].Items.Remove(item);
                Object.Destroy(item.SpriteGO);
                GameBoard.DisplayText($"{Name}拾取了{item.Name},{item.ItemType}");

                var fastItem = FastItems.FirstOrDefault(c => c.Item == null);
                fastItem.AddItem(item);
            }
        }

        internal void Attack(Floor[,] floors)
        {
            GameBoard.DisplayText($"---攻击---");
            var creature = floors[X, Y].Creatures.FirstOrDefault();
            if (creature == null)
            {
                GameBoard.DisplayText($"{Name}打在了空气中");
                return;
            }
            GameBoard.DisplayText($"{Name}:{GetAttackableCreatureDiscription()}");
            GameBoard.DisplayText($"{creature.Name}:{creature.GetAttackableCreatureDiscription()}");
            var result = Attack(creature, Buffs);
            GameBoard.DisplayText($"{Name}攻击了{creature.Name},造成了{result.ChangedHP}点伤害");
            if (result.IsDead)
            {
                floors[X, Y].Creatures.Remove(creature);
                Object.Destroy(creature.SpriteGO);
                GameBoard.DisplayText($"{creature.Name}被打倒了");
            }
            else
            {
                result = creature.Attack(this, Buffs);
                GameBoard.DisplayText($"{creature.Name}攻击了{Name},造成了{result.ChangedHP}点伤害");
                if (result.IsDead)
                {
                    PlayerGO.SetActive(false);
                    GameBoard.DisplayText($"{Name}被打倒了");
                }
            }
        }

        internal void UseFastItem(string v)
        {
            GameBoard.DisplayText($"---使用道具---");
            var fastItem = FastItems.FirstOrDefault(c => c.Key == v);
            if (fastItem == null)
            {
                GameBoard.DisplayText($"{Name}喝了口空气");
                return;
            }
            var buff = Dictionaries.BuffDic[fastItem.Item.ItemType];
            Buffs.Add(buff.Key, buff.Value);
            GameBoard.DisplayText($"{Name}使用了{buff.Key},持续({ buff.Value})回合");

            //二步走
            //操作 界面对象
            //操作 逻辑对象
            Gaming0316.Destroy(fastItem.Item.SpriteGO);//界面
            Items.Remove(fastItem.Item);//包裹
            fastItem.Item = null;//快捷栏
        }
    }
    interface AttackableCreature
    {
        int Attr_HP { set; get; }
        int Attr_AttackMax { set; get; }
        int Attr_AttackMin { set; get; }
        int Attr_Defend { set; get; }
        Dictionary<Buff, int> Buffs { set; get; }
        AttackResult Attack(AttackableCreature creature, Dictionary<Buff, int> buffs);
        string GetAttackableCreatureDiscription();
    }
    class AttackResult
    {
        public int ChangedHP;
        public bool IsDead;
    }

    public static partial class ValueEx
    {
        public static void ToStartMenuButtonStyle(this GameObject startGameBtn)
        {
            var image = startGameBtn.GetComponent<Image>();
            image.color = Color.black;
            var canvasGroup = startGameBtn.AddComponent<CanvasGroup>();
            canvasGroup.alpha = 0.6f;
            var text = startGameBtn.GetComponentInChildren<Text>();
            text.color = Color.white;
            text.fontSize = 50;
            var rectTransform = startGameBtn.GetComponent<RectTransform>();
            rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
            rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
            rectTransform.localPosition = new Vector3(0f, 0f, 0f);
            rectTransform.sizeDelta = new Vector2(320, 60);
        }
    }
}