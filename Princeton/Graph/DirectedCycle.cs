using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Princeton
{
    public class DirectedCycle
    {
        public bool[] marked;
        public int[] edgeTo;
        public bool[] onStack;
        public Stack<int> cycle;

        public DirectedCycle(Diagraph g)
        {
            marked = new bool[g.V];
            edgeTo = new int[g.V];
            onStack = new bool[g.V];

            for (int i = 0; i < g.V; i++)
            {
                if (!marked[i] && cycle == null)
                {
                    dfs(g, i);
                }
            }
        }

        public void dfs(Diagraph g, int v)
        {
            marked[v] = true;
            onStack[v] = true;
            foreach (int w in g.adj(v))
            {
                if (cycle != null)
                    return;

                if (!marked[w])
                {
                    edgeTo[w] = v;
                    dfs(g, w);
                }
                else if(onStack[w])
                {
                    //we have cycle
                    cycle = new Stack<int>();
                    int i = v;
                    for(;i != w; i=edgeTo[i])
                    {
                        cycle.Push(i);
                    }
                    cycle.Push(w);
                    cycle.Push(v);
                    return;
                }
            }

            onStack[v] = false;
        }

        public bool hasCycle()
        {
            return cycle != null;
        }

        public IEnumerable<int> Cycle()
        {
            return cycle;
        }

        public static void InternalMain()
        {
            Diagraph g = new Diagraph(@"Graph/tinyDG.txt");
            Console.Write(g.toString());

            DirectedCycle dc = new DirectedCycle(g);            
            Console.WriteLine(dc.hasCycle());
            Console.WriteLine(Graph.PrintFormat(dc.Cycle()));
        }
    }
}
