using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VL.Gaming.Study.Patterns
{
    /// <summary>
    /// Facade 门户模式要点即将内容整合成门面
    /// </summary>
    public class SampleFacade
    {
        public void Test()
        {
            Facade facade = new Facade();
            facade.DoSomethingA();
            facade.DoSomethingB();
        }
    }
    public class SubSystemA
    {
        public void DoSomethingA()
        {
            Console.WriteLine($"{nameof(DoSomethingA)} from {nameof(SubSystemA)}");
        }
    }
    public class SubSystemB
    {
        public void DoSomethingB()
        {
            Console.WriteLine($"{nameof(DoSomethingB)} from {nameof(SubSystemB)}");
        }
    }
    /// <summary>
    /// Facade 门户在于资源整合
    /// </summary>
    public class Facade
    {
        SubSystemA _systemA = new SubSystemA();
        SubSystemB _systemB = new SubSystemB();

        public void DoSomethingA()
        {
            _systemA.DoSomethingA();
        }
        public void DoSomethingB()
        {
            _systemB.DoSomethingB();
        }
    }

}
