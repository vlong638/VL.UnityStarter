using System.Collections.Generic;
using System.IO;
using VL.Gaming.Framework.Tools;

namespace JYFixer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MockData_DialogueData();


            // 输入图片路径
            string inputImagePath = "D:\\input_image.jpg";

            // 输出图片路径
            string outputImagePath = "D:\\output_pixel_art.png";

            // 指定像素画大小
            int pixelSize = 32;

            // 调用转换方法
            PixelConverter.ConvertToPixelArt(inputImagePath, outputImagePath, pixelSize);
        }

        private static void MockData_DialogueData()
        {
            //造数据
            List<Dialogue> testData = new List<Dialogue>();
            testData.Add(new Dialogue(PortraitLocation.Left, "Sprites\\DialogueTest_猎人", "猎人", "终于找到你了"));
            testData.Add(new Dialogue(PortraitLocation.Right, "Sprites\\DialogueTest_大灰狼", "大灰狼", "我只是个普普通通的老婆婆"));
            testData.Add(new Dialogue(PortraitLocation.Left, "Sprites\\DialogueTest_猎人", "猎人", "别装了,你这只愚蠢的大灰狼"));
            testData.Add(new Dialogue(PortraitLocation.Right, "Sprites\\DialogueTest_大灰狼", "大灰狼", "什么?什么大灰狼"));
            testData.Add(new Dialogue(PortraitLocation.Left, "Sprites\\DialogueTest_猎人", "猎人", "你的狼尾巴都露出来了"));
            testData.Add(new Dialogue(PortraitLocation.Left, "Sprites\\DialogueTest_猎人", "猎人", "受死吧!可恶的大灰狼"));
            File.WriteAllText(@"D:\\游戏开发\\测试数据\\DialogueTest.json", Newtonsoft.Json.JsonConvert.SerializeObject(testData));
        }
    }


    public enum PortraitLocation
    {
        None,
        Left,
        Right,
    }

    public class Dialogue
    {
        public PortraitLocation portraitLocation;
        public string portraitSource;
        public string title;
        public string content;

        public Dialogue(PortraitLocation portraitLocation, string portraitSource, string title, string content)
        {
            this.portraitLocation = portraitLocation;
            this.portraitSource = portraitSource;
            this.title = title;
            this.content = content;
        }
    }
}
