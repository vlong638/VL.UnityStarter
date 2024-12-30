using System;
using System.Collections.Generic;
using System.Linq;
using VL.Gaming.Framework.LocalServer;

namespace VL.Gaming.Unity.GamingV2
{
    public interface IGameSystem
    {
        Command GetCommand(string input);
        void NoValidCommand();
    }

    public class ConsoleGameSystem : IGameSystem
    {
        private static ConsoleGameSystem instance;
        public static ConsoleGameSystem Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ConsoleGameSystem();
                }
                return instance;
            }
        }

        List<Command> Commands = new List<Command>()
        {
            new Command("w"),
            new Command("s"),
            new Command("a"),
            new Command("d"),
            new Command("login",() =>
            {
                Console.WriteLine("Player1 log in");
                Console.WriteLine("hello world");
            }),
        };
        public Command GetCommand(string name)
        {
            return Commands.FirstOrDefault(c => c.Name == name);
        }
        public void NoValidCommand()
        {
            Console.WriteLine("No Valid Command Founded");
        }

        //public void PlayerLogin()
        //{
        //    var command  = Commands.FirstOrDefault(c => c.Name == "login");
        //    Server.Instance.Commands.Enqueue(command);
        //}

        public void GameStart()
        {
            Server.Instance.Start();
        }
    }
}
