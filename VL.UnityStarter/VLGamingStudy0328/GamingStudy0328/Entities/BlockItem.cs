using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scenes.VLGamingStudy0328
{
    public class BlockItem : Item, ICloneableObject<BlockItem>
    {
        public BlockType BlockType;

        public BlockItem(GameObject spriteGO, BlockType blockType, string name = "") : base(spriteGO, name)
        {
            BlockType = blockType;
        }

        public BlockItem Clone()
        {
            return new BlockItem(Object.Instantiate(SpriteGO), BlockType, Name);
        }
    }
}
