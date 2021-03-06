﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Princeton;
namespace ConsoleApplication1
{
    class MatrixProblems
    {
        public static void PrintMatrix(int[,] arr)
        {
            int rowLength = arr.GetLength(0);
            int columnLength = arr.GetLength(1);

            for(int i=0; i< rowLength; i++)
            {
                for (int j = 0; j < columnLength; j++)
                {
                    Console.Write(arr[i, j]);
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
        }

        //N*N matrix only
        public static void TransponseMatrix(int[,] arr)
        {
            int length = arr.GetLength(0);
            for (int i = 0; (i < length) ; i++)
            {
                for (int j = 0; (j < i); j++)
                {
                    int temp = arr[i, j];
                    arr[i, j] = arr[j, i];
                    arr[j, i] = temp;
                }
            }

            PrintMatrix(arr);
        }


        
        public static void RotateMatrix90Degrees(int[,] arr)
        {
            
            int length = arr.GetLength(0);
            //circle loop
            for(int x=0; x<= length/2; x++)
            {
                for(int y=x; y<(length-x-1); y++)
                {
                    int temp = arr[x, y];
                    arr[x, y] = arr[y, length - x-1];
                    arr[y, length - x-1] = arr[length - x-1, length - y-1];
                    arr[length - x-1, length - y-1] = arr[length -y-1, x];
                    arr[length - y-1, x] = temp;
                }

            }

            PrintMatrix(arr);
        }
        public static void PrintMatrixDiagnolly(int[,] arr)
        {
            int rowLength = arr.GetLength(0);
            int columnLength = arr.GetLength(1);
            int c = 0;

            ////print diagnolly until you reach all the rows, you should end at max length diagnol
            //while (c < rowLength)
            //{
            //    int k = 0;
            //    while (k <= c)
            //    {
            //        if (k < columnLength )
            //        {
            //            Console.Write(arr[c - k, k]);
            //            Console.Write(' ');
            //        }
            //        k++;
            //    }
            //    Console.WriteLine();
            //    c++;
            //}

            //print diagnolly until you reach all the rows, you should end at max length diagnol
            while (c < rowLength)
            {
                for (int i = c, j = 0; i >= 0; i--, j++)
                {
                    if (j < columnLength)
                    {
                        Console.Write(arr[i, j]);
                        Console.Write(' ');
                    }
                }
                Console.WriteLine();
                c++;
            }

            c = 1;            
            //print diagnolly until you reach end of all the columns, 
            while (c < columnLength)
            {//i>=c
                for (int i = rowLength - 1, j = c; i>=0; i--, j++)
                {
                    if (j < columnLength)
                    {
                        Console.Write(arr[i, j]);
                        Console.Write(' ');
                    }
                }
                Console.WriteLine();
                c++;
            }            
        }

        //also referred as stair search.
        public static bool Search2DSortedMatrix(int[,] arr, int target)
        {
            int rowLength = arr.GetLength(0) - 1;
            int colLength = arr.GetLength(1) - 1;
            if (arr[0, 0] > target || arr[rowLength, colLength] < target)
                return false;
            int i = 0;
            int j = colLength;
            while (i <= rowLength && j >= 0)
            {
                if (arr[i, j] > target)
                {
                    j--;
                }
                else if (arr[i, j] < target)
                {
                    i++;
                }
                else
                    return true;
            }

            return false;
        }


        //ToDO
        //public static int PrintKthSmallestIn2DSortedArray(int[,] arr, int target, PriorityQueue<int,int> maxHeap)
        //{
        //    //int rowLength = arr.GetLength(0) - 1;
        //    //int colLength = arr.GetLength(1) - 1;
        //    //if (arr[0, 0] > target || arr[rowLength, colLength] < target)
        //    //    return -1;
        //    //int i = 0;
        //    //int j = colLength;
        //    //while (i <= rowLength && j >= 0)
        //    //{
        //    //    if (arr[i, j] > target)
        //    //    {
        //    //        j--;
        //    //    }
        //    //    else if (arr[i, j] < target)
        //    //    {
        //    //        i++;
        //    //    }
        //    //    else
        //    //        return true;
        //    //}

        //    //return false;
        //}

        public static void InternalMain()
        {
            int[,] arr4 = new int[4, 4]
            {
                {2,6,7,11 },
                {3,8,10,12 },
                {4,9,11,13 },
                {5,15,16,18 }
            };

            Console.WriteLine(Search2DSortedMatrix(arr4, 14));
           
        }

    }
}
