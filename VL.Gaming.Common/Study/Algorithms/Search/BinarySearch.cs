using System;

namespace VL.Gaming.Study.Algorithms.Search
{
    /// <summary>
    /// ？？？
    /// 时间复杂度 ？？？
    /// </summary>
    public class Sample_BinarySearch
    {
        public void Search()
        {
            int[] arr = { 2, 3, 4, 10, 40 };
            int x = 10;
            Console.WriteLine($"arr：{string.Join(",", arr)}");
            Console.WriteLine($"find：{x}");
            int result = BinarySearch(arr, x);
            if (result == -1)
            {
                Console.WriteLine("Element not present");
            }
            else
            {
                Console.WriteLine("Element found at index " + result);
            }
        }

        public int BinarySearch(int[] arr, int x)
        {
            int left = 0;
            int right = arr.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                Console.WriteLine($"Check {arr[mid]}");
                if (arr[mid] == x)
                {
                    return mid;
                }
                else if (arr[mid] < x)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return -1; // 如果未找到则返回-1
        }
    }
}
