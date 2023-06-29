using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scenes.VLGamingStudy0328
{
    public class Cave : Entrance, ICloneableObject<Cave>
    {
        public Cave(GameObject spriteGO, string name = "") : base(spriteGO, EntranceType.Town, name)
        {
        }

        public Cave Clone()
        {
            return new Cave(Object.Instantiate(SpriteGO), Name);
        }
    }
}
