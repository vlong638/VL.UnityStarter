using System;
using System.Collections.Generic;
using System.Linq;

namespace VL.Gaming.Study.Algorithms.Search
{
    /// <summary>
    /// BFS,BepthFirstSearch
    /// 时间复杂度 θ(节点^分支数)
    /// 广度优先基于队列实现
    /// 循环队列总是当前层的链接节点检索，将检索结果丢到Queue队列中
    /// 由于每一个下层的处理层级更低，处在下一级的处理循环中，所以他们进入队列的顺序也就靠后
    /// 从而实现了深度优先的搜索，这也说明了深度优先与队列结构的设计上的贴合结构
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
            ///    49
            ///    
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
    }
}
