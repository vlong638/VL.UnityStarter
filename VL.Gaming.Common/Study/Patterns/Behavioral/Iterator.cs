using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VL.Gaming.Study.Patterns
{
    /// <summary>
    /// 迭代器
    /// </summary>
    public class SampleIterator
    {
        public void Test()
        {
            var aggregate = new ConcreteAggregate();
            aggregate.AddItem("Item 1");
            aggregate.AddItem("Item 2");
            aggregate.AddItem("Item 3");
            var iterator = aggregate.CreateIterator();
            while (iterator.HasNext())
            {
                Console.WriteLine(iterator.Next());
            }
        }
    }

    public interface IIterator
    {
        bool HasNext();
        object Next();
    }
    public class ConcreteIterator : IIterator
    {
        ConcreteAggregate _aggregate;
        int _index = 0;

        public ConcreteIterator(ConcreteAggregate aggregate)
        {
            _aggregate = aggregate;
        }

        public bool HasNext()
        {
            return _index < _aggregate.Count;
        }

        public object Next()
        {
            if (HasNext())
            {
                return _aggregate[_index++];
            }
            else
            {
                throw new InvalidOperationException("End of Collection Reached");
            }
        }
    }

    public interface IAggregate
    {
        IIterator CreateIterator();
    }

    public class ConcreteAggregate : IAggregate {
        ArrayList _items = new ArrayList();

        public void AddItem(object item)
        {
            _items.Add(item);
        }

        public IIterator CreateIterator()
        {
            return new ConcreteIterator(this);
        }

        public int Count { get { return _items.Count; } }
        public object this[int index] { get { return _items[index]; } }
    }
}