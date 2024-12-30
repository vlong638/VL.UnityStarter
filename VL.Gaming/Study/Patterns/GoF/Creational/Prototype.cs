using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VL.Gaming.Study.Patterns
{
    public class SamplePrototype
    {
        public void Test()
        {
            Shape original = new Shape { Type = "Circle" ,Location=new Location() { Name="杭州" } };
            original.CreateTime = DateTime.Now;
            System.Threading.Thread.Sleep(1000);
            Shape shadowCloned = (Shape)original.ShadowClone();
            Console.WriteLine($"Original Type: {original.Type},Created at {original.CreateTime},Location:{original.Location.Name}");
            Console.WriteLine($"Cloned Type: {shadowCloned.Type},Created at {shadowCloned.CreateTime},Location:{shadowCloned.Location.Name}");
            shadowCloned.Type = "Triangle";
            shadowCloned.Location.Name = "慈溪";
            Console.WriteLine($"Change Type");
            Console.WriteLine($"Original Type: {original.Type},Created at {original.CreateTime},Location:{original.Location.Name}");
            Console.WriteLine($"Cloned Type: {shadowCloned.Type},Created at {shadowCloned.CreateTime},Location:{shadowCloned.Location.Name}");
            Console.WriteLine($"-------------");
            Shape deepCloned = (Shape)original.DeepClone();
            Console.WriteLine($"Original Type: {original.Type},Created at {original.CreateTime},Location:{original.Location.Name}");
            Console.WriteLine($"Cloned Type: {deepCloned.Type},Created at {deepCloned.CreateTime},Location:{deepCloned.Location.Name}");
            deepCloned.Type = "Rectangle";
            deepCloned.Location.Name = "宁波";
            Console.WriteLine($"Change Type");
            Console.WriteLine($"Original Type: {original.Type},Created at {original.CreateTime},Location:{original.Location.Name}");
            Console.WriteLine($"Cloned Type: {deepCloned.Type},Created at {deepCloned.CreateTime},Location:{deepCloned.Location.Name}");
            //结论
            //浅拷贝的引用类型的更改会影响原本
            //string属于引用类型，但在框架下已经默认被优化成类似值类型的处理模式了
            //深拷贝的引用类型的更改则不会影响原本
        }

    }
    public class Location
    {
        public string Name { get; set; }
    }

    public class Shape
    {
        public string Type { get; set; }
        public DateTime CreateTime { get; set; }
        public Location Location { get; set; }

        public object ShadowClone()
        {
            return this.MemberwiseClone();
        }

        public Shape DeepClone()
        {
            var clone = new Shape()
            {
                Type = this.Type,
                CreateTime = this.CreateTime,
                Location = new Location() { Name = Location.Name },
            };
            return clone;

        }
    }
}
