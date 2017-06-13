using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Graph
    {
        int noOfNodes;
        List<LinkedList<int>> adj = new List<LinkedList<int>>();

        public Graph(int numNodes)
        {
            this.noOfNodes = numNodes;
            for(int i=0; i<  numNodes; i++)
            {
                adj.Add( new LinkedList<int>());
            }
        }
        public void AddEdge(int s, int d)
        {
            LinkedList<int> temp = adj[s];
            if (!temp.Contains(d))
                temp.AddLast(d);
        }

        public void PrintBFS(int s)
        {
            // you will miss disconnected nodes from the source node.
            Queue<int> q = new Queue<int>();
            bool[] visited = new bool[this.noOfNodes];
            q.Enqueue(s);

            while(q.Any())
            {
                int temp = q.Dequeue();
                visited[temp] = true;
                Console.Write(temp + " ");
                foreach(int i in adj[temp])
                {
                    if (visited[i] == false)
                        q.Enqueue(i);
                }
            }

        }

        public void PrintDFS(int s)
        {
            // you will miss disconnected nodes from the source node.
            Stack<int> stack = new Stack<int>();
            bool[] visited = new bool[this.noOfNodes];
            stack.Push(s);

            while(stack.Any())
            {
                int temp = stack.Pop();
                visited[temp] = true;
                Console.Write(temp + " ");
                foreach (int i in adj[temp])
                {
                    if (visited[i] == false)
                        stack.Push(i);
                }
            }

        }
        public void PrintGraph()
        {
            int i = 0;
            foreach(var v in adj)
            {
                Console.Write(i++ + ": ");
                foreach(int j in v)
                {
                    Console.Write(j + " ");
                }
                Console.WriteLine();
            }
        }

        public static void TestGraph()
        {
            Graph g = new Graph(7);
            g.AddEdge(0, 1);
            g.AddEdge(0, 2);
            g.AddEdge(1, 2);
            g.AddEdge(2, 0);
            g.AddEdge(2, 3);
            g.AddEdge(3, 4);
            g.AddEdge(4, 5);
            g.AddEdge(5, 5);
            g.AddEdge(6, 6);
            g.PrintGraph();
            Console.WriteLine();
            g.PrintBFS(2);
            Console.WriteLine();
            g.PrintDFS(2);
        }
        //public void 
    } 
}
