using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Princeton
{
    public class MST
    {
        public MST(EdgeWeightedGraph e)
        {

        }

        public IEnumerable<Edge> edges()
        {
            return null;
        }

        public double Weight()
        {
            return 0.0;
        }

        public static void InternalMain()
        {
            EdgeWeightedGraph g = new EdgeWeightedGraph(@"Graph/testdata/TinyEWG.txt");
            Console.Write(g.ToString());

            MST mst = new MST(g);
            //Console.WriteLine(bfsPths.hasPathTo(3));
            //Console.WriteLine(bfsPths.hasPathTo(1));
            //Console.WriteLine(bfsPths.hasPathTo(7));
            //Console.WriteLine(Graph.PrintFormat(bfsPths.pathTo(3)));
        }
    }
}
