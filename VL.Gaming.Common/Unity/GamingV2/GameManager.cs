using System;
using System.Collections.Generic;
using System.Linq;

namespace VL.Gaming.Unity.GamingV2
{
    public interface IGameSystem
    {
        void Welcome();
        VLCommand GetCommand(string input);
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

        List<VLCommand> Commands = new List<VLCommand>()
        {
            new VLCommand("w"),
            new VLCommand("s"),
            new VLCommand("a"),
            new VLCommand("d"),
            new VLCommand("h"),
        };
        public VLCommand GetCommand(string name)
        {
            return Commands.FirstOrDefault(c => c.Command == name);
        }
        public void NoValidCommand()
        {
            Console.WriteLine("No Valid Command Founded");
        }

        public void Welcome()
        {
            Console.WriteLine("Welcome to Unique Land");
            Console.WriteLine("h for help");
            Console.WriteLine("u can find happyness here");
        }
    }
    public class VLCommand
    {
        public string Command;

        public VLCommand(string command)
        {
            Command = command;
        }
    }
}
