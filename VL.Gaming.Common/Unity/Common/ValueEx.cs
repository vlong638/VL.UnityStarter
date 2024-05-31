using System;
using UnityEngine;
using UnityEngine.UI;

namespace VL.Gaming.Common
{
    public static partial class ValueEx
    {
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
            image.color = new Color(color.r, color.g, color.b, alpha);
        }
        #endregion

        #region Enum
        public static int ToInt(this Enum enumValue)
        {
            return Convert.ToInt32(enumValue);
        }
        #endregion

        #region GameObject

        public static void SetParent(this GameObject go, GameObject parent)
        {
            go.transform.SetParent(parent.transform);
        }
        public static void SetPosition(this GameObject go, float x, float y, float z)
        {
            go.transform.position = new Vector3(x, y, z);
        }
        public static void SetScale(this GameObject go, float x, float y, float z = 1)
        {
            go.transform.localScale = new Vector3(x, y, z);
        }
        public static void SetSizeDelta(this GameObject go, float x, float y)
        {
            go.SetSizeDelta(new Vector2(x, y));
        }
        public static void SetSizeDelta(this GameObject go, Vector2 sizeDelta)
        {
            go.GetComponent<RectTransform>().sizeDelta = sizeDelta;
        }
        public static void SetImageColor(this GameObject go, Color color)
        {
            go.GetComponent<Image>().color = color;
        }
        public static void SetRectStretch(this GameObject gameObject, int left = 0, int right = 0, int up = 0, int down = 0)
        {
            var rectTransform = gameObject.GetComponent<RectTransform>();
            rectTransform.SetRectStretch(left, right, up, down);
        }
        public static void SetRectLeftDown(this GameObject gameObject, float offsetX, float offsetY, float x, float y)
        {
            var rectTransform = gameObject.GetComponent<RectTransform>();
            rectTransform.SetRectLeftDown(offsetX, offsetY, x, y);
        }
        public static void SetRectLeftTop(this GameObject gameObject, float offsetX, float offsetY, float x, float y)
        {
            var rectTransform = gameObject.GetComponent<RectTransform>();
            rectTransform.SetRectLeftTop(offsetX, offsetY, x, y);
        }
        public static void SetRectTopDownOnRight(this GameObject gameObject)
        {
            var rectTransform = gameObject.GetComponent<RectTransform>();
            rectTransform.SetRectTopDownOnRight();
        }
        public static void SetRectLeftRightOnBottom(this GameObject gameObject)
        {
            var rectTransform = gameObject.GetComponent<RectTransform>();
            rectTransform.SetRectLeftRightOnBottom();
        }

        public static GameObject GetTextObject(this GameObject go)
        {
            return go.transform.Find("Text").gameObject;
        }

        #endregion

        #region RectTransform

        /// <summary>
        /// 设置成 Stretch
        /// </summary>
        /// <param name="rectTransform"></param>
        public static void SetRectStretch(this RectTransform rectTransform, int left = 0, int right = 0, int up = 0, int down = 0)
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
        public static void SetRectLeftDown(this RectTransform rectTransform, float offsetX, float offsetY, float x, float y)
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
        public static void SetRectLeftTop(this RectTransform rectTransform, float offsetX, float offsetY, float x, float y)
        {
            rectTransform.anchorMin = new Vector2(0, 1);//设置RectTransform的最小锚点位置为左下角
            rectTransform.anchorMax = new Vector2(0, 1);//设置RectTransform的最大锚点位置为右上角
            rectTransform.pivot = new Vector2(0, 1);//设置RectTransform的中心点为中心, 翻转中心
            rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, offsetX, x);// SetInsetAndSizeFromParentEdge 根据父对象边缘设置位置和大小
            rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, -offsetY, y);// SetInsetAndSizeFromParentEdge 根据父对象边缘设置位置和大小
        }
        /// <summary>
        /// 设置成 上下对齐(右侧)
        /// </summary>
        /// <param name="rectTransform"></param>
        public static void SetRectTopDownOnRight(this RectTransform rectTransform)
        {
            rectTransform.anchorMin = new Vector2(1, 0);//设置RectTransform的最小锚点位置为左下角
            rectTransform.anchorMax = new Vector2(1, 1);//设置RectTransform的最大锚点位置为右上角
            rectTransform.pivot = new Vector2(0, 0.5f);//设置RectTransform的中心点为中心, 翻转中心
        }
        /// <summary>
        /// 设置成 左右对齐(底部)
        /// </summary>
        /// <param name="rectTransform"></param>
        public static void SetRectLeftRightOnBottom(this RectTransform rectTransform)
        {
            rectTransform.anchorMin = new Vector2(0, 0);//设置RectTransform的最小锚点位置为左下角
            rectTransform.anchorMax = new Vector2(1, 0);//设置RectTransform的最大锚点位置为右上角
            rectTransform.pivot = new Vector2(0.5f, 0);//设置RectTransform的中心点为中心, 翻转中心
        }
        #endregion


        #region Text
        #endregion
    }
}
