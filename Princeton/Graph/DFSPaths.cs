using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Princeton
{
    public class DFSPaths
    {
        public bool[] marked;
        public int[] edgeTo;
        public int S;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="s">Source</param>
        public DFSPaths(Graph g, int s)
        {
            marked = new bool[g.V];
            edgeTo = new int[g.V];
            this.S = s;

            dfs(g, s);
        }

        public void dfs(Graph g, int v)
        {
            marked[v] = true;
            foreach (int w in g.adj(v))
            {
                if (!marked[w])
                {
                    edgeTo[w] = v;
                    dfs(g, w);
                }
            }
        }

        public bool hasPathTo(int v)
        {
            return marked[v];
        }

        public IEnumerable<int> pathTo(int v)
        {
            if (!hasPathTo(v))
                return null;
            Stack<int> s = new Stack<int>();
            
            for (int i= v; i != S; i = edgeTo[i] )
            {
                s.Push(i);
            }
            s.Push(S);
            return s;
        }

        public static void InternalMain()
        {
            Graph g = new Graph(@"Graph/TinyG.txt");
            Console.Write(g.toString());

            DFSPaths dfsPths = new DFSPaths(g, 0);
            Console.WriteLine(dfsPths.hasPathTo(7));
            Console.WriteLine(dfsPths.hasPathTo(3));
            Console.WriteLine(Graph.PrintFormat(dfsPths.pathTo(3)));
            Console.WriteLine(Graph.PrintFormat(dfsPths.pathTo(6)));
            Console.WriteLine(Graph.PrintFormat(dfsPths.pathTo(2)));
        }

        
    }
}
