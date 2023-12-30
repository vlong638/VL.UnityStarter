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
    /// 状态模式与策略模式类似 但关注点不同
    /// 比如 文档编辑器，有预览状态，编辑状态，锁定状态
    /// 比如 排序算法，有快速排序策略，冒泡排序策略，插入排序策略
    /// 要点：状态+系列行为
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
            _state.Handle1(this);
        }
    }

    public interface State
    {
        void Handle1(StateContext context);
        void Handle2(StateContext context);
        void Handle3(StateContext context);
    }

    public class ConcreteStateA : State
    {
        public void Handle1(StateContext context)
        {
            Console.WriteLine("ConcreteStateA handles Request 1.");
        }

        public void Handle2(StateContext context)
        {
            Console.WriteLine("ConcreteStateA handles Request 2.");
        }

        public void Handle3(StateContext context)
        {
            Console.WriteLine("ConcreteStateA handles Request 3.");
        }
    }

    public class ConcreteStateB : State
    {
        public void Handle1(StateContext context)
        {
            Console.WriteLine("ConcreteStateB handles Request 1.");
        }

        public void Handle2(StateContext context)
        {
            Console.WriteLine("ConcreteStateB handles Request 2.");
        }

        public void Handle3(StateContext context)
        {
            Console.WriteLine("ConcreteStateB handles Request 3.");
        }
    }
}