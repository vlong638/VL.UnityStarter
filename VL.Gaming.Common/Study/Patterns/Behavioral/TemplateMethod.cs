using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VL.Gaming.Study.Patterns
{
    /// <summary>
    /// 
    /// </summary>
    public class SampleTemplateMethod
    {
        public void Test()
        {
        }
    }
}

//using System;

//// Abstract Class
//public abstract class AbstractClass
//{
//    public void TemplateMethod()
//    {
//        PrimitiveOperation1();
//        PrimitiveOperation2();
//    }

//    protected abstract void PrimitiveOperation1();
//    protected abstract void PrimitiveOperation2();
//}

//// Concrete Class A
//public class ConcreteClassA : AbstractClass
//{
//    protected override void PrimitiveOperation1()
//    {
//        Console.WriteLine("ConcreteClassA: Primitive Operation 1");
//    }

//    protected override void PrimitiveOperation2()
//    {
//        Console.WriteLine("ConcreteClassA: Primitive Operation 2");
//    }
//}

//// Concrete Class B
//public class ConcreteClassB : AbstractClass
//{
//    protected override void PrimitiveOperation1()
//    {
//        Console.WriteLine("ConcreteClassB: Primitive Operation 1");
//    }

//    protected override void PrimitiveOperation2()
//    {
//        Console.WriteLine("ConcreteClassB: Primitive Operation 2");
//    }
//}

//// Client
//public class Client
//{
//    public void Main()
//    {
//        AbstractClass classA = new ConcreteClassA();
//        classA.TemplateMethod();

//        AbstractClass classB = new ConcreteClassB();
//        classB.TemplateMethod();
//    }
//}

//AbstractClass: 定义了一个模板方法，其中包含了算法的骨架，具体步骤由子类实现。
//ConcreteClassA和ConcreteClassB: 实现了AbstractClass中的抽象方法，以定义算法的具体步骤。
//Client: 创建具体子类对象，并调用模板方法，展示了如何使用模板方法模式。
