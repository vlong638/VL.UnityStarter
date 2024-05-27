using System;
using UnityEngine;
using UnityEngine.UI;

namespace VL.Gaming.Common
{
    public static partial class ValueEx
    {
        #region Enum
        public static int ToInt(this Enum enumValue)
        {
            return Convert.ToInt32(enumValue);
        } 
        #endregion

        #region Color
        /// <summary>
        /// 字符串 转 颜色
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static Color ToColor(this string s)
        {
            ColorUtility.TryParseHtmlString(s, out var c);
            return c;
        }
        /// <summary>
        /// 设置下级组件的颜色
        /// </summary>
        /// <param name="backgroundGO"></param>
        /// <param name="color"></param>
        /// <param name="alpha"></param>
        public static void SetColor(this GameObject backgroundGO, Color color, float alpha = 1)
        {
            var image = backgroundGO.GetComponent<Image>();
            color.a = alpha;
            image.color = color;
        }
        /// <summary>
        /// 设置下级组件的颜色
        /// </summary>
        /// <param name="backgroundGO"></param>
        /// <param name="color"></param>
        /// <param name="alpha"></param>
        public static void SetColorAlpha(this Image image, float alpha = 1)
        {
            var color = image.color;
            image.color =  new Color(color.r, color.g, color.b, alpha);
        }
        #endregion

        #region GameObject

        /// <summary>
        /// 设置 Parent
        /// </summary>
        /// <param name="go"></param>
        /// <param name="parent"></param>
        public static void SetParent(this GameObject go, GameObject parent)
        {
            go.transform.SetParent(parent.transform);
        }
        public static void SetScale(this GameObject go, float x, float y, float z)
        {
            go.transform.localScale = new Vector3(x, y, z);
        }
        public static void SetPosition(this GameObject go, float x, float y, float z)
        {
            go.transform.position = new Vector3(x, y, z);
        }
        #endregion

        #region RectTransform
        /// <summary>
        /// 设置成 Stretch
        /// </summary>
        /// <param name="rectTransform"></param>
        public static void SetStretch(this RectTransform rectTransform, int left = 0, int right = 0, int up = 0, int down = 0)
        {
            rectTransform.anchorMin = new Vector2(0, 0);//设置RectTransform的最小锚点位置为左下角
            rectTransform.anchorMax = new Vector2(1, 1);//设置RectTransform的最大锚点位置为右上角
            rectTransform.offsetMin = new Vector2(left, up);//设置RectTransform的最小偏移量
            rectTransform.offsetMax = new Vector2(-right, -down);//设置RectTransform的最大偏移量
            rectTransform.pivot = new Vector2(0.5f, 0.5f);//设置RectTransform的中心点为中心, 翻转中心
        }
        /// <summary>
        /// 设置成 左下角对齐
        /// </summary>
        /// <param name="rectTransform"></param>
        public static void SetLeftDown(this RectTransform rectTransform, float offsetX, float offsetY, float x, float y)
        {
            rectTransform.anchorMin = new Vector2(0, 0);//设置RectTransform的最小锚点位置为左下角
            rectTransform.anchorMax = new Vector2(0, 0);//设置RectTransform的最大锚点位置为右上角
            rectTransform.pivot = new Vector2(0, 0);//设置RectTransform的中心点为中心, 翻转中心
            rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, offsetX, x);// SetInsetAndSizeFromParentEdge 根据父对象边缘设置位置和大小
            rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, offsetY, y);// SetInsetAndSizeFromParentEdge 根据父对象边缘设置位置和大小
        }
        /// <summary>
        /// 设置成 左上角对齐
        /// </summary>
        /// <param name="rectTransform"></param>
        public static void SetLeftTop(this RectTransform rectTransform, float offsetX, float offsetY, float x, float y)
        {
            rectTransform.anchorMin = new Vector2(0, 1);//设置RectTransform的最小锚点位置为左下角
            rectTransform.anchorMax = new Vector2(0, 1);//设置RectTransform的最大锚点位置为右上角
            rectTransform.pivot = new Vector2(0, 1);//设置RectTransform的中心点为中心, 翻转中心
            rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, offsetX, x);// SetInsetAndSizeFromParentEdge 根据父对象边缘设置位置和大小
            rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, offsetY, y);// SetInsetAndSizeFromParentEdge 根据父对象边缘设置位置和大小
        }
        /// <summary>
        /// 设置成 上下对齐(右侧)
        /// </summary>
        /// <param name="rectTransform"></param>
        public static void SetTopDownOnRight(this RectTransform rectTransform)
        {
            rectTransform.anchorMin = new Vector2(1, 0);//设置RectTransform的最小锚点位置为左下角
            rectTransform.anchorMax = new Vector2(1, 1);//设置RectTransform的最大锚点位置为右上角
            rectTransform.pivot = new Vector2(0, 0.5f);//设置RectTransform的中心点为中心, 翻转中心
        }
        /// <summary>
        /// 设置成 左右对齐(底部)
        /// </summary>
        /// <param name="rectTransform"></param>
        public static void SetLeftRightOnBottom(this RectTransform rectTransform)
        {
            rectTransform.anchorMin = new Vector2(0, 0);//设置RectTransform的最小锚点位置为左下角
            rectTransform.anchorMax = new Vector2(1, 0);//设置RectTransform的最大锚点位置为右上角
            rectTransform.pivot = new Vector2( 0.5f,0);//设置RectTransform的中心点为中心, 翻转中心
        }
        #endregion
    }
}
