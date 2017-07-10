using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class BitTest
    {
        public static void OverFlowTest()
        {
            byte a = 255;
            byte b = 255;

            byte c = (byte)(a + b);
            Console.WriteLine("Value" + c);

            checked
            {
                byte d = (byte)(a + b);
                Console.WriteLine("Value" + c);
            }

        }

        public static int ORAndXorSame(long n)
        {
            List<long> output = new List<long>();//although not required , useful for printing numbers.
            output.Add(0); //special case
            long mask = 1;

            while (mask <= n)
            {
                if (((n & mask) ^ mask) != 0)
                {
                    long len = output.Count; ;
                    for (int i = 0; i < len; i++)
                    {
                        output.Add(output[i] | mask);
                    }
                }

                mask = mask << 1;
            }

            return output.Count;
        }

        public static bool CheckIfNPowerOfTwo(ulong n)
        {
            ulong mask = 1;
            int i = 0;
            //mask <= n
            while (i < 64)
            {
                i++;
                if ((mask | n) == mask) return true;
                else mask = mask << 1;
            }
            return false;
        }
        public static ulong GetMaxPowLessThanN(ulong n)
        {
            ulong nc = n;
            int i = 0;
            while (nc > 0)
            {
                nc = nc >> 1;
                i++;
            }
            ulong mask = 1;
            while (i > 1)
            {
                mask = mask << 1;
                i--;
            }
            return mask;
        }

        public static string Test(ulong n)
        {

            if (n == 1)
            {

                return "Richard";
            }
            bool isRichard = false;
            while (n > 1)
            {
                if (CheckIfNPowerOfTwo(n))
                {
                    n = n / 2;
                }
                else
                {
                    n = n - GetMaxPowLessThanN(n);
                }

                isRichard = !isRichard;
            }

            return (isRichard ? "Louise " : "Richard");
        }

        public static Tuple<uint, uint> FindDuplicates(uint[] arr,uint maxN)
        {
            uint xor = 0;
            for(uint i=0; i<arr.Length;i++)
            {
                xor = xor ^ arr[i];
            }
            for (uint i = 1; i <= maxN; i++)
            {
                xor = xor ^ i;
            }

            // now xor contains number which sets bits that are different in x and y.
            //find the right most set bit
            uint rightSetBit = xor & (~(xor - 1));
            uint x = 0, y = 0;
            for (uint i = 0; i < arr.Length; i++)
            {
                if ((rightSetBit & arr[i]) > 0)
                    x = x ^ arr[i];
                else
                    y = y ^ arr[i];
            }
            for (uint i = 1; i <= maxN; i++)
            {
                if ((rightSetBit & i) > 0)
                    x = x ^ i;
                else
                    y = y ^ i;
            }
            return new Tuple<uint, uint>(x, y);
        }

        public static int atoi( string s)
        {
            int val = 0;
            for(int i= s.Length -1; i>=0; i--)
            {
                val += int.Parse(s[i].ToString()) * (int)Math.Pow(2, i);
            }
            return val;
        }

        public static string itoa(uint num)
        {
            StringBuilder s = new StringBuilder();
            while(num != 0)
            {
                s.Append(num % 2);
                num /= 2;
            }

            return s.ToString();
        }
    }
}
