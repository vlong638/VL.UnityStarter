using System;

namespace VL.Gaming.Study.Patterns
{
    /// <summary>
    /// 多层级的工厂模式
    /// Abstract Facotory = IProduct*n + IFactory*n
    /// 1.Abstract IProductA,IProductAPlus
    /// 2.Abstract IFactory
    /// 3.IProductA = IFactory.CreateProductA()
    /// 4.IProductA.Work()
    /// 5.IProductAPlus = IFactory.CreateProductAPlus()
    /// 6.IProductAPlus.Work() or IProductAPlus.WorkPlus()
    /// </summary>
    public class AbstractFactory
    {
        public void Sample(IAbstractFactory factory)
        {
            var productA = factory.CreateProductA();
            var productB = factory.CreateProductB();

            Console.WriteLine(productB.DoSomething());
            Console.WriteLine(productB.DoSomethingPlus(productA));
        }
    }

    // Abstract Product A
    public interface IAbstractProductA
    {
        string DoSomething();
    }

    // Concrete Product A1
    public class ConcreteProductA1 : IAbstractProductA
    {
        public string DoSomething()
        {
            return "The result of the product A1.";
        }
    }

    // Concrete Product A2
    public class ConcreteProductA2 : IAbstractProductA
    {
        public string DoSomething()
        {
            return "The result of the product A2.";
        }
    }

    // Abstract Product B
    public interface IAbstractProductB
    {
        string DoSomething();
        int DoSomethingPlus(IAbstractProductA collaborator);
    }

    // Concrete Product B1
    public class ConcreteProductB1 : IAbstractProductB
    {
        public string DoSomething()
        {
            return "The result of the product B1.";
        }

        public int DoSomethingPlus(IAbstractProductA collaborator)
        {
            var result = collaborator.DoSomething();
            return result.Length;
        }
    }

    // Concrete Product B2
    public class ConcreteProductB2 : IAbstractProductB
    {
        public string DoSomething()
        {
            return "The result of the product B2.";
        }

        public int DoSomethingPlus(IAbstractProductA collaborator)
        {
            var result = collaborator.DoSomething();
            return result.Length * 2;
        }
    }

    // Abstract Factory
    public interface IAbstractFactory
    {
        IAbstractProductA CreateProductA();
        IAbstractProductB CreateProductB();
    }

    // Concrete Factory 1
    public class ConcreteFactory1 : IAbstractFactory
    {
        public IAbstractProductA CreateProductA()
        {
            return new ConcreteProductA1();
        }

        public IAbstractProductB CreateProductB()
        {
            return new ConcreteProductB1();
        }
    }

    // Concrete Factory 2
    public class ConcreteFactory2 : IAbstractFactory
    {
        public IAbstractProductA CreateProductA()
        {
            return new ConcreteProductA2();
        }

        public IAbstractProductB CreateProductB()
        {
            return new ConcreteProductB2();
        }
    }
}
