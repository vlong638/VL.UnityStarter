using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VL.Godot.VLCommon
{
    public static class MathEx
    {
        private static readonly Random _rand = new Random();

        public static T PickRandom<T>(this IList<T> list)
        {
            if (list == null || list.Count == 0)
                throw new ArgumentException("集合为空");
            return list[_rand.Next(list.Count)];
        }
    }
}
