using System;

namespace VL.Gaming.Study.Algorithms.DynamicProgramming
{
    /// <summary>
    /// TODO
    /// KnapsackProblem,背包问题
    /// 时间复杂度 ？？？
    /// </summary>
    public class Sample_KnapsackProblem
    {
        public void Process()
        {
            Item[] items = new Item[]
            {
            new Item { Name = "Item1", Weight = 2, Value = 6 },
            new Item { Name = "Item2", Weight = 2, Value = 10 },
            new Item { Name = "Item3", Weight = 3, Value = 12 }
            };

            int capacity = 5;

            Knapsack knapsack = new Knapsack();
            int maxValue = knapsack.SolveKnapsack(items, capacity);

            Console.WriteLine("The maximum value that can be put in a knapsack of capacity " + capacity + " is: " + maxValue);
        }
    }
    public class Item
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Value { get; set; }
    }

    public class Knapsack
    {
        public int SolveKnapsack(Item[] items, int capacity)
        {
            int[,] dp = new int[items.Length + 1, capacity + 1];

            for (int i = 0; i <= items.Length; i++)
            {
                for (int w = 0; w <= capacity; w++)
                {
                    if (i == 0 || w == 0)
                    {
                        dp[i, w] = 0;
                    }
                    else if (items[i - 1].Weight <= w)
                    {
                        dp[i, w] = Math.Max(items[i - 1].Value + dp[i - 1, w - items[i - 1].Weight], dp[i - 1, w]);
                    }
                    else
                    {
                        dp[i, w] = dp[i - 1, w];
                    }
                }
            }

            return dp[items.Length, capacity];
        }
    }
}
