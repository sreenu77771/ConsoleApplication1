using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Fibonacci
    {

        public static int FindFibonacci(int n)
        {
            //fib(0) = 1;
            //fib(1) = 1;

            int prev = 0;
            int current = 1;
            int next = 0;

            int counter = 2;

            while (counter <= n)
            {
                next = prev + current;
                prev = current;
                current = next;
                counter++;
            }

            return next;
        }

        public static void InternalMain()
        {
            Console.WriteLine(FindFibonacci(9));
        }
    }
}
