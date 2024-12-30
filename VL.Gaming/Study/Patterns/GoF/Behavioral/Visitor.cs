using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VL.Gaming.Study.Patterns
{
    /// <summary>
    /// Visitor 访问者
    /// 要点：抽离访问者模型，并定义元素类，以此定义与访问相关的一系列行为，如访问不同基类时产生不同的行为
    /// 在不改变元素类的情况下，根据不同的访问者执行不同的操作
    /// 元素类需要支持各自不同的访问行为
    /// 比如文件系统的遍历器，计算文件夹的大小，统计文件夹的数量
    /// 
    /// 价值: 将对对象的访问收束在Visitor类中,保持元素的封装性
    /// 代价: 每增加一个元素便需要对所有的访问者进行维护
    /// 行为: 1:1 * N
    /// </summary>
    public class SampleVisitor
    {
        public void Test()
        {
            var elements = new List<IVisitable>() { new ConcreteElementA("A11"), new ConcreteElementA("B13"), new ConcreteElementB(18) };
            var visitorA = new ConcreteVisitorA();
            var visitorB = new ConcreteVisitorB();
            foreach (var element in elements)
            {
                element.Accept(visitorA);
                element.Accept(visitorB);
            }
        }
    }

    interface IVisitable
    {
        void Accept(IVisitor visitor);
    }
    class ConcreteElementA : IVisitable
    {
        public string Name;

        public ConcreteElementA(string name)
        {
            Name = name;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitConcreteElement(this);
        }

        public void Operation()
        {
            Console.WriteLine($"ConcreteElementA Operation,My Name is {Name}");
        }
    }
    class ConcreteElementB : IVisitable
    {
        public int Age;

        public ConcreteElementB(int age)
        {
            Age = age;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitConcreteElement(this);
        }

        public void Operation()
        {
            Console.WriteLine($"ConcreteElementB Operation,My Age is {Age}");
        }
    }

    interface IVisitor
    {
        void VisitConcreteElement(ConcreteElementA element);
        void VisitConcreteElement(ConcreteElementB element);
    }
    class ConcreteVisitorA : IVisitor
    {
        public void VisitConcreteElement(ConcreteElementA element)
        {
            Console.WriteLine($"高贵的A Visiting ConcreteElementA");
            element.Operation();
        }
        public void VisitConcreteElement(ConcreteElementB element)
        {
            Console.WriteLine($"高贵的A Visiting ConcreteElementB");
            element.Operation();
        }
    }
    class ConcreteVisitorB : IVisitor
    {
        public void VisitConcreteElement(ConcreteElementA element)
        {
            Console.WriteLine($"低贱的B Visiting ConcreteElementA");
            element.Name = "XXX";
            element.Operation();
        }
        public void VisitConcreteElement(ConcreteElementB element)
        {
            Console.WriteLine($"低贱的B Visiting ConcreteElementB");
            element.Age = 0;
            element.Operation();
        }
    }
}