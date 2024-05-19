﻿using UnityEngine;
using VL.Gaming.Unity.Common;

namespace VL.Gaming.Common
{
    /// <summary>
    /// 模拟数据生成器
    /// </summary>
    public class MockHelper
    {
        public static int[] MockInts(int length,int minValue,int maxValue)
        {
            var result = new int[length];
            for (int i = 0; i < length; i++)
                result[i] = RandomHelper.Random.Next(minValue, maxValue);
            return result;
        }

        static Color[] Colors = new Color[] { Color.cyan, Color.yellow, Color.green };
        static int ColorIndex = 0;
        public static Color MockColor()
        {
            if (ColorIndex >= 3)
                ColorIndex = 0;
            return Colors[ColorIndex++];
        }
        static Color[] Colors2 = new Color[] { Color.red, Color.blue };
        static int ColorIndex2 = 0;
        public static Color MockColor2()
        {
            if (ColorIndex2 >= 2)
                ColorIndex2 = 0;
            return Colors2[ColorIndex2++];
        }
    }
}