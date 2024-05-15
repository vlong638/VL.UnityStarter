using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            testData.Add(new Dialogue(1, 0, DialogueContentType.Dialogue, DialoguePortraitLocation.Left, "Sprites\\DialogueTest_猎人", "猎人", "终于找到你了"));
            testData.Add(new Dialogue(2, 1, DialogueContentType.Dialogue, DialoguePortraitLocation.Right, "Sprites\\DialogueTest_大灰狼", "大灰狼", "我只是个普普通通的老婆婆"));
            testData.Add(new Dialogue(3, 2, DialogueContentType.Dialogue, DialoguePortraitLocation.Left, "Sprites\\DialogueTest_猎人", "猎人", "别装了,大灰狼"));
            testData.Add(new Dialogue(4, 3, DialogueContentType.Dialogue, DialoguePortraitLocation.Right, "Sprites\\DialogueTest_大灰狼", "大灰狼", "什么?什么大灰狼"));
            testData.Add(new Dialogue(5, 4, DialogueContentType.Option, DialoguePortraitLocation.Left, "Sprites\\DialogueTest_猎人", "猎人", "对不起,认错人了."));
            testData.Add(new Dialogue(6, 4, DialogueContentType.Option, DialoguePortraitLocation.Left, "Sprites\\DialogueTest_猎人", "猎人", "你这只愚蠢的大灰狼,你的狼尾巴都露出来了(智慧7)", DialogueRequirementType.IntelligenceAttribute, 7));
            testData.Add(new Dialogue(7, 4, DialogueContentType.Option, DialoguePortraitLocation.Left, "", "猎人", "没有老婆婆会在傍晚在这里出没 (智慧10)", DialogueRequirementType.IntelligenceAttribute, 10));
            testData.Add(new Dialogue(8, 6, DialogueContentType.Dialogue, DialoguePortraitLocation.Right, "Sprites\\DialogueTest_大灰狼", "大灰狼", "该死的,被发现了!咱老狼要跑了!"));
            testData.Add(new Dialogue(9, 8, DialogueContentType.Option, DialoguePortraitLocation.Left, "Sprites\\DialogueTest_猎人", "猎人", "受死吧!可恶的大灰狼(敏捷10)", DialogueRequirementType.AgilityAttribute, 10));
            testData.Add(new Dialogue(10, 8, DialogueContentType.Option, DialoguePortraitLocation.Left, "Sprites\\DialogueTest_猎人", "猎人", "追不上,可恶,继续追,哪怕会被埋伏"));
            testData.Add(new Dialogue(11, 8, DialogueContentType.Option, DialoguePortraitLocation.Left, "Sprites\\DialogueTest_猎人", "猎人", "追不上,可恶,先回去再说"));
            testData.Add(new Dialogue(12, 7, DialogueContentType.Dialogue, DialoguePortraitLocation.Right, "Sprites\\DialogueTest_大灰狼", "大灰狼", "我藏了一些好东西,放过我就告诉你它们在哪."));
            testData.Add(new Dialogue(13, 12, DialogueContentType.Option, DialoguePortraitLocation.Left, "Sprites\\DialogueTest_猎人", "猎人", "我不会放过你的"));
            testData.Add(new Dialogue(14, 12, DialogueContentType.Option, DialoguePortraitLocation.Left, "Sprites\\DialogueTest_猎人", "猎人", "这次就先放过你"));
            testData.Add(new Dialogue(101, 0, DialogueContentType.Option, DialoguePortraitLocation.Left, "Sprites\\DialogueTest_猎人", "猎人", "又见到你了,大灰狼"));
            testData.Add(new Dialogue(102, 101, DialogueContentType.Dialogue, DialoguePortraitLocation.Right, "Sprites\\DialogueTest_大灰狼", "大灰狼", "大哥你,这么强,我给你做小弟吧!"));
            testData.Add(new Dialogue(103, 102, DialogueContentType.Option, DialoguePortraitLocation.Left, "Sprites\\DialogueTest_猎人", "猎人", "想都别想,受死吧!(开战)"));
            testData.Add(new Dialogue(104, 102, DialogueContentType.Option, DialoguePortraitLocation.Left, "Sprites\\DialogueTest_猎人", "猎人", "看你还有点用,我正好缺个端茶的(招募)"));
            testData.Add(new Dialogue(105, 102, DialogueContentType.Option, DialoguePortraitLocation.Left, "Sprites\\DialogueTest_猎人", "猎人", "把你拐走的萝莉交出来,我可以考虑考虑(需要智慧30)", DialogueRequirementType.IntelligenceAttribute, 30));
            var testFile = @"D:\\游戏开发\\测试数据\\DialogueTest.json";
            File.WriteAllText(testFile, Newtonsoft.Json.JsonConvert.SerializeObject(testData));

            //数据校验
            var testDataStr = File.ReadAllText(testFile);
            testData = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Dialogue>>(testDataStr);
            var sourceCount = testData.Count();
            var root = new Dialogue(0, -1);
            foreach (var dialogue in testData)
            {
                root.Insert(dialogue);
            }
            var rootCount = root.Count();
            Console.WriteLine($"part1");
            var part1 = root.GetNodeById(6);
            part1.TraverseDelegate(c => { Console.WriteLine($"Id:{c.Id},Content:{c.Content}"); });
            Console.WriteLine($"part2");
            var part2 = root.GetNodeById(7);
            part2.TraverseDelegate(c => { Console.WriteLine($"Id:{c.Id},Content:{c.Content}"); });
            Console.WriteLine($"part3");
            var part3 = root.GetNodeById(101);
            part3.TraverseDelegate(c => { Console.WriteLine($"Id:{c.Id},Content:{c.Content}"); });
        }
    }
    public enum DialogueContentType
    {
        None,
        Dialogue,
        Option,
    }
    public enum DialoguePortraitLocation
    {
        None,
        Left,
        Right,
        Option,
        Main,
    }
    public enum DialogueRequirementType
    {
        None,
        StrengthAttribute,
        AgilityAttribute,
        ConstitutionAttribute,
        IntelligenceAttribute,
        WillpowerAttribute,
        CharismaAttribute,
        LeadershipAttribute,
    }
    public class Dialogue
    {
        public long Id;
        public long ParentId;
        public DialogueContentType ContentType;
        public DialogueRequirementType RequirementType;
        public double RequirementValue;
        public DialoguePortraitLocation PortraitLocation;
        public string PortraitSource;
        public string Title;
        public string Content;
        public string BackgroundSource;
        public string SoundSource;

        [JsonIgnore]
        public Dialogue RootNode;
        [JsonIgnore]
        public List<Dialogue> Children = new List<Dialogue>();


        public Dialogue(long id, long parentId)
        {
            this.Id = id;
            this.ParentId = parentId;
        }

        [JsonConstructor]
        public Dialogue(long id, long parentId, DialogueContentType contentType, DialoguePortraitLocation portraitLocation, string portraitSource, string title, string content, DialogueRequirementType requirementType = DialogueRequirementType.None, double requirementValue = 0, string backgroundSource = "", string soundSource = "")
        {
            this.Id = id;
            this.ParentId = parentId;
            this.ContentType = contentType;
            this.PortraitLocation = portraitLocation;
            this.PortraitSource = portraitSource;
            this.Title = title;
            this.Content = content;
            this.RequirementType = requirementType;
            this.RequirementValue = requirementValue;
            this.BackgroundSource = backgroundSource;
            this.SoundSource = soundSource;
        }


        public void Insert(Dialogue node)
        {
            if (node.ParentId == this.Id)
            {
                this.Children.Add(node);
                return;
            }
            foreach (var child in this.Children)
            {
                child.Insert(node);
            }
        }

        public Dialogue GetNodeById(long id)
        {
            if (this.Id == id)
            {
                return this;
            }
            foreach (Dialogue child in this.Children)
            {
                Dialogue result = child.GetNodeById(id);
                if (result != null)
                {
                    return result;
                }
            }
            return null;
        }

        public int Count()
        {
            int count = 1;
            foreach (var child in Children)
            {
                count += child.Count();
            }
            return count;
        }

        public void TraverseDelegate(Action<Dialogue> action)
        {
            action(this);
            foreach (var child in Children)
            {
                child.TraverseDelegate(action); 
            }
        }
    }
}
