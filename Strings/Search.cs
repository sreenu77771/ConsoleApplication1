using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Search
    {
        public static int FindValOrNextSmallest(int[] arr, int find)
        {
            if (arr == null || arr.Length == 0) return -1;
            return FindValOrNextSmallestInternal(arr, find, 0, arr.Length - 1);
        }



        private static int FindValOrNextSmallestInternal(int[] arr, int find, int low, int high)
        {
            if (low > high)
            {
                //return low - 1;
                //find the closet to find number
                if (low == 0) return -1;
                if (Math.Abs(arr[low] - find) > Math.Abs(arr[high] - find))
                    return high;
                else return low;
            }                
            int mid = (low + high) / 2;
            if (arr[mid] == find) return mid;
            else if (find > arr[mid])
                return FindValOrNextSmallestInternal(arr, find, mid + 1, high);
            else
                return FindValOrNextSmallestInternal(arr, find, low, mid-1);
        }

        private static int FindValOrNextSmallestITerative(int[] arr, int find, int low, int high)
        {
            while (true)
            {
                if (low > high)
                    return low - 1;
                int mid = (low + high) / 2;
                if (arr[mid] == find) return mid;
                else if (find > arr[mid])
                {
                    low = mid + 1; 
                }                    
                else
                {
                    high = mid - 1;
                }                   
            }
        }

        public static int CountNumberOfOccurrencesInSortedArray(int[] arr, int find)
        {
            if (arr == null || arr.Length == 0) return -1;
            int begin = FindFirstOccurrence(arr, 0, arr.Length - 1, find);
            int last = begin;
            if (begin != -1)
            {
                last = FindLastOccurrence(arr, begin, arr.Length - 1, find);
                return last - begin + 1;
            }
            return -1;
        }

        private static int FindFirstOccurrence(int[] arr, int begin, int end, int find)
        {
            if (begin > end) return -1;
            int mid = (begin + end) / 2;
            if ((mid == 0 && arr[mid] == find) || ((arr[mid - 1] < find) && (arr[mid] == find))) return mid;
            else if(arr[mid] >= find)
            {
                return FindFirstOccurrence(arr, 0, mid - 1, find);
            }
            else
                return FindFirstOccurrence(arr, mid+1, end, find);
        }

        private static int FindLastOccurrence(int[] arr, int begin, int end, int find)
        {
            if (begin > end) return -1;
            int mid = (begin + end) / 2;
            if ((mid == arr.Length-1 && arr[mid] == find) || ((arr[mid + 1] > find) && arr[mid] == find)) return mid;
            else if (arr[mid] > find)
            {
                return FindLastOccurrence(arr, 0, mid - 1, find);
            }
            else
                return FindLastOccurrence(arr, mid + 1, end, find);
        }

        public static int CountNumberOfOccurrencesInSortedArrayLinear(int[] arr, int find)
        {
            if (arr == null || arr.Length == 0) return -1;
            int findIndex = BinarySearch(arr, 0, arr.Length - 1, find);
            if (findIndex == -1) return -1;
            int leftCount = 1;            
            while((findIndex -leftCount >= 0) && (arr[findIndex - leftCount] == find))
            {
                leftCount++;
            }
            int rightCount = 1;
            while(((findIndex + rightCount) < arr.Length) && (arr[findIndex+ rightCount] == find))
            {
                rightCount++;
            }
            return ((leftCount - 1) + (rightCount - 1) + 1);
        }

        public static int RotateArrayPivot(int[] arr, int begin, int end)
        {
            if (arr == null || arr.Length == 0) return -1;
            if (end < begin) return -1;
            if (begin == end) return begin;
            int mid = (begin + end) / 2;
            if ((mid < end) && (arr[mid] > arr[mid + 1])) return mid;
            if ((mid > begin) && (arr[mid - 1] > arr[mid])) return mid - 1;
            if(arr[mid] <= arr[begin])
            {
                return RotateArrayPivot(arr, begin, mid - 1);
            }
            return RotateArrayPivot(arr, mid+1, end);
        }

        public static int findPivot(int[] arr, int low, int high)
        {
            // base cases
            if (high < low) return -1;
            if (high == low) return low;

            int mid = (low + high) / 2;   /*low + (high - low)/2;*/
            if (mid < high && arr[mid] > arr[mid + 1])
                return mid;
            if (mid > low && arr[mid] < arr[mid - 1])
                return (mid - 1);
            if (arr[low] >= arr[mid])
                return findPivot(arr, low, mid - 1);
            return findPivot(arr, mid + 1, high);
        }
        private static int BinarySearch(int[] arr, int begin, int end, int find)
        {
            if (begin > end) return -1;
            int mid = (begin + end) / 2;
            if (arr[mid] == find) return mid;
            else if (arr[mid] < find)
                return BinarySearch(arr, mid + 1, end, find);
            else
                return BinarySearch(arr, begin, mid-1, find);
        }
    }
}
