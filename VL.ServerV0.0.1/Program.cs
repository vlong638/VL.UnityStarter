using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using VL.Gaming.Framework.ClientServer;

namespace VL.ServerV0._0._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new Server().Start(638);
            Console.ReadLine();
        }
    }
}
