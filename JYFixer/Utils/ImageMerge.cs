using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JYFixer
{
    internal class ImageMerge
    {
        public static void MergeImages(string inputPath, string outputPath)
        {
            var imagePaths = Directory.GetFiles(inputPath);
            const int tileSize = 60;  // 每个子图片的大小
            int imagesCount = imagePaths.Length;

            // 计算合并后图片的总尺寸
            int gridSize = (int)Math.Ceiling(Math.Sqrt(imagesCount));
            int outputWidth = gridSize * tileSize;
            int outputHeight = gridSize * tileSize;

            using (Bitmap finalImage = new Bitmap(outputWidth, outputHeight))
            {
                using (Graphics g = Graphics.FromImage(finalImage))
                {
                    g.Clear(Color.White);
                    int row = 0, col = 0;

                    foreach (var path in imagePaths)
                    {
                        using (Bitmap image = new Bitmap(path))
                        {
                            // 调整图片大小为60x60
                            using (Bitmap resizedImage = new Bitmap(image, new Size(tileSize, tileSize)))
                            {
                                int x = col * tileSize;
                                int y = row * tileSize;
                                g.DrawImage(resizedImage, new Rectangle(x, y, tileSize, tileSize));
                            }
                        }
                        col++;
                        if (col >= gridSize)
                        {
                            col = 0;
                            row++;
                        }
                    }
                }

                // 保存合并后的图片
                finalImage.Save(outputPath, ImageFormat.Png);
            }
        }
    }
}
