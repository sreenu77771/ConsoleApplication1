using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class GraphNode
    {
        public int val;

        public List<GraphNode> neighbours;

        public GraphNode(int pVal)
        {
            this.val = pVal;
            this.neighbours  = new List<GraphNode>();
        }
    }

    class Graph1
    {
        public void BFS(GraphNode source)
        {
            Queue<GraphNode> q = new Queue<GraphNode>();
            q.Enqueue(source);
           
            Dictionary<GraphNode, bool> hm = new Dictionary<GraphNode, bool>();
            hm.Add(source, true);
            while (q.Any())
            {
                GraphNode s = q.Dequeue();
                
                Console.Write(s.val + " " + s + " ");
                foreach (GraphNode n in s.neighbours)
                {
                    if(!hm.ContainsKey(n) || hm[n] == false)
                    {
                        q.Enqueue(n);
                        hm.Add(n, true);
                    }
                }
            }
            Console.WriteLine();
        }
        public GraphNode cloneGraph(GraphNode source)
        {
            Queue<GraphNode> q = new Queue<GraphNode>();
            q.Enqueue(source);

            Dictionary<GraphNode, GraphNode> hm = new Dictionary<GraphNode, GraphNode>();
            GraphNode sourceClone = new GraphNode(source.val);
            hm.Add(source, sourceClone);
            while(q.Any())
            {
                GraphNode s = q.Dequeue();
                GraphNode sClone = hm[s];
                if(s.neighbours!= null)
                {
                    List<GraphNode> sNeighbours = s.neighbours;

                    foreach(GraphNode n in sNeighbours)
                    {
                        GraphNode nClone = null;
                        hm.TryGetValue(n, out nClone);
                        if (nClone == null)
                        {
                            q.Enqueue(n);
                            nClone = new GraphNode(n.val);
                            hm.Add(n, nClone);
                        }
                        sClone.neighbours.Add(nClone);
                    }
                }
            }
            return sourceClone;

        }



        public GraphNode buildGraph()
        {
            /*
                Note : All the edges are Undirected
                Given Graph:
                1--2
                |  |
                4--3
            */
            GraphNode node1 = new GraphNode(1);
            GraphNode node2 = new GraphNode(2);
            GraphNode node3 = new GraphNode(3);
            GraphNode node4 = new GraphNode(4);
            List<GraphNode> v = new List<GraphNode>();
            v.Add(node2);
            v.Add(node4);
            node1.neighbours = v;
            v = new List<GraphNode>();
            v.Add(node1);
            v.Add(node3);
            node2.neighbours = v;
            v = new List<GraphNode>();
            v.Add(node2);
            v.Add(node4);
            node3.neighbours = v;
            v = new List<GraphNode>();
            v.Add(node3);
            v.Add(node1);
            node4.neighbours = v;
            return node1;
        }

        public static void TestGraph()
        {
            Graph1 graph = new Graph1();
            GraphNode source = graph.buildGraph();
            Console.Write("BFS traversal of a graph before cloning");
            graph.BFS(source);
            GraphNode newSource = graph.cloneGraph(source);
            Console.Write("BFS traversal of a graph after cloning");
            graph.BFS(newSource);
        }
    }
}
