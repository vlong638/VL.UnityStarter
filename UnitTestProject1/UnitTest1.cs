using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using VL.Gaming.Study.Patterns;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod_FactoryMethod()
        {
            new FactoryMethod().Sample();
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestMethod_AbstractFactory()
        {
            new AbstractFactory().Sample(new ConcreteFactory1());
            new AbstractFactory().Sample(new ConcreteFactory2());
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestMethod_Singleton()
        {
            Console.WriteLine("Now:" + DateTime.Now.ToString());
            Singleton.Instance.Sample();
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Now:" + DateTime.Now.ToString());
            Singleton.Instance.Sample();
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Now:" + DateTime.Now.ToString());
            Singleton.Instance.Sample();
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestMethod_Builder()
        {
            var result = new SampleBuilder().Test().DoSomething();
            Console.WriteLine(result);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestMethod_Prototype()
        {
            new SamplePrototype().Test();
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestMethod_Adapter()
        {
            new SampleAdapter().Test();
            Assert.IsTrue(true);
        }
    }
}
