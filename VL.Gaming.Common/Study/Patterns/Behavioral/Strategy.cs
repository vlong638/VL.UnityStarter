using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VL.Gaming.Study.Patterns
{
    /// <summary>
    /// 策略模式将不同的策略进行封装
    /// 状态模式与策略模式类似 但关注点不同
    /// 比如 文档编辑器，有预览状态，编辑状态，锁定状态
    /// 比如 人的工作机能受到身体状态影响，有正常状态，兴奋状态，虚弱状态，生病状态
    /// 比如 排序算法，有快速排序策略，冒泡排序策略，插入排序策略
    /// 比如 销售策略：有折扣策略，有溢价策略，有常规策略
    /// </summary>
    public class SampleStrategy
    {
        public void Test()
        {
            var context = new StrategyContext();
            context.SetStrategy(new ConcreteStrategyOnSale());
            context.Sell(new Goods(17, "ball"));
            context.SetStrategy(new ConcreteStrategyNormal());
            context.Sell(new Goods(17, "ball"));
        }
    }

    public interface IStrategy
    {
        string Name { set; get; }
        double PriceDiscount { set; get; }
        void UpdatePrice(Goods goods);
    }

    public class ConcreteStrategyOnSale : IStrategy
    {
        public string Name { set; get; }
        public double PriceDiscount { set; get; }
        public void UpdatePrice(Goods goods)
        {
            Name = "On Sale";
            PriceDiscount = 0.75;
            goods.CurrentPrice = goods.OriginPrice * PriceDiscount;
        }
    }

    public class ConcreteStrategyNormal : IStrategy
    {
        public string Name { set; get; }
        public double PriceDiscount { set; get; }
        public void UpdatePrice(Goods goods)
        {
            Name = "Normal Sell";
            PriceDiscount = 0.9;
            goods.CurrentPrice = goods.OriginPrice * PriceDiscount;
        }
    }

    public class StrategyContext
    {
        IStrategy SellStrategy;

        public void SetStrategy(IStrategy sellStrategy)
        {
            SellStrategy = sellStrategy;
        }

        public void Sell(Goods goods)
        {
            SellStrategy.UpdatePrice(goods);
            Console.WriteLine($"正在销售{goods.Name},当前销售策略:{SellStrategy.Name},原价:{goods.OriginPrice},现价:{goods.CurrentPrice}");
        }
    }

    public class Goods
    {
        public string Name { set; get; }
        public double OriginPrice { set; get; }
        public double CurrentPrice { set; get; }

        public Goods(double price, string name)
        {
            OriginPrice = price;
            Name = name;
        }
    }
}