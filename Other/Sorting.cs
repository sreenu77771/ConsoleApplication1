using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Sorting
    {
        public static int[] QuickSort(int[] arr)
        {
            return QuickSortPrivate(arr, 0, arr.Length - 1, arr.Length/2);
        }

        private static int[] QuickSortPrivate(int[] arr, int i, int j, int p)
        {
            if(i>=j)
            {
                return arr;
            }
            while(i<j)
            {
                while (arr[i] < arr[p])
                    i++;
                while (arr[j] > arr[p])
                    j--;
                if (arr[i] > arr[j])
                {
                    int temp = arr[j];
                    arr[j] = arr[i];
                    arr[i] = temp;
                    //i++; j--;
                }
            }

            QuickSortPrivate(arr, i, p - 1, (i+ p - 1) / 2);
            QuickSortPrivate(arr, p+1, j, (j + p+1) / 2);
            return arr;

        }
    }
}
