using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VL.Godot.VLCommon
{
    public static class AnimatedSpriteEX
    {
        /// <summary>
        /// 从 AnimatedSprite2D 的 SpriteFrames 中取出某动画某帧的 Texture2D。
        /// 返回的通常是 AtlasTexture，可直接赋给 Sprite2D / 粒子脚本使用。
        /// </summary>
        public static Texture2D GetFrameTexture(
            this AnimatedSprite2D anim,
            string animationName,
            int frameIndex)
        {
            if (anim == null || anim.SpriteFrames == null) return null;
            if (!anim.SpriteFrames.HasAnimation(animationName)) return null;

            int frameCount = anim.SpriteFrames.GetFrameCount(animationName);
            if (frameIndex < 0 || frameIndex >= frameCount) return null;

            return anim.SpriteFrames.GetFrameTexture(animationName, frameIndex);
        }
        public static Texture2D BakeFrameTexture(this AnimatedSprite2D anim, string name, int idx)
        {
            var frames = anim?.SpriteFrames;
            if (frames == null || !frames.HasAnimation(name)) return null;
            if (idx < 0 || idx >= frames.GetFrameCount(name)) return null;

            var atlas = frames.GetFrameTexture(name, idx);
            if (atlas == null) return null;

            Image img = atlas.GetImage();
            if (img == null) return null;
            if (img.IsCompressed()) img.Decompress();

            return ImageTexture.CreateFromImage(img);
        }
    }
}
