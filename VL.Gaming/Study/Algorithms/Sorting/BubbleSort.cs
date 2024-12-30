using System;

namespace VL.Gaming.Study.Algorithms.Sorting
{
    /// <summary>
    /// 冒泡排序
    /// 时间复杂度θ（n^2）
    /// </summary>
    public class Sample_BubbleSort
    {
        public int[] Sort(int[] array)
        {
            if (array == null || array.Length == 0)
                return array;
            var result = new int[array.Length];
            Array.Copy(array, 0, result, 0, array.Length);
            for (int i = 0; i < result.Length; i++)
            {
                for (int j = result.Length - 1; j > i; j--)
                {
                    if (result[j] < result[j - 1])
                    {
                        var temp = result[j];
                        result[j] = result[j - 1];
                        result[j - 1] = temp;
                    }
                }
            }
            return result;
        }
    }
}
