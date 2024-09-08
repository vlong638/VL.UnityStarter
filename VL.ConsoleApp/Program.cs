using System;
using VL.Gaming.Framework.LocalServer;
using VL.Gaming.Unity.GamingV2;

namespace VL.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleGameSystem.Instance.GameStart();
            var input = "";
            while ((input = Console.ReadLine()) != "q")
            {
                var c = ConsoleGameSystem.Instance.GetCommand(input);
                if (c == null)
                {
                    ConsoleGameSystem.Instance.NoValidCommand();
                    continue;
                }
                else
                {
                    Server.Instance.Commands.Enqueue(c);
                }
                Console.WriteLine($"player input: {input}");
            }
        }
    }
}
