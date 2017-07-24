using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Princeton.Sorting
{
    class MySort
    {
        public void SelectionSort(int[] arr)
        {
            for(int i=0; i< arr.Length; i++)
            {
                int min = i;
                for(int j=i+1; j<arr.Length; j++)
                {
                    if (less(arr[j], arr[min])) min = j;
                }

                exch(ref arr[i], ref arr[min]);
            }
        }

        public void InsertionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {                
                for (int j = i;  j >0;  j--)
                {
                    if (less(arr[j], arr[j - 1]))
                        exch(ref arr[j], ref arr[j-1]);
                    else
                        break;
                }
                
            }
        }

        public void ShellSort(int[] arr)
        {
            //starting h 
            int h = 1;
            int N = arr.Length;
            while (h < N / 3) h = 3 * h + 1;

            while (h >= 1)
            {
                for (int i = h; i < arr.Length; i++)
                {
                    for (int j = i; j-h >= 0; j = j - h)
                    {
                        if (less(arr[j], arr[j - h]))
                            exch(ref arr[j], ref arr[j - h]);
                        else
                            break;
                    }
                }
                h = h / 3;
            }
        }

        public void QuickSort(int[] arr)
        {
        }
        public void MergeSort(int[] arr, int[] aux, int lo, int hi)
        {
            if (lo >= hi) return;
            int mid = lo + (hi - lo) / 2;
            MergeSort(arr, aux, lo, mid);
            MergeSort(arr, aux, mid + 1, hi);
            Merge(arr, aux, lo, hi);
        }

        private void Merge(int[] arr, int[] aux, int lo, int hi)
        {
           int mid = lo + (hi - lo) / 2;

            for (int i = lo; i <= hi; i++)
            {
                aux[i] = arr[i];
            }

            int j = lo;
            int k = mid + 1;

            for (int i = lo; i <= hi; i++)
            {
                if (j > mid) arr[i++] = aux[k++];
                else if(k> hi) arr[i++] = aux[j++];
                else if (less(arr[j], arr[k])) arr[i++] = aux[j++];
                else arr[i++] = aux[k++];
            }
        }



        #region Optimized merge without extra copy 
        public void MergeSort1(int[] arr, int[] aux, int lo, int hi)
        {
            if (lo >= hi) return;
            int mid = lo + (hi - lo) / 2;
            MergeSort1(aux, arr, lo, mid);
            MergeSort1(aux, arr, mid + 1, hi);
            Merge1(arr, aux, lo, hi);
        }

        private void Merge1(int[] arr, int[] aux, int lo, int hi)
        {
            int mid = lo + (hi - lo) / 2;
          
            int j = lo;
            int k = mid + 1;

            for (int i = lo; i <= hi; i++)
            {
                if (j > mid) aux[i++] = arr[k++];
                else if (k > hi) aux[i++] = arr[j++];
                else if (less(arr[j], arr[k])) aux[i++] = arr[j++];
                else aux[i++] = arr[k++];
            }
        } 
        #endregion

        private static bool less(int item1, int item2)
        {
            return item1.CompareTo(item2) < 0;
        }

        private static void exch(ref int item1, ref int item2)
        {
            int temp = item1;
            item1 = item2;
            item2 = temp;
        }

        private static bool IsSorted(int[] a)
        {
            for(int i= 1; i<a.Length; i++)
            {
                if (!less(a[i-1], a[i])) return false;
            }
            return true;
        }
    }
}
