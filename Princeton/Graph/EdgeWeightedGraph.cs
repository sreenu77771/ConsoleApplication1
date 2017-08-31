using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Princeton
{
    public class EdgeWeightedGraph
    {
        public readonly int V = 0;
        public int E = 0;

        public HashSet<Edge>[] bag;

        private string NEWLINE = Environment.NewLine;

        public EdgeWeightedGraph(int v)
        {
            V = v;
            bag = new HashSet<Edge>[V];
            for (int i = 0; i < V; i++)
            {
                bag[i] = new HashSet<Edge>();
            }
        }

        //first line int - number of vertices
        //second line - number of edges
        //third and more line - Edges in line separately
        public EdgeWeightedGraph(string fileName)
        {
            try
            {
                string[] lines = File.ReadAllLines(fileName);
                this.V = Int32.Parse(lines[0]);

                bag = new HashSet<Edge>[V];
                for (int i = 0; i < V; i++)
                {
                    bag[i] = new HashSet<Edge>();
                }
                for (int i = 2; i < lines.Length; i++)
                {
                    string[] tokens = lines[i].Split(' ');
                    int v = Int32.Parse(tokens[0]);
                    int w = Int32.Parse(tokens[1]);
                    int weight = Int32.Parse(tokens[2]);

                    this.addEdge(new Edge(v, w, weight));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

        }

        public void addEdge(Edge e)
        {
            int v = e.either();
            int w = e.other(v);
            validateVertex(v);
            validateVertex(w);
            this.bag[v].Add(e);
            this.bag[w].Add(e);
            E++;
        }

        public IEnumerable<Edge> adj(int v)
        {
            validateVertex(v);
            return this.bag[v];
        }

        private void validateVertex(int v)
        {
            if (v < 0 || v >= V)
                throw new ArgumentException("vertex " + v + " is not between 0 and " + (V - 1));
        }
    }
}
