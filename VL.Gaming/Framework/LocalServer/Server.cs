using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VL.Gaming.Framework.LocalServer
{
    public class Command
    {
        public Command(string name)
        {
            Name = name;
        }
        public Command(string name, Action action)
        {
            Name = name;
            Execute += action;
        }

        public string Name { get; set; }

        public event Action Execute;

        public void RaiseEvent()
        {
            Execute?.Invoke();
        }
    }

    public class CommandCollection
    {
        List<Command> Commands = new List<Command>();

        public void Enqueue(Command c)
        {
            Commands.Add(c);
        }

        public Command Dequeue()
        {
            var c = Commands.FirstOrDefault();
            if (c != null)
            {
                Commands.Remove(c);
                return c;
            }
            return null;
        }

        public int Count()
        {
            return Commands.Count;
        }
    }

    public class Server
    {
        public CommandCollection Commands;

        static Server instance;
        public static Server Instance
        {
            get
            {
                if (instance ==null)
                {
                    instance = new Server();
                }
                return instance;
            }
        }

        public Server()
        {
            Commands = new CommandCollection();
        }

        public void Start()
        {
            Task.Run(() =>
            {
                Console.WriteLine("服务端启动，等待连接...");
                while (true)
                {
                    if (Commands.Count() == 0)
                        continue;
                    //待处理任务
                    Console.WriteLine($"待处理任务:{Commands.Count()}");
                    //处理任务
                    var c = Commands.Dequeue();
                    c.RaiseEvent();
                }
            });
        }
    }
}
