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
    public class SampleObserver
    {
        public void Test()
        {
        }
    }
}

//// Subject
//public interface ISubject
//{
//    void Attach(IObserver observer);
//    void Detach(IObserver observer);
//    void Notify();
//}

//// Concrete Subject
//public class ConcreteSubject : ISubject
//{
//    private readonly List<IObserver> _observers = new List<IObserver>();
//    private string _state;

//    public string State
//    {
//        get => _state;
//        set
//        {
//            _state = value;
//            Notify();
//        }
//    }

//    public void Attach(IObserver observer)
//    {
//        _observers.Add(observer);
//    }

//    public void Detach(IObserver observer)
//    {
//        _observers.Remove(observer);
//    }

//    public void Notify()
//    {
//        foreach (var observer in _observers)
//        {
//            observer.Update();
//        }
//    }
//}

//// Observer
//public interface IObserver
//{
//    void Update();
//}

//// Concrete Observer
//public class ConcreteObserver : IObserver
//{
//    private readonly ConcreteSubject _subject;

//    public ConcreteObserver(ConcreteSubject subject)
//    {
//        _subject = subject;
//        _subject.Attach(this);
//    }

//    public void Update()
//    {
//        Console.WriteLine($"The new state is {_subject.State}");
//    }
//}

//// Client
//public class Client
//{
//    public void Main()
//    {
//        var subject = new ConcreteSubject();
//        var observerA = new ConcreteObserver(subject);
//        var observerB = new ConcreteObserver(subject);

//        subject.State = "New State"; // Output: The new state is New State (twice)
//    }
//}
//详细讲解
//ISubject: 定义了观察者模式的主题接口，包括附加、分离和通知观察者的方法。
//ConcreteSubject: 实现了主题接口，维护了一组观察者对象，并在状态改变时通知它们。
//IObserver: 定义了观察者接口，包括更新方法。
//ConcreteObserver: 实现了观察者接口，以便在主题状态发生变化时接收通知并作出相应的响应。
//Client: 创建主题和观察者对象，并演示它们之间的交互。