using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VL.Gaming.Study.Patterns
{
    /// <summary>
    /// 对象池模式
    /// 要点：对象的重复利用，创建池，取出，放入
    /// </summary>
    public class Sample_ObjectPool
    {
        public void Test()
        {
            var pool = new ObjectPool(5);
            Parallel.For(0, 20, i =>
            {
                var obj = pool.GetOne();
                obj.DoSomething();
                pool.PutOne(obj);
            });
        }
    }

    public class ReuseableObject
    {
        public ReuseableObject(int i)
        {
            Index = i;
        }

        public int Index { get; }

        public void DoSomething()
        {
            Console.WriteLine($"ReuseableObject doing something,Index:{Index}");
        }
    }

    public class ObjectPool
    {
        object locker = new object();
        private List<ReuseableObject> _pool = new List<ReuseableObject>();

        public ObjectPool(int size)
        {
            for (int i = 0; i < size; i++)
            {
                _pool.Add(new ReuseableObject(i));
            }
        }

        public ReuseableObject GetOne()
        {
            if (_pool.Count > 0)
            {
                lock (locker)
                {
                    ReuseableObject obj = _pool[0];
                    _pool.RemoveAt(0);
                    return obj;
                }
            }
            return new ReuseableObject(-1);
        }

        public void PutOne(ReuseableObject obj)
        {
            _pool.Add(obj);
        }
    }


}