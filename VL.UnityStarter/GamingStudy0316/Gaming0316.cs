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

        public static Dictionary<string, string> CodeDescriptions = new Dictionary<string, string>()
        {
            {"Grass_1","Grass_1"},
            {"Grass_2","Grass_2"},
            {"Grass_3","Grass_3"},
            {"Grass_4","Grass_4"},
            {"TexturedGrass_1","TexturedGrass_1"},
            {"TexturedGrass_2","TexturedGrass_2"},
            {"TexturedGrass_4","TexturedGrass_4"},
            {"TexturedGrass_5","TexturedGrass_5"},
            {"Shore_4","Shore_4"},
            {"Shore_0","Shore_0"},
            {"Shore_1","Shore_1"},
            {"Shore_2","Shore_2"},
            {"Shore_3","Shore_3"},
            {"Cliff_0","Cliff_0"},
            {"Cliff_1","Cliff_1"},
            {"Cliff_2","Cliff_2"},
            {"Cliff_5","Cliff_5"},
            {"Cliff_6","Cliff_6"},
            {"Cliff_7","Cliff_7"},
            {"Cliff_10","Cliff_10"},
            {"Cliff_11","Cliff_11"},
            {"Cliff_12","Cliff_12"},
            {"Cliff_9","Cliff_9"},
            {"Cliff_38","Cliff_38"},
            {"Cliff_39","Cliff_39"},
            {"Cliff_40","Cliff_40"},
            {"Cliff_41","Cliff_41"},
            {"Cliff_42","Cliff_42"},
            {"Cliff_43","Cliff_43"},
            {"Cliff_48","Cliff_48"},
            {"Cliff_49","Cliff_49"},
            {"Cliff_50","Cliff_50"},
            {"Cliff_8","Cliff_8"},
            {"Cliff_4","Cliff_4"},
            {"Cliff_3","Cliff_3"},
            {"Cliff_15","Cliff_15"},
            {"Cliff_16","Cliff_16"},
            {"Cliff_22","Cliff_22"},
            {"Cliff_23","Cliff_23"},
            {"PineTrees_1","PineTrees_1"},
            {"PineTrees_0","PineTrees_0"},
            {"Trees_0","这是一片森林,有斧头的话,你可以尝试砍伐一些树木1"},
            {"Trees_1","这是一片森林,有斧头的话,你可以尝试砍伐一些树木2"},
            {"Trees_2","这是一片森林,有斧头的话,你可以尝试砍伐一些树木3"},
            {"Trees_3","这是一片森林,有斧头的话,你可以尝试砍伐一些树木4"},
            {"Wheatfield_0","Wheatfield_0"},
            {"Wheatfield_1","Wheatfield_1"},
            {"Wheatfield_2","Wheatfield_2"},
            {"Wheatfield_3","Wheatfield_3"},
            {"CaveV2_0","这里有一个废弃的矿坑,入口散落着碎石块."},
            {"CaveV2_1","这里有一个废弃的矿坑,入口散落着2"},
            {"CaveV2_2","这里有一个废弃的矿坑,入口散落着3"},
            {"CaveV2_3","这里有一个废弃的矿坑,入口散落着4"},
            {"CaveV2_4","这里有一个废弃的矿坑,入口散落着5"},
            {"CaveV2_5","这里有一个废弃的矿坑,入口散落着6"},
            {"Chapels_0","Chapels_0"},
            {"Chapels_1","Chapels_1"},
            {"Chapels_2","Chapels_2"},
            {"Chapels_3","Chapels_3"},
            {"Chapels_4","Chapels_4"},
            {"Chapels_5","Chapels_5"},
            {"Keep_0","这是一个小城镇,里面冉冉燃起了炊烟1"},
            {"Keep_1","这是一个小城镇,里面冉冉燃起了炊烟2"},
            {"Keep_6","这是一个小城镇,里面冉冉燃起了炊烟3"},
            {"Keep_7","这是一个小城镇,里面冉冉燃起了炊烟4"},
            {"Keep_4","这是一个小城镇,里面冉冉燃起了炊烟5"},
            {"Keep_5","这是一个小城镇,里面冉冉燃起了炊烟6"},
            {"Keep_10","这是一个小城镇,里面冉冉燃起了炊烟7"},
            {"Keep_11","这是一个小城镇,里面冉冉燃起了炊烟8"},
            {"AllBuildings-Preview_68","哥布林的巢穴,入口混乱不堪,掺杂着血迹1"},
            {"AllBuildings-Preview_84","哥布林的巢穴,入口混乱不堪,掺杂着血迹2"},
            {"AllBuildings-Preview_100","哥布林的巢穴,入口混乱不堪,掺杂着血迹3"},
            {"AllBuildings-Preview_115","哥布林的巢穴,入口混乱不堪,掺杂着血迹4"},
            {"AllBuildings-Preview_116","哥布林的巢穴,入口混乱不堪,掺杂着血迹5"},
            {"AllBuildings-Preview_87","哥布林的巢穴,入口混乱不堪,掺杂着血迹6"},
            {"AllBuildings-Preview_145","哥布林的巢穴,入口混乱不堪,掺杂着血迹7"},
            {"AllBuildings-Preview_161","哥布林的巢穴,入口混乱不堪,掺杂着血迹8"},
            {"AllBuildings-Preview_177","哥布林的巢穴,入口混乱不堪,掺杂着血迹9"},
            {"AllBuildings-Preview_165","哥布林的巢穴,入口混乱不堪,掺杂着血迹10"},
            {"AllBuildings-Preview_166","哥布林的巢穴,入口混乱不堪,掺杂着血迹11"},
            {"AllBuildings-Preview_167","哥布林的巢穴,入口混乱不堪,掺杂着血迹12"},
            {"AllBuildings-Preview_34","哥布林的巢穴,入口混乱不堪,掺杂着血迹13"},
            {"AllBuildings-Preview_35","AllBuildings-Preview_35"},
            {"AllBuildings-Preview_50","AllBuildings-Preview_50"},
            {"AllBuildings-Preview_51","AllBuildings-Preview_51"},
            {"AllBuildings-Preview_36","AllBuildings-Preview_36"},
            {"AllBuildings-Preview_37","AllBuildings-Preview_37"},
            {"AllBuildings-Preview_52","AllBuildings-Preview_52"},
            {"AllBuildings-Preview_53","AllBuildings-Preview_53"},
            {"AllBuildings-Preview_38","AllBuildings-Preview_38"},
            {"AllBuildings-Preview_39","AllBuildings-Preview_39"},
            {"AllBuildings-Preview_54","AllBuildings-Preview_54"},
            {"AllBuildings-Preview_55","AllBuildings-Preview_55"},
        };
        public static string GetDescriptionByCode(string name)
        {
            return !string.IsNullOrEmpty(name) && Dictionaries.CodeDescriptions.ContainsKey(name) ? Dictionaries.CodeDescriptions[name] : "???";
        }

        public static Dictionary<string, CreatureMathModel> CodeCreatureMathModels = new Dictionary<string, CreatureMathModel>()
        {

            {nameof(Player),new CreatureMathModel(){
                Attr_AttackMax_from = 17,
                Attr_AttackMax_to = 20,
                Attr_AttackMin_from=4,
                Attr_AttackMin_to = 6,
                Attr_HP_from=100,
                Attr_HP_to = 100,
                Attr_Defend_from=3,
                Attr_Defend_to=6,
            } },
            {"ArcherGoblin",new CreatureMathModel(){
                Attr_AttackMax_from = 17,
                Attr_AttackMax_to = 20,
                Attr_AttackMin_from=4,
                Attr_AttackMin_to = 6,
                Attr_HP_from=30,
                Attr_HP_to = 45,
                Attr_Defend_from=3,
                Attr_Defend_to=6,
            } },
            {"ClubGoblin",new CreatureMathModel(){
                Attr_AttackMax_from = 17,
                Attr_AttackMax_to = 20,
                Attr_AttackMin_from=14,
                Attr_AttackMin_to = 16,
                Attr_HP_from=60,
                Attr_HP_to = 75,
                Attr_Defend_from=6,
                Attr_Defend_to=7,} },
            {"FarmerGoblin",new CreatureMathModel(){
                Attr_AttackMax_from = 7,
                Attr_AttackMax_to = 10,
                Attr_AttackMin_from=4,
                Attr_AttackMin_to = 6,
                Attr_HP_from=50,
                Attr_HP_to = 65,
                Attr_Defend_from=1,
                Attr_Defend_to=2,} },
            {"KamikazeGoblin",new CreatureMathModel(){
                Attr_AttackMax_from = 7,
                Attr_AttackMax_to = 10,
                Attr_AttackMin_from=4,
                Attr_AttackMin_to = 6,
                Attr_HP_from=30,
                Attr_HP_to = 45,
                Attr_Defend_from=3,
                Attr_Defend_to=6,} },
            {"SpearGoblin",new CreatureMathModel(){
                Attr_AttackMax_from = 27,
                Attr_AttackMax_to = 20,
                Attr_AttackMin_from=14,
                Attr_AttackMin_to = 16,
                Attr_HP_from=60,
                Attr_HP_to = 75,
                Attr_Defend_from=11,
                Attr_Defend_to=12,} },
            {"Minotaur",new CreatureMathModel(){
                Attr_AttackMax_from = 47,
                Attr_AttackMax_to = 40,
                Attr_AttackMin_from=34,
                Attr_AttackMin_to = 36,
                Attr_HP_from=230,
                Attr_HP_to = 245,
                Attr_Defend_from=31,
                Attr_Defend_to=42,} },
            {"Orc",new CreatureMathModel(){
                Attr_AttackMax_from = 57,
                Attr_AttackMax_to = 60,
                Attr_AttackMin_from=44,
                Attr_AttackMin_to = 46,
                Attr_HP_from=130,
                Attr_HP_to = 145,
                Attr_Defend_from=21,
                Attr_Defend_to=22,} },
            {"OrcMage",new CreatureMathModel(){
                Attr_AttackMax_from = 7,
                Attr_AttackMax_to = 10,
                Attr_AttackMin_from=4,
                Attr_AttackMin_to = 6,
                Attr_HP_from=70,
                Attr_HP_to = 85,
                Attr_Defend_from=11,
                Attr_Defend_to=12, } },
            {"OrcShaman",new CreatureMathModel(){
                Attr_AttackMax_from = 7,
                Attr_AttackMax_to = 10,
                Attr_AttackMin_from=4,
                Attr_AttackMin_to = 6,
                Attr_HP_from=60,
                Attr_HP_to = 75,
                Attr_Defend_from=1,
                Attr_Defend_to=2,} },
            {"ArmouredRedDemon",new CreatureMathModel(){
                Attr_AttackMax_from = 71,
                Attr_AttackMax_to = 102,
                Attr_AttackMin_from=41,
                Attr_AttackMin_to = 62,
                Attr_HP_from=230,
                Attr_HP_to = 245,
                Attr_Defend_from=61,
                Attr_Defend_to=82,} },
            {"PurpleDemon",new CreatureMathModel(){
                Attr_AttackMax_from = 71,
                Attr_AttackMax_to = 102,
                Attr_AttackMin_from=41,
                Attr_AttackMin_to = 62,
                Attr_HP_from=230,
                Attr_HP_to = 245,
                Attr_Defend_from=61,
                Attr_Defend_to=82,} },
            {"RedDemon",new CreatureMathModel(){
                Attr_AttackMax_from = 71,
                Attr_AttackMax_to = 102,
                Attr_AttackMin_from=41,
                Attr_AttackMin_to = 62,
                Attr_HP_from=230,
                Attr_HP_to = 245,
                Attr_Defend_from=61,
                Attr_Defend_to=82,} },
        };

        public static Dictionary<SoundAudioType, List<AudioClip>> CodeAudios = new Dictionary<SoundAudioType, List<AudioClip>>();
        public static List<AudioClip> GetCodeAudioByCode(SoundAudioType type)
        {
            return type != SoundAudioType.None && CodeAudios.ContainsKey(type) ? Dictionaries.CodeAudios[type] : null;
        }

        static Dictionaries()
        {
            #region Audioes

            CodeAudios.Add(SoundAudioType.Move_Grass, new List<AudioClip>() { Resources.Load<AudioClip>("Audio/Move1")
            ,Resources.Load<AudioClip>("Audio/Move2")});
            CodeAudios.Add(SoundAudioType.Move_Stone, new List<AudioClip>() { Resources.Load<AudioClip>("Audio/Move_Stone")
            ,Resources.Load<AudioClip>("Audio/Move_Stone2")});
            CodeAudios.Add(SoundAudioType.Collider, new List<AudioClip>() { Resources.Load<AudioClip>("Audio/Collider") });
            CodeAudios.Add(SoundAudioType.CutTree, new List<AudioClip>() { Resources.Load<AudioClip>("Audio/CutTree") });
            CodeAudios.Add(SoundAudioType.Human_DeepHurt, new List<AudioClip>() { Resources.Load<AudioClip>("Audio/Human_DeepHurt")
                , Resources.Load<AudioClip>("Audio/Human_DeepHurt2") });
            CodeAudios.Add(SoundAudioType.Human_Hurt, new List<AudioClip>() { Resources.Load<AudioClip>("Audio/Human_Hurt")
                , Resources.Load<AudioClip>("Audio/Human_Hurt2") });
            CodeAudios.Add(SoundAudioType.Mining, new List<AudioClip>() { Resources.Load<AudioClip>("Audio/Mining") });
            CodeAudios.Add(SoundAudioType.Mining_Grass, new List<AudioClip>() { Resources.Load<AudioClip>("Audio/Mining_Grass") });
            CodeAudios.Add(SoundAudioType.Orc_Attack, new List<AudioClip>() { Resources.Load<AudioClip>("Audio/Orc_Attack1")
                , Resources.Load<AudioClip>("Audio/Orc_Attack2") });
            CodeAudios.Add(SoundAudioType.Orc_Die, new List<AudioClip>() { Resources.Load<AudioClip>("Audio/Orc_Die") });
            CodeAudios.Add(SoundAudioType.Orc_Hurt, new List<AudioClip>() { Resources.Load<AudioClip>("Audio/Orc_Hurt1")
                , Resources.Load<AudioClip>("Audio/Orc_Hurt2") });
            CodeAudios.Add(SoundAudioType.Sword_Cut, new List<AudioClip>() { Resources.Load<AudioClip>("Audio/Sword_Cut")
                , Resources.Load<AudioClip>("Audio/Sword_Cut2") });

            #endregion

        }
    }
    public enum SoundAudioType
    {
        None,
        Move_Grass,
        Move_Stone,
        CutTree,
        Human_DeepHurt,
        Human_Hurt,
        Mining,
        Mining_Grass,
        Orc_Attack,
        Orc_Die,
        Orc_Hurt,
        Sword_Cut,
        Collider,
    }

    public class CreatureMathModel
    {
        public int Attr_HP_from { set; get; }
        public int Attr_HP_to { set; get; }
        public int Attr_AttackMax_from { set; get; }
        public int Attr_AttackMax_to { set; get; }
        public int Attr_AttackMin_from { set; get; }
        public int Attr_AttackMin_to { set; get; }
        public int Attr_Defend_from { set; get; }
        public int Attr_Defend_to { set; get; }

        internal void Decorate(Creature creature)
        {
            creature.Attr_MaxHP = Random.Range(this.Attr_HP_from, this.Attr_HP_to);
            creature.Attr_HP = creature.Attr_MaxHP;
            creature.Attr_AttackMax = Random.Range(this.Attr_AttackMax_from, this.Attr_AttackMax_to);
            creature.Attr_AttackMin = Random.Range(this.Attr_AttackMin_from, this.Attr_AttackMin_to);
            creature.Attr_Defend = Random.Range(this.Attr_Defend_from, this.Attr_Defend_to);
        }
    }
    public class ResourceObject
    {
        public string Code;
        public string ImageName;
        public string CheckDescription;
    }
    public enum SpriteType
    {
        None = 0,
        Floor = 3,
        Item = 5,
        Creature = 9,
        HPMP_Bar = 10,
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
    public class Gaming0316 : MonoBehaviour
    {
        public static Gaming0316 instance = null;
        void Awake()
        {
            if (instance == null)
                instance = this;
            else if (instance != this)
                Destroy(gameObject);
            DontDestroyOnLoad(gameObject);
        }

        internal GameObject startGO { set; get; }
        internal GameObject assetGO { set; get; }
        internal GameObject gamingGO { set; get; }
        internal GameObject settingGO { set; get; }

        public GameBoard GameBoard { set; get; }

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
            GameBoard = new GameBoard();
            GameBoard.GamingGO = gamingGO;
            StartCoroutine(nameof(PrepareAsset), GameBoard);

            //背景音乐
            var audioSourceGO = VLCreater.CreateAudioSource();
            audioSourceGO.SetParent(instance.gameObject);
            var audioSource = audioSourceGO.GetComponent<AudioSource>();
            SoundManager.instance.MusicSource = audioSource;
            SoundManager.instance.MusicSource.name = nameof(SoundManager.MusicSource);
            SoundManager.instance.MainSoundSource = GameObject.Instantiate(audioSource, instance.gameObject.transform);
            SoundManager.instance.MainSoundSource.name = nameof(SoundManager.MainSoundSource);
            SoundManager.instance.SecondSoundSource = GameObject.Instantiate(audioSource, instance.gameObject.transform);
            SoundManager.instance.SecondSoundSource.name = nameof(SoundManager.MainSoundSource);

            AudioClip clip = Resources.Load<AudioClip>("Audio/Background");
            SoundManager.instance.PlayMusic(clip);

            Debug.Log($"Started");
        }

        void Update()
        {
            if (GameBoard == null || GameBoard.Player == null)
                return;
            if (GameBoard.Player.OperationStatus != OperationStatus.TurnOff)
            {
                GameBoard.PlayerOperation();
            }
            else
            {
                GameBoard.EnermyOperation();
            }
        }

        private void LateUpdate()
        {
            if (GameBoard == null || GameBoard.CameraGO == null || GameBoard.Player.PlayerGO == null)
                return;
            GameBoard.CameraGO.transform.position = GameBoard.Player.PlayerGO.transform.position + GameBoard.Player.CameraOffSet;
            //GameBoard.CameraGO.transform.rotation = GameBoard.Player.PlayerGO.transform.rotation;
        }

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
                SoundManager.instance.StopMusic();
                StartCoroutine(StartingGame());
            }
        }

        #region StartGame

        private bool isStarting = false;
        IEnumerator StartingGame()
        {
            while (!GameBoard.IsResourceReady)
            {
                Debug.Log("正在加载资源");
                yield return new WaitForSeconds(1f);
            }

            SoundManager.instance.StopMusic();

            Debug.Log($"StartingGame");
            isStarting = true;
            startGO.SetActive(false);
            gamingGO.SetActive(true);
            assetGO.SetActive(false);
            settingGO.SetActive(false);
            GameBoard.PreInit();
            GameBoard.DisplayText("开始生成地形");
            yield return GameBoard.InitFloors();
            GameBoard.DisplayText("开始生成城镇");
            yield return GameBoard.InitTowns();
            GameBoard.DisplayText("开始生成敌方城镇");
            yield return GameBoard.InitEnermyTowns();
            GameBoard.DisplayText("开始生成矿坑");
            yield return GameBoard.InitCaves();
            GameBoard.DisplayText("开始生成道路");
            yield return GameBoard.InitRoads();
            GameBoard.DisplayText("开始生成岩石");
            yield return GameBoard.InitStones();
            GameBoard.DisplayText("开始生成树木");
            yield return GameBoard.InitTrees();
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

        private void PrepareAsset(GameBoard gameBoard)
        {
            GameBoard.IsResourceReady = false;

            #region Images
            //血条
            var sprite = Resources.Load<Sprite>("vl/white");
            var spriteGO = VLCreater.CreateSprite(sprite, "BloodBar");
            spriteGO.transform.localScale = new Vector3(12, 1, 1);
            spriteGO.transform.localPosition = new Vector3(0, 0.09f, 0);
            var spriteRender = spriteGO.GetComponent<SpriteRenderer>();
            spriteRender.color = "#FF0000".ToColor();
            spriteRender.sortingOrder = (int)SpriteType.HPMP_Bar;
            GameBoard.Resource_BloodBar = spriteGO;
            sprite = Resources.Load<Sprite>("vl/white");
            spriteGO = VLCreater.CreateSprite(sprite, "MagicBar");
            spriteGO.transform.localScale = new Vector3(12, 1, 1);
            spriteGO.transform.localPosition = new Vector3(0, 0.08f, 0);
            spriteRender = spriteGO.GetComponent<SpriteRenderer>();
            spriteRender.color = "#0077F8".ToColor();
            spriteRender.sortingOrder = (int)SpriteType.HPMP_Bar;
            GameBoard.Resource_MagicBar = spriteGO;
            //草地
            var sprites = Resources.LoadAll<Sprite>("16x16-mini-world-sprites/Ground/Grass");
            GameBoard.Resource_Grounds = new List<Floor>();
            GameBoard.Resource_Grounds.Add(new Floor(VLCreater.CreateSprite(sprites.First(c => c.name == "Grass_1"), "Grass_1", assetGO), FloorType.Grassland));
            GameBoard.Resource_Grounds.Add(new Floor(VLCreater.CreateSprite(sprites.First(c => c.name == "Grass_2"), "Grass_2", assetGO), FloorType.Grassland));
            //道路
            GameBoard.Resource_Roads = new List<Floor>();
            GameBoard.Resource_Roads.Add(new Floor(VLCreater.CreateSprite(sprites.First(c => c.name == "Grass_3"), "Grass_3", assetGO), FloorType.Grassland));
            GameBoard.Resource_Roads.Add(new Floor(VLCreater.CreateSprite(sprites.First(c => c.name == "Grass_4"), "Grass_4", assetGO), FloorType.Grassland));
            //草地
            sprites = Resources.LoadAll<Sprite>("16x16-mini-world-sprites/Ground/TexturedGrass");
            GameBoard.Resource_Grounds.Add(new Floor(VLCreater.CreateSprite(sprites.First(c => c.name == "TexturedGrass_1"), "TexuredGrass_1", assetGO), FloorType.Grassland));
            GameBoard.Resource_Grounds.Add(new Floor(VLCreater.CreateSprite(sprites.First(c => c.name == "TexturedGrass_2"), "TexuredGrass_2", assetGO), FloorType.Grassland));
            GameBoard.Resource_Grounds.Add(new Floor(VLCreater.CreateSprite(sprites.First(c => c.name == "TexturedGrass_4"), "TexuredGrass_4", assetGO), FloorType.Grassland));
            GameBoard.Resource_Grounds.Add(new Floor(VLCreater.CreateSprite(sprites.First(c => c.name == "TexturedGrass_5"), "TexuredGrass_5", assetGO), FloorType.Grassland));
            //深水
            sprites = Resources.LoadAll<Sprite>("16x16-mini-world-sprites/Ground/Shore");
            GameBoard.Resource_Waters = new List<Floor>();
            GameBoard.Resource_Waters.Add(new Floor(VLCreater.CreateSprite(sprites.First(c => c.name == "Shore_4"), "Shore_4", assetGO), FloorType.River));
            //海滩
            GameBoard.Resource_GradientWaters = new List<Floor>();
            GameBoard.Resource_GradientWaters.Add(new Floor(VLCreater.CreateSprite(sprites.First(c => c.name == "Shore_0"), "Shore_0", assetGO), FloorType.Shore));
            GameBoard.Resource_GradientWaters.Add(new Floor(VLCreater.CreateSprite(sprites.First(c => c.name == "Shore_1"), "Shore_1", assetGO), FloorType.Shore));
            GameBoard.Resource_GradientWaters.Add(new Floor(VLCreater.CreateSprite(sprites.First(c => c.name == "Shore_2"), "Shore_2", assetGO), FloorType.Shore));
            GameBoard.Resource_GradientWaters.Add(new Floor(VLCreater.CreateSprite(sprites.First(c => c.name == "Shore_3"), "Shore_3", assetGO), FloorType.Shore));
            //石矿坑
            sprites = Resources.LoadAll<Sprite>("16x16-mini-world-sprites/Ground/Cliff");
            GameBoard.Resource_Mountains_Stone = new List<Floor>();
            GameBoard.Resource_Mountains_Stone.Add(new Floor(VLCreater.CreateSprite(sprites.First(c => c.name == "Cliff_0"), "Cliff_0", assetGO), FloorType.Mountain));
            GameBoard.Resource_Mountains_Stone.Add(new Floor(VLCreater.CreateSprite(sprites.First(c => c.name == "Cliff_1"), "Cliff_1", assetGO), FloorType.Mountain));
            GameBoard.Resource_Mountains_Stone.Add(new Floor(VLCreater.CreateSprite(sprites.First(c => c.name == "Cliff_2"), "Cliff_2", assetGO), FloorType.Mountain));
            GameBoard.Resource_Mountains_Stone.Add(new Floor(VLCreater.CreateSprite(sprites.First(c => c.name == "Cliff_5"), "Cliff_5", assetGO), FloorType.Mountain));
            GameBoard.Resource_Mountains_Stone.Add(new Floor(VLCreater.CreateSprite(sprites.First(c => c.name == "Cliff_6"), "Cliff_6", assetGO), FloorType.Mountain));
            GameBoard.Resource_Mountains_Stone.Add(new Floor(VLCreater.CreateSprite(sprites.First(c => c.name == "Cliff_7"), "Cliff_7", assetGO), FloorType.Mountain));
            GameBoard.Resource_Mountains_Stone.Add(new Floor(VLCreater.CreateSprite(sprites.First(c => c.name == "Cliff_10"), "Cliff_10", assetGO), FloorType.Mountain));
            GameBoard.Resource_Mountains_Stone.Add(new Floor(VLCreater.CreateSprite(sprites.First(c => c.name == "Cliff_11"), "Cliff_11", assetGO), FloorType.Mountain));
            GameBoard.Resource_Mountains_Stone.Add(new Floor(VLCreater.CreateSprite(sprites.First(c => c.name == "Cliff_12"), "Cliff_12", assetGO), FloorType.Mountain));
            //石矿坑入口
            GameBoard.Resource_Mountains_StoneMine = new Entrance(VLCreater.CreateSprite(sprites.First(c => c.name == "Cliff_9"), "Cliff_9", assetGO), EntranceType.StoneMine);
            //铜矿坑
            GameBoard.Resource_Mountains_Copper = new List<Floor>();
            GameBoard.Resource_Mountains_Copper.Add(new Floor(VLCreater.CreateSprite(sprites.First(c => c.name == "Cliff_38"), "Cliff_38", assetGO), FloorType.Mountain));
            GameBoard.Resource_Mountains_Copper.Add(new Floor(VLCreater.CreateSprite(sprites.First(c => c.name == "Cliff_39"), "Cliff_39", assetGO), FloorType.Mountain));
            GameBoard.Resource_Mountains_Copper.Add(new Floor(VLCreater.CreateSprite(sprites.First(c => c.name == "Cliff_40"), "Cliff_40", assetGO), FloorType.Mountain));
            GameBoard.Resource_Mountains_Copper.Add(new Floor(VLCreater.CreateSprite(sprites.First(c => c.name == "Cliff_41"), "Cliff_41", assetGO), FloorType.Mountain));
            GameBoard.Resource_Mountains_Copper.Add(new Floor(VLCreater.CreateSprite(sprites.First(c => c.name == "Cliff_42"), "Cliff_42", assetGO), FloorType.Mountain));
            GameBoard.Resource_Mountains_Copper.Add(new Floor(VLCreater.CreateSprite(sprites.First(c => c.name == "Cliff_43"), "Cliff_43", assetGO), FloorType.Mountain));
            GameBoard.Resource_Mountains_Copper.Add(new Floor(VLCreater.CreateSprite(sprites.First(c => c.name == "Cliff_48"), "Cliff_48", assetGO), FloorType.Mountain));
            GameBoard.Resource_Mountains_Copper.Add(new Floor(VLCreater.CreateSprite(sprites.First(c => c.name == "Cliff_49"), "Cliff_49", assetGO), FloorType.Mountain));
            GameBoard.Resource_Mountains_Copper.Add(new Floor(VLCreater.CreateSprite(sprites.First(c => c.name == "Cliff_50"), "Cliff_50", assetGO), FloorType.Mountain));
            //铜矿坑入口
            GameBoard.Resource_Mountains_CopperMine = new Entrance(VLCreater.CreateSprite(sprites.First(c => c.name == "Cliff_8"), "Cliff_8", assetGO), EntranceType.CopperMine);
            //矿石
            GameBoard.Resource_Mountains_StoneOre = new BlockItem(VLCreater.CreateSprite(sprites.First(c => c.name == "Cliff_4"), "Cliff_4", assetGO), BlockType.Stone);
            //矿石(草)
            GameBoard.Resource_Mountains_CutterOre = new BlockItem(VLCreater.CreateSprite(sprites.First(c => c.name == "Cliff_3"), "Cliff_3", assetGO), BlockType.Stone);
            //矿石(巨型)
            GameBoard.Resource_Mountains_BigOre = new List<BlockItem>();
            GameBoard.Resource_Mountains_BigOre.Add(new BlockItem(VLCreater.CreateSprite(sprites.First(c => c.name == "Cliff_15"), "Cliff_15", assetGO), BlockType.Stone));
            GameBoard.Resource_Mountains_BigOre.Add(new BlockItem(VLCreater.CreateSprite(sprites.First(c => c.name == "Cliff_16"), "Cliff_16", assetGO), BlockType.Stone));
            GameBoard.Resource_Mountains_BigOre.Add(new BlockItem(VLCreater.CreateSprite(sprites.First(c => c.name == "Cliff_22"), "Cliff_22", assetGO), BlockType.Stone));
            GameBoard.Resource_Mountains_BigOre.Add(new BlockItem(VLCreater.CreateSprite(sprites.First(c => c.name == "Cliff_23"), "Cliff_23", assetGO), BlockType.Stone));
            //树木
            sprites = Resources.LoadAll<Sprite>("16x16-mini-world-sprites/Nature/PineTrees");
            GameBoard.Resource_Trees = new List<Tree>();
            GameBoard.Resource_Trees.Add(new Tree(
                null
                , VLCreater.CreateSprite(sprites.First(c => c.name == "PineTrees_1"), "PineTrees_1", assetGO)
                , VLCreater.CreateSprite(sprites.First(c => c.name == "PineTrees_0"), "PineTrees_0", assetGO)
                , "PineTrees_1"
                ));
            sprites = Resources.LoadAll<Sprite>("16x16-mini-world-sprites/Nature/Trees");
            GameBoard.Resource_Trees.Add(new Tree(
                null
                , VLCreater.CreateSprite(sprites.First(c => c.name == "Trees_1"), "Trees_1", assetGO)
                , VLCreater.CreateSprite(sprites.First(c => c.name == "Trees_0"), "Trees_0", assetGO)
                , "Trees_1"
                ));
            GameBoard.Resource_Trees.Add(new Tree(
                null
                , VLCreater.CreateSprite(sprites.First(c => c.name == "Trees_2"), "Trees_2", assetGO)
                , VLCreater.CreateSprite(sprites.First(c => c.name == "Trees_0"), "Trees_0", assetGO)
                , "Trees_1"
                ));
            GameBoard.Resource_Trees.Add(new Tree(
                null
                , VLCreater.CreateSprite(sprites.First(c => c.name == "Trees_3"), "Trees_3", assetGO)
                , VLCreater.CreateSprite(sprites.First(c => c.name == "Trees_0"), "Trees_0", assetGO)
                , "Trees_1"
                ));
            //稻谷
            sprites = Resources.LoadAll<Sprite>("16x16-mini-world-sprites/Nature/Wheatfield");
            GameBoard.Resource_Wheatfield = new Wheatfield(
                VLCreater.CreateSprite(sprites.First(c => c.name == "Wheatfield_0"), "Wheatfield_0", assetGO)
                , VLCreater.CreateSprite(sprites.First(c => c.name == "Wheatfield_1"), "Wheatfield_1", assetGO)
                , VLCreater.CreateSprite(sprites.First(c => c.name == "Wheatfield_2"), "Wheatfield_2", assetGO)
                , VLCreater.CreateSprite(sprites.First(c => c.name == "Wheatfield_3"), "Wheatfield_3", assetGO)
                );
            //冒险洞穴
            sprites = Resources.LoadAll<Sprite>("16x16-mini-world-sprites/Buildings/Wood/CaveV2");
            GameBoard.Resource_Caves = new List<Cave>();
            GameBoard.Resource_Caves.Add(new Cave(VLCreater.CreateSprite(sprites.First(c => c.name == "CaveV2_0"), "CaveV2_0", assetGO)));
            GameBoard.Resource_Caves.Add(new Cave(VLCreater.CreateSprite(sprites.First(c => c.name == "CaveV2_1"), "CaveV2_1", assetGO)));
            GameBoard.Resource_Caves.Add(new Cave(VLCreater.CreateSprite(sprites.First(c => c.name == "CaveV2_2"), "CaveV2_2", assetGO)));
            GameBoard.Resource_Caves.Add(new Cave(VLCreater.CreateSprite(sprites.First(c => c.name == "CaveV2_3"), "CaveV2_3", assetGO)));
            GameBoard.Resource_Caves.Add(new Cave(VLCreater.CreateSprite(sprites.First(c => c.name == "CaveV2_4"), "CaveV2_4", assetGO)));
            GameBoard.Resource_Caves.Add(new Cave(VLCreater.CreateSprite(sprites.First(c => c.name == "CaveV2_5"), "CaveV2_5", assetGO)));
            //城镇(小)
            sprites = Resources.LoadAll<Sprite>("16x16-mini-world-sprites/Buildings/Wood/Chapels");
            GameBoard.Resource_Towns = new List<Town>();
            GameBoard.Resource_Towns.Add(new Town(VLCreater.CreateSprite(sprites.First(c => c.name == "Chapels_0"), "Chapels_0", assetGO)));
            GameBoard.Resource_Towns.Add(new Town(VLCreater.CreateSprite(sprites.First(c => c.name == "Chapels_1"), "Chapels_1", assetGO)));
            GameBoard.Resource_Towns.Add(new Town(VLCreater.CreateSprite(sprites.First(c => c.name == "Chapels_2"), "Chapels_2", assetGO)));
            GameBoard.Resource_Towns.Add(new Town(VLCreater.CreateSprite(sprites.First(c => c.name == "Chapels_3"), "Chapels_3", assetGO)));
            GameBoard.Resource_Towns.Add(new Town(VLCreater.CreateSprite(sprites.First(c => c.name == "Chapels_4"), "Chapels_4", assetGO)));
            GameBoard.Resource_Towns.Add(new Town(VLCreater.CreateSprite(sprites.First(c => c.name == "Chapels_5"), "Chapels_5", assetGO)));
            //城镇(大)
            sprites = Resources.LoadAll<Sprite>("16x16-mini-world-sprites/Buildings/Wood/Keep");
            GameBoard.Resource_BigTowns = new List<BigTown>();
            GameBoard.Resource_BigTowns.Add(
                new BigTown(
                VLCreater.CreateSprite(sprites.First(c => c.name == "Keep_0"), "Keep_0", assetGO)
                , VLCreater.CreateSprite(sprites.First(c => c.name == "Keep_1"), "Keep_1", assetGO)
                , VLCreater.CreateSprite(sprites.First(c => c.name == "Keep_6"), "Keep_6", assetGO)
                , VLCreater.CreateSprite(sprites.First(c => c.name == "Keep_7"), "Keep_7", assetGO)
                ));
            GameBoard.Resource_BigTowns.Add(
                new BigTown(
                VLCreater.CreateSprite(sprites.First(c => c.name == "Keep_4"), "Keep_4", assetGO)
                , VLCreater.CreateSprite(sprites.First(c => c.name == "Keep_5"), "Keep_5", assetGO)
                , VLCreater.CreateSprite(sprites.First(c => c.name == "Keep_10"), "Keep_10", assetGO)
                , VLCreater.CreateSprite(sprites.First(c => c.name == "Keep_11"), "Keep_11", assetGO)
                ));
            //生物
            sprites = Resources.LoadAll<Sprite>("16x16-mini-world-sprites/Characters/Monsters/Orcs/ArcherGoblin");
            GameBoard.Resource_ArcherGoblin = new Creature(VLCreater.CreateSprite(sprites.First(c => c.name == "ArcherGoblin_0"), "ArcherGoblin", assetGO))
            { DiedSounds = Dictionaries.GetCodeAudioByCode(SoundAudioType.Orc_Die) };
            sprites = Resources.LoadAll<Sprite>("16x16-mini-world-sprites/Characters/Monsters/Orcs/ClubGoblin");
            GameBoard.Resource_ClubGoblin = new Creature(VLCreater.CreateSprite(sprites.First(c => c.name == "ClubGoblin_0"), "ClubGoblin", assetGO))
            { DiedSounds = Dictionaries.GetCodeAudioByCode(SoundAudioType.Orc_Die) };
            sprites = Resources.LoadAll<Sprite>("16x16-mini-world-sprites/Characters/Monsters/Orcs/FarmerGoblin");
            GameBoard.Resource_FarmerGoblin = new Creature(VLCreater.CreateSprite(sprites.First(c => c.name == "FarmerGoblin_0"), "FarmerGoblin", assetGO))
            { DiedSounds = Dictionaries.GetCodeAudioByCode(SoundAudioType.Orc_Die) };
            sprites = Resources.LoadAll<Sprite>("16x16-mini-world-sprites/Characters/Monsters/Orcs/KamikazeGoblin");
            GameBoard.Resource_KamikazeGoblin = new Creature(VLCreater.CreateSprite(sprites.First(c => c.name == "KamikazeGoblin_0"), "KamikazeGoblin", assetGO))
            { DiedSounds = Dictionaries.GetCodeAudioByCode(SoundAudioType.Orc_Die) };
            sprites = Resources.LoadAll<Sprite>("16x16-mini-world-sprites/Characters/Monsters/Orcs/SpearGoblin");
            GameBoard.Resource_SpearGoblin = new Creature(VLCreater.CreateSprite(sprites.First(c => c.name == "SpearGoblin_0"), "SpearGoblin", assetGO))
            { DiedSounds = Dictionaries.GetCodeAudioByCode(SoundAudioType.Orc_Die) };
            sprites = Resources.LoadAll<Sprite>("16x16-mini-world-sprites/Characters/Monsters/Orcs/Minotaur");
            GameBoard.Resource_Minotaur = new Creature(VLCreater.CreateSprite(sprites.First(c => c.name == "Minotaur_0"), "Minotaur", assetGO))
            { DiedSounds = Dictionaries.GetCodeAudioByCode(SoundAudioType.Orc_Die) };
            sprites = Resources.LoadAll<Sprite>("16x16-mini-world-sprites/Characters/Monsters/Orcs/Orc");
            GameBoard.Resource_Orc = new Creature(VLCreater.CreateSprite(sprites.First(c => c.name == "Orc_0"), "Orc", assetGO))
            { DiedSounds = Dictionaries.GetCodeAudioByCode(SoundAudioType.Orc_Die) };
            sprites = Resources.LoadAll<Sprite>("16x16-mini-world-sprites/Characters/Monsters/Orcs/OrcMage");
            GameBoard.Resource_OrcMage = new Creature(VLCreater.CreateSprite(sprites.First(c => c.name == "OrcMage_0"), "OrcMage", assetGO))
            { DiedSounds = Dictionaries.GetCodeAudioByCode(SoundAudioType.Orc_Die) };
            sprites = Resources.LoadAll<Sprite>("16x16-mini-world-sprites/Characters/Monsters/Orcs/OrcShaman");
            GameBoard.Resource_OrcShaman = new Creature(VLCreater.CreateSprite(sprites.First(c => c.name == "OrcShaman_0"), "OrcShaman", assetGO))
            { DiedSounds = Dictionaries.GetCodeAudioByCode(SoundAudioType.Orc_Die) };
            //BOSS
            sprites = Resources.LoadAll<Sprite>("16x16-mini-world-sprites/Characters/Monsters/Demons/ArmouredRedDemon");
            GameBoard.Resource_ArmouredRedDemon = new Creature(VLCreater.CreateSprite(sprites.First(c => c.name == "ArmouredRedDemon_0"), "ArmouredRedDemon", assetGO))
            { DiedSounds = Dictionaries.GetCodeAudioByCode(SoundAudioType.Orc_Die) };
            sprites = Resources.LoadAll<Sprite>("16x16-mini-world-sprites/Characters/Monsters/Demons/PurpleDemon");
            GameBoard.Resource_PurpleDemon = new Creature(VLCreater.CreateSprite(sprites.First(c => c.name == "PurpleDemon_0"), "PurpleDemon", assetGO))
            { DiedSounds = Dictionaries.GetCodeAudioByCode(SoundAudioType.Orc_Die) };
            sprites = Resources.LoadAll<Sprite>("16x16-mini-world-sprites/Characters/Monsters/Demons/RedDemon");
            GameBoard.Resource_RedDemon = new Creature(VLCreater.CreateSprite(sprites.First(c => c.name == "RedDemon_0"), "RedDemon", assetGO))
            { DiedSounds = Dictionaries.GetCodeAudioByCode(SoundAudioType.Orc_Die) };
            //兽人巢穴(小)
            sprites = Resources.LoadAll<Sprite>("16x16-mini-world-sprites/Buildings/Enemy/Orc/AllBuildings-Preview");
            GameBoard.Resource_Orc_Towns = new List<EnermyTown>();
            GameBoard.Resource_Orc_Towns.Add(new EnermyTown(VLCreater.CreateSprite(sprites.First(c => c.name == "AllBuildings-Preview_68"), "AllBuildings-Preview_68", assetGO)
                , EnermyTownType.GoblinTownlv1, new List<CreatureSeed>() {
                    new CreatureSeed(GameBoard.Resource_FarmerGoblin,new SeedRandom(50, 1),6),
                }));
            GameBoard.Resource_Orc_Towns.Add(new EnermyTown(VLCreater.CreateSprite(sprites.First(c => c.name == "AllBuildings-Preview_84"), "AllBuildings-Preview_84", assetGO)
                , EnermyTownType.GoblinTownlv2, new List<CreatureSeed>() {
                    new CreatureSeed(GameBoard.Resource_FarmerGoblin,new SeedRandom(50, 1),2),
                    new CreatureSeed(GameBoard.Resource_ArcherGoblin,new SeedRandom(100, 1),2),
                    new CreatureSeed(GameBoard.Resource_ClubGoblin,new SeedRandom(150, 1),2),
                }));
            GameBoard.Resource_Orc_Towns.Add(new EnermyTown(VLCreater.CreateSprite(sprites.First(c => c.name == "AllBuildings-Preview_100"), "AllBuildings-Preview_100", assetGO)
                , EnermyTownType.GoblinTownlv3, new List<CreatureSeed>() {
                    new CreatureSeed(GameBoard.Resource_ArcherGoblin,new SeedRandom(50, 1),2),
                    new CreatureSeed(GameBoard.Resource_ClubGoblin,new SeedRandom(100, 1),2),
                    new CreatureSeed(GameBoard.Resource_KamikazeGoblin,new SeedRandom(150, 1),1),
                    new CreatureSeed(GameBoard.Resource_SpearGoblin,new SeedRandom(150, 1),1),
                }));
            GameBoard.Resource_Orc_Towns2 = new List<EnermyTown>();
            GameBoard.Resource_Orc_Towns2.Add(new EnermyTown(VLCreater.CreateSprite(sprites.First(c => c.name == "AllBuildings-Preview_115"), "AllBuildings-Preview_115", assetGO)
                , EnermyTownType.GoblinTownOrc, new List<CreatureSeed>() {
                    new CreatureSeed(GameBoard.Resource_ClubGoblin,new SeedRandom(50, 1),3),
                    new CreatureSeed(GameBoard.Resource_KamikazeGoblin,new SeedRandom(75, 1),2),
                    new CreatureSeed(GameBoard.Resource_SpearGoblin,new SeedRandom(75, 1),2),
                    new CreatureSeed(GameBoard.Resource_Orc,new SeedRandom(150, 1),1),
                }));
            GameBoard.Resource_Orc_Towns2.Add(new EnermyTown(VLCreater.CreateSprite(sprites.First(c => c.name == "AllBuildings-Preview_116"), "AllBuildings-Preview_116", assetGO)
                , EnermyTownType.GoblinTownOrc, new List<CreatureSeed>() {
                    new CreatureSeed(GameBoard.Resource_ClubGoblin,new SeedRandom(50, 1),3),
                    new CreatureSeed(GameBoard.Resource_KamikazeGoblin,new SeedRandom(75, 1),2),
                    new CreatureSeed(GameBoard.Resource_SpearGoblin,new SeedRandom(75, 1),2),
                    new CreatureSeed(GameBoard.Resource_Orc,new SeedRandom(150, 1),1),
                }));
            GameBoard.Resource_Orc_Towns2.Add(new EnermyTown(VLCreater.CreateSprite(sprites.First(c => c.name == "AllBuildings-Preview_87"), "AllBuildings-Preview_87", assetGO)
                , EnermyTownType.GoblinTownMaga, new List<CreatureSeed>() {
                    new CreatureSeed(GameBoard.Resource_ClubGoblin,new SeedRandom(50, 1),3),
                    new CreatureSeed(GameBoard.Resource_KamikazeGoblin,new SeedRandom(75, 1),2),
                    new CreatureSeed(GameBoard.Resource_SpearGoblin,new SeedRandom(75, 1),2),
                    new CreatureSeed(GameBoard.Resource_OrcMage,new SeedRandom(150, 1),1),
                }));
            GameBoard.Resource_Orc_Towns2.Add(new EnermyTown(VLCreater.CreateSprite(sprites.First(c => c.name == "AllBuildings-Preview_145"), "AllBuildings-Preview_145", assetGO)
                , EnermyTownType.GoblinTownMaga, new List<CreatureSeed>() {
                    new CreatureSeed(GameBoard.Resource_ClubGoblin,new SeedRandom(50, 1),3),
                    new CreatureSeed(GameBoard.Resource_KamikazeGoblin,new SeedRandom(75, 1),2),
                    new CreatureSeed(GameBoard.Resource_SpearGoblin,new SeedRandom(75, 1),2),
                    new CreatureSeed(GameBoard.Resource_OrcMage,new SeedRandom(150, 1),1),
                }));
            GameBoard.Resource_Orc_Towns2.Add(new EnermyTown(VLCreater.CreateSprite(sprites.First(c => c.name == "AllBuildings-Preview_161"), "AllBuildings-Preview_161", assetGO)
                , EnermyTownType.GoblinTownShaman, new List<CreatureSeed>() {
                    new CreatureSeed(GameBoard.Resource_ClubGoblin,new SeedRandom(50, 1),3),
                    new CreatureSeed(GameBoard.Resource_KamikazeGoblin,new SeedRandom(75, 1),2),
                    new CreatureSeed(GameBoard.Resource_SpearGoblin,new SeedRandom(75, 1),2),
                    new CreatureSeed(GameBoard.Resource_OrcShaman,new SeedRandom(150, 1),1),
                }));
            GameBoard.Resource_Orc_Towns2.Add(new EnermyTown(VLCreater.CreateSprite(sprites.First(c => c.name == "AllBuildings-Preview_177"), "AllBuildings-Preview_177", assetGO)
                , EnermyTownType.GoblinTownShaman, new List<CreatureSeed>() {
                    new CreatureSeed(GameBoard.Resource_ClubGoblin,new SeedRandom(50, 1),3),
                    new CreatureSeed(GameBoard.Resource_KamikazeGoblin,new SeedRandom(75, 1),2),
                    new CreatureSeed(GameBoard.Resource_SpearGoblin,new SeedRandom(75, 1),2),
                    new CreatureSeed(GameBoard.Resource_OrcShaman,new SeedRandom(150, 1),1),
                }));
            GameBoard.Resource_Orc_Towns3 = new List<EnermyTown>();
            GameBoard.Resource_Orc_Towns3.Add(new EnermyTown(VLCreater.CreateSprite(sprites.First(c => c.name == "AllBuildings-Preview_165"), "AllBuildings-Preview_165", assetGO)
                , EnermyTownType.GoblinTownMinotaur, new List<CreatureSeed>() {
                    new CreatureSeed(GameBoard.Resource_ClubGoblin,new SeedRandom(50, 1),3),
                    new CreatureSeed(GameBoard.Resource_KamikazeGoblin,new SeedRandom(75, 1),2),
                    new CreatureSeed(GameBoard.Resource_SpearGoblin,new SeedRandom(75, 1),2),
                    new CreatureSeed(GameBoard.Resource_Minotaur,new SeedRandom(150, 1),1),
                }));
            GameBoard.Resource_Orc_Towns3.Add(new EnermyTown(VLCreater.CreateSprite(sprites.First(c => c.name == "AllBuildings-Preview_166"), "AllBuildings-Preview_166", assetGO)
                , EnermyTownType.GoblinTownMinotaur, new List<CreatureSeed>() {
                    new CreatureSeed(GameBoard.Resource_ClubGoblin,new SeedRandom(50, 1),3),
                    new CreatureSeed(GameBoard.Resource_KamikazeGoblin,new SeedRandom(75, 1),2),
                    new CreatureSeed(GameBoard.Resource_SpearGoblin,new SeedRandom(75, 1),2),
                    new CreatureSeed(GameBoard.Resource_Minotaur,new SeedRandom(150, 1),1),
                }));
            GameBoard.Resource_Orc_Towns3.Add(new EnermyTown(VLCreater.CreateSprite(sprites.First(c => c.name == "AllBuildings-Preview_167"), "AllBuildings-Preview_167", assetGO)
                , EnermyTownType.GoblinTownMinotaur, new List<CreatureSeed>() {
                    new CreatureSeed(GameBoard.Resource_ClubGoblin,new SeedRandom(50, 1),3),
                    new CreatureSeed(GameBoard.Resource_KamikazeGoblin,new SeedRandom(75, 1),2),
                    new CreatureSeed(GameBoard.Resource_SpearGoblin,new SeedRandom(75, 1),2),
                    new CreatureSeed(GameBoard.Resource_Minotaur,new SeedRandom(150, 1),1),
                }));
            //兽人巢穴(大)
            GameBoard.Resource_Orc_BigTowns = new List<BigEnermyTown>();
            GameBoard.Resource_Orc_BigTowns.Add(
                new BigEnermyTown(
                VLCreater.CreateSprite(sprites.First(c => c.name == "AllBuildings-Preview_34"), "AllBuildings-Preview_34", assetGO)
                , VLCreater.CreateSprite(sprites.First(c => c.name == "AllBuildings-Preview_35"), "AllBuildings-Preview_35", assetGO)
                , VLCreater.CreateSprite(sprites.First(c => c.name == "AllBuildings-Preview_50"), "AllBuildings-Preview_50", assetGO)
                , VLCreater.CreateSprite(sprites.First(c => c.name == "AllBuildings-Preview_51"), "AllBuildings-Preview_51", assetGO)
                , EnermyTownType.GoblinTownBoss
                ));
            GameBoard.Resource_Orc_BigTowns.Add(
                new BigEnermyTown(
                VLCreater.CreateSprite(sprites.First(c => c.name == "AllBuildings-Preview_36"), "AllBuildings-Preview_36", assetGO)
                , VLCreater.CreateSprite(sprites.First(c => c.name == "AllBuildings-Preview_37"), "AllBuildings-Preview_37", assetGO)
                , VLCreater.CreateSprite(sprites.First(c => c.name == "AllBuildings-Preview_52"), "AllBuildings-Preview_52", assetGO)
                , VLCreater.CreateSprite(sprites.First(c => c.name == "AllBuildings-Preview_53"), "AllBuildings-Preview_53", assetGO)
                , EnermyTownType.GoblinTownBoss
                ));
            GameBoard.Resource_Orc_BigTowns.Add(
                new BigEnermyTown(
                VLCreater.CreateSprite(sprites.First(c => c.name == "AllBuildings-Preview_38"), "AllBuildings-Preview_38", assetGO)
                , VLCreater.CreateSprite(sprites.First(c => c.name == "AllBuildings-Preview_39"), "AllBuildings-Preview_39", assetGO)
                , VLCreater.CreateSprite(sprites.First(c => c.name == "AllBuildings-Preview_54"), "AllBuildings-Preview_54", assetGO)
                , VLCreater.CreateSprite(sprites.First(c => c.name == "AllBuildings-Preview_55"), "AllBuildings-Preview_55", assetGO)
                , EnermyTownType.GoblinTownBoss
                ));
            //地点
            //物品
            //玩家
            sprites = Resources.LoadAll<Sprite>("16x16-mini-world-sprites/Characters/Champions/Gangblanc");
            GameBoard.Resource_Player = new Creature(VLCreater.CreateSprite(sprites[0], "Player"))
            { DiedSounds = Dictionaries.GetCodeAudioByCode(SoundAudioType.Human_DeepHurt) };
            #endregion

            GameBoard.IsResourceReady = true;
        }
    }
    public class Movement
    {
        public int X, Y;
        public float XLength { get { return X * GameBoard.StepX; } }
        public float YLength { get { return Y * GameBoard.StepY; } }

        public Vector2 startPosition;
        public Vector2 targetPosition;
        public float moveStartTime = 0f;

        public Movement(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public void CalculateMovement(Vector3 startPosition)
        {
            var targetPosition = new Vector2(startPosition.x + this.XLength, startPosition.y + this.YLength);
            this.startPosition = startPosition;
            this.targetPosition = targetPosition;
            this.moveStartTime = Time.time;
        }
        public void CalculateColliderMovement(Vector3 startPosition)
        {
            var targetPosition = new Vector2(startPosition.x + this.XLength / 3, startPosition.y + this.YLength / 3);
            this.startPosition = startPosition;
            this.targetPosition = targetPosition;
            this.moveStartTime = Time.time;
        }
        internal void CalculateAttectMovement(Vector3 position)
        {
            //TODO 暂时使用碰撞移动表示攻击
            CalculateColliderMovement(position);
        }
    }
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
        public GameObject GamingGO { get; internal set; }
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
                        Player.Movement = new Movement(0, 1);
                    }
                    else if (Input.GetKey(KeyCode.S))
                    {
                        Player.OperationStatus = OperationStatus.Input_Move;
                        Player.Movement = new Movement(0, -1);
                    }
                    else if (Input.GetKey(KeyCode.A))
                    {
                        Player.OperationStatus = OperationStatus.Input_Move;
                        Player.Movement = new Movement(-1, 0);
                    }
                    else if (Input.GetKey(KeyCode.D))
                    {
                        Player.OperationStatus = OperationStatus.Input_Move;
                        Player.Movement = new Movement(1, 0);
                    }
                    else if (Input.GetKey(KeyCode.Space))
                    {
                        canInput = false;
                        Player.OperationStatus = OperationStatus.Do_Collect;
                        Gaming0316.instance.StartCoroutine(ResetInput(0.5f));
                    }
                    else if (Input.GetKey(KeyCode.C))
                    {
                        canInput = false;
                        Player.Check(Floors);
                        Gaming0316.instance.StartCoroutine(ResetInput(0.5f));
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
                        Gaming0316.instance.GameBoard.DisplayText($"前方无路可走");

                        Player.OperationStatus = OperationStatus.Do_AttemptMove;
                    }
                    else if (Player.CheckCollider(Floors))
                    {
                        Player.Movement.CalculateColliderMovement(Player.PlayerGO.transform.position);
                        Gaming0316.instance.GameBoard.DisplayText($"前方无法通行");

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
                        Gaming0316.instance.GameBoard.DisplayText($"移动 X:{Player.X},Y:{Player.Y}");
                        Player.UpdateBuffs(Gaming0316.instance.GameBoard);
                        SoundManager.instance.PlaySound(Dictionaries.GetCodeAudioByCode(SoundAudioType.Move_Grass));

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
                        SoundManager.instance.PlaySound(Dictionaries.GetCodeAudioByCode(SoundAudioType.Collider));
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
                        SoundManager.instance.PlaySound(Dictionaries.GetCodeAudioByCode(SoundAudioType.Sword_Cut));
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
                                enermy.Movement = new Movement(x, y);
                                enermy.Movement.CalculateAttectMovement(enermy.SpriteGO.transform.position);
                                enermy.OperationStatus = OperationStatus.Do_CloseAttackMove;
                            }
                            else if (Mathf.Abs(Player.X + Player.Y - enermy.X - enermy.Y) < 10)
                            {
                                //跟踪
                                var x = enermy.X == Player.X ? 0 : enermy.X > Player.X ? -1 : 1;
                                var y = enermy.Y == Player.Y ? 0 : enermy.Y > Player.Y ? -1 : 1;
                                enermy.Movement = new Movement(x, y);
                                enermy.Movement.CalculateMovement(enermy.SpriteGO.transform.position);
                                //TODO 需要进行跨地形检测
                                enermy.OperationStatus = OperationStatus.Input_Move;
                            }
                            else
                            {
                                //漫步
                                var x = Random.Range(-1, 2);
                                var y = Random.Range(-1, 2);
                                enermy.Movement = new Movement(x, y);
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
            FloorsGO = new GameObject("Floors"); FloorsGO.SetParent(Gaming0316.instance.gamingGO);
            ItemsGO = new GameObject("Items"); ItemsGO.SetParent(Gaming0316.instance.gamingGO);
            CavesGO = new GameObject("Caves"); CavesGO.SetParent(Gaming0316.instance.gamingGO);
            BuildingsGO = new GameObject("Buildings"); BuildingsGO.SetParent(Gaming0316.instance.gamingGO);
            EnermyBuidingsGO = new GameObject("EnermyBuidings"); EnermyBuidingsGO.SetParent(Gaming0316.instance.gamingGO);
            CreaturesGO = new GameObject("Creatures"); CreaturesGO.SetParent(Gaming0316.instance.gamingGO);
            //创建文本输出框
            CanvasGO = VLCreater.CreateCanvas("Canvas", Gaming0316.instance.gamingGO);
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
            Player.SpriteGO.SetParent(GamingGO);
            Player.OperationStatus = OperationStatus.TurnOn;
            Gaming0316.instance.GameBoard = this;
            Gaming0316.instance.GameBoard.Floors[Player.X, Player.Y].Creatures.Add(Player);
            var creatureModel = Dictionaries.CodeCreatureMathModels[nameof(Player)];
            creatureModel.Decorate(Player);
            return null;
        }

        internal Vector2 GetPosition(int x, int y)
        {
            return new Vector2(x * StepX, y * StepY);
        }

        internal object InitCamera()
        {
            var cameraGO = VLCreater.CreateCamera("Camera_Player", GamingGO);
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
    public class FastItem
    {
        public GameObject Parent;
        public GameObject FastItemBlock;
        public Item Item;
        public string Name;
        public string Key;

        public FastItem(GameObject spriteGO)
        {
            this.FastItemBlock = spriteGO;
        }

        public float FastItemBlockX { get; internal set; }
        public float FastItemBlockY { get; internal set; }

        internal void AddItem(Item item)
        {
            var imageGO = VLCreater.CreateImage("FastItemImage", Parent);
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
    public enum EntranceType
    {
        None = 0,
        StoneMine,
        CopperMine,
        Shop,
        House,
        Town,
        BigTown,
        Cave,
    }
    public class Entrance : Item
    {
        public EntranceType EntranceType;

        public Entrance(GameObject spriteGO, EntranceType entranceType, string name = "") : base(spriteGO, name)
        {
            EntranceType = entranceType;
        }
    }
    public enum EnermyTownType
    {
        GoblinTownlv1,//club
        GoblinTownlv2,//+archer
        GoblinTownlv3,//+spear
        GoblinTownOrc,//兽人
        GoblinTownMaga,//术士
        GoblinTownShaman,//萨满
        GoblinTownMinotaur,//牛头人
        GoblinTownBoss,//+Demon
    }
    public class EnermyTown : Entrance, ICloneableObject<EnermyTown>
    {
        public EnermyTownType EnermyTownType;
        public EnermyTown(GameObject imageGO, EnermyTownType enermyTownType, List<CreatureSeed> creatureSeeds) : base(imageGO, EntranceType.Town)
        {
            EnermyTownType = enermyTownType;
            CreatureSeeds = creatureSeeds;
        }

        public List<CreatureSeed> CreatureSeeds = new List<CreatureSeed>();
        public List<Creature> Armies = new List<Creature>();

        internal void GenerateEnermy(GameBoard gameBoard)
        {
            if (Armies.Count >= 3)
                return;

            foreach (var creatureSeeds in CreatureSeeds)
            {
                if (creatureSeeds.SeedRandom.GetNext() == 1)
                {
                    var creature = creatureSeeds.Creature.Clone();
                    creature.CreatureType = CreatureType.Enermy;
                    var creatureModel = Dictionaries.CodeCreatureMathModels[creature.Name];
                    creatureModel.Decorate(creature);
                    creature.X = X;
                    creature.Y = Y;
                    creature.SpriteGO.transform.parent = gameBoard.CreaturesGO.transform;
                    creature.SpriteGO.transform.position = gameBoard.GetPosition(creature.X, creature.Y);
                    Armies.Add(creature);
                    gameBoard.Enermies.Add(creature);
                    gameBoard.Floors[X, Y].Creatures.Add(creature);
                    gameBoard.DisplayText($"{creature.Name}出现了");
                    return;
                }
            }
        }

        public EnermyTown Clone()
        {
            return new EnermyTown(Object.Instantiate(SpriteGO), EnermyTownType, CreatureSeeds);
        }
    }
    public class CreatureSeed : ICloneableObject<CreatureSeed>
    {
        public CreatureSeed(Creature creature, SeedRandom seedRandom, int maxCount)
        {
            Creature = creature;
            SeedRandom = seedRandom;
            MaxCount = maxCount;
        }

        public string Name { set; get; }
        public Creature Creature { set; get; }
        public SeedRandom SeedRandom { set; get; }
        public int MaxCount { get; internal set; }

        public CreatureSeed Clone()
        {
            return new CreatureSeed(Creature, SeedRandom.Clone(), MaxCount);
        }
    }
    public class BigEnermyTown : Entrance
    {
        GameObject ImageGO_LT;
        GameObject ImageGO_RT;
        GameObject ImageGO_LB;
        GameObject ImageGO_RB;
        EnermyTownType EnermyTownType;

        public BigEnermyTown(GameObject imageGO_LT, GameObject imageGO_RT, GameObject imageGO_LB, GameObject imageGO_RB, EnermyTownType enermyTownType) : base(null, EntranceType.BigTown)
        {
            ImageGO_LT = imageGO_LT;
            ImageGO_LT.GetComponent<SpriteRenderer>().sortingOrder = (int)SpriteType.Item;
            ImageGO_RT = imageGO_RT;
            ImageGO_RT.GetComponent<SpriteRenderer>().sortingOrder = (int)SpriteType.Item;
            ImageGO_LB = imageGO_LB;
            ImageGO_LB.GetComponent<SpriteRenderer>().sortingOrder = (int)SpriteType.Item;
            ImageGO_RB = imageGO_RB;
            ImageGO_RB.GetComponent<SpriteRenderer>().sortingOrder = (int)SpriteType.Item;
            EnermyTownType = enermyTownType;
        }
    }
    public class Town : Entrance, ICloneableObject<Town>
    {
        public Town(GameObject spriteGO, string name = "") : base(spriteGO, EntranceType.Town, name)
        {
        }

        public Town Clone()
        {
            return new Town(Object.Instantiate(SpriteGO), Name);
        }
    }
    public class Cave : Entrance, ICloneableObject<Cave>
    {
        public Cave(GameObject spriteGO, string name = "") : base(spriteGO, EntranceType.Town, name)
        {
        }

        public Cave Clone()
        {
            return new Cave(Object.Instantiate(SpriteGO), Name);
        }
    }
    public class BigTown : Entrance
    {
        GameObject ImageGO_LT;
        GameObject ImageGO_RT;
        GameObject ImageGO_LB;
        GameObject ImageGO_RB;
        public BigTown(GameObject imageGO_LT, GameObject imageGO_RT, GameObject imageGO_LB, GameObject imageGO_RB) : base(null, EntranceType.BigTown)
        {
            ImageGO_LT = imageGO_LT;
            ImageGO_LT.GetComponent<SpriteRenderer>().sortingOrder = (int)SpriteType.Item;
            ImageGO_RT = imageGO_RT;
            ImageGO_RT.GetComponent<SpriteRenderer>().sortingOrder = (int)SpriteType.Item;
            ImageGO_LB = imageGO_LB;
            ImageGO_LB.GetComponent<SpriteRenderer>().sortingOrder = (int)SpriteType.Item;
            ImageGO_RB = imageGO_RB;
            ImageGO_RB.GetComponent<SpriteRenderer>().sortingOrder = (int)SpriteType.Item;
        }
    }
    public class Floor : UnityObject
    {
        public List<Item> Items = new List<Item>();
        public List<Creature> Creatures = new List<Creature>();
        public FloorType FloorType;

        public Floor(GameObject spriteGO, string name = "") : base(spriteGO, name)
        {
        }
        public Floor(GameObject spriteGO, FloorType floorType, string name = "") : base(spriteGO, name)
        {
            FloorType = floorType;
            var sprite = spriteGO.GetComponent<SpriteRenderer>();
            sprite.sortingOrder = (int)SpriteType.Floor;
        }

        public Floor Clone()
        {
            return new Floor(Object.Instantiate(SpriteGO), Name);
        }
    }
    public enum FloorType
    {
        None = 0,
        Plain,
        Grassland,
        Forest,
        Mountain,
        River,
        Shore,
        Mine,
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
        //Tree = 2,
        //Creature = 3,
    }
    public class BlockItem : Item, ICloneableObject<BlockItem>
    {
        public BlockType BlockType;

        public BlockItem(GameObject spriteGO, BlockType blockType, string name = "") : base(spriteGO, name)
        {
            BlockType = blockType;
        }

        public BlockItem Clone()
        {
            return new BlockItem(Object.Instantiate(SpriteGO), BlockType, Name);
        }
    }
    public class Wheatfield : Item
    {
        public GameObject CutDownSpriteGO;
        public GameObject PlantSpriteGO;
        public GameObject GrowSpriteGO;
        public GameObject HarvestSpriteGO;

        public Wheatfield(GameObject cutDownSpriteGO, GameObject plantSpriteGO, GameObject growSpriteGO, GameObject harvestSpriteGO, string name = "") : base(null, name)
        {
            CutDownSpriteGO = cutDownSpriteGO;
            CutDownSpriteGO.GetComponent<SpriteRenderer>().sortingOrder = (int)SpriteType.Item;
            PlantSpriteGO = plantSpriteGO;
            PlantSpriteGO.GetComponent<SpriteRenderer>().sortingOrder = (int)SpriteType.Item;
            GrowSpriteGO = growSpriteGO;
            GrowSpriteGO.GetComponent<SpriteRenderer>().sortingOrder = (int)SpriteType.Item;
            HarvestSpriteGO = harvestSpriteGO;
            HarvestSpriteGO.GetComponent<SpriteRenderer>().sortingOrder = (int)SpriteType.Item;
        }
    }
    public class Tree : Item, ICloneableObject<Tree>
    {
        public GameObject OrientSpriteGO;
        public GameObject CutDownSpriteGO;

        public Tree(GameObject spriteGO, GameObject orientSpriteGO, GameObject cutDownSpriteGO, string name = "") : base(spriteGO, name)
        {
            OrientSpriteGO = orientSpriteGO;
            CutDownSpriteGO = cutDownSpriteGO;
        }

        public Tree Clone()
        {
            return new Tree(SpriteGO != null ? Object.Instantiate(SpriteGO) : null, OrientSpriteGO, CutDownSpriteGO, Name);
        }
    }
    public class UnityObject : IUnityObject
    {
        public string Name;
        public int X;
        public int Y;
        public GameObject SpriteGO { set; get; }

        public UnityObject(GameObject spriteGO, string name)
        {
            SpriteGO = spriteGO;
            if (!string.IsNullOrEmpty(name))
            {
                Name = name;
            }
            else if (SpriteGO != null)
                Name = SpriteGO.name;
        }
    }
    public class Item : UnityObject //,ICloneableObject<Item> 会导致泛型混淆
    {
        public ItemType ItemType;

        public Item(GameObject spriteGO, string name) : base(spriteGO, name)
        {
            if (spriteGO == null)
                return;
            spriteGO.GetComponent<SpriteRenderer>().sortingOrder = (int)SpriteType.Item;
        }

        //public Item Clone()
        //{
        //    Item clone = new Item(CloneHelper.Clone(SpriteGO));
        //    clone.Name = Name;
        //    return clone;
        //}

        internal void Display(GameBoard gameBoard)
        {
            gameBoard.DisplayText(Dictionaries.GetDescriptionByCode(Name));
        }
    }
    public interface IUnityObject
    {
        GameObject SpriteGO { set; get; }
    }
    public interface ICloneableObject<T>
    {
        T Clone();
    }
    public enum CreatureType
    {
        None,
        Friendly,
        Medium,
        Enermy
    }
    public class Creature : UnityObject, AttackableCreature, ICloneableObject<Creature>
    {
        public bool IsPlayer = false;
        public OperationStatus OperationStatus { get; internal set; }
        public GameObject BloodBarGO { set; get; }

        public Creature(GameObject spriteGO, string name = "") : base(spriteGO, name)
        {
            var sprite = spriteGO.GetComponent<SpriteRenderer>();
            sprite.sortingOrder = (int)SpriteType.Creature;

            BloodBarGO = Gaming0316.instance.GameBoard.Resource_BloodBar;
        }

        public CreatureType CreatureType { set; get; }

        #region AttackableCreature
        public int Attr_MaxHP { set; get; }
        public int Attr_HP { set; get; }
        public int Attr_AttackMax { set; get; }
        public int Attr_AttackMin { set; get; }
        public int Attr_Defend { set; get; }
        public Dictionary<Buff, int> Buffs { set; get; } = new Dictionary<Buff, int>();
        public List<AudioClip> DiedSounds { get; internal set; }

        public AttackResult Attack()
        {
            var movement = Movement;
            AttackResult result = new AttackResult();
            var creature = Gaming0316.instance.GameBoard.Floors[X + movement.X, Y + movement.Y].Creatures.FirstOrDefault(c => c is AttackableCreature);
            if (creature == null)
                return result;
            result.Creature = creature;
            return Attack(creature);
        }
        AttackResult Attack(Creature creature)
        {
            var floors = Gaming0316.instance.GameBoard.Floors;
            if (IsPlayer) Gaming0316.instance.GameBoard.DisplayText($"---当前状态---");
            Gaming0316.instance.GameBoard.DisplayText($"{Name}:{GetAttackableCreatureDiscription()}");
            Gaming0316.instance.GameBoard.DisplayText($"{creature.Name}:{creature.GetAttackableCreatureDiscription()}");
            Gaming0316.instance.GameBoard.DisplayText($"---攻击---");
            AttackResult result = AttackCore(creature, Buffs);
            result.Creature = creature;
            Gaming0316.instance.GameBoard.DisplayText($"{Name}攻击了{creature.Name},造成了{result.ChangedHP}点伤害");
            if (result.IsDead)
            {
                Gaming0316.instance.GameBoard.DisplayText($"{creature.Name}被打倒了");
            }
            else
            {
                //TODO 具备反击特性才会反击
                //result = creature.Attack(this, Buffs);
                //GameBoard.DisplayText($"{creature.Name}攻击了{Name},造成了{result.ChangedHP}点伤害");
                //if (result.IsDead)
                //{
                //    PlayerGO.SetActive(false);
                //    GameBoard.DisplayText($"{Name}被打倒了");
                //}
            }
            return result;
        }
        AttackResult AttackCore(AttackableCreature creature, Dictionary<Buff, int> buffs)
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

        internal void Display(GameBoard gameBoard)
        {
            gameBoard.DisplayText(Dictionaries.GetDescriptionByCode(Name));
        }

        internal Movement Movement;

        internal void UpdateBuffs(GameBoard GameBoard)
        {
            foreach (var key in Buffs.Keys)
            {
                Buffs[key]--;
                if (Buffs[key] == 0)
                {
                    Buffs.Remove(key);
                    if (IsPlayer)
                        GameBoard.DisplayText($"{key.ToString()},不再生效");
                }
                else
                {
                    if (IsPlayer)
                        GameBoard.DisplayText($"{key.ToString()},剩余({ Buffs[key]})回合");
                }
            }
        }

        public bool CanAttack(Player player)
        {
            //TODO
            //远程战斗单位增加远程攻击
            return Mathf.Abs(player.X - X) <= 1 && Mathf.Abs(player.Y - Y) <= 1;
        }

        public OperationData OperationData = new OperationData();

        #endregion

        // 边界检测
        public bool CheckOverEdge(Floor[,] floors)
        {
            return X + Movement.X < 0 || X + Movement.X > GameBoard.XSteps
                || Y + Movement.Y < 0 || Y + Movement.Y > GameBoard.YSteps;
        }

        // 碰撞检测
        public bool CheckCollider(Floor[,] floors)
        {
            var floor = floors[X + Movement.X, Y + Movement.Y];
            return floor.FloorType == FloorType.River || floor.FloorType == FloorType.Mountain || floor.Items.Any(c => c is BlockItem);
        }

        // 战斗检测
        public bool CheckCloseAttack(Floor[,] floors)
        {
            var floor = floors[X + Movement.X, Y + Movement.Y];
            return floor.Creatures.Any(c => c.CreatureType == CreatureType.Enermy);
        }

        internal void Move(Floor[,] floors)
        {
            floors[X, Y].Creatures.Remove(this);
            X += Movement.X;
            Y += Movement.Y;
            floors[X, Y].Creatures.Add(this);
            VLDebug.DelegateDebug(() =>
            {
                Debug.Log($"{Name}Move X:{X},Y:{Y}");
            });
        }

        public float DisplaySmoothMove(GameObject go, Movement movement, float moveDuration = 0.2f)
        {
            float elapsedTime = Time.time - movement.moveStartTime;
            float clampTime = Mathf.Clamp01(elapsedTime / moveDuration);
            Vector2 newPosition = Vector2.Lerp(movement.startPosition, movement.targetPosition, clampTime);
            go.transform.position = newPosition;
            return clampTime;
        }

        internal void Defeated()
        {
            Gaming0316.instance.GameBoard.Enermies.Remove(this);
            Gaming0316.instance.GameBoard.Floors[X, Y].Creatures.Remove(this);
            Object.Destroy(this.SpriteGO);
        }

        public Creature Clone()
        {
            var spriteGO = Object.Instantiate(SpriteGO);
            return new Creature(spriteGO, Name)
            {
                CreatureType = CreatureType,
                DiedSounds = DiedSounds,
                BloodBarGO = Object.Instantiate(BloodBarGO, spriteGO.transform),
            };
        }

        static float BloodBarScaleX = Gaming0316.instance.GameBoard.Resource_BloodBar.GetComponent<SpriteRenderer>().transform.localScale.x;
        internal void UpdateBloodBar()
        {
            BloodBarGO.transform.localScale = new Vector3(BloodBarScaleX * Attr_HP / Attr_MaxHP, 1, 1);
        }
    }
    public class OperationData
    {
        public bool IsMyTurn { get; internal set; }
        public bool IsOperated = false;

        private bool isAttackingSetup;
        private bool isMovingSetup;
        private bool isMoving;
        private bool isCollecttingSetup;

        public bool IsAttackingSetup
        {
            get => isAttackingSetup; set
            {
                if (value) IsOperated = true;
                isAttackingSetup = value;
            }
        }
        public bool IsMovingSetup
        {
            get => isMovingSetup;
            set
            {
                if (value) IsOperated = true;
                isMovingSetup = value;
            }
        }
        public bool IsMoving
        {
            get => isMoving;
            set
            {
                if (value) IsOperated = true;
                isMoving = value;
            }
        }
        public bool IsCollecttingSetup
        {
            get => isCollecttingSetup;
            set
            {
                if (value) IsOperated = true;
                isCollecttingSetup = value;
            }
        }

        public bool IsAttempMoving { get; internal set; }
        public bool IsAttempMovingBack { get; internal set; }
    }
    public enum Buff
    {
        None = 0,
        DoubleAttack = 1,
        DoubleDefend = 2,
        DoubleSpeed = 3,
    }

    public enum OperationStatus
    {
        None,
        TurnOn,
        TurnOff,
        Input_Move,
        Do_Move,
        Do_AttemptMove,
        Do_AttemptMoveBack,
        Do_Collect,
        Do_Attack,
        Do_CloseAttackMove,
        Do_CloseAttackMoveBack,
    }
    public class Player : Creature
    {
        public Vector3 CameraOffSet { get; internal set; }

        public GameObject PlayerGO;
        public List<Item> Items = new List<Item>();
        public List<FastItem> FastItems = new List<FastItem>();
        public GameObject MagicBarGO { set; get; }

        public Player(GameObject imageGO) : base(imageGO, "Player")
        {
            PlayerGO = imageGO;
            CameraOffSet = new Vector3(0, 0, -2);
            OperationStatus = OperationStatus.TurnOn;
            IsPlayer = true;

            MagicBarGO = Object.Instantiate(Gaming0316.instance.GameBoard.Resource_MagicBar, SpriteGO.transform);
            BloodBarGO = Object.Instantiate(Gaming0316.instance.GameBoard.Resource_BloodBar, SpriteGO.transform);
        }

        internal void Collect(Floor[,] floors)
        {
            Gaming0316.instance.GameBoard.DisplayText($"---拾取---");
            if (floors[X, Y].Items.Count == 0)
            {
                Gaming0316.instance.GameBoard.DisplayText($"{Name}捡了一把空气");
                return;
            }
            for (int i = floors[X, Y].Items.Count - 1; i >= 0; i--)
            {
                var item = floors[X, Y].Items[i];
                Items.Add(item);
                floors[X, Y].Items.Remove(item);
                Object.Destroy(item.SpriteGO);
                Gaming0316.instance.GameBoard.DisplayText($"{Name}拾取了{item.Name},{item.ItemType}");

                var fastItem = FastItems.FirstOrDefault(c => c.Item == null);
                fastItem.AddItem(item);
            }
        }

        internal void Check(Floor[,] floors)
        {
            Gaming0316.instance.GameBoard.DisplayText($"---查看---");
            foreach (var item in floors[X, Y].Items)
            {
                item.Display(Gaming0316.instance.GameBoard);
            }
            foreach (var creature in floors[X, Y].Creatures)
            {
                if (creature.IsPlayer)
                    continue;
                creature.Display(Gaming0316.instance.GameBoard);
            }
        }

        internal void UseFastItem(string v)
        {
            Gaming0316.instance.GameBoard.DisplayText($"---使用道具---");
            var fastItem = FastItems.FirstOrDefault(c => c.Key == v);
            if (fastItem == null)
            {
                Gaming0316.instance.GameBoard.DisplayText($"{Name}喝了口空气");
                return;
            }
            var buff = Dictionaries.BuffDic[fastItem.Item.ItemType];
            Buffs.Add(buff.Key, buff.Value);
            Gaming0316.instance.GameBoard.DisplayText($"{Name}使用了{buff.Key},持续({ buff.Value})回合");

            //二步走
            //操作 界面对象
            //操作 逻辑对象
            Gaming0316.Destroy(fastItem.Item.SpriteGO);//界面
            Items.Remove(fastItem.Item);//包裹
            fastItem.Item = null;//快捷栏
        }
    }
    public class CheckMovementResult
    {
        public bool IsOverEdge { set; get; }
    }
    public interface AttackableCreature
    {
        int Attr_HP { set; get; }
        int Attr_AttackMax { set; get; }
        int Attr_AttackMin { set; get; }
        int Attr_Defend { set; get; }
        Dictionary<Buff, int> Buffs { set; get; }
        //AttackResult Attack(AttackableCreature creature, Dictionary<Buff, int> buffs);
        string GetAttackableCreatureDiscription();
    }
    public class AttackResult
    {
        public int ChangedHP;
        public bool IsDead;

        public Creature Creature { get; internal set; }
    }
    public class SeedRandom : ICloneableObject<SeedRandom>
    {
        private int[] numbers;
        private int currentIndex;

        public int Total { get; }
        public int Seed { get; }

        public SeedRandom(int total, int seed)
        {
            Total = total;
            Seed = seed;
            numbers = new int[total];
            for (int i = 0; i < seed; i++)
            {
                numbers[i] = 1;
            }
            for (int i = seed; i < total; i++)
            {
                numbers[i] = 0;
            }
            Shuffle();
        }

        private void Shuffle()
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                int j = Random.Range(i, numbers.Length);
                int temp = numbers[i];
                numbers[i] = numbers[j];
                numbers[j] = temp;
            }
            currentIndex = 0;
        }

        public int GetNext()
        {
            if (currentIndex == numbers.Length)
            {
                Shuffle();
            }
            return numbers[currentIndex++];
        }

        public SeedRandom Clone()
        {
            return new SeedRandom(Total, Seed);
        }
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