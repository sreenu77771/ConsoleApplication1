using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Princeton
{
    class MinHeap<T> where T : IComparable<T>
    {
        private T[] pq;
        private int N;
        public MinHeap(int capacity)
        {
            //use of extra 1 slot for ease of pointer movement.
            pq = new T[capacity + 1];
        }

        public bool isEmpty()
        {
            return N == 0;
        }
        public void insert(T key)
        {
            pq[++N] = key;
            swim(N);
        }
        public T min()
        {
           return pq[1];
        }


        public T DelMin()
        {
            exch(1, N);
            T min = pq[N];
            N--;
            sink(1);
            return min;
        }

        private void swim(int k)
        {
            while (k / 2 != 0)
            {
                if (less(k, k / 2))
                {
                    exch(k, k / 2);
                    k = k / 2;
                }
                else break;
            }
        }

        private void sink(int k)
        {
            while(k*2 <= N)
            {
                int j = 2 * k;
                if(j< N && !less(j, j+1))
                {
                    j++;
                }

                if (!less(k, j))
                {
                    exch(k, j);
                    k = 2 * k;
                }
                else
                    break;
            }
        }

        private bool less(int i, int j)
        { return pq[i].CompareTo(pq[j]) < 0; }

        private void exch(int i, int j)
        { T t = pq[i]; pq[i] = pq[j]; pq[j] = t; }

        public static void InternalMain()
        {
            MinHeap<int> h = new MinHeap<int>(7);
            h.insert(7);
            h.insert(6);
            h.insert(8);
            h.insert(9);
            h.insert(5);
            h.insert(4);
            h.insert(10);

            Console.WriteLine(h.DelMin());
            Console.WriteLine(h.DelMin());
            Console.WriteLine(h.DelMin());
            Console.WriteLine(h.DelMin());
            Console.WriteLine(h.DelMin());
            Console.WriteLine(h.DelMin());
            Console.WriteLine(h.DelMin());
            Console.Read();
        }
    }
}
