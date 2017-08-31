using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StdLib;
namespace Princeton
{
    class QuickUnionPathCompressionUF
    {
        private readonly int[] id;

        /// <summary>
        /// Return the number of connected components
        /// </summary>
        public int Count { get; private set; }

        public QuickUnionPathCompressionUF(int N)
        {
            Count = N;
            id = new int[N];
            for (int i = 0; i < N; i++)
            {
                id[i] = i;
            }
        }

        public int Find(int p)
        {
            while (id[p] != p)
            {
                id[p] = id[id[p]];
                p = id[p];
            }
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
            id[p] = q;
            Count--;
        }
    }

    public class QuickUnionPathCompressionUFExample
    {
        public static void Main(string[] args)
        {
            int N = StdIn.ReadInt();

            QuickUnionPathCompressionUF uf = new QuickUnionPathCompressionUF(N);

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
