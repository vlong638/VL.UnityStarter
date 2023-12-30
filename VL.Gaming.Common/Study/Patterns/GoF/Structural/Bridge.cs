using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VL.Gaming.Study.Patterns
{
    /// <summary>
    /// it decouples an abstraction from its implementation so that the two can vary independently
    /// 解耦抽象和实现，下述案例将Implementor与Abstraction解耦
    /// 这样A和B可以采用不同的实现类而不用更改Abstraction
    /// 要点：将某部分特定业务完整抽离，桥接适配，业务的结构分层
    /// </summary>
    public class SampleBridge
    {
        public void Test()
        {
            IWindowImpl windows = new ImplWindows();
            IWindowImpl mac =new ImplMAC();
            WindowBridgeAbstraction regularWindow;
            WindowBridgeAbstraction specialWindow;

            regularWindow = new RegularWindow(windows);
            regularWindow.Draw();
            specialWindow = new SpecialWindow(windows);
            specialWindow.Draw();

            regularWindow = new RegularWindow(mac);
            regularWindow.Draw();
            specialWindow = new SpecialWindow(mac);
            specialWindow.Draw();
        }
    }

    /// <summary>
    /// IWindowImpl指的是与Window相关的实现部分
    /// 决定桥接器模式有效应用的根本要素是
    /// 隔离分界的有效性，比如提炼了操作系统相关部分的窗口绘制
    /// 那么这部分就认为不再会在抽象的Draw（）中继续耦合。
    /// </summary>
    interface IWindowImpl
    {
        void DrawWindow();
    }

    class ImplWindows : IWindowImpl
    {
        public void DrawWindow()
        {
            Console.WriteLine("Windows drawing a window,与操作系统相关的部分");
        }
    }

    class ImplMAC : IWindowImpl
    {
        public void DrawWindow()
        {
            Console.WriteLine("MAC drawing a window,与操作系统相关的部分");
        }
    }

    ///Bridge abstraction
    ///将实现IWindow与绘制DrawWindow解耦
    ///从而使得他们之间的抽象关系是稳固的
    ///并且当扩展发生时，只需要派生新的扩展类型进行实现即可
    ///其中IWindowImpl指的是与操作系统相关的实现部分
    ///Draw中则是整体包括与操作系统相关与无关的部分
    ///
    abstract class WindowBridgeAbstraction
    {
        protected IWindowImpl implementor;

        public WindowBridgeAbstraction(IWindowImpl implementor)
        {
            this.implementor = implementor;
        }

        public abstract void Draw();
    }

    class RegularWindow : WindowBridgeAbstraction
    {
        public RegularWindow(IWindowImpl implementor) : base(implementor)
        {
        }

        public override void Draw()
        {
            implementor.DrawWindow();
            Console.WriteLine("Draw a regular window,与操作系统无关的部分");
        }
    }
    class SpecialWindow : WindowBridgeAbstraction
    {
        public SpecialWindow(IWindowImpl implementor) : base(implementor)
        {
        }

        public override void Draw()
        {
            implementor.DrawWindow();
            Console.WriteLine("Draw a special window,与操作系统无关的部分");
        }
    }
}
