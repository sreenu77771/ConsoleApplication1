using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Princeton
{
    //reverse post order of DFS ( application precendence finding, priorities etc)
    public class Topological
    {
        private IEnumerable<int> order;
        private int[] rankArr;

        public Topological(Diagraph G)
        {
            DirectedCycle finder = new DirectedCycle(G);
            if (!finder.hasCycle())
            {
                DepthFirstOrder dfs = new DepthFirstOrder(G);
                order = dfs.reversePost();
                rankArr = new int[G.V];
                int i = 0;
                foreach (int v in order)
                    rankArr[v] = i++;
            }
        }

        public IEnumerable<int> GetOrder()
        {
            return order;
        }

        public bool hasOrder()
        {
            return order != null;
        }

        public int rank(int v)
        {
            if (hasOrder()) return rankArr[v];
            else return -1;

        }


        public static void InternalMain()
        {
            Diagraph g = new Diagraph(@"Graph/testdata/TinyDAG.txt");
            Console.Write(g.toString());

            Topological t = new Topological(g);
            Console.WriteLine(Graph.PrintFormat(t.GetOrder()));
        }
    }
}
