using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;

namespace VL.Godot.VLCommon
{
    public static class MathEx
    {
        private static readonly Random _rand = new Random();

        #region List
        public static T PickRandom<T>(this IList<T> list)
        {
            if (list == null || list.Count == 0)
                throw new ArgumentException("集合为空");
            return list[_rand.Next(list.Count)];
        } 
        #endregion

        #region Vector2
        public static Vector2 SetX(this Vector2 vector2, float value)
        {
            return  new Vector2(value, vector2.Y);
        }
        public static Vector2 SetY(this Vector2 vector2, float value)
        {
            return new Vector2(vector2.X, value);
        } 
        #endregion
    }
}
