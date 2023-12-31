using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VL.Gaming.Study.Patterns
{
    /// <summary>
    /// Decorator 装饰者
    /// 要点：扩展行为，现在可以用更好用的扩展方法来实现
    /// </summary>
    public class SampleDecorator
    {
        public void Test()
        {
            var component = new ConcreteDecorator(new ConcreteComponent());
            component.Operation();
        }
    }

    interface IComponent
    {
        void Operation();
    }

    class ConcreteComponent : IComponent
    {
        public void Operation()
        {
            Console.WriteLine("ConcreteComponent Operation");
        }
    }
    class Decorator : IComponent
    {
        IComponent _component;

        public Decorator(IComponent component)
        {
            _component = component;
        }

        public virtual void Operation()
        {
            _component.Operation();
        }
    }

    class ConcreteDecorator : Decorator
    {
        public ConcreteDecorator(IComponent component) : base(component)
        {
        }
        public override void Operation()
        {
            base.Operation();
            Console.WriteLine("ConcreteDecorator Operation");
        }
    }
}
