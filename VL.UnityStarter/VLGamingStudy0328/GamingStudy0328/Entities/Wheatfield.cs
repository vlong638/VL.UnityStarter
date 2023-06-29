using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scenes.VLGamingStudy0328
{
    public class Wheatfield : Item
    {
        public GameObject CutDownSpriteGO;
        public GameObject PlantSpriteGO;
        public GameObject GrowSpriteGO;
        public GameObject HarvestSpriteGO;

        public Wheatfield(GameObject cutDownSpriteGO, GameObject plantSpriteGO, GameObject growSpriteGO, GameObject harvestSpriteGO, string name = "") : base(null, name)
        {
            CutDownSpriteGO = cutDownSpriteGO;
            CutDownSpriteGO.GetComponent<SpriteRenderer>().sortingOrder = (int)SortingOrder.Item;
            PlantSpriteGO = plantSpriteGO;
            PlantSpriteGO.GetComponent<SpriteRenderer>().sortingOrder = (int)SortingOrder.Item;
            GrowSpriteGO = growSpriteGO;
            GrowSpriteGO.GetComponent<SpriteRenderer>().sortingOrder = (int)SortingOrder.Item;
            HarvestSpriteGO = harvestSpriteGO;
            HarvestSpriteGO.GetComponent<SpriteRenderer>().sortingOrder = (int)SortingOrder.Item;
        }
    }
}
