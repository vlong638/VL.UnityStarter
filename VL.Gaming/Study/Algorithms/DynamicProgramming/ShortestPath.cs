using System;

namespace VL.Gaming.Study.Algorithms.DynamicProgramming
{
    /// <summary>
    /// ShortestPath,最短路径,Dijkstra算法
    /// 时间复杂度 ？？？
    /// </summary>
    public class Sample_ShortestPath
    {
        public void Process()
        {
        }
    }

    ///// <summary>
    ///// 处理最短路径的Dijkstra算法，迪科斯彻算法，贪婪算法
    ///// 解决赋权有向图或无向图的单源最短路径问题
    ///// 方案：采用广度优先搜索来解决单源最短路径问题
    ///// 缺点：时间复杂度过高θ（VE）
    ///// </summary>
    //public class ShortestPath_Dijkstra
    //{
    //    int VerticeCount;
    //    int[,] Graph;

    //    public ShortestPath_Dijkstra(int vertice)
    //    {
    //        VerticeCount = vertice;
    //        Graph = new int[vertice, vertice];
    //    }

    //    public void AddEdge(int u, int v, int weight)
    //    {
    //        Graph[u, v] = weight;
    //    }

    //    public void Dijkstra(int source)
    //    {
    //        int[] distance = new int[VerticeCount];
    //        bool[] visited = new bool[VerticeCount];
    //        for (int i = 0; i < VerticeCount; i++)
    //        {
    //            distance[i] = int.MaxValue;
    //            visited[i] = false;
    //        }
    //        distance[source] = 0;
    //        for (int i = 0; i < VerticeCount-1; i++)
    //        {
    //            int minIndex = MinDistanceIndex(distance, visited);
    //            visited[minIndex] = true;
    //            distance[minIndex] = MinDistance(minIndex, distance, visited);
    //        }
    //        PrintSolution(distance);
    //    }

    //    int MinDistanceIndex(int[] distance, bool[] visited)
    //    {
    //        int min = int.MaxValue;
    //        int minIndex = -1;
    //        for (int i = 0; i < VerticeCount; i++)
    //        {
    //            if (!visited[i] && distance[i] <= min)
    //            {
    //                min = distance[i];
    //                minIndex = i;
    //            }
    //        }
    //        return minIndex;
    //    }
    //    int MinDistance(int minIndex, int[] distance, bool[] visited)
    //    {
    //        var minDistance = distance[minIndex];
    //        for (int j = 0; j < VerticeCount; j++)
    //        {
    //            if (!visited[j]
    //                && Graph[minIndex, j] != 0
    //                && distance[minIndex] != int.MaxValue
    //                && distance[minIndex] + Graph[minIndex, j] < distance[minIndex])
    //            {
    //                minDistance = distance[minIndex] + Graph[minIndex, j];
    //            }
    //        }
    //        return minDistance;
    //    }
    //    void PrintSolution(int[] distance)
    //    {
    //        Console.WriteLine("Vertex \t Distance from Source");
    //        for (int i = 0; i < VerticeCount; i++)
    //        {
    //            Console.WriteLine(i + " \t " + distance[i]);
    //        }
    //    }
    //}

    /// <summary>
    /// Floyd算法
    /// 解决有向图或负权（但不可存在负权回路）的最短路径算法
    /// </summary>
    public class ShortestPath_Floyd
    {
    }
    /// <summary>
    /// SPFA算法，也称作Moore-Bellman-Ford算法
    /// 这是一种动态逼近法采用了松弛操作来优化时间复杂度
    /// </summary>
    public class ShortestPath_SPFA
    {
    }
}
