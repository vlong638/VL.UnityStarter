using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VL.Gaming.Study.Patterns
{
    /// <summary>
    /// 模版方法模式基于虚方法或抽象方法，预定义了算法的流程骨架
    /// 具体的实现由子类定义实现
    /// 要点：虚方法or抽象方法+定义模版
    /// </summary>
    public class SampleTemplateMethod
    {
        public void Test()
        {
            var implA = new ConcreteTemplateImplementationA();
            implA.TemplateMethod();
            var implB = new ConcreteTemplateImplementationB();
            implB.TemplateMethod();
        }
    }

    public abstract class AbstractTemplate
    {
        public void TemplateMethod()
        {
            Operation1();
            Operation2();
        }
        public abstract void Operation1();
        public abstract void Operation2();
    }

    public class ConcreteTemplateImplementationA : AbstractTemplate
    {
        public override void Operation1()
        {
            Console.WriteLine($"{nameof(Operation1)} from {nameof(ConcreteTemplateImplementationA)}");
        }

        public override void Operation2()
        {
            Console.WriteLine($"{nameof(Operation2)} from {nameof(ConcreteTemplateImplementationA)}");
        }
    }
    public class ConcreteTemplateImplementationB : AbstractTemplate
    {
        public override void Operation1()
        {
            Console.WriteLine($"{nameof(Operation1)} from {nameof(ConcreteTemplateImplementationB)}");
        }

        public override void Operation2()
        {
            Console.WriteLine($"{nameof(Operation2)} from {nameof(ConcreteTemplateImplementationB)}");
        }
    }
}