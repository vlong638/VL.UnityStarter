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


        #endregion

        #region Float


        #endregion
    }
}