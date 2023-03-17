using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}