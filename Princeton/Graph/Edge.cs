using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Princeton
{
    public class Edge : IComparable<Edge>
    {
        public readonly int V;
        public readonly int W;
        public readonly double Weight;
        public Edge(int v, int w, double weight)
        {
            this.V = v;
            this.W = w;
            this.Weight = weight;
        }
        public int CompareTo(Edge other)
        {
            if (this.Weight > other.Weight)
                return 1;
            else if (this.Weight < other.Weight)
                return -1;
            else
                return 0;
        }

        public int either()
        {
            return this.V;
        }

        public int other(int v)
        {
            if (v == this.V)
                return this.W;
            else
                return this.V;
        }

        public override string ToString()
        {
            return ($"V: {V} W: {W} Weight: {Weight}");
        }
    }
}
