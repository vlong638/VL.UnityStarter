using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scenes.VLGamingStudy0328
{
    public class Tree : Item, ICloneableObject<Tree>
    {
        public GameObject OrientSpriteGO;
        public GameObject CutDownSpriteGO;

        public Tree(GameObject spriteGO, GameObject orientSpriteGO, GameObject cutDownSpriteGO, string name = "") : base(spriteGO, name)
        {
            OrientSpriteGO = orientSpriteGO;
            CutDownSpriteGO = cutDownSpriteGO;
        }

        public Tree Clone()
        {
            return new Tree(SpriteGO != null ? Object.Instantiate(SpriteGO) : null, OrientSpriteGO, CutDownSpriteGO, Name);
        }
    }
}
