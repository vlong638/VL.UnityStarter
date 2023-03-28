using UnityEngine;

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
