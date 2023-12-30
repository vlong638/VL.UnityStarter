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
            Shape original = new Shape { Type = "Circle" };
            original.CreateTime = DateTime.Now;
            System.Threading.Thread.Sleep(1000);
            Shape cloned = (Shape)original.Clone();
            //cloned.CreateTime = DateTime.Now;
            Console.WriteLine($"Original Type: {original.Type},Created at {original.CreateTime}");
            Console.WriteLine($"Cloned Type: {cloned.Type},Created at {cloned.CreateTime}");
        }

    }

    public class Shape : ICloneable
    {
        public string Type { get; set; }
        public DateTime CreateTime { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
