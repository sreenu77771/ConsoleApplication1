using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Princeton
{
    //Connected components
    public class KosarajuSharirSCC
    {
        public bool[] marked;
        public int[] connectedId;
        int connectedComponentCounter = 0;
        public KosarajuSharirSCC(Diagraph g)
        {
            marked = new bool[g.V];
            connectedId = new int[g.V];

            DepthFirstOrder depthFirstOrder = new DepthFirstOrder(g);

            foreach(int i in depthFirstOrder.reversePost())
            {
                if(!marked[i])
                {
                    dfs(g, i);
                    connectedComponentCounter++;
                }
                
            }
        }

        public void dfs(Diagraph g, int v)
        {
            marked[v] = true;
            connectedId[v] = connectedComponentCounter;
            foreach (int w in g.adj(v))
            {
                if (!marked[w])
                {                    
                    dfs(g, w);
                }
            }
        }

        public bool connected(int v, int w)
        {
            return connectedId[v] == connectedId[w];
        }

        public int count()
        {
            return connectedId.Max()+1;
        }
        //connected component identifier for vertex v 
        public int id(int v)
        {
            return connectedId[v];
        }

        public static void InternalMain()
        {
            Diagraph g = new Diagraph(@"Graph/testdata/tinyDAG.txt");
            Console.Write(g.toString());

            KosarajuSharirSCC cc = new KosarajuSharirSCC(g);
            Console.WriteLine("Number of connected components" + cc.count());
            Console.WriteLine(cc.connected(3, 7));
        }

    }
}
