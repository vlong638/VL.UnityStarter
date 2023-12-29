using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VL.Gaming.Study.Patterns
{
    /// <summary>
    /// 状态模式支持在不同的状态下改变行为
    /// 将与状态相关的行为进行封装
    /// </summary>
    public class SampleState
    {
        public void Test()
        {
            var context = new StateContext(new ConcreteStateA());
            context.Request();
            context.TransitionTo(new ConcreteStateB());
            context.Request();
        }
    }

    public class StateContext
    {
        State _state;

        public StateContext(State state)
        {
            _state = state;
        }

        public void TransitionTo(State state)
        {
            Console.WriteLine($"Context: Transition to {state.GetType().Name}.");
            _state = state;
        }

        public void Request()
        {
            _state.Handle(this);
        }
    }

    public interface State
    {
        void Handle(StateContext context);
    }

    public class ConcreteStateA : State
    {
        public void Handle(StateContext context)
        {
            Console.WriteLine("ConcreteStateA handles Request.");
        }
    }

    public class ConcreteStateB : State
    {
        public void Handle(StateContext context)
        {
            Console.WriteLine("ConcreteStateB handles Request.");
        }
    }
}