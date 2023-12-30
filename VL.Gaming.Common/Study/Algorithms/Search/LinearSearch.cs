using System;

namespace VL.Gaming.Study.Algorithms.Search
{
    /// <summary>
    /// 时间复杂度 θ(n)
    /// </summary>
    public class Sample_LinearSearch
    {
        public int Search(int[] array,int x)
        {
            if (array == null || array.Length == 0)
                return -1;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i]==x)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
