using UnityEngine;

namespace Assets.Scenes.VLGamingStudy0328
{
    public class Entrance : Item
    {
        public EntranceType EntranceType;

        public Entrance(GameObject spriteGO, EntranceType entranceType, string name = "") : base(spriteGO, name)
        {
            EntranceType = entranceType;
        }
    }
}
