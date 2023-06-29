using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scenes.VLGamingStudy0328
{
    public class Floor : UnityObject
    {
        public List<Item> Items = new List<Item>();
        public List<Creature> Creatures = new List<Creature>();
        public FloorType FloorType;

        public Floor(GameObject spriteGO, string name = "") : base(spriteGO, name)
        {
        }
        public Floor(GameObject spriteGO, FloorType floorType, string name = "") : base(spriteGO, name)
        {
            FloorType = floorType;
            var sprite = spriteGO.GetComponent<SpriteRenderer>();
            sprite.sortingOrder = (int)SortingOrder.Floor;
        }

        public Floor Clone()
        {
            return new Floor(Object.Instantiate(SpriteGO), Name);
        }
    }
}
