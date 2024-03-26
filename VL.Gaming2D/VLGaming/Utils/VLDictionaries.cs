using System.Collections.Generic;
using UnityEngine;

namespace VL.Gaming2D
{
    public static class VLDictionaries
    {
        public static Dictionary<string, Color> ColorDic = new Dictionary<string, Color>()
        {
            //{ nameof(FastItem.FastItemBlock), Color.black},
            //{ nameof(Creature), "#FF0F00".ToColor()},
            //{ nameof(Floor), "#BC9401".ToColor()},
            //{ nameof(ItemType.DoubleAttack), "#DC00E7".ToColor()},
            //{ nameof(ItemType.DoubleDefend), Color.yellow},
            //{ nameof(ItemType.DoubleSpeed), Color.blue},
        };
        public static Dictionary<string, string> CodeDescriptions = new Dictionary<string, string>()
        {
            //{"Grass_1","Grass_1"},
            //{"Grass_2","Grass_2"},
            //{"Grass_3","Grass_3"},
            //{"Grass_4","Grass_4"},
        };
        static VLDictionaries()
        {
            //CodeAudios.Add(SoundAudioType.Move_Grass, new List<AudioClip>() { Resources.Load<AudioClip>("Audio/Move1")
            //,Resources.Load<AudioClip>("Audio/Move2")});
            //CodeAudios.Add(SoundAudioType.Move_Stone, new List<AudioClip>() { Resources.Load<AudioClip>("Audio/Move_Stone")
            //,Resources.Load<AudioClip>("Audio/Move_Stone2")});
        }
    }
}
