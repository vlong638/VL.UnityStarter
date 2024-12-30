using System;
using System.Drawing;

namespace VL.Gaming.Framework.Tools
{
    public class PixelConverter
    {
        public static void ConvertToPixelArt(string inputImagePath, string outputImagePath, int pixelSize)
        {
            // 打开输入图片
            Bitmap inputImage = new Bitmap(inputImagePath);

            // 创建一个新的Bitmap对象，将输入图片调整为指定大小
            Bitmap outputImage = new Bitmap(inputImage, new Size(pixelSize, pixelSize));

            // 保存输出图片
            outputImage.Save(outputImagePath);

            // 释放资源
            inputImage.Dispose();
            outputImage.Dispose();
        }
    }
}
