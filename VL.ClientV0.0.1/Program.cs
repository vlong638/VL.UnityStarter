using System;
using System.Net.Sockets;
using System.Text;

namespace VL.ClientV0._0._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TcpClient client = new TcpClient("127.0.0.1", 638);
            NetworkStream stream = client.GetStream();
            Console.WriteLine("已连接到服务器。");
            while (true)
            {
                string message = Console.ReadLine();
                byte[] data = Encoding.UTF8.GetBytes(message);
                stream.Write(data, 0, data.Length);
            }
        }
    }
}
