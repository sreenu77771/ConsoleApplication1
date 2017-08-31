using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StdLib;
namespace Princeton
{
    class WeightedQuickUnionPathCompressionUF
    {
        private readonly int[] id;
        private readonly int[] sz;

        /// <summary>
        /// Return the number of connected components
        /// </summary>
        public int Count { get; private set; }

        public WeightedQuickUnionPathCompressionUF(int N)
        {
            Count = N;
            id = new int[N];
            sz = new int[N];
            for (int i = 0; i < N; i++)
            {
                id[i] = i;
            }
        }

        public int Find(int p)
        {
            while (id[p] == p) p = id[p];
            return p;
        }

        public bool Connected(int p, int q)
        {
            return Find(p) == Find(q);
        }

        public void Union(int p, int q)
        {
            p = Find(p);
            q = Find(q);
            if (p == q) return;

            //checksize and union
            if (sz[p] >= sz[q])
            {
                id[q] = p;
                sz[p] += sz[q];
            }
            else
            {
                id[p] = q;
                sz[q] += sz[p];
            }
            Count--;
        }
    }

    public class WeightedQuickUnionPathCompressionUFExample
    {
        public static void Main(string[] args)
        {
            int N = StdIn.ReadInt();

            WeightedQuickUnionPathCompressionUF uf = new WeightedQuickUnionPathCompressionUF(N);

            // read in a sequence of pairs of integers (each in the range 0 to N-1),
            // calling find() for each pair: If the members of the pair are not already
            // call union() and print the pair.
            while (!StdIn.IsEmpty())
            {
                int p = StdIn.ReadInt();
                int q = StdIn.ReadInt();

                if (uf.Connected(p, q)) continue;
                uf.Union(p, q);

                Console.WriteLine(p + " " + q);
            }

            Console.WriteLine(uf.Count + " components");
        }
    }
}
