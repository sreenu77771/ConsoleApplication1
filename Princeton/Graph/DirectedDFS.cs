using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Princeton
{
    public class DirectedDFS
    {
        public bool[] marked;
        public int[] edgeTo;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="s">Source</param>
        public DirectedDFS(Diagraph g, int s)
        {
            marked = new bool[g.V];
            edgeTo = new int[g.V];

            marked[s] = true;
            edgeTo[s] = s;
            dfs(g, s);
        }

        public void dfs(Diagraph g, int v)
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

        public DirectedDFS(Diagraph g, IEnumerable<int> sources)
        {
            marked = new bool[g.V];
            edgeTo = new int[g.V];

            foreach(var i in sources)
            {
                if (!marked[i])
                {
                    dfs(g, i);
                }
            }
            
        }


        //marked or connected
        public bool hasPathTo(int v)
        {
            return marked[v];
        }

        public IEnumerable<int> pathTo(int v)
        {
            if (!hasPathTo(v))
                return null;
            Stack<int> s = new Stack<int>();

            int i = v;
            for (; i != edgeTo[i]; i = edgeTo[i] )
            {
                s.Push(i);
            }
            s.Push(i);
            return s;
        }

        public static void InternalMain()
        {
            Diagraph g = new Diagraph(@"Graph/testdata/TinyDG.txt");
            Console.Write(g.toString());

            DirectedDFS dfsPths = new DirectedDFS(g, 6);
            Console.WriteLine(dfsPths.hasPathTo(3));
            Console.WriteLine(dfsPths.hasPathTo(1));
            Console.WriteLine(dfsPths.hasPathTo(7));
            Console.WriteLine(Graph.PrintFormat(dfsPths.pathTo(3)));
        }

        
    }
}
