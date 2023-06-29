using System.Collections.Generic;
using UnityEngine;
using Assets.Scenes.VLGamingStudy0328;

namespace Assets.Scenes.VLGamingStudy0328
{
    public static class VLDictionaries
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
            return !string.IsNullOrEmpty(name) && VLDictionaries.CodeDescriptions.ContainsKey(name) ? VLDictionaries.CodeDescriptions[name] : "???";
        }
        public static Dictionary<string, CreatureFightDecorator> CodeCreatureMathModels = new Dictionary<string, CreatureFightDecorator>()
        {

            {nameof(Player),new CreatureFightDecorator(){
                Attr_AttackMax_from = 17,
                Attr_AttackMax_to = 20,
                Attr_AttackMin_from=4,
                Attr_AttackMin_to = 6,
                Attr_HP_from=100,
                Attr_HP_to = 100,
                Attr_Defend_from=3,
                Attr_Defend_to=6,
            } },
            {"ArcherGoblin",new CreatureFightDecorator(){
                Attr_AttackMax_from = 17,
                Attr_AttackMax_to = 20,
                Attr_AttackMin_from=4,
                Attr_AttackMin_to = 6,
                Attr_HP_from=30,
                Attr_HP_to = 45,
                Attr_Defend_from=3,
                Attr_Defend_to=6,
            } },
            {"ClubGoblin",new CreatureFightDecorator(){
                Attr_AttackMax_from = 17,
                Attr_AttackMax_to = 20,
                Attr_AttackMin_from=14,
                Attr_AttackMin_to = 16,
                Attr_HP_from=60,
                Attr_HP_to = 75,
                Attr_Defend_from=6,
                Attr_Defend_to=7,} },
            {"FarmerGoblin",new CreatureFightDecorator(){
                Attr_AttackMax_from = 7,
                Attr_AttackMax_to = 10,
                Attr_AttackMin_from=4,
                Attr_AttackMin_to = 6,
                Attr_HP_from=50,
                Attr_HP_to = 65,
                Attr_Defend_from=1,
                Attr_Defend_to=2,} },
            {"KamikazeGoblin",new CreatureFightDecorator(){
                Attr_AttackMax_from = 7,
                Attr_AttackMax_to = 10,
                Attr_AttackMin_from=4,
                Attr_AttackMin_to = 6,
                Attr_HP_from=30,
                Attr_HP_to = 45,
                Attr_Defend_from=3,
                Attr_Defend_to=6,} },
            {"SpearGoblin",new CreatureFightDecorator(){
                Attr_AttackMax_from = 27,
                Attr_AttackMax_to = 20,
                Attr_AttackMin_from=14,
                Attr_AttackMin_to = 16,
                Attr_HP_from=60,
                Attr_HP_to = 75,
                Attr_Defend_from=11,
                Attr_Defend_to=12,} },
            {"Minotaur",new CreatureFightDecorator(){
                Attr_AttackMax_from = 47,
                Attr_AttackMax_to = 40,
                Attr_AttackMin_from=34,
                Attr_AttackMin_to = 36,
                Attr_HP_from=230,
                Attr_HP_to = 245,
                Attr_Defend_from=31,
                Attr_Defend_to=42,} },
            {"Orc",new CreatureFightDecorator(){
                Attr_AttackMax_from = 57,
                Attr_AttackMax_to = 60,
                Attr_AttackMin_from=44,
                Attr_AttackMin_to = 46,
                Attr_HP_from=130,
                Attr_HP_to = 145,
                Attr_Defend_from=21,
                Attr_Defend_to=22,} },
            {"OrcMage",new CreatureFightDecorator(){
                Attr_AttackMax_from = 7,
                Attr_AttackMax_to = 10,
                Attr_AttackMin_from=4,
                Attr_AttackMin_to = 6,
                Attr_HP_from=70,
                Attr_HP_to = 85,
                Attr_Defend_from=11,
                Attr_Defend_to=12, } },
            {"OrcShaman",new CreatureFightDecorator(){
                Attr_AttackMax_from = 7,
                Attr_AttackMax_to = 10,
                Attr_AttackMin_from=4,
                Attr_AttackMin_to = 6,
                Attr_HP_from=60,
                Attr_HP_to = 75,
                Attr_Defend_from=1,
                Attr_Defend_to=2,} },
            {"ArmouredRedDemon",new CreatureFightDecorator(){
                Attr_AttackMax_from = 71,
                Attr_AttackMax_to = 102,
                Attr_AttackMin_from=41,
                Attr_AttackMin_to = 62,
                Attr_HP_from=230,
                Attr_HP_to = 245,
                Attr_Defend_from=61,
                Attr_Defend_to=82,} },
            {"PurpleDemon",new CreatureFightDecorator(){
                Attr_AttackMax_from = 71,
                Attr_AttackMax_to = 102,
                Attr_AttackMin_from=41,
                Attr_AttackMin_to = 62,
                Attr_HP_from=230,
                Attr_HP_to = 245,
                Attr_Defend_from=61,
                Attr_Defend_to=82,} },
            {"RedDemon",new CreatureFightDecorator(){
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
            return type != SoundAudioType.None && CodeAudios.ContainsKey(type) ? VLDictionaries.CodeAudios[type] : null;
        }
        static VLDictionaries()
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
}
