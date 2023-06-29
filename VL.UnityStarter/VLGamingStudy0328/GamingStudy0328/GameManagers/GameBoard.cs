using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Assets.Scenes.VLGamingStudy0328
{
    public class GameBoard
    {
        public static float Width = 2560;
        public static float Height = 1440;
        public static int XSteps = 160;
        public static int YSteps = 90;
        public static float StepX = 0.16f;
        public static float StepY = 0.16f;
        public Floor[,] Floors;
        internal float floorWidth;
        internal float floorHeight;
        internal Player Player;
        public bool IsResourceReady { get; internal set; }
        public GameObject CameraGO { get; internal set; }
        public Camera Camera { get; internal set; }
        public GameObject GameboardGO { get; internal set; }
        public GameObject CanvasGO { get; private set; }
        public GameObject ScrollViewGO { get; set; }
        public GameObject ScrollTextGO { get; set; }
        public Text ScrollText { get; set; }

        #region Resources
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
        public Creature Resource_Player { get; internal set; }
        public List<Tree> Resource_Trees { get; internal set; }
        public Wheatfield Resource_Wheatfield { get; internal set; }
        public List<Town> Resource_Towns { get; internal set; }
        public List<BigTown> Resource_BigTowns { get; internal set; }
        public List<EnermyTown> Resource_Orc_Towns { get; internal set; }
        public List<EnermyTown> Resource_Orc_Towns2 { get; internal set; }
        public List<EnermyTown> Resource_Orc_Towns3 { get; internal set; }
        public List<BigEnermyTown> Resource_Orc_BigTowns { get; internal set; }
        public List<Cave> Resource_Caves { get; internal set; }
        public Creature Resource_ArcherGoblin { get; internal set; }
        public Creature Resource_ClubGoblin { get; internal set; }
        public Creature Resource_FarmerGoblin { get; internal set; }
        public Creature Resource_KamikazeGoblin { get; internal set; }
        public Creature Resource_Minotaur { get; internal set; }
        public Creature Resource_Orc { get; internal set; }
        public Creature Resource_OrcMage { get; internal set; }
        public Creature Resource_OrcShaman { get; internal set; }
        public Creature Resource_SpearGoblin { get; internal set; }
        public Creature Resource_ArmouredRedDemon { get; internal set; }
        public Creature Resource_PurpleDemon { get; internal set; }
        public Creature Resource_RedDemon { get; internal set; }
        #endregion

        public GameBoard()
        {
            Floors = new Floor[XSteps, YSteps];
        }

        private bool canInput = true;
        private IEnumerator ResetInput(float interval = 0.5f)
        {
            yield return new WaitForSeconds(interval);
            canInput = true;
        }

        public void PlayerOperation()
        {
            if (Player == null || Player.SpriteGO == null)
                return;
            switch (Player.OperationStatus)
            {
                case OperationStatus.None:
                    break;
                case OperationStatus.TurnOn:
                    if (!canInput)
                        return;
                    if (Input.GetKey(KeyCode.W))
                    {
                        Player.OperationStatus = OperationStatus.Input_Move;
                        Player.Movement = new CreatureMove(0, 1);
                    }
                    else if (Input.GetKey(KeyCode.S))
                    {
                        Player.OperationStatus = OperationStatus.Input_Move;
                        Player.Movement = new CreatureMove(0, -1);
                    }
                    else if (Input.GetKey(KeyCode.A))
                    {
                        Player.OperationStatus = OperationStatus.Input_Move;
                        Player.Movement = new CreatureMove(-1, 0);
                    }
                    else if (Input.GetKey(KeyCode.D))
                    {
                        Player.OperationStatus = OperationStatus.Input_Move;
                        Player.Movement = new CreatureMove(1, 0);
                    }
                    else if (Input.GetKey(KeyCode.Space))
                    {
                        canInput = false;
                        Player.OperationStatus = OperationStatus.Do_Collect;
                        GameManager.instance.StartCoroutine(ResetInput(0.5f));
                    }
                    else if (Input.GetKey(KeyCode.C))
                    {
                        canInput = false;
                        Player.Check(Floors);
                        GameManager.instance.StartCoroutine(ResetInput(0.5f));
                    }
                    else if (Input.GetKey(KeyCode.Alpha1))
                    {
                        Player.UseFastItem("1");
                    }
                    else if (Input.GetKey(KeyCode.Alpha2))
                    {
                        Player.UseFastItem("2");
                    }
                    else if (Input.GetAxis("Mouse ScrollWheel") != 0)
                    {
                        var value = Input.GetAxis("Mouse ScrollWheel");
                        if (value > 0 && Player.CameraOffSet.z <= -1)
                        {
                            Player.CameraOffSet += new Vector3(0, 0, 0.5f);
                        }
                        else if (value < 0 && Player.CameraOffSet.z >= -3)
                        {
                            Player.CameraOffSet -= new Vector3(0, 0, 0.5f);
                        }
                    }
                    break;
                case OperationStatus.Input_Move:
                    if (Player.CheckOverEdge(Floors))
                    {
                        Player.Movement.CalculateColliderMovement(Player.PlayerGO.transform.position);
                        GameManager.instance.GameBoard.DisplayText($"前方无路可走");

                        Player.OperationStatus = OperationStatus.Do_AttemptMove;
                    }
                    else if (Player.CheckCollider(Floors))
                    {
                        Player.Movement.CalculateColliderMovement(Player.PlayerGO.transform.position);
                        GameManager.instance.GameBoard.DisplayText($"前方无法通行");

                        Player.OperationStatus = OperationStatus.Do_AttemptMove;
                    }
                    else if (Player.CheckCloseAttack(Floors))
                    {
                        Player.Movement.CalculateAttectMovement(Player.PlayerGO.transform.position);
                        Player.OperationStatus = OperationStatus.Do_CloseAttackMove;
                    }
                    else
                    {
                        Player.Movement.CalculateMovement(Player.PlayerGO.transform.position);
                        Player.Move(Floors);
                        GameManager.instance.GameBoard.DisplayText($"移动 X:{Player.X},Y:{Player.Y}");
                        Player.UpdateBuffs(GameManager.instance.GameBoard);
                        SoundManager.instance.PlaySound(VLDictionaries.GetCodeAudioByCode(SoundAudioType.Move_Grass));

                        Player.OperationStatus = OperationStatus.Do_Move;
                    }
                    break;
                case OperationStatus.Do_AttemptMove:
                    var clampTime = Player.DisplaySmoothMove(Player.PlayerGO, Player.Movement, 0.05f);
                    if (clampTime >= 1.0f)
                    {
                        Player.Movement.moveStartTime = Time.time;
                        var orient = Player.Movement.startPosition;
                        Player.Movement.startPosition = Player.Movement.targetPosition;
                        Player.Movement.targetPosition = orient;
                        Player.OperationStatus = OperationStatus.Do_AttemptMoveBack;
                        SoundManager.instance.PlaySound(VLDictionaries.GetCodeAudioByCode(SoundAudioType.Collider));
                    }
                    break;
                case OperationStatus.Do_AttemptMoveBack:
                    clampTime = Player.DisplaySmoothMove(Player.PlayerGO, Player.Movement, 0.15f);
                    if (clampTime >= 1.0f)
                        Player.OperationStatus = OperationStatus.TurnOn;
                    break;
                case OperationStatus.Do_Move:
                    clampTime = Player.DisplaySmoothMove(Player.PlayerGO, Player.Movement);
                    if (clampTime >= 1.0f)
                    {
                        Player.OperationStatus = OperationStatus.TurnOff;
                        Enermies.ForEach(c => c.OperationStatus = OperationStatus.TurnOn);
                    }
                    break;
                case OperationStatus.Do_Collect:
                    Player.Collect(Floors);
                    Player.UpdateBuffs(this);
                    Player.OperationStatus = OperationStatus.TurnOff;
                    Enermies.ForEach(c => c.OperationStatus = OperationStatus.TurnOn);
                    break;
                case OperationStatus.Do_CloseAttackMove:
                    clampTime = Player.DisplaySmoothMove(Player.PlayerGO, Player.Movement, 0.05f);
                    if (clampTime >= 1.0f)
                    {
                        Player.Movement.moveStartTime = Time.time;
                        var orient = Player.Movement.startPosition;
                        Player.Movement.startPosition = Player.Movement.targetPosition;
                        Player.Movement.targetPosition = orient;
                        SoundManager.instance.PlaySound(VLDictionaries.GetCodeAudioByCode(SoundAudioType.Sword_Cut));
                        Player.OperationStatus = OperationStatus.Do_CloseAttackMoveBack;
                    }
                    break;
                case OperationStatus.Do_CloseAttackMoveBack:
                    clampTime = Player.DisplaySmoothMove(Player.PlayerGO, Player.Movement, 0.15f);
                    if (clampTime >= 1.0f)
                        Player.OperationStatus = OperationStatus.Do_Attack;
                    break;
                case OperationStatus.Do_Attack:
                    var result = Player.Attack();
                    Player.UpdateBuffs(this);
                    if (result.IsDead)
                    {
                        SoundManager.instance.PlaySecondSound(result.Creature.DiedSounds);
                        result.Creature.Defeated();
                    }
                    else
                    {
                        result.Creature.UpdateBloodBar();
                    }
                    Player.OperationStatus = OperationStatus.TurnOff;
                    Enermies.ForEach(c => c.OperationStatus = OperationStatus.TurnOn);
                    break;
                default:
                    break;
            }
        }

        public void EnermyOperation()
        {
            //创造
            if (Enermies.Any(c => c.OperationStatus != OperationStatus.TurnOff))
            {
                //行动
                foreach (var enermy in Enermies)
                {
                    switch (enermy.OperationStatus)
                    {
                        case OperationStatus.TurnOn:
                            if (Mathf.Abs(Player.X + Player.Y - enermy.X - enermy.Y) > 30)
                            {
                                enermy.OperationStatus = OperationStatus.TurnOff;
                                continue;
                            }

                            if (enermy.CanAttack(Player))
                            {
                                var x = enermy.X == Player.X ? 0 : enermy.X > Player.X ? -1 : 1;
                                var y = enermy.Y == Player.Y ? 0 : enermy.Y > Player.Y ? -1 : 1;
                                enermy.Movement = new CreatureMove(x, y);
                                enermy.Movement.CalculateAttectMovement(enermy.SpriteGO.transform.position);
                                enermy.OperationStatus = OperationStatus.Do_CloseAttackMove;
                            }
                            else if (Mathf.Abs(Player.X + Player.Y - enermy.X - enermy.Y) < 10)
                            {
                                //跟踪
                                var x = enermy.X == Player.X ? 0 : enermy.X > Player.X ? -1 : 1;
                                var y = enermy.Y == Player.Y ? 0 : enermy.Y > Player.Y ? -1 : 1;
                                enermy.Movement = new CreatureMove(x, y);
                                enermy.Movement.CalculateMovement(enermy.SpriteGO.transform.position);
                                //TODO 需要进行跨地形检测
                                enermy.OperationStatus = OperationStatus.Input_Move;
                            }
                            else
                            {
                                //漫步
                                var x = Random.Range(-1, 2);
                                var y = Random.Range(-1, 2);
                                enermy.Movement = new CreatureMove(x, y);
                                enermy.Movement.CalculateMovement(enermy.SpriteGO.transform.position);
                                enermy.OperationStatus = OperationStatus.Input_Move;
                            }
                            break;
                        case OperationStatus.Input_Move:
                            if (enermy.CheckOverEdge(Floors))
                            {
                                enermy.OperationStatus = OperationStatus.TurnOff;
                            }
                            else
                            {
                                enermy.Move(Floors);
                                enermy.OperationStatus = OperationStatus.Do_Move;
                            }
                            break;
                        case OperationStatus.Do_Move:
                            var clampTime = enermy.DisplaySmoothMove(enermy.SpriteGO, enermy.Movement);
                            if (clampTime >= 1.0f)
                            {
                                enermy.OperationStatus = OperationStatus.TurnOff;
                            }
                            break;
                        case OperationStatus.Do_CloseAttackMove:
                            clampTime = enermy.DisplaySmoothMove(enermy.SpriteGO, enermy.Movement, 0.05f);
                            if (clampTime >= 1.0f)
                            {
                                enermy.Movement.moveStartTime = Time.time;
                                var orient = enermy.Movement.startPosition;
                                enermy.Movement.startPosition = enermy.Movement.targetPosition;
                                enermy.Movement.targetPosition = orient;
                                enermy.OperationStatus = OperationStatus.Do_CloseAttackMoveBack;
                            }
                            break;
                        case OperationStatus.Do_CloseAttackMoveBack:
                            clampTime = enermy.DisplaySmoothMove(enermy.SpriteGO, enermy.Movement, 0.15f);
                            if (clampTime >= 1.0f)
                                enermy.OperationStatus = OperationStatus.Do_Attack;
                            break;
                        case OperationStatus.Do_Attack:
                            var result = enermy.Attack();
                            if (result.IsDead)
                            {
                                SoundManager.instance.PlaySound(result.Creature.DiedSounds);
                                result.Creature.Defeated();
                            }
                            else
                            {
                                result.Creature.UpdateBloodBar();
                            }
                            enermy.OperationStatus = OperationStatus.TurnOff;
                            break;
                        case OperationStatus.Do_AttemptMove:
                        case OperationStatus.Do_AttemptMoveBack:
                        case OperationStatus.Do_Collect:
                        default:
                            enermy.OperationStatus = OperationStatus.TurnOff;
                            break;
                    }
                }
            }
            else
            {
                GenerateEnermyBuidings();
                foreach (var item in EnemyTowns)
                {
                    item.GenerateEnermy(this);
                }
                Player.OperationStatus = OperationStatus.TurnOn;
            }
        }

        private void GenerateEnermyBuidings()
        {
            if (EnemyTowns.Count > 30)
                return;
            //TODO
        }

        internal Object PreInit()
        {
            //分层管理
            FloorsGO = new GameObject("Floors"); FloorsGO.SetParent(GameManager.instance.gameboardGO);
            ItemsGO = new GameObject("Items"); ItemsGO.SetParent(GameManager.instance.gameboardGO);
            CavesGO = new GameObject("Caves"); CavesGO.SetParent(GameManager.instance.gameboardGO);
            BuildingsGO = new GameObject("Buildings"); BuildingsGO.SetParent(GameManager.instance.gameboardGO);
            EnermyBuidingsGO = new GameObject("EnermyBuidings"); EnermyBuidingsGO.SetParent(GameManager.instance.gameboardGO);
            CreaturesGO = new GameObject("Creatures"); CreaturesGO.SetParent(GameManager.instance.gameboardGO);
            //创建文本输出框
            CanvasGO = VLCreater.CreateCanvas("Canvas", GameManager.instance.gameboardGO);
            ScrollViewGO = VLCreater.CreateScrollView("TextDisplay", CanvasGO);
            var rect = ScrollViewGO.GetComponent<RectTransform>();
            rect.anchorMin = new Vector2(0, 1);
            rect.anchorMax = new Vector2(0, 1);
            rect.pivot = new Vector2(0, 1);
            rect.anchoredPosition = new Vector2(0, 0);
            rect.sizeDelta = new Vector2(800, 800);
            var canvasGroup = ScrollViewGO.AddComponent<CanvasGroup>();
            canvasGroup.alpha = 0.6f;
            ScrollTextGO = VLCreater.CreateText("ScrollText", CanvasGO);
            rect = ScrollTextGO.GetComponent<RectTransform>();
            rect.anchorMin = new Vector2(0, 1);
            rect.anchorMax = new Vector2(0, 1);
            rect.pivot = new Vector2(0, 1);
            rect.anchoredPosition = new Vector2(20, -20);
            rect.sizeDelta = new Vector2(800, 800);
            ScrollText = ScrollTextGO.GetComponent<Text>();
            ScrollText.fontSize = 32;
            ScrollText.color = Color.black;
            ScrollText.alignment = TextAnchor.UpperLeft;

            return null;
        }

        public GameObject FloorsGO;
        public GameObject ItemsGO;
        public GameObject CavesGO;
        public GameObject BuildingsGO;
        public GameObject EnermyBuidingsGO;
        public GameObject CreaturesGO;

        public List<Town> Towns;
        public List<EnermyTown> EnemyTowns;
        public List<Cave> Caves;
        public List<Creature> Enermies { set; get; } = new List<Creature>();
        public GameObject Resource_BloodBar { get; internal set; }
        public GameObject Resource_MagicBar { get; internal set; }

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

        public void DisplayText(string message)
        {
            var texts = ScrollText.text.Split('\n').ToList();
            texts.Add(message);
            while (texts.Count > 20)
                texts.RemoveAt(0);
            ScrollText.text = string.Join("\n", texts);
        }

        internal object InitTowns()
        {
            SeedRandom sr = new SeedRandom(500, 1);
            var resources = Resource_Towns;
            var target = BuildingsGO;
            Towns = Init1StepItem(sr, resources, target, (f) => { return f.Items.Count > 0; });
            return null;
        }

        internal object InitEnermyTowns()
        {
            SeedRandom sr = new SeedRandom(500, 1);
            var resources = Resource_Orc_Towns;
            var target = EnermyBuidingsGO;
            EnemyTowns = Init1StepItem(sr, resources, target, (f) => { return f.Items.Count > 0; });
            return null;
        }

        internal object InitCaves()
        {
            SeedRandom sr = new SeedRandom(1000, 1);
            var resources = Resource_Caves;
            var target = CavesGO;
            Caves = Init1StepItem(sr, resources, target, (f) => { return f.Items.Count > 0; });
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

        internal object InitStones()
        {
            SeedRandom sr = new SeedRandom(100, 1);
            var resources = new List<BlockItem>() { Resource_Mountains_StoneOre, Resource_Mountains_CutterOre };
            var target = ItemsGO;
            Init1StepItem(sr, resources, target, (f) => { return f.Items.Count > 0; });
            return null;
        }

        internal object InitTrees()
        {
            SeedRandom sr = new SeedRandom(100, 40);
            var resources = Resource_Trees;
            var target = ItemsGO;
            Init1StepItem(sr, resources, target, (f) => { return f.Items.Count > 0; }, (t) => { return Object.Instantiate(t.OrientSpriteGO); });
            return null;
        }


        internal object InitPlayer()
        {
            Player = new Player(Resource_Player.SpriteGO);
            Player.DiedSounds = Resource_Player.DiedSounds;
            Player.X = 20;
            Player.Y = 20;
            Player.PlayerGO.transform.position = GetPosition(Player.X, Player.Y);
            Player.SpriteGO.SetParent(GameboardGO);
            Player.OperationStatus = OperationStatus.TurnOn;
            GameManager.instance.GameBoard = this;
            GameManager.instance.GameBoard.Floors[Player.X, Player.Y].Creatures.Add(Player);
            //数值系统
            var creatureModel = VLDictionaries.CodeCreatureMathModels[nameof(Player)];
            creatureModel.Decorate(Player);
            //对话系统
            Player.DialogueGO = VLCreaterPlus.CreateDialogue("dialogue", Player.PlayerGO);
            return null;
        }

        internal Vector2 GetPosition(int x, int y)
        {
            return new Vector2(x * StepX, y * StepY);
        }

        internal object InitCamera()
        {
            var cameraGO = VLCreater.CreateCamera("Camera_Player", GameboardGO);
            var camera2D = cameraGO.GetComponent<Camera>();
            var transform = camera2D.transform;
            transform.position = Player.PlayerGO.transform.position + Player.CameraOffSet;
            transform.rotation = Player.PlayerGO.transform.rotation;
            camera2D.backgroundColor = "#282828".ToColor();
            CameraGO = cameraGO;
            Camera = camera2D;
            return null;
        }

        private List<T> Init1StepItem<T>(SeedRandom sr, List<T> resources, GameObject target, System.Predicate<Floor> skipLogic = null, System.Func<T, GameObject> setSpriteForMultipleSpriteObject = null)
            where T : Item, ICloneableObject<T>
        {
            List<T> initItems = new List<T>();
            for (int i = 0; i < XSteps; i++)
            {
                for (int j = 0; j < YSteps; j++)
                {
                    if (sr.GetNext() == 0)
                        continue;

                    if (skipLogic != null && skipLogic(Floors[i, j]))
                        continue;

                    T resource = resources[Random.Range(0, resources.Count())];
                    T t = resource.Clone();
                    if (setSpriteForMultipleSpriteObject != null)
                        t.SpriteGO = setSpriteForMultipleSpriteObject(t);
                    var sprite = t.SpriteGO.GetComponent<SpriteRenderer>();
                    sprite.transform.position = GetPosition(i, j);
                    t.SpriteGO.SetParent(target);
                    t.X = i;
                    t.Y = j;
                    Floors[i, j].Items.Add(t);
                    initItems.Add(t);
                }
            }
            return initItems;
        }
        private List<Item> Init4StepItem(SeedRandom sr, Item[] resources, GameObject[] targets, System.Predicate<Floor> skipLogic = null)
        {
            List<Item> initItems = new List<Item>();
            for (int i = 0; i < XSteps; i++)
            {
                for (int j = 0; j < YSteps; j++)
                {
                    if (sr.GetNext() == 0)
                        continue;

                    if (skipLogic != null && skipLogic(Floors[i, j]))
                        continue;


                }
            }
            return initItems;
        }
    }
}
