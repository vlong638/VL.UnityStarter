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
    public class SampleStrategy
    {
        public void Test()
        {
        }
    }
}

//Copy
//using System;

//// Strategy interface
//public interface IStrategy
//{
//    void Execute();
//}

//// Concrete strategies
//public class ConcreteStrategyA : IStrategy
//{
//    public void Execute()
//    {
//        Console.WriteLine("Executing strategy A");
//    }
//}

//public class ConcreteStrategyB : IStrategy
//{
//    public void Execute()
//    {
//        Console.WriteLine("Executing strategy B");
//    }
//}

//// Context
//public class Context
//{
//    private IStrategy _strategy;

//    public Context(IStrategy strategy)
//    {
//        _strategy = strategy;
//    }

//    public void SetStrategy(IStrategy strategy)
//    {
//        _strategy = strategy;
//    }

//    public void ExecuteStrategy()
//    {
//        _strategy.Execute();
//    }
//}

//// Client
//public class Client
//{
//    public void Main()
//    {
//        var context = new Context(new ConcreteStrategyA());
//        context.ExecuteStrategy(); // Output: Executing strategy A

//        context.SetStrategy(new ConcreteStrategyB());
//        context.ExecuteStrategy(); // Output: Executing strategy B
//    }
//}
//详细讲解
//IStrategy: 定义了所有支持的算法的共同接口。
//ConcreteStrategyA和ConcreteStrategyB: 实现了IStrategy接口，即具体的算法。
//Context: 维护一个对Strategy对象的引用，可以在运行时切换不同的策略。
//Client: 创建Context对象，并演示如何在运行时切换不同的策略。