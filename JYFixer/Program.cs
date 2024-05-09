using VL.Gaming.Framework.Tools;

namespace JYFixer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 输入图片路径
            string inputImagePath = "D:\\input_image.jpg";

            // 输出图片路径
            string outputImagePath = "D:\\output_pixel_art.png";

            // 指定像素画大小
            int pixelSize = 32;

            // 调用转换方法
            PixelConverter.ConvertToPixelArt(inputImagePath, outputImagePath, pixelSize);
        }
    }
}
