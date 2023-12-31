using System;

namespace VL.Gaming.Study.Algorithms.Search
{
    /// <summary>
    /// 时间复杂度 θ(n)
    /// </summary>
    public class Sample_LinearSearch
    {
        public void Search()
        {
            Console.WriteLine($"arr：{string.Join(",", arr)}");
            Console.WriteLine($"find：{x}");
            int[] arr = { 2, 3, 4, 10, 40 };
            int x = 10;
            int result = LinearSearch(arr, x);
            if (result == -1)
            {
                Console.WriteLine("Element not present");
            }
            else
            {
                Console.WriteLine("Element found at index " + result);
            }
        }
        public int LinearSearch(int[] arr, int x)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"Check {arr[i]}");
                if (arr[i] == x)
                {
                    return i; // 返回元素的索引
                }
            }
            return -1; // 如果未找到则返回-1
        }
    }
}
