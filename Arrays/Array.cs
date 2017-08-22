using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class MyArray
    {

        public static int FindMissingNumber(int[] arr)
        {
            //check for null or empty array
            if (arr == null) return -1;
            if (arr.Length == 0) return -1;

            //sum of n numbers is (n*(n+1))/2
            int n = arr.Length;
            int sum = (n+1) * (n + 2) / 2;

            for(int i=0; i< arr.Length; i++)
            {
                sum -= arr[i];
            }

            return sum;

        }

        //O(n*n) computation , o(1) space
        public static int[] FindDuplicates(int[] arr)
        {
            List<int> duplicates = new List<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        duplicates.Add(arr[i]);
                        break;
                    }
                }
            }

            return duplicates.ToArray<int>();
        }

        //o(1) computation , o(n) space
        //consider arr contains max as n;
        public static int[] FindDuplicates1(int[] arr)
        {
            int[] countArr = new int[arr.Length+1];
            List<int> duplicates = new List<int>();
            for (int i=0; i< arr.Length;i++)
            {
                if (countArr[arr[i]] != 0)
                    duplicates.Add(arr[i]);
                else
                    countArr[arr[i]] = 1;

            }
            return duplicates.ToArray<int>();
        }

        //o(1) computation , o(1) space
        //consider arr contains max as n;
        public static int[] FindDuplicates2(int[] arr)
        {
            List<int> duplicates = new List<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[Math.Abs(arr[i])] > 0)
                    arr[Math.Abs(arr[i])] = -arr[Math.Abs(arr[i])];
                else
                    duplicates.Add(arr[i]);

            }
            return duplicates.ToArray<int>();
        }

        public static int GivenArrayReturnIndexOfAverage(int[] arr)
        {
            double sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }

            double average = Math.Round(sum / arr.Length, 2);

            //find adjacent for average in case average is not found during scan. 
            double minAfterAverage = double.MaxValue;
            int minAfterAverageIndex = -1;
            double maxBeforeAverage = double.MinValue;
            int maxBeforeAverageIndex = -1;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == average)
                    return i + 1;

                if (maxBeforeAverage < arr[i] && arr[i] < average)
                {
                    maxBeforeAverage = arr[i];
                    maxBeforeAverageIndex = i;
                }

                if (average < arr[i] && arr[i] < minAfterAverage)
                {
                    minAfterAverage = arr[i];
                    minAfterAverageIndex = i;
                }
            }

            if (Math.Abs(average - minAfterAverage) > Math.Abs(average - maxBeforeAverage))
            {
                return maxBeforeAverageIndex + 1;
            }
            else return minAfterAverageIndex + 1;

        }

        public static void InternalMain()
        {
            int[] arr = { 5, 3, 2, 0, 2 };
            Console.WriteLine(GivenArrayReturnIndexOfAverage(arr));

        }
    }
}
