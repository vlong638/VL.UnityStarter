using System;

namespace VL.Gaming.Study.Patterns
{
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
