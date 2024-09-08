using System;
using System.Net.Sockets;
using System.Text;

namespace VL.Gaming.Framework.ClientServer
{
    public interface IObserver
    {
        void Update(string message);
    }
    public class Observer : IObserver
    {
        private TcpClient client;

        public Observer(TcpClient client)
        {
            this.client = client;
        }

        public void Update(string message)
        {
            NetworkStream stream = client.GetStream();
            byte[] data = Encoding.UTF8.GetBytes(message);
            stream.Write(data, 0, data.Length);
            Console.WriteLine($"分发消息: {message}");
        }
    }
}
