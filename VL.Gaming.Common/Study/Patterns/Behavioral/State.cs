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
    public class SampleState
    {
        public void Test()
        {
        }
    }
}

//Copy
//using System;

//// Context
//public class Context
//{
//    private IState _state;

//    public Context(IState state)
//    {
//        TransitionTo(state);
//    }

//    public void TransitionTo(IState state)
//    {
//        Console.WriteLine($"Context: Transition to {state.GetType().Name}.");
//        _state = state;
//        _state.SetContext(this);
//    }

//    public void Request1()
//    {
//        _state.Handle1();
//    }

//    public void Request2()
//    {
//        _state.Handle2();
//    }
//}

//// State
//public interface IState
//{
//    void SetContext(Context context);
//    void Handle1();
//    void Handle2();
//}

//// Concrete State
//public class ConcreteStateA : IState
//{
//    private Context _context;

//    public void SetContext(Context context)
//    {
//        _context = context;
//    }

//    public void Handle1()
//    {
//        Console.WriteLine("ConcreteStateA handles Request1.");
//        Console.WriteLine("ConcreteStateA wants to change the state of the context.");
//        _context.TransitionTo(new ConcreteStateB());
//    }

//    public void Handle2()
//    {
//        Console.WriteLine("ConcreteStateA handles Request2.");
//    }
//}

//public class ConcreteStateB : IState
//{
//    private Context _context;

//    public void SetContext(Context context)
//    {
//        _context = context;
//    }

//    public void Handle1()
//    {
//        Console.WriteLine("ConcreteStateB handles Request1.");
//    }

//    public void Handle2()
//    {
//        Console.WriteLine("ConcreteStateB handles Request2.");
//        Console.WriteLine("ConcreteStateB wants to change the state of the context.");
//        _context.TransitionTo(new ConcreteStateA());
//    }
//}

//// Client
//public class Client
//{
//    public void Main()
//    {
//        var context = new Context(new ConcreteStateA());
//        context.Request1();
//        context.Request2();
//    }
//}
//详细讲解
//Context: 定义了客户感兴趣的接口，维护一个ConcreteState子类的实例，该实例定义当前状态。
//IState: 定义了一个接口以封装与Context的一个特定状态相关的行为。
//ConcreteStateA和ConcreteStateB: 实现了IState接口，每个类处理一个特定的状态，并在必要时进行状态转移。
//Client: 创建Context并触发其请求，演示状态模式如何在不同的状态下改变对象的行为。