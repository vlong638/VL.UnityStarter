using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VL.Gaming.Study.Patterns
{
    /// <summary>
    /// 享元模式旨在构建一个共享的集合
    /// 避免同一对象的重复创建
    /// 要点：集合字典的单例集合，复用层
    /// 
    /// </summary>
    public class SampleFlyWeight
    {
        public void Test()
        {
            IRobot robot;
            RobotFactory robotFactory = new RobotFactory();
            robot = robotFactory.GetRobot("Alice");
            robot.Print();
            System.Threading.Thread.Sleep(1000);
            robot = robotFactory.GetRobot("Bear");
            robot.Print();
            System.Threading.Thread.Sleep(1000);
            robot = robotFactory.GetRobot("Bob");
            robot.Print();
            System.Threading.Thread.Sleep(1000);
            robot = robotFactory.GetRobot("Alice");
            robot.Print();
        }
    }

    interface IRobot
    {

        string Name { get; set; }
        DateTime CreateAt { get; set; }

        void Print();
    }
    class SmallRobot : IRobot
    {
        public string Name { get; set; }
        public DateTime CreateAt { get; set; }

        public SmallRobot(string name)
        {
            Name = name;
            CreateAt = DateTime.Now;
        }

        public void Print()
        {
            Console.WriteLine($"this is a small robot {Name},CreateAt:{CreateAt.ToString()}");
        }
    }
    class RobotFactory
    {
        Dictionary<int, IRobot> _robots = new Dictionary<int, IRobot>();

        public IRobot GetRobot(string name)
        {
            var robotKV = _robots.FirstOrDefault(c => c.Key == name.GetHashCode());
            if (robotKV.Value!=null)
                return robotKV.Value;
            var robot = new SmallRobot(name);
            _robots.Add(name.GetHashCode(), robot);
            return robot;
        }
    }
}
