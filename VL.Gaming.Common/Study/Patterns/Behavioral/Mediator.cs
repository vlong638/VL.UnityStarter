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
    public class SampleMediator
    {
        public void Test()
        {
        }
    }
}

//// Mediator interface
//public interface IMediator
//{
//    void Notify(object sender, string event);
//    }

//    // Concrete mediator
//    public class ConcreteMediator : IMediator
//    {
//        private Component1 _component1;
//        private Component2 _component2;

//        public ConcreteMediator(Component1 component1, Component2 component2)
//        {
//            _component1 = component1;
//            _component1.SetMediator(this);
//            _component2 = component2;
//            _component2.SetMediator(this);
//        }

//        public void Notify(object sender, string ev)
//        {
//            if (ev == "A")
//            {
//                Console.WriteLine("Mediator reacts to event A and triggers following operations:");
//                _component2.DoC();
//            }
//            if (ev == "D")
//            {
//                Console.WriteLine("Mediator reacts to event D and triggers following operations:");
//                _component1.DoB();
//                _component2.DoC();
//            }
//        }
//    }

//    // Colleague interface
//    public abstract class Colleague
//    {
//        protected IMediator _mediator;

//        public void SetMediator(IMediator mediator)
//        {
//            _mediator = mediator;
//        }
//    }

//    // Concrete colleagues
//    public class Component1 : Colleague
//    {
//        public void DoA()
//        {
//            Console.WriteLine("Component 1 does A");
//            _mediator.Notify(this, "A");
//        }

//        public void DoB()
//        {
//            Console.WriteLine("Component 1 does B");
//            _mediator.Notify(this, "B");
//        }
//    }

//    public class Component2 : Colleague
//    {
//        public void DoC()
//        {
//            Console.WriteLine("Component 2 does C");
//            _mediator.Notify(this, "C");
//        }

//        public void DoD()
//        {
//            Console.WriteLine("Component 2 does D");
//            _mediator.Notify(this, "D");
//        }
//    }

//    // Usage
//    public class Client
//    {
//        public void Main()
//        {
//            var component1 = new Component1();
//            var component2 = new Component2();
//            var mediator = new ConcreteMediator(component1, component2);

//            component1.DoA(); // Triggers mediator to react to event A
//            component2.DoD(); // Triggers mediator to react to event D
//        }
//    }