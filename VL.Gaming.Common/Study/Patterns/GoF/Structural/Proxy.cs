using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VL.Gaming.Study.Patterns
{
    /// <summary>
    /// 代理的要义在于构建代理层
    /// 代理层进行代理的核心业务处理
    /// </summary>
    public  class SampleProxy
    {
        public void Test()
        {
            InternetProxy proxy;
            proxy = new InternetProxy(Country.Japan,Job.Employee);
            proxy.ConnectTo("www.baidu.com");
            proxy = new InternetProxy(Country.Japan, Job.Manager);
            proxy.ConnectTo("www.baidu.com");
            proxy = new InternetProxy(Country.Korean, Job.Employee);
            proxy.ConnectTo("www.baidu.com");
            proxy = new InternetProxy(Country.Korean, Job.Manager);
            proxy.ConnectTo("www.baidu.com");
        }
    }

    interface IInternet
    {
        void ConnectTo(string serverHost);
    }
    class JapanInternet : IInternet
    {
        public void ConnectTo(string serverHost)
        {
            Console.WriteLine("Connecting to Japan," + serverHost);
        }
    }
    class KoreanInternet : IInternet
    {
        public void ConnectTo(string serverHost)
        {
            Console.WriteLine("Connecting to Korean," + serverHost);
        }
    }

    enum Country
    {
        None =0,
        Japan = 1,
        Korean = 2,
    }
    enum Job
    {
        None = 0,
        Employee = 1,
        Manager = 2,
    }
    class InternetProxy : IInternet
    {
        JapanInternet _japanInternet;
        KoreanInternet _koreanInternet;
        Country _country;
        Job _job;


        public InternetProxy(Country country,Job job)
        {
            this._japanInternet = new JapanInternet();
            this._koreanInternet = new KoreanInternet();
            _country = country;
            _job = job;
        }

        public void ConnectTo(string serverHost)
        {
            switch (_country)
            {
                case Country.None:
                    break;
                case Country.Japan:
                    switch (_job)
                    {
                        case Job.None:
                            break;
                        case Job.Employee:
                            Console.WriteLine($"{_job.ToString()} is canceled from {_country.ToString()}");
                            break;
                        case Job.Manager:
                            _japanInternet.ConnectTo(serverHost);
                            break;
                        default:
                            break;
                    }
                    break;
                case Country.Korean:
                    switch (_job)
                    {
                        case Job.None:
                            break;
                        case Job.Employee:
                            _japanInternet.ConnectTo(serverHost);
                            break;
                        case Job.Manager:
                            _koreanInternet.ConnectTo(serverHost);
                            break;
                        default:
                            break;
                    }
                    break;
                    break;
                default:
                    break;
            }
        }
    }
}
