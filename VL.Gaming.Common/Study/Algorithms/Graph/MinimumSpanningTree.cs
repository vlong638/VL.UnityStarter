using System;

namespace VL.Gaming.Study.Algorithms.Graph
{
    /// <summary>
    /// MinimumSpanningTree,最小生成树算法
    /// 有： Prim's algorithm, Kruskal's algorithm
    /// 时间复杂度 ？？？
    /// </summary>
    public class Sample_MinimumSpanningTree
    {
        public void Process()
        {
            MinimumSpanningTree mst = new MinimumSpanningTree(5);
            mst.AddEdge(0, 1, 2);
            mst.AddEdge(0, 3, 6);
            mst.AddEdge(1, 2, 3);
            mst.AddEdge(1, 3, 8);
            mst.AddEdge(1, 4, 5);
            mst.AddEdge(2, 4, 7);
            mst.AddEdge(3, 4, 9);

            mst.PrimMST();
        }
    }
    public class MinimumSpanningTree
    {
        private int V; // 顶点数
        private int[,] graph; // 邻接矩阵

        public MinimumSpanningTree(int v)
        {
            V = v;
            graph = new int[v, v];
        }

        public void AddEdge(int u, int v, int weight)
        {
            graph[u, v] = weight;
            graph[v, u] = weight; // 如果是有向图则不需要这一行
        }

        private int MinKey(int[] key, bool[] mstSet)
        {
            int min = int.MaxValue;
            int minIndex = -1;

            for (int v = 0; v < V; v++)
            {
                if (!mstSet[v] && key[v] < min)
                {
                    min = key[v];
                    minIndex = v;
                }
            }

            return minIndex;
        }

        public void PrimMST()
        {
            int[] parent = new int[V];
            int[] key = new int[V];
            bool[] mstSet = new bool[V];

            for (int i = 0; i < V; i++)
            {
                key[i] = int.MaxValue;
                mstSet[i] = false;
            }

            key[0] = 0;
            parent[0] = -1;

            for (int count = 0; count < V - 1; count++)
            {
                int u = MinKey(key, mstSet);
                mstSet[u] = true;

                for (int v = 0; v < V; v++)
                {
                    if (graph[u, v] != 0 && !mstSet[v] && graph[u, v] < key[v])
                    {
                        parent[v] = u;
                        key[v] = graph[u, v];
                    }
                }
            }

            PrintMST(parent);
        }

        private void PrintMST(int[] parent)
        {
            Console.WriteLine("Edge \t Weight");
            for (int i = 1; i < V; i++)
            {
                Console.WriteLine(parent[i] + " - " + i + "\t" + graph[i, parent[i]]);
            }
        }
    }
}
