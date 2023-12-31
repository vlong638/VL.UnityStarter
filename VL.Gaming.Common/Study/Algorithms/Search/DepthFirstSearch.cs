using System;
using System.Collections.Generic;
using System.Linq;

namespace VL.Gaming.Study.Algorithms.Search
{
    /// <summary>
    /// DFS,DepthFirstSearch
    /// 时间复杂度 θ(节点^分支数)
    /// 深度优先搜索基于一个遍历表bool[] Visited节点访问表来设计实现
    /// </summary>
    public class Sample_DepthFirstSearch
    {
        public void Search()
        {
            
            Graph g = new Graph(4);
            g.AddEdge(0, 0);//0和1有连接
            g.AddEdge(0, 2);//0和2有连接
            g.AddEdge(1, 2);//1和2有连接
            g.AddEdge(2, 0);//2和0有连接
            g.AddEdge(2, 3);//2和3有连接
            g.AddEdge(3, 3);//3和3有连接，自环

            var result = g.DFS(2);
            var depth = result.ToList().Where(c => c == true).Count();
            Console.WriteLine("DFS starting from vertex 2:");
            Console.WriteLine($"Depth:{depth}");
        }
    }

    public class Graph
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

        public bool[] DFS(int vertice)
        {
            bool[] visited = new bool[VerticeCount];
            DFSUlti(vertice, visited);
            return visited;
        }

        public void AddEdge(int vertice, int w)
        {
            AdjacencyList[vertice].Add(w);
        }

        //循环不变式
        public void DFSUlti(int vertice, bool[] visited)
        {
            visited[vertice] = true;
            foreach (var adjacency in AdjacencyList[vertice])
            {
                if (!visited[adjacency])
                {
                    DFSUlti(adjacency, visited);
                }
            }
        }
    }
}
