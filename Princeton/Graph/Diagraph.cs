using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Princeton
{
    public class Diagraph
    {
        public readonly int V = 0;
        public int E = 0;

        public HashSet<int>[] bag;
        public int[] indegreeArr;

        private string NEWLINE = Environment.NewLine;

        public Diagraph(int v)
        {
            V = v;
            bag = new HashSet<int>[V];
            for (int i = 0; i < V; i++)
            {
                bag[i] = new HashSet<int>();
            }

            indegreeArr = new int[V];
        }

        //first line int - number of vertices
        //second line - number of edges
        //third and more line - Edges in line separately
        public Diagraph(string fileName)
        {
            try
            {
                string[] lines = File.ReadAllLines(fileName);
                this.V = Int32.Parse(lines[0]);

                bag = new HashSet<int>[V];
                for (int i = 0; i < V; i++)
                {
                    bag[i] = new HashSet<int>();
                }

                indegreeArr = new int[V];


                for (int i = 2; i < lines.Length; i++)
                {
                    string[] tokens = lines[i].Split(' ');
                    int v = Int32.Parse(tokens[0]);
                    int w = Int32.Parse(tokens[1]);

                    this.addEdge(v, w);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

        }

        public void addEdge(int v, int w)
        {
            validateVertex(v);
            validateVertex(w);
            this.bag[v].Add(w);
            //this.bag[w].Add(v);
            this.indegreeArr[w]++;
            E++;
        }

        public IEnumerable<int> adj(int v)
        {
            validateVertex(v);
            return this.bag[v];
        }
        public int outdegree(int v)
        {
            validateVertex(v);
            return this.bag[v].Count;

        }

        public int indegree(int v)
        {
            validateVertex(v);
            return this.indegreeArr[v];

        }

        public Diagraph reverse()
        {
            Diagraph reverseDiagraph = new Diagraph(this.V);

            int index = 0;
            foreach(var list in bag)
            {                
                foreach( int i in list)
                {
                    reverseDiagraph.addEdge(i, index);
                }
                index++;
            }

            return reverseDiagraph;
        }
        public String toString()
        {
            StringBuilder s = new StringBuilder();
            s.Append(V + " vertices, " + E + " edges " + NEWLINE);
            for (int v = 0; v < V; v++)
            {
                s.Append(v + ": ");
                foreach (int w in adj(v))
                {
                    s.Append(w + " ");
                }
                s.Append(NEWLINE);
            }
            s.Append("************************************");
            s.Append(NEWLINE);
            return s.ToString();
        }
        private void validateVertex(int v)
        {
            if (v < 0 || v >= V)
                throw new ArgumentException("vertex " + v + " is not between 0 and " + (V - 1));
        }

        public Graph Clone()
        {
            Graph g = new Graph(this.V);
            int i = 0;
            foreach (var b in bag)
            {
                if (i >= V)
                {
                    throw new InvalidOperationException("DDD");
                }
                foreach (int n in b)
                {
                    g.addEdge(i, n);
                }
                i++;
            }

            g.E = g.E / 2;
            return g;
        }

        public void Compare(Graph g1, Graph g2)
        {

        }

        public static void InternalMain()
        {
            Diagraph g = new Diagraph(@"Graph/testdata/tinyDG.txt");
            Console.Write(g.toString());

            //Graph g1 = g.Clone();
            //Console.Write(g1.toString());
        }
    }
}
