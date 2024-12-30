using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VL.Gaming.Study.Patterns
{
    /// <summary>
    /// 依赖注入
    /// </summary>
    public class Sample_DependencyInjection
    {
        public void Test()
        {
            // 创建服务实例
            IService service = new ConcreteService();
            //1.通过构造函数注入服务
            Client1 client = new Client1(service);
            client.DoWork("client1's work");
            //2.通过参数注入服务
            Client2 client2 = new Client2();
            client2.DoWork(service, "client2's work");
        }
    }

    public interface IService
    {
        void Serve(string work);
    }

    public class ConcreteService : IService
    {
        public void Serve(string work)
        {
            Console.WriteLine("Being Served," + work);
        }
    }

    public class Client1
    {
        readonly IService _service;

        //通过构造函数注入服务
        public Client1(IService service)
        {
            _service = service;
        }

        public void DoWork(string work)
        {
            _service.Serve(work);
        }
    }

    public class Client2
    {
        //通过参数注入服务
        public void DoWork(IService service, string work)
        {
            service.Serve(work);
        }
    }
}