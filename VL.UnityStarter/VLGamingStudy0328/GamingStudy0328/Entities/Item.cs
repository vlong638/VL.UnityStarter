using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scenes.VLGamingStudy0328
{
    public class Item : UnityObject //,ICloneableObject<Item> 会导致泛型混淆
    {
        public ItemType ItemType;

        public Item(GameObject spriteGO, string name) : base(spriteGO, name)
        {
            if (spriteGO == null)
                return;
            spriteGO.GetComponent<SpriteRenderer>().sortingOrder = (int)SortingOrder.Item;
        }

        //public Item Clone()
        //{
        //    Item clone = new Item(CloneHelper.Clone(SpriteGO));
        //    clone.Name = Name;
        //    return clone;
        //}

        internal void Display(GameBoard gameBoard)
        {
            gameBoard.DisplayText(VLDictionaries.GetDescriptionByCode(Name));
        }
    }
}
