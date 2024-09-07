using System;
using VL.Gaming.Unity.GamingV2;

namespace VL.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleGameSystem.Instance.Welcome();
            var input = "";
            while ((input = Console.ReadLine()) !="q")
            {
                var c = ConsoleGameSystem.Instance.GetCommand(input);
                if (c==null)
                {
                    ConsoleGameSystem.Instance.NoValidCommand();
                    continue;
                }
                Console.WriteLine($"player input: {input}");
            }
        }
    }
}
