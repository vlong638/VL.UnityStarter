using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VL.Gaming.Study.Patterns
{
    /// <summary>
    /// 中介者
    /// 提供了发送通知和通知触发的机制
    /// 他以第三方中介形式构建
    /// 用以抽离多方之间的协调性质的业务
    /// </summary>
    public class SampleMediator
    {
        public void Test()
        {
            var component1 = new Component1();
            var component2 = new Component2();
            var mediator = new ConcreteMediator(component1, component2);
            component1.DoA();            
            component2.DoD();
            component1.DoB();
        }
    }

    public interface IMediator
    {
        void Notify(object sender,string @event);
    }

    public abstract class Colleague
    {
        protected IMediator _mediator;

        public void SetMediator(IMediator mediator)
        {
            _mediator = mediator;
        }
    }

    public class Component1 : Colleague
    {
        public void DoA()
        {
            Console.WriteLine("Component 1 does A");
            _mediator.Notify(this, "A");
        }

        public void DoB()
        {
            Console.WriteLine("Component 1 does B");
            _mediator.Notify(this, "B");
        }
    }

    public class Component2 : Colleague
    {
        public void DoC()
        {
            Console.WriteLine("Component 2 does C");
            _mediator.Notify(this, "C");
        }

        public void DoD()
        {
            Console.WriteLine("Component 2 does D");
            _mediator.Notify(this, "D");
        }
    }

    public class ConcreteMediator : IMediator
    {
        Component1 _component1;
        Component2 _component2;

        public ConcreteMediator(Component1 component1, Component2 component2)
        {
            _component1 = component1;
            _component1.SetMediator(this);
            _component2 = component2;
            _component2.SetMediator(this);
        }

        public void Notify(object sender, string @event)
        {
            if (@event =="A")
            {
                _component2.DoC();
            }
            if (@event == "D")
            {
                _component1.DoA();
            }
        }
    }
}