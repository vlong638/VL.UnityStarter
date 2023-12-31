using System;
using System.Collections.Generic;
using System.Linq;

namespace VL.Gaming.Study.Algorithms.Search
{
    /// <summary>
    /// BFS,BepthFirstSearch
    /// 时间复杂度 θ(节点^分支数)
    /// 深度优先搜索基于一个遍历表bool[] Visited节点访问表来设计实现
    /// </summary>
    public class Sample_BreadthFirstSearch
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
            var result = g.BFS(0);
            var depth = result.ToList().Where(c => c == true).Count();
            Console.WriteLine("BFS starting from vertex 2:");
            Console.WriteLine($"Depth:{depth}");
        }
    }

    public partial class Graph
    {
        public bool[] BFS(int vertice)
        {
            bool[] visited = new bool[VerticeCount];
            Queue<int> queue = new Queue<int>();
            visited[vertice] = true; Console.WriteLine($"visited {vertice}");
            queue.Enqueue(vertice);
            while (queue.Count!=0)
            {
                var v = queue.Dequeue();
                foreach (var a in AdjacencyList[v])
                {
                    if (!visited[a])
                    {
                        visited[a] = true; Console.WriteLine($"visited {a}");
                        queue.Enqueue(a);
                    }
                }
            }
            return visited;
        }
        //循环不变式
        public void BFSUlti(int vertice, bool[] visited)
        {
            List<int> tempAdjcency = new List<int>();
            foreach (var adjacency in AdjacencyList[vertice])
            {
                if (!visited[adjacency])
                {
                    tempAdjcency.Add(adjacency);
                    visited[adjacency] = true;
                    Console.WriteLine($"visited {adjacency}");
                }
            }
            foreach (var adjcency in tempAdjcency)
            {
                BFSUlti(adjcency, visited);
            }
        }
    }
}
