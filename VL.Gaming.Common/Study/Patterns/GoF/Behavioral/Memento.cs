using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VL.Gaming.Study.Patterns
{
    ///Memento: 存储Originator内部状态的类。
    ///Caretaker: 看护者，负责保存Memento，但不对其内容进行操作。
    ///Originator: 恢复器，创建并恢复自身状态的类。
    ///Client: 创建Originator、Memento和Caretaker实例，并演示如何使用备忘录模式来保存和恢复对象的状态。
    ///要点：Obj.Backup=>Memento=>Obj.Rollback
    ///
    /// 行为: backup
    ///
    public class SampleMemento
    {
        public void Test()
        {
            var originator = new Originator();
            var caretaker = new CareTaker();

            originator.State = "State1";
            Console.WriteLine($"Set State");
            Console.WriteLine($"Current State: {originator.State}");

            caretaker.Memento = originator.Backup();
            Console.WriteLine($"Backup");
            Console.WriteLine($"Memento State: {caretaker.Memento.State}");
            
            originator.State = "State2";
            Console.WriteLine($"Set State");
            Console.WriteLine($"Current State: {originator.State}");

            originator.Rollback(caretaker.Memento);
            Console.WriteLine($"Rollback");
            Console.WriteLine($"Current State: {originator.State}");
        }
    }

    public class Memento
    {
        public string State { get; }

        public Memento(string state)
        {
            State = state;
        }
    }

    public class CareTaker
    {
        public Memento Memento { get; set; }
    }

    public class Originator
    {
        public string State { get; set; }

        public Memento Backup()
        {
            return new Memento(State);
        }

        public void Rollback(Memento memento)
        {
            State = memento.State;
        }
    }
}