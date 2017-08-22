using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Princeton
{
    public class BFSPaths
    {
        public bool[] marked;
        public int[] edgeTo;
        public int[] distTo; // to keep level

        /// <summary>
        /// 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="s">Source</param>
        public BFSPaths(Graph g, int s)
        {
            marked = new bool[g.V];
            edgeTo = new int[g.V];
            distTo = new int[g.V];

            bfs(g, s);
        }

        public BFSPaths(Graph g, IEnumerable<int> sources)
        {
            marked = new bool[g.V];
            edgeTo = new int[g.V];
            distTo = new int[g.V];

            bfs(g, sources);
        }


        private void bfs(Graph g, int s)
        {
            Queue<int> q = new Queue<int>();
            for (int v = 0; v < g.V; v++)
                distTo[v] = Int32.MaxValue;

            distTo[s] = 0;
            marked[s] = true;
            q.Enqueue(s);


            while (q.Count != 0)
            {
                int v = q.Dequeue();

                foreach (var i in g.adj(v))
                {
                    if (!marked[i])
                    {
                        edgeTo[i] = v;
                        distTo[i] = distTo[v] + 1;
                        marked[i] = true;
                        q.Enqueue(i);
                    }
                }
            }
        }

        private void bfs(Graph g, IEnumerable<int> sources)
        {
            Queue<int> q = new Queue<int>();
            for (int v = 0; v < g.V; v++)
                distTo[v] = Int32.MaxValue;

            foreach (int s in sources)
            {
                distTo[s] = 0;
                marked[s] = true;
                q.Enqueue(s);
            }

            while (q.Count != 0)
            {
                int v = q.Dequeue();

                foreach (var i in g.adj(v))
                {
                    if (!marked[i])
                    {
                        edgeTo[i] = v;
                        distTo[i] = distTo[v] + 1;
                        marked[i] = true;
                        q.Enqueue(i);
                    }
                }
            }
        }
        public bool hasPathTo(int v)
        {
            validateVertex(v);
            return marked[v];
        }

        public int distanceTo(int v)
        {
            validateVertex(v);
            return distTo[v];
        }

        public IEnumerable<int> pathTo(int v)
        {
            validateVertex(v);
            if (!hasPathTo(v)) return null;

            Stack<int> stack = new Stack<int>();
            int i = v;
            for (; distTo[i]!=0; i=edgeTo[i])
            {
                stack.Push(i);
            }
            stack.Push(i);

            return stack;
        }
        private void validateVertex(int v)
        {
            int V = marked.Length;
            if (v < 0 || v >= V)
                throw new ArgumentException("vertex " + v + " is not between 0 and " + (V - 1));
        }

        // throw an IllegalArgumentException unless {@code 0 <= v < V}
        private void validateVertices(IEnumerable<int> vertices)
        {
            if (vertices == null)
            {
                throw new ArgumentException("argument is null");
            }
            int V = marked.Length;
            foreach (int v in vertices)
            {
                if (v < 0 || v >= V)
                {
                    throw new ArgumentException("vertex " + v + " is not between 0 and " + (V - 1));
                }
            }
        }

        public static void InternalMain()
        {
            Graph g = new Graph(@"Graph/TinyG.txt");
            Console.Write(g.toString());

            BFSPaths bfsPths = new BFSPaths(g, 0);
            Console.WriteLine(bfsPths.hasPathTo(7));
            Console.WriteLine(bfsPths.hasPathTo(3));
            Console.WriteLine(Graph.PrintFormat(bfsPths.pathTo(3)));
            Console.WriteLine(Graph.PrintFormat(bfsPths.pathTo(4)));
            Console.WriteLine(Graph.PrintFormat(bfsPths.pathTo(2)));
        }

    }
}
