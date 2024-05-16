using System.Collections.Generic;
using UnityEngine;

namespace VL.Gaming.Unity.Tools
{
    public static class VLDictionaries
    {
        public static Dictionary<string, Color> ColorDic = new Dictionary<string, Color>()
        {
            //{ nameof(FastItem.FastItemBlock), Color.black},
        };
        public static Dictionary<string, string> CodeDescriptions = new Dictionary<string, string>()
        {
            {"Grass_1","Grass_1"},
            {"Grass_2","Grass_2"},
            {"Keep_0","这是一个小城镇,里面冉冉燃起了炊烟1"},
            {"Keep_1","这是一个小城镇,里面冉冉燃起了炊烟2"},
            {"Keep_11","这是一个小城镇,里面冉冉燃起了炊烟8"},
            {"AllBuildings-Preview_68","哥布林的巢穴,入口混乱不堪,掺杂着血迹1"},
            {"AllBuildings-Preview_84","哥布林的巢穴,入口混乱不堪,掺杂着血迹2"},
        };
        public static string GetDescriptionByCode(string name)
        {
            return !string.IsNullOrEmpty(name) && VLDictionaries.CodeDescriptions.ContainsKey(name) ? VLDictionaries.CodeDescriptions[name] : "???";
        }
        //public static Dictionary<string, CreatureFightDecorator> CodeCreatureMathModels = new Dictionary<string, CreatureFightDecorator>()
        //{

        //    {nameof(Player),new CreatureFightDecorator(){
        //        Attr_AttackMax_from = 17,
        //        Attr_AttackMax_to = 20,
        //        Attr_AttackMin_from=4,
        //        Attr_AttackMin_to = 6,
        //        Attr_HP_from=100,
        //        Attr_HP_to = 100,
        //        Attr_Defend_from=3,
        //        Attr_Defend_to=6,
        //    } },
        //};
        //public static Dictionary<SoundAudioType, List<AudioClip>> CodeAudios = new Dictionary<SoundAudioType, List<AudioClip>>();
        //public static List<AudioClip> GetCodeAudioByCode(SoundAudioType type)
        //{
        //    return type != SoundAudioType.None && CodeAudios.ContainsKey(type) ? VLDictionaries.CodeAudios[type] : null;
        //}
        //static VLDictionaries()
        //{
        //    CodeAudios.Add(SoundAudioType.Move_Grass, new List<AudioClip>() { Resources.Load<AudioClip>("Audio/Move1")
        //    ,Resources.Load<AudioClip>("Audio/Move2")});
        //    CodeAudios.Add(SoundAudioType.Move_Stone, new List<AudioClip>() { Resources.Load<AudioClip>("Audio/Move_Stone")
        //    ,Resources.Load<AudioClip>("Audio/Move_Stone2")});
        //    CodeAudios.Add(SoundAudioType.Collider, new List<AudioClip>() { Resources.Load<AudioClip>("Audio/Collider") });
        //    CodeAudios.Add(SoundAudioType.CutTree, new List<AudioClip>() { Resources.Load<AudioClip>("Audio/CutTree") });
        //    CodeAudios.Add(SoundAudioType.Human_DeepHurt, new List<AudioClip>() { Resources.Load<AudioClip>("Audio/Human_DeepHurt")
        //        , Resources.Load<AudioClip>("Audio/Human_DeepHurt2") });
        //    CodeAudios.Add(SoundAudioType.Human_Hurt, new List<AudioClip>() { Resources.Load<AudioClip>("Audio/Human_Hurt")
        //        , Resources.Load<AudioClip>("Audio/Human_Hurt2") });
        //    CodeAudios.Add(SoundAudioType.Mining, new List<AudioClip>() { Resources.Load<AudioClip>("Audio/Mining") });
        //    CodeAudios.Add(SoundAudioType.Mining_Grass, new List<AudioClip>() { Resources.Load<AudioClip>("Audio/Mining_Grass") });
        //    CodeAudios.Add(SoundAudioType.Orc_Attack, new List<AudioClip>() { Resources.Load<AudioClip>("Audio/Orc_Attack1")
        //        , Resources.Load<AudioClip>("Audio/Orc_Attack2") });
        //    CodeAudios.Add(SoundAudioType.Orc_Die, new List<AudioClip>() { Resources.Load<AudioClip>("Audio/Orc_Die") });
        //    CodeAudios.Add(SoundAudioType.Orc_Hurt, new List<AudioClip>() { Resources.Load<AudioClip>("Audio/Orc_Hurt1")
        //        , Resources.Load<AudioClip>("Audio/Orc_Hurt2") });
        //    CodeAudios.Add(SoundAudioType.Sword_Cut, new List<AudioClip>() { Resources.Load<AudioClip>("Audio/Sword_Cut")
        //        , Resources.Load<AudioClip>("Audio/Sword_Cut2") });
        //}
    }
}
