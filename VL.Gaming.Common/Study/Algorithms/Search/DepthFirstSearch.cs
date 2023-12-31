using System;
using System.Collections.Generic;
using System.Linq;

namespace VL.Gaming.Study.Algorithms.Search
{
    /// <summary>
    /// DFS,DepthFirstSearch
    /// 时间复杂度 θ(节点^分支数)
    /// 深度优先搜索基于一个遍历表bool[] Visited节点访问表来设计实现
    /// 基于对每一个节点的递归处理而实现
    /// 每一个节点处理自身并递归处理下级节点
    /// </summary>
    public class Sample_DepthFirstSearch
    {
        public void Search()
        {
            
            Graph g = new Graph(6);
            g.AddEdge(0, 1);
            g.AddEdge(0, 2);
            g.AddEdge(1, 3);
            g.AddEdge(1, 4);
            g.AddEdge(2, 5);
            ///    0
            /// 1    2
            ///3 4  5
            var result = g.DFS(0);
            var depth = result.ToList().Where(c => c == true).Count();
            Console.WriteLine("DFS starting from vertex 2:");
            Console.WriteLine($"Depth:{depth}");
        }
    }

    public partial class Graph
    {
        public bool[] DFS(int vertice)
        {
            bool[] visited = new bool[VerticeCount];
            DFSUlti(vertice, visited);
            return visited;
        }

        //循环不变式
        public void DFSUlti(int vertice, bool[] visited)
        {
            visited[vertice] = true; Console.WriteLine($"visited {vertice}");
            foreach (var adjacency in AdjacencyList[vertice])
            {
                if (!visited[adjacency])
                {
                    DFSUlti(adjacency, visited);
                }
            }
        }
    }
    public partial class Graph
    {
        public int VerticeCount;//顶点数量
        public List<int>[] AdjacencyList;//邻接表

        public Graph(int verticeCount)
        {
            VerticeCount = verticeCount;
            AdjacencyList= new List<int>[VerticeCount];
            for (int i = 0; i < verticeCount; i++)
            {
                AdjacencyList[i] = new List<int>();
            }
        }

        public void AddEdge(int startVertice, int endVertice)
        {
            AdjacencyList[startVertice].Add(endVertice);
        }
    }
}
