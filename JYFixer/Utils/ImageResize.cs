using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace JYFixer
{
    internal class ImageResize
    {
        public static void TileImage(string inputPath, string outputPath, int width, int height)
        {
            using (Image originalImage = Image.FromFile(inputPath))
            {
                using (Bitmap tiledImage = new Bitmap(width, height))
                {
                    using (Graphics graphics = Graphics.FromImage(tiledImage))
                    {
                        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        graphics.SmoothingMode = SmoothingMode.HighQuality;
                        graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        graphics.CompositingQuality = CompositingQuality.HighQuality;

                        // 创建纹理笔刷并设置平铺模式
                        using (TextureBrush brush = new TextureBrush(originalImage))
                        {
                            brush.WrapMode = WrapMode.Tile;
                            graphics.FillRectangle(brush, 0, 0, width, height);
                        }
                    }

                    tiledImage.Save(outputPath, ImageFormat.Jpeg); // 保存图像到输出路径
                }
            }
        }
    }
}
