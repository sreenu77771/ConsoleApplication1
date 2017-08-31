using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StdLib;
namespace Princeton
{
    class QuickFindUF
    {
        private readonly int[] id;

        /// <summary>
        /// Return the number of connected components
        /// </summary>
        public int Count { get; private set; }

        public QuickFindUF(int N)
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
            return id[p];
        }

        public bool Connected(int p, int q)
        {
            return id[p] == id[q];
        }

        public void Union(int p, int q)
        {
            if(!Connected(p, q))
            {
                for (int i = 0; i < Count; i++)
                {
                    if (id[i] == id[p]) id[i] = id[q];
                }

                Count--;
            } 
        }
    }

    public class QuickFindUFExample
    {
        public static void Main(string[] args)
        {
            int N = StdIn.ReadInt();

            QuickFindUF uf = new QuickFindUF(N);

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

            Console.Write(uf.Count + " components");
        }
    }
}
