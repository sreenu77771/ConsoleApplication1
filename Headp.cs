using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{

    //few properites of maxheap
    //FindMax == o(1)
    //Deletemax == o(1)
    //insert == o(log n)
    //increase key == o(log n)
    //decrease key == o(log n)

    //heap is not optimized for these
    //findMin == o(n)
    //search == o(n)
    //delete random key == o(n+log n) == o(n)

    //properties of complete binary tree

    //height of node is defined as number of edges to leaf ( https://www.youtube.com/watch?v=2fA1FdxNqiE)
    //maximum nodes in complete binary tree is (2 pow (Height +1 ) -1)
    //similarly maximum notes in complete ternary tree( node containing three nodes) would be (3 pow (Height+1) -1)
    //height of binary tree is ( Floor of log n) ex 3 nodes, height = 1, 7 nodes height = 2 etc..

    // in any complete binary tree , leaves will be at (n/2) +1 to N
    class MinHeap
    {
        
        public static void HeapifyAtKey(List<int> arr, int i)
        {
            int l = left(i);
            int r = right(i);
            int min = i;

            if (i < arr.Count && l < arr.Count && arr[min] > arr[l])
            {
                min = l;
            }
            if (i < arr.Count && r < arr.Count && arr[min] > arr[r])
            {
                min = r;
            }

            if(min != i)
            {
                swap(arr,i, min);
                HeapifyAtKey(arr, min);
            }

        }

        public static void decreaseKey(List<int> arr, int i, int newVal)
        {
            //assume newVal is less than arr[i];
            arr[i] = newVal;
            bubbleUp(arr, i);
        }

        public static void insertKey(List<int> arr, int newVal)
        {            
            arr.Add(newVal);
            bubbleUp(arr, arr.Count-1);
        }

        public static void deleteKey(List<int> arr, int i)
        {
            //assume newVal is less than arr[i];
            arr[i] = arr[arr.Count - 1];
            HeapifyAtKey(arr, i);
            arr.RemoveAt(arr.Count - 1);
        }

        public static int extractMin(List<int> arr)
        {
            int temp = arr[0];
            arr[0] = arr[arr.Count - 1];
            HeapifyAtKey(arr, 0);
            arr.RemoveAt(arr.Count - 1);
            return temp;
        }

        public static void bubbleUp(List<int> arr, int i)
        {
            while(i!=0 && arr[parent(i)] > arr[i])
            {
                swap(arr,i, parent(i));
                i = parent(i);
            }
        }

        private static void swap(List<int> arr, int i, int min)
        {
            int temp = arr[i];
            arr[i] = arr[min];
            arr[min] = temp;
        }

        

        public static int parent(int i)
        {
            return (i-1)/ 2;
        }

        public static int left(int i)
        {
            return (2 * i) + 1 ;
        }

        public static int right(int i)
        {
            return (2*i) + 2;
        }

    }
}
