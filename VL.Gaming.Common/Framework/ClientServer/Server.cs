using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace VL.Gaming.Framework.ClientServer
{
    public class Server
    {
        private Subject subject;

        public Server()
        {
            subject = new Subject();
        }

        public void Start(int port)
        {
            TcpListener listener = new TcpListener(IPAddress.Any, port);
            listener.Start();
            Console.WriteLine("服务端启动，等待连接...");

            Task.Run(() =>
            {
                while (true)
                {
                    TcpClient tcp = listener.AcceptTcpClient();
                    Console.WriteLine("客户端已连接");
                    var observer = new Observer(tcp);
                    subject.Attach(observer);
                    Task.Run(() => HandleObserver(tcp, observer));
                }
            });
        }

        private void HandleObserver(TcpClient client, Observer Observer)
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            int bytesRead;

            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Console.WriteLine($"接收消息: {message}");
                subject.Notify(message);
            }

            subject.Detach(Observer);
            Console.WriteLine("客户端已断开");
            client.Close();
        }

        public void SendMessage(string message)
        {
            subject.Notify(message);
        }
    }
}
