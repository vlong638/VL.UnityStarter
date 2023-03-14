using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}

public static class ValueEx
{
    public static Color ToColor(this string s)
    {
        ColorUtility.TryParseHtmlString(s, out var c);
        return c;
    }
}