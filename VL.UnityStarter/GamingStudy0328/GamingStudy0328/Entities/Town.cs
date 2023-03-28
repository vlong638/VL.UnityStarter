using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scenes.GamingStudy0328
{
    public class Town : Entrance, ICloneableObject<Town>
    {
        public Town(GameObject spriteGO, string name = "") : base(spriteGO, EntranceType.Town, name)
        {
        }

        public Town Clone()
        {
            return new Town(Object.Instantiate(SpriteGO), Name);
        }
    }
}
