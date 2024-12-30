using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VL.Gaming.Study.Patterns
{
    /// <summary>
    /// Builder 构造器模式
    /// 负责将构建职责提炼出来，与表现层相独立
    /// It constructs complex objects by separating construction and representation
    /// </summary>
    public class SampleBuilder
    {
        public SampleComplexObject Test()
        
        {
            return new SampleComplexObject()
                .BuildInformation()
                .BuildAbility()
                .BuildWealth();
        }
    }

    public static class SampleComplexObjectEx
    {
        public static SampleComplexObject BuildInformation(this SampleComplexObject obj)
        {
            obj.Name = "Test1";
            obj.Age = 16;
            return obj;
        }
        public static SampleComplexObject BuildAbility(this SampleComplexObject obj)
        {
            obj.Ability = "Hunting";
            return obj;
        }
        public static SampleComplexObject BuildWealth(this SampleComplexObject obj)
        {
            obj.Car = "Ferrari";
            return obj;
        }
    }

    public class SampleComplexObject
    {
        public string Name { get; set; }
        public int Age { get; set; } 

        public string Ability { get; set; }

        public string Car { get; set; }

        public SampleComplexObject()
        { 
        }

        public string DoSomething()
        {
            return $"I am {Name},{Age} years old. I can {Ability}, and I got a car {Car}";
        }
    }
}
