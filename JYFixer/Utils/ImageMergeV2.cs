using System;
using System.Drawing;
using System.IO;

namespace JYFixer
{
    class ImageMergerV2
    {
        private string inputDirectory; // 输入目录路径
        private string outputFilePath; // 输出图片文件路径
        private int spacing; // 图片之间的间隔（单位像素）
        private int VSize; // 横向最大堆叠的图片数量

        public ImageMergerV2(string inputDirectory, string outputFilePath, int spacing, int VSize)
        {
            this.inputDirectory = inputDirectory;
            this.outputFilePath = outputFilePath;
            this.spacing = spacing;
            this.VSize = VSize;
        }

        // 合并图片并保存到输出路径
        public void MergeImages()
        {
            // 获取输入目录下的所有图片文件路径
            string[] imageFiles = Directory.GetFiles(inputDirectory, "*.png");

            if (imageFiles.Length == 0)
            {
                Console.WriteLine("没有找到图片文件！");
                return;
            }

            // 加载图片
            var images = new Image[imageFiles.Length];
            int totalWidth = 0;
            int totalHeight = 0;

            // 计算合并后的总宽度和最大高度
            for (int i = 0; i < imageFiles.Length; i++)
            {
                images[i] = Image.FromFile(imageFiles[i]);
                totalWidth += images[i].Width;
                if (images[i].Height > totalHeight)
                {
                    totalHeight = images[i].Height;
                }
            }

            // 计算合并图片后的宽度和高度
            int rows = (int)Math.Ceiling((double)images.Length / VSize); // 计算需要的行数
            int width = 0;
            int height = 0;

            // 计算每行的宽度并求总高度
            int currentRowWidth = 0;
            int currentRowHeight = 0;
            for (int i = 0; i < images.Length; i++)
            {
                if (i % VSize == 0 && i != 0)
                {
                    height += currentRowHeight + spacing; // 每行之间的间隔
                    currentRowWidth = 0;
                    currentRowHeight = 0;
                }
                currentRowWidth += images[i].Width + spacing;
                currentRowHeight = Math.Max(currentRowHeight, images[i].Height);
            }

            height += currentRowHeight; // 最后一行的高度（没有下面的间隔）

            // 合并后的图片宽度（注意：最后一张图片的右侧不需要额外的间隔）
            width = currentRowWidth - spacing;

            // 创建合并后的图像
            using (Bitmap resultImage = new Bitmap(width, height))
            {
                using (Graphics g = Graphics.FromImage(resultImage))
                {
                    g.Clear(Color.White); // 背景为白色

                    int x = 0, y = 0;

                    // 将每张图片绘制到合并图像中
                    for (int i = 0; i < images.Length; i++)
                    {
                        g.DrawImage(images[i], x, y);
                        x += images[i].Width + spacing; // 计算下一个图片的横坐标

                        // 如果已经达到横向最大堆叠数量，换行
                        if ((i + 1) % VSize == 0)
                        {
                            x = 0;
                            y += currentRowHeight + spacing; // 换行，计算纵坐标
                        }
                    }
                }

                // 保存合并后的图片
                resultImage.Save(outputFilePath);
                Console.WriteLine($"图片合并完成，保存至: {outputFilePath}");
            }

            // 释放图片资源
            foreach (var image in images)
            {
                image.Dispose();
            }
        }

        public static void Merge(string inputDirectory, string outputFilePath, int spacing = 10, int VSize = 5)
        {
            var imageMerger = new ImageMergerV2(inputDirectory, outputFilePath, spacing, VSize);
            imageMerger.MergeImages();
        }
    }
}
