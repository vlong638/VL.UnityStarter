using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VL.Gaming.Study.Patterns
{
    /// <summary>
    /// 职责链旨在构建一个职责分拣传递的递归处理模式
    /// 分拣 
    /// 传递 base.Handle()
    /// 它的适用领域是：
    /// 当多个对象可以处理同一请求，但具体的处理者在运行时确定时
    /// 在需要不明确接收者的情况下，将请求发送给多个对象中的一个
    /// 当需要按顺序执行处理逻辑，直到找到能够处理请求的对象。
    /// </summary>
    public class SampleChainOfResponsibility
    {
        public void Test()
        {
            var hA = new ConcreteHandlerA();
            var hB = new ConcreteHandlerB();
            var hC = new ConcreteHandlerC();
            var hO = new ConcreteHandlerOthers();
            hA.SetNext(hB);
            hB.SetNext(hC); 
            hC.SetNext(hO);
            
            Console.WriteLine(hA.Handle("A"));
            Console.WriteLine(hA.Handle("B"));
            Console.WriteLine(hA.Handle("C"));
            Console.WriteLine(hA.Handle("D"));
            Console.WriteLine(hA.Handle("E"));
        }
    }

    public interface IHandler
    {
        void SetNext(IHandler handler);
        string Handle(string request);
    }

    public abstract class BaseHandler : IHandler
    {
        IHandler _nextHandler;

        public virtual string Handle(string request)
        {
            if (_nextHandler == null)
                return null;
            return _nextHandler.Handle(request);
        }

        public void SetNext(IHandler handler)
        {
            _nextHandler = handler;
        }
    }

    public class ConcreteHandlerA : BaseHandler
    {
        public override string Handle(string request)
        {
            if (request=="A")
            {
                return "Handled by ConcreteHandlerA";
            }
            return base.Handle(request);
        }
    }
    public class ConcreteHandlerB: BaseHandler
    {
        public override string Handle(string request)
        {
            if (request == "B")
            {
                return "Handled by ConcreteHandlerB";
            }
            return base.Handle(request);
        }
    }
    public class ConcreteHandlerC : BaseHandler
    {
        public override string Handle(string request)
        {
            if (request == "C")
            {
                return "Handled by ConcreteHandlerC";
            }
            return base.Handle(request);
        }
    }
    public class ConcreteHandlerOthers : BaseHandler
    {
        public override string Handle(string request)
        {
            return "Handled by ConcreteHandlerOthers";
        }
    }
}
