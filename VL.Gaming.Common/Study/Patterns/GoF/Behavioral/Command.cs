using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VL.Gaming.Study.Patterns
{
    /// <summary>
    /// Command将请求封装成对象Command
    /// 从而使Receiver接受者和Invoker发送者之间解耦，让Invoker可以通过绑定来调用
    /// 解耦则意味着请求和发送者中间这个环节需要增加业务功能：
    /// 当需要将请求封装成独立对象，以支持参数化操作，队列，日志等功能
    /// 当需要支持命令的操作进行排队，记录日志，撤销操作，或重做操作
    /// 当需要将命令的执行与发起者解耦，以支持请求的异步执行或者延迟执行时
    /// </summary>
    public class SampleCommand
    {
        public void Test()
        {
            var receiver = new Light();
            var commandA = new TurnOnCommand(receiver);
            var commandB = new TurnOffCommand(receiver);
            var invoker = new RemoteControl();
            invoker.SetCommand(commandA);
            invoker.ExecuteCommand();
            invoker.SetCommand(commandB);
            invoker.ExecuteCommand();
        }
    }
    //ICommand
    public interface ICommand
    {
        void Execute();
    }
    //Receiver
    public class Light
    {
        public void TurnOn(TurnOnCommand command)
        {
            Console.WriteLine("light turns on");
        }
        public void TurnOff(TurnOffCommand command)
        {
            Console.WriteLine("light turns off");
        }
    }
    //ConcreteCommand
    public class TurnOnCommand : ICommand
    {
        public Light _light;

        public TurnOnCommand(Light light)
        {
            _light = light;
        }

        public void Execute()
        {
            _light.TurnOn(this);
        }
    }
    //ConcreteCommand
    public class TurnOffCommand : ICommand
    {
        public Light _light;

        public TurnOffCommand(Light light)
        {


            _light = light;
        }

        public void Execute()
        {
            _light.TurnOff(this);
        }
    }
    //Invoker
    public class RemoteControl
    {
        ICommand _command;

        public void SetCommand(ICommand command)
        {
            _command = command; 
        }
        public void ExecuteCommand()
        {
            _command.Execute(); 
        }
    }


}
