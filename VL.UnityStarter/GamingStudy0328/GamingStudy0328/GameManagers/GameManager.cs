using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scenes.GamingStudy0328
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance = null;
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
        internal GameObject gameboardGO { set; get; }
        internal GameObject settingGO { set; get; }

        public GameBoard GameBoard { set; get; }

        void Start()
        {
            Debug.Log($"Start");

            startGO = GameObject.Find("startGO");
            assetGO = GameObject.Find("assetGO");
            gameboardGO = GameObject.Find("gameboardGO");
            settingGO = GameObject.Find("settingGO");
            //start
            var gameObject = GameObject.Find("start");
            var button = gameObject.GetComponent<Button>();
            button.onClick.AddListener(StartGame);
            //load
            gameObject = GameObject.Find("load");
            button = gameObject.GetComponent<Button>();
            button.onClick.AddListener(Load);
            //config
            gameObject = GameObject.Find("config");
            button = gameObject.GetComponent<Button>();
            button.onClick.AddListener(Config);
            //end
            gameObject = GameObject.Find("end");
            button = gameObject.GetComponent<Button>();
            button.onClick.AddListener(EndGame);

            //Ԥ����
            GameBoard = new GameBoard();
            GameBoard.GameboardGO = gameboardGO;
            StartCoroutine(nameof(PrepareAsset), GameBoard);

            //��������
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
        private void Config()
        {
            Debug.Log($"Config Ended");
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
                Debug.Log("���ڼ�����Դ");
                yield return new WaitForSeconds(1f);
            }

            SoundManager.instance.StopMusic();

            Debug.Log($"StartingGame");
            isStarting = true;
            startGO.SetActive(false);
            gameboardGO.SetActive(true);
            assetGO.SetActive(false);
            settingGO.SetActive(false);
            GameBoard.PreInit();
            GameBoard.DisplayText("��ʼ���ɵ���");
            yield return GameBoard.InitFloors();
            GameBoard.DisplayText("��ʼ���ɳ���");
            yield return GameBoard.InitTowns();
            GameBoard.DisplayText("��ʼ���ɵз�����");
            yield return GameBoard.InitEnermyTowns();
            GameBoard.DisplayText("��ʼ���ɿ��");
            yield return GameBoard.InitCaves();
            GameBoard.DisplayText("��ʼ���ɵ�·");
            yield return GameBoard.InitRoads();
            GameBoard.DisplayText("��ʼ������ʯ");
            yield return GameBoard.InitStones();
            GameBoard.DisplayText("��ʼ������ľ");
            yield return GameBoard.InitTrees();
            GameBoard.DisplayText("��ʼ���ɺ���");
            yield return GameBoard.InitRivers();
            GameBoard.DisplayText("��ʼ�������");
            yield return GameBoard.InitPlayer();
            GameBoard.DisplayText("��ʼ��������ͷ");
            yield return GameBoard.InitCamera();
            //yield return new WaitForSeconds(1f); // ģ�ⳤʱ������

            isStarting = false;
        }

        #endregion

        private void PrepareAsset(GameBoard gameBoard)
        {
            GameBoard.IsResourceReady = false;

            #region Images
            //Ѫ��
            var sprite = Resources.Load<Sprite>("vl/white");
            var spriteGO = VLCreater.CreateSprite(sprite, "BloodBar");
            spriteGO.transform.localScale = new Vector3(12, 1, 1);
            spriteGO.transform.localPosition = new Vector3(0, 0.09f, 0);
            var spriteRender = spriteGO.GetComponent<SpriteRenderer>();
            spriteRender.color = "#FF0000".ToColor();
            spriteRender.sortingOrder = (int)SortingOrder.AboveAll;
            GameBoard.Resource_BloodBar = spriteGO;
            sprite = Resources.Load<Sprite>("vl/white");
            spriteGO = VLCreater.CreateSprite(sprite, "MagicBar");
            spriteGO.transform.localScale = new Vector3(12, 1, 1);
            spriteGO.transform.localPosition = new Vector3(0, 0.08f, 0);
            spriteRender = spriteGO.GetComponent<SpriteRenderer>();
            spriteRender.color = "#0077F8".ToColor();
            spriteRender.sortingOrder = (int)SortingOrder.AboveAll;
            GameBoard.Resource_MagicBar = spriteGO;
            //�ݵ�
            var sprites = Resources.LoadAll<Sprite>("16x16-mini-world-sprites/Ground/Grass");
            GameBoard.Resource_Grounds = new List<Floor>();
            GameBoard.Resource_Grounds.Add(new Floor(VLCreater.CreateSprite(sprites.First(c => c.name == "Grass_1"), "Grass_1", assetGO), FloorType.Grassland));
            GameBoard.Resource_Grounds.Add(new Floor(VLCreater.CreateSprite(sprites.First(c => c.name == "Grass_2"), "Grass_2", assetGO), FloorType.Grassland));
            //��·
            GameBoard.Resource_Roads = new List<Floor>();
            GameBoard.Resource_Roads.Add(new Floor(VLCreater.CreateSprite(sprites.First(c => c.name == "Grass_3"), "Grass_3", assetGO), FloorType.Grassland));
            GameBoard.Resource_Roads.Add(new Floor(VLCreater.CreateSprite(sprites.First(c => c.name == "Grass_4"), "Grass_4", assetGO), FloorType.Grassland));
            //�ݵ�
            sprites = Resources.LoadAll<Sprite>("16x16-mini-world-sprites/Ground/TexturedGrass");
            GameBoard.Resource_Grounds.Add(new Floor(VLCreater.CreateSprite(sprites.First(c => c.name == "TexturedGrass_1"), "TexuredGrass_1", assetGO), FloorType.Grassland));
            GameBoard.Resource_Grounds.Add(new Floor(VLCreater.CreateSprite(sprites.First(c => c.name == "TexturedGrass_2"), "TexuredGrass_2", assetGO), FloorType.Grassland));
            GameBoard.Resource_Grounds.Add(new Floor(VLCreater.CreateSprite(sprites.First(c => c.name == "TexturedGrass_4"), "TexuredGrass_4", assetGO), FloorType.Grassland));
            GameBoard.Resource_Grounds.Add(new Floor(VLCreater.CreateSprite(sprites.First(c => c.name == "TexturedGrass_5"), "TexuredGrass_5", assetGO), FloorType.Grassland));
            //��ˮ
            sprites = Resources.LoadAll<Sprite>("16x16-mini-world-sprites/Ground/Shore");
            GameBoard.Resource_Waters = new List<Floor>();
            GameBoard.Resource_Waters.Add(new Floor(VLCreater.CreateSprite(sprites.First(c => c.name == "Shore_4"), "Shore_4", assetGO), FloorType.River));
            //��̲
            GameBoard.Resource_GradientWaters = new List<Floor>();
            GameBoard.Resource_GradientWaters.Add(new Floor(VLCreater.CreateSprite(sprites.First(c => c.name == "Shore_0"), "Shore_0", assetGO), FloorType.Shore));
            GameBoard.Resource_GradientWaters.Add(new Floor(VLCreater.CreateSprite(sprites.First(c => c.name == "Shore_1"), "Shore_1", assetGO), FloorType.Shore));
            GameBoard.Resource_GradientWaters.Add(new Floor(VLCreater.CreateSprite(sprites.First(c => c.name == "Shore_2"), "Shore_2", assetGO), FloorType.Shore));
            GameBoard.Resource_GradientWaters.Add(new Floor(VLCreater.CreateSprite(sprites.First(c => c.name == "Shore_3"), "Shore_3", assetGO), FloorType.Shore));
            //ʯ���
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
            //ʯ������
            GameBoard.Resource_Mountains_StoneMine = new Entrance(VLCreater.CreateSprite(sprites.First(c => c.name == "Cliff_9"), "Cliff_9", assetGO), EntranceType.StoneMine);
            //ͭ���
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
            //ͭ������
            GameBoard.Resource_Mountains_CopperMine = new Entrance(VLCreater.CreateSprite(sprites.First(c => c.name == "Cliff_8"), "Cliff_8", assetGO), EntranceType.CopperMine);
            //��ʯ
            GameBoard.Resource_Mountains_StoneOre = new BlockItem(VLCreater.CreateSprite(sprites.First(c => c.name == "Cliff_4"), "Cliff_4", assetGO), BlockType.Stone);
            //��ʯ(��)
            GameBoard.Resource_Mountains_CutterOre = new BlockItem(VLCreater.CreateSprite(sprites.First(c => c.name == "Cliff_3"), "Cliff_3", assetGO), BlockType.Stone);
            //��ʯ(����)
            GameBoard.Resource_Mountains_BigOre = new List<BlockItem>();
            GameBoard.Resource_Mountains_BigOre.Add(new BlockItem(VLCreater.CreateSprite(sprites.First(c => c.name == "Cliff_15"), "Cliff_15", assetGO), BlockType.Stone));
            GameBoard.Resource_Mountains_BigOre.Add(new BlockItem(VLCreater.CreateSprite(sprites.First(c => c.name == "Cliff_16"), "Cliff_16", assetGO), BlockType.Stone));
            GameBoard.Resource_Mountains_BigOre.Add(new BlockItem(VLCreater.CreateSprite(sprites.First(c => c.name == "Cliff_22"), "Cliff_22", assetGO), BlockType.Stone));
            GameBoard.Resource_Mountains_BigOre.Add(new BlockItem(VLCreater.CreateSprite(sprites.First(c => c.name == "Cliff_23"), "Cliff_23", assetGO), BlockType.Stone));
            //��ľ
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
            //����
            sprites = Resources.LoadAll<Sprite>("16x16-mini-world-sprites/Nature/Wheatfield");
            GameBoard.Resource_Wheatfield = new Wheatfield(
                VLCreater.CreateSprite(sprites.First(c => c.name == "Wheatfield_0"), "Wheatfield_0", assetGO)
                , VLCreater.CreateSprite(sprites.First(c => c.name == "Wheatfield_1"), "Wheatfield_1", assetGO)
                , VLCreater.CreateSprite(sprites.First(c => c.name == "Wheatfield_2"), "Wheatfield_2", assetGO)
                , VLCreater.CreateSprite(sprites.First(c => c.name == "Wheatfield_3"), "Wheatfield_3", assetGO)
                );
            //ð�ն�Ѩ
            sprites = Resources.LoadAll<Sprite>("16x16-mini-world-sprites/Buildings/Wood/CaveV2");
            GameBoard.Resource_Caves = new List<Cave>();
            GameBoard.Resource_Caves.Add(new Cave(VLCreater.CreateSprite(sprites.First(c => c.name == "CaveV2_0"), "CaveV2_0", assetGO)));
            GameBoard.Resource_Caves.Add(new Cave(VLCreater.CreateSprite(sprites.First(c => c.name == "CaveV2_1"), "CaveV2_1", assetGO)));
            GameBoard.Resource_Caves.Add(new Cave(VLCreater.CreateSprite(sprites.First(c => c.name == "CaveV2_2"), "CaveV2_2", assetGO)));
            GameBoard.Resource_Caves.Add(new Cave(VLCreater.CreateSprite(sprites.First(c => c.name == "CaveV2_3"), "CaveV2_3", assetGO)));
            GameBoard.Resource_Caves.Add(new Cave(VLCreater.CreateSprite(sprites.First(c => c.name == "CaveV2_4"), "CaveV2_4", assetGO)));
            GameBoard.Resource_Caves.Add(new Cave(VLCreater.CreateSprite(sprites.First(c => c.name == "CaveV2_5"), "CaveV2_5", assetGO)));
            //����(С)
            sprites = Resources.LoadAll<Sprite>("16x16-mini-world-sprites/Buildings/Wood/Chapels");
            GameBoard.Resource_Towns = new List<Town>();
            GameBoard.Resource_Towns.Add(new Town(VLCreater.CreateSprite(sprites.First(c => c.name == "Chapels_0"), "Chapels_0", assetGO)));
            GameBoard.Resource_Towns.Add(new Town(VLCreater.CreateSprite(sprites.First(c => c.name == "Chapels_1"), "Chapels_1", assetGO)));
            GameBoard.Resource_Towns.Add(new Town(VLCreater.CreateSprite(sprites.First(c => c.name == "Chapels_2"), "Chapels_2", assetGO)));
            GameBoard.Resource_Towns.Add(new Town(VLCreater.CreateSprite(sprites.First(c => c.name == "Chapels_3"), "Chapels_3", assetGO)));
            GameBoard.Resource_Towns.Add(new Town(VLCreater.CreateSprite(sprites.First(c => c.name == "Chapels_4"), "Chapels_4", assetGO)));
            GameBoard.Resource_Towns.Add(new Town(VLCreater.CreateSprite(sprites.First(c => c.name == "Chapels_5"), "Chapels_5", assetGO)));
            //����(��)
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
            //����
            sprites = Resources.LoadAll<Sprite>("16x16-mini-world-sprites/Characters/Monsters/Orcs/ArcherGoblin");
            GameBoard.Resource_ArcherGoblin = new Creature(VLCreater.CreateSprite(sprites.First(c => c.name == "ArcherGoblin_0"), "ArcherGoblin", assetGO))
            { DiedSounds = VLDictionaries.GetCodeAudioByCode(SoundAudioType.Orc_Die) };
            sprites = Resources.LoadAll<Sprite>("16x16-mini-world-sprites/Characters/Monsters/Orcs/ClubGoblin");
            GameBoard.Resource_ClubGoblin = new Creature(VLCreater.CreateSprite(sprites.First(c => c.name == "ClubGoblin_0"), "ClubGoblin", assetGO))
            { DiedSounds = VLDictionaries.GetCodeAudioByCode(SoundAudioType.Orc_Die) };
            sprites = Resources.LoadAll<Sprite>("16x16-mini-world-sprites/Characters/Monsters/Orcs/FarmerGoblin");
            GameBoard.Resource_FarmerGoblin = new Creature(VLCreater.CreateSprite(sprites.First(c => c.name == "FarmerGoblin_0"), "FarmerGoblin", assetGO))
            { DiedSounds = VLDictionaries.GetCodeAudioByCode(SoundAudioType.Orc_Die) };
            sprites = Resources.LoadAll<Sprite>("16x16-mini-world-sprites/Characters/Monsters/Orcs/KamikazeGoblin");
            GameBoard.Resource_KamikazeGoblin = new Creature(VLCreater.CreateSprite(sprites.First(c => c.name == "KamikazeGoblin_0"), "KamikazeGoblin", assetGO))
            { DiedSounds = VLDictionaries.GetCodeAudioByCode(SoundAudioType.Orc_Die) };
            sprites = Resources.LoadAll<Sprite>("16x16-mini-world-sprites/Characters/Monsters/Orcs/SpearGoblin");
            GameBoard.Resource_SpearGoblin = new Creature(VLCreater.CreateSprite(sprites.First(c => c.name == "SpearGoblin_0"), "SpearGoblin", assetGO))
            { DiedSounds = VLDictionaries.GetCodeAudioByCode(SoundAudioType.Orc_Die) };
            sprites = Resources.LoadAll<Sprite>("16x16-mini-world-sprites/Characters/Monsters/Orcs/Minotaur");
            GameBoard.Resource_Minotaur = new Creature(VLCreater.CreateSprite(sprites.First(c => c.name == "Minotaur_0"), "Minotaur", assetGO))
            { DiedSounds = VLDictionaries.GetCodeAudioByCode(SoundAudioType.Orc_Die) };
            sprites = Resources.LoadAll<Sprite>("16x16-mini-world-sprites/Characters/Monsters/Orcs/Orc");
            GameBoard.Resource_Orc = new Creature(VLCreater.CreateSprite(sprites.First(c => c.name == "Orc_0"), "Orc", assetGO))
            { DiedSounds = VLDictionaries.GetCodeAudioByCode(SoundAudioType.Orc_Die) };
            sprites = Resources.LoadAll<Sprite>("16x16-mini-world-sprites/Characters/Monsters/Orcs/OrcMage");
            GameBoard.Resource_OrcMage = new Creature(VLCreater.CreateSprite(sprites.First(c => c.name == "OrcMage_0"), "OrcMage", assetGO))
            { DiedSounds = VLDictionaries.GetCodeAudioByCode(SoundAudioType.Orc_Die) };
            sprites = Resources.LoadAll<Sprite>("16x16-mini-world-sprites/Characters/Monsters/Orcs/OrcShaman");
            GameBoard.Resource_OrcShaman = new Creature(VLCreater.CreateSprite(sprites.First(c => c.name == "OrcShaman_0"), "OrcShaman", assetGO))
            { DiedSounds = VLDictionaries.GetCodeAudioByCode(SoundAudioType.Orc_Die) };
            //BOSS
            sprites = Resources.LoadAll<Sprite>("16x16-mini-world-sprites/Characters/Monsters/Demons/ArmouredRedDemon");
            GameBoard.Resource_ArmouredRedDemon = new Creature(VLCreater.CreateSprite(sprites.First(c => c.name == "ArmouredRedDemon_0"), "ArmouredRedDemon", assetGO))
            { DiedSounds = VLDictionaries.GetCodeAudioByCode(SoundAudioType.Orc_Die) };
            sprites = Resources.LoadAll<Sprite>("16x16-mini-world-sprites/Characters/Monsters/Demons/PurpleDemon");
            GameBoard.Resource_PurpleDemon = new Creature(VLCreater.CreateSprite(sprites.First(c => c.name == "PurpleDemon_0"), "PurpleDemon", assetGO))
            { DiedSounds = VLDictionaries.GetCodeAudioByCode(SoundAudioType.Orc_Die) };
            sprites = Resources.LoadAll<Sprite>("16x16-mini-world-sprites/Characters/Monsters/Demons/RedDemon");
            GameBoard.Resource_RedDemon = new Creature(VLCreater.CreateSprite(sprites.First(c => c.name == "RedDemon_0"), "RedDemon", assetGO))
            { DiedSounds = VLDictionaries.GetCodeAudioByCode(SoundAudioType.Orc_Die) };
            //���˳�Ѩ(С)
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
            //���˳�Ѩ(��)
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
            //�ص�
            //��Ʒ
            //���
            sprites = Resources.LoadAll<Sprite>("16x16-mini-world-sprites/Characters/Champions/Gangblanc");
            GameBoard.Resource_Player = new Creature(VLCreater.CreateSprite(sprites[0], "Player"))
            { DiedSounds = VLDictionaries.GetCodeAudioByCode(SoundAudioType.Human_DeepHurt) };
            #endregion

            GameBoard.IsResourceReady = true;
        }
    }
}