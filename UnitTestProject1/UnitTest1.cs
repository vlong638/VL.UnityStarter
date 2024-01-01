using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using VL.Gaming.Framework.Tools;
using VL.Gaming.Study.Algorithms;
using VL.Gaming.Study.Algorithms.DynamicProgramming;
using VL.Gaming.Study.Algorithms.Graph;
using VL.Gaming.Study.Algorithms.Search;
using VL.Gaming.Study.Algorithms.Sorting;
using VL.Gaming.Study.Patterns;

namespace UnitTestProject1
{
    /// <summary>
    /// 23种设计模式
    /// </summary>
    [TestClass]
    public partial class UnitTest1
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

        [TestMethod]
        public void TestMethod_Bridge()
        {
            new SampleBridge().Test();
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestMethod_Composite()
        {
            new SampleComposite().Test();
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestMethod_Decorator()
        {
            new SampleDecorator().Test();
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestMethod_Proxy()
        {
            new SampleProxy().Test();
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestMethod_FlyWeight()
        {
            new SampleFlyWeight().Test();
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestMethod_Facade()
        {
            new SampleFacade().Test();
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestMethod_ChainOfResponsibility()
        {
            new SampleChainOfResponsibility().Test();
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestMethod_Command()
        {
            new SampleCommand().Test();
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestMethod_Interpreter()
        {
            new SampleInterpreter().Test();
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestMethod_Iterator()
        {
            new SampleIterator().Test();
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestMethod_Mediator()
        {
            new SampleMediator().Test();
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestMethod_Memento()
        {
            new SampleMemento().Test();
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestMethod_Observer()
        {
            new SampleObserver().Test();
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestMethod_State()
        {
            new SampleState().Test();
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestMethod_Strategy()
        {
            new SampleStrategy().Test();
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestMethod_TemplateMethod()
        {
            new SampleTemplateMethod().Test();
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestMethod_Visitor()
        {
            new SampleVisitor().Test();
            Assert.IsTrue(true);
        }
    }

    /// <summary>
    /// 其他设计模式
    /// </summary>
    public partial class UnitTest1
    {
        [TestMethod]
        public void TestMethod_DependencyInjection()
        {
            new Sample_DependencyInjection().Test();
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void TestMethod_EventDriven()
        {
            new Sample_EventDriven().Test();
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void TestMethod_ObjectPool()
        {
            new Sample_ObjectPool().Test();
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void TestMethod_Repository()
        {
            new Sample_Repository().Test();
            Assert.IsTrue(true);
        }
    }
    /// <summary>
    /// 算法
    /// </summary>
    public partial class UnitTest1
    {
        [TestMethod]
        public void TestMethod_BubbleSort()
        {
            for (int i = 0; i < 10; i++)
            {
                var input = MockHelper.MockInts(20, 1, 100);
                var output = new Sample_BubbleSort().Sort(input);
                Console.WriteLine("input:" + String.Join(",", input));
                Console.WriteLine("output:" + String.Join(",", output));
                Assert.IsTrue(true);
            }
        }
        [TestMethod]
        public void TestMethod_BinarySearch()
        {
            new Sample_BinarySearch().Search();
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void TestMethod_DepthFirstSearch()
        {
            new Sample_DepthFirstSearch().Search();
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void TestMethod_BreadthFirstSearch()
        {
            new Sample_BreadthFirstSearch().Search();
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void TestMethod_LinearSearch()
        {
            new Sample_LinearSearch().Search();
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void TestMethod_ShortestPath()
        {
            new VL.Gaming.Study.Algorithms.Graph.Sample_ShortestPath().Process();
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void TestMethod_MinimumSpanningTree()
        {
            new Sample_MinimumSpanningTree().Process();
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void TestMethod_LongestCommonSubsequencee()
        {
            new Sample_LongestCommonSubsequence().Process();
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void TestMethod_KnapsackProblem()
        {
            new Sample_KnapsackProblem().Process();
            Assert.IsTrue(true);
        }
    }
}
