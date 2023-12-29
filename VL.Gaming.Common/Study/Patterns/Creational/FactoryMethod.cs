using System;

namespace VL.Gaming.Study.Patterns
{
    /// <summary>
    /// 单一层级的工厂模式
    /// FactoryMethod = IProduct + IFactory
    /// 1.Abstract IProduct
    /// 2.Abstract IFactory
    /// 3.IProduct = IFactory.CreateProduct()
    /// 4.IProduct.Work()
    /// 适用于当子类决定某个具体对象需要创建时
    /// </summary>
    public class FactoryMethod
    {
        public void Sample()
        {
            IFactory factory;
            IProduct product;
            // 使用具体工厂A创建产品A
            factory = new ConcreteFactoryA();
            product = factory.CreateProduct();
            product.Work();

            // 使用具体工厂B创建产品B
            factory = new ConcreteFactoryB();
            product = factory.CreateProduct();
            product.Work();
        }
    }

    // 抽象产品接口
    public interface IProduct
    {
        void Work();
    }

    // 具体产品A
    public class ConcreteProductA : IProduct
    {
        public void Work()
        {
            Console.WriteLine("Product A Produced");
        }
    }

    // 具体产品B
    public class ConcreteProductB : IProduct
    {
        public void Work()
        {
            Console.WriteLine("Product B Produced");
        }
    }

    // 抽象工厂接口
    public interface IFactory
    {
        IProduct CreateProduct();
    }

    // 具体工厂A
    public class ConcreteFactoryA : IFactory
    {
        public IProduct CreateProduct()
        {
            return new ConcreteProductA();
        }
    }

    // 具体工厂B
    public class ConcreteFactoryB : IFactory
    {
        public IProduct CreateProduct()
        {
            return new ConcreteProductB();
        }
    }
}
