using UnityEngine;

namespace VL.Gaming2D
{
    public static partial class ValueEx
    {
        #region Color

        public static Color ToColor(this string s)
        {
            ColorUtility.TryParseHtmlString(s, out var c);
            return c;
        }

        #endregion

        #region GameObject

        public static void SetParent(this GameObject go, GameObject parent)
        {
            go.transform.parent = parent.transform;
        }

        #endregion

        #region Vector3

        public static bool IsZeroDistance(this Vector3 v1, Vector3 v2)
        {
            return (v1 - v2).sqrMagnitude < float.Epsilon;
        }

        #endregion

        #region Float

        public static bool IsZero(this float v)
        {
            return v < float.Epsilon;
        }

        #endregion
    }
}