using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Princeton
{
    //Connected components
    public class CC
    {
        public bool[] marked;
        public int[] connectedId;
        int connectedComponentCounter = 0;
        public CC(Graph g)
        {
            marked = new bool[g.V];
            connectedId = new int[g.V];

            for(int i=0; i< g.V; i++)
            {
                if(!marked[i])
                {
                    dfs(g, i);
                    connectedComponentCounter++;
                }
                
            }
        }

        public void dfs(Graph g, int v)
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
            Graph g = new Graph(@"Graph/testdata/TinyG.txt");
            Console.Write(g.toString());

            CC cc = new CC(g);
            Console.WriteLine("Number of connected components" + cc.count());
            Console.WriteLine(cc.connected(3,0));
            Console.WriteLine(cc.connected(3, 7));
            Console.WriteLine(cc.id(7));
        }

    }
}
