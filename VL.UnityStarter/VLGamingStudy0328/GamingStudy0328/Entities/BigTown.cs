using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scenes.VLGamingStudy0328
{
    public class BigTown : Entrance
    {
        GameObject ImageGO_LT;
        GameObject ImageGO_RT;
        GameObject ImageGO_LB;
        GameObject ImageGO_RB;
        public BigTown(GameObject imageGO_LT, GameObject imageGO_RT, GameObject imageGO_LB, GameObject imageGO_RB) : base(null, EntranceType.BigTown)
        {
            ImageGO_LT = imageGO_LT;
            ImageGO_LT.GetComponent<SpriteRenderer>().sortingOrder = (int)SortingOrder.Item;
            ImageGO_RT = imageGO_RT;
            ImageGO_RT.GetComponent<SpriteRenderer>().sortingOrder = (int)SortingOrder.Item;
            ImageGO_LB = imageGO_LB;
            ImageGO_LB.GetComponent<SpriteRenderer>().sortingOrder = (int)SortingOrder.Item;
            ImageGO_RB = imageGO_RB;
            ImageGO_RB.GetComponent<SpriteRenderer>().sortingOrder = (int)SortingOrder.Item;
        }
    }
}
