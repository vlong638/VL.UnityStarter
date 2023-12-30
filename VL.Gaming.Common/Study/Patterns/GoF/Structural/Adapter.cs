using System;

namespace VL.Gaming.Study.Patterns
{
    /// <summary>
    /// Adapter, it allows classes with incompatible interfaces to work together
    /// wrap its interface around that of an already existing class
    /// 适配器模式要点是使得旧有接口再应用
    /// </summary>
    public class SampleAdapter
    {
        public void Test()
        { 
            Adaptee adaptee = new Adaptee();
            Adapter adapter = new Adapter(adaptee);
            adapter.Request();
        }
    }

    public class Adaptee
    {
        public void SomethingToAdapt()
        {
            Console.WriteLine("old request");
        }
    }

    interface ITarget
    {
        void Request();
    }

    public class Adapter : ITarget
    {
        Adaptee _adaptee;

        public Adapter(Adaptee adaptee)
        {
            _adaptee = adaptee;
        }

        public void Request()
        {
            _adaptee.SomethingToAdapt();
        }
    }
}
