using System;

namespace VL.Gaming.Study.Algorithms.Graph
{
    /// <summary>
    /// ShortestPath,最短路径,Dijkstra算法
    /// 时间复杂度 ？？？
    /// </summary>
    public class Sample_ShortestPath
    {
        public void Process()
        {
            var sp = new ShortestPath_Dijkstra(5);
            sp.AddEdge(0, 1, 6);
            sp.AddEdge(0, 3, 1);
            sp.AddEdge(1, 3, 2);
            sp.AddEdge(1, 2, 5);
            sp.AddEdge(3, 2, 1);
            sp.AddEdge(3, 4, 10);
            sp.AddEdge(2, 4, 5);

            sp.Dijkstra(0);
        }
    }

    /// <summary>
    /// 处理最短路径的Dijkstra算法，迪科斯彻算法，贪婪算法
    /// 解决赋权有向图或无向图的单源最短路径问题
    /// 方案：采用广度优先搜索来解决单源最短路径问题
    /// 缺点：时间复杂度过高θ（VE）
    /// </summary>
    public class ShortestPath_Dijkstra
    {
        int VerticeCount;
        int[,] Graph;

        public ShortestPath_Dijkstra(int vertice)
        {
            VerticeCount = vertice;
            Graph = new int[vertice, vertice];
        }

        public void AddEdge(int u, int v, int weight)
        {
            Graph[u, v] = weight;
        }

        public void Dijkstra(int source)
        {
            int[] distance = new int[VerticeCount];
            bool[] visited = new bool[VerticeCount];
            for (int i = 0; i < VerticeCount; i++)
            {
                distance[i] = int.MaxValue;
                visited[i] = false;
            }
            distance[source] = 0;
            for (int i = 0; i < VerticeCount - 1; i++)
            {
                int minIndex = MinDistanceIndex(distance, visited);
                visited[minIndex] = true;
                UpdateMinDistance(minIndex, distance, visited);
            }
            PrintSolution(distance);
        }

        int MinDistanceIndex(int[] distance, bool[] visited)
        {
            int min = int.MaxValue;
            int minIndex = -1;
            for (int i = 0; i < VerticeCount; i++)
            {
                if (!visited[i] && distance[i] <= min)
                {
                    min = distance[i];
                    minIndex = i;
                }
            }
            return minIndex;
        }
        void UpdateMinDistance(int minIndex, int[] distance, bool[] visited)
        {
            for (int j = 0; j < VerticeCount; j++)
            {
                if (!visited[j]
                    && Graph[minIndex, j] != 0
                    && distance[minIndex] != int.MaxValue
                    && distance[minIndex] + Graph[minIndex, j] < distance[j])
                {
                    distance[j] = distance[minIndex] + Graph[minIndex, j];
                }
            }
        }
        void PrintSolution(int[] distance)
        {
            Console.WriteLine("Vertex \t Distance from Source");
            for (int i = 0; i < VerticeCount; i++)
            {
                Console.WriteLine(i + " \t " + distance[i]);
            }
        }
    }
    public class ShortestPath
    {
        private int V; // 顶点数
        private int[,] graph; // 邻接矩阵

        public ShortestPath(int v)
        {
            V = v;
            graph = new int[v, v];
        }

        public void AddEdge(int u, int v, int weight)
        {
            graph[u, v] = weight;
        }

        public void Dijkstra(int source)
        {
            int[] distance = new int[V];
            bool[] visited = new bool[V];

            for (int i = 0; i < V; i++)
            {
                distance[i] = int.MaxValue;
                visited[i] = false;
            }

            distance[source] = 0;

            for (int count = 0; count < V - 1; count++)
            {
                int u = MinDistance(distance, visited);
                visited[u] = true;

                for (int v = 0; v < V; v++)
                {
                    if (!visited[v] && graph[u, v] != 0 && distance[u] != int.MaxValue && distance[u] + graph[u, v] < distance[v])
                    {
                        distance[v] = distance[u] + graph[u, v];
                    }
                }
            }

            PrintSolution(distance);
        }

        private int MinDistance(int[] distance, bool[] visited)
        {
            int min = int.MaxValue;
            int minIndex = -1;

            for (int v = 0; v < V; v++)
            {
                if (!visited[v] && distance[v] <= min)
                {
                    min = distance[v];
                    minIndex = v;
                }
            }

            return minIndex;
        }

        private void PrintSolution(int[] distance)
        {
            Console.WriteLine("Vertex \t Distance from Source");
            for (int i = 0; i < V; i++)
            {
                Console.WriteLine(i + " \t " + distance[i]);
            }
        }
    }
}
