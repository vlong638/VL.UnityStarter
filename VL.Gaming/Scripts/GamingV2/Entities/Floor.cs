using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace VL.Gaming.Scripts.GamingV2.Entities
{
    public enum FloorType
    {
        None = 0,
        Plain,
        Grassland,
        Forest,
        Mountain,
        River,
        Shore,
        Mine,
    }
    public enum SortingOrder
    {
        None = 0,
        Floor = 3,
        Item = 5,
        Creature = 7,
        Sky = 9,
    }
    public class Floor : UnityObject
    {
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
    public class UnityObject : IUnityObject
    {
        public GameObject SpriteGO { set; get; }
        public string Name { get => SpriteGO.name; set { SpriteGO.name = value; } }
        public int X { get => (int)SpriteGO.transform.position.x; set { SpriteGO.transform.position = new Vector3(value, SpriteGO.transform.position.y, SpriteGO.transform.position.z); } }
        public int Y { get => (int)SpriteGO.transform.position.y; set { SpriteGO.transform.position = new Vector3(SpriteGO.transform.position.x, value, SpriteGO.transform.position.z); } }

        public UnityObject(GameObject spriteGO, string name)
        {
            SpriteGO = spriteGO;
            if (!string.IsNullOrEmpty(name))
            {
               this.Name = name;
            }
            else if (SpriteGO != null)
                Name = SpriteGO.name;
        }
    }
    public interface IUnityObject
    {
        string Name { set; get; }
        int X { set; get; }
        int Y { set; get; }
        GameObject SpriteGO { set; get; }
    }
    public class Item : UnityObject
    {

        public Item(GameObject spriteGO, string name) : base(spriteGO, name)
        {
            if (spriteGO == null)
                return;
            spriteGO.GetComponent<SpriteRenderer>().sortingOrder = (int)SortingOrder.Item;
        }
    }
}
