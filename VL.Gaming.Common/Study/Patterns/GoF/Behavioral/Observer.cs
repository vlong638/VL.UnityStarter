using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VL.Gaming.Study.Patterns
{
    /// <summary>
    /// Observer实现了通知体系
    /// 定义了可订阅的主体：支持附加，分离，通知行为
    /// 定义了进行订阅的客体：支持订阅
    /// 当主体变更后通知进行订阅的客体
    /// 要点：订阅对象+订阅+取消+通知
    /// 
    /// 行为: subscribe
    /// 
    /// </summary>
    public class SampleObserver
    {
        public void Test()
        {
            var subject = new ConcreteSubject();
            subject.State = "State1";
            subject.Age = 14;
            var observer1 = new ConcreteObserver(subject, "observer1");
            subject.State = "State2";
            subject.Age = 15;
            var observer2 = new ConcreteObserver(subject, "observer2");
            subject.State = "State3";
            subject.Age = 16;
        }
    }

    public interface ISubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify();
    }

    public class ConcreteSubject : ISubject
    {
        private readonly List<IObserver> _observers = new List<IObserver>();
        private string _state;

        public string State
        {
            get => _state;
            set
            {
                _state = value;
                Notify();
            }
        }

        private int _age;

        public int Age
        {
            get => _age;
            set
            {
                _age = value;
                Notify();
            }
        }


        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
                observer.Update();
        }
    }

    public interface IObserver
    {
        void Update();
    }
    public class ConcreteObserver : IObserver
    {
        ConcreteSubject _subject;
        string _name;

        public ConcreteObserver(ConcreteSubject subject, string name)
        {
            _subject = subject;
            _subject.Attach(this);
            _name = name;
        }

        public void Update()
        {
            Console.WriteLine($"The new state is {_subject.State} The new age is {_subject.Age} from Observer {_name}");
        }
    }
}