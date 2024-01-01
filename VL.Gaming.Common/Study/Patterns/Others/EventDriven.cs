using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VL.Gaming.Study.Patterns
{
    /// <summary>
    /// TODO
    /// ???
    /// </summary>
    public class Sample_EventDriven
    {
        public void Test()
        {
            var publisher = new EventPublisher();
            var subscriber = new EventSubscripber();
            publisher.OnEvent += subscriber.HandleEvent;
            publisher.RaiseEvent("event from publisher");
        }
    }


    public class EventPublisher
    {
        public delegate void EventHandler(string message);
        public event EventHandler OnEvent;

        public void RaiseEvent(string message)
        {
            Console.WriteLine("publisher RaiseEvent");
            OnEvent?.Invoke(message);
        }
    }

    public class EventSubscripber
    {
        public void HandleEvent(string message)
        {
            Console.WriteLine("EventSubscriber received the message:" + message);
        }
    }
}