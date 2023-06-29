using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scenes.VLGamingStudy0328
{
    public class UnityObject : IUnityObject
    {
        public string Name;
        public int X;
        public int Y;
        public GameObject SpriteGO { set; get; }

        public UnityObject(GameObject spriteGO, string name)
        {
            SpriteGO = spriteGO;
            if (!string.IsNullOrEmpty(name))
            {
                Name = name;
            }
            else if (SpriteGO != null)
                Name = SpriteGO.name;
        }
    }
}
