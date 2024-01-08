using System;

namespace VL.Gaming.Study.Algorithms.DynamicProgramming
{
    /// <summary>
    /// LongestCommonSubsequence,最长公共子序列
    /// 时间复杂度 ？？？
    /// </summary>
    public class Sample_LongestCommonSubsequence
    {
        public void Process()
        {
            string str1 = "LongestCommonSubsequence";
            string str2 = "Common";

            LongestCommonSubsequence lcs = new LongestCommonSubsequence();
            int length = lcs.FindLCSLength(str1, str2);

            Console.WriteLine("The length of the longest common subsequence is: " + length);
        }
    }
    public class LongestCommonSubsequence
    {
        public int FindLCSLength(string str1, string str2)
        {
            int[,] dp = new int[str1.Length + 1, str2.Length + 1];

            for (int i = 0; i <= str1.Length; i++)
            {
                for (int j = 0; j <= str2.Length; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        dp[i, j] = 0;
                    }
                    else if (str1[i - 1] == str2[j - 1])
                    {
                        dp[i, j] = 1 + dp[i - 1, j - 1];
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                    }
                }
            }

            return dp[str1.Length, str2.Length];
        }
    }
}
