using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scenes.GamingStudy0328
{
    public class FastItem
    {
        public GameObject Parent;
        public GameObject FastItemBlock;
        public Item Item;
        public string Name;
        public string Key;

        public FastItem(GameObject spriteGO)
        {
            this.FastItemBlock = spriteGO;
        }

        public float FastItemBlockX { get; internal set; }
        public float FastItemBlockY { get; internal set; }

        internal void AddItem(Item item)
        {
            var imageGO = VLCreater.CreateImage("FastItemImage", Parent);
            var image = imageGO.GetComponent<Image>();
            image.color = Dictionaries.ColorDic[item.ItemType.ToString()];
            image.rectTransform.anchorMin = new Vector2(0f, 0f);
            image.rectTransform.anchorMax = new Vector2(0f, 0f);
            image.rectTransform.pivot = new Vector2(0f, 0f);
            image.rectTransform.sizeDelta = new Vector2(40, 40);
            image.rectTransform.anchoredPosition = new Vector2(FastItemBlockX + 20, FastItemBlockY + 20);
            image.rectTransform.localScale = new Vector3(1.5f, 1.5f, 0);
            item.SpriteGO = imageGO;
            Item = item;
        }

        internal void UseItem()
        {
            Gaming0328.Destroy(Item.SpriteGO);
            Item = null;
        }
    }
}
