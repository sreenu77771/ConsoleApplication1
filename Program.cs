using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            //MyLinkedListNode head = MyLinkedListNode.CreateTestLinkList_1();
            //MyLinkedListNode.PrintLinkedList(head);
            //MyLinkedListNode.PrintLinkedList(MyLinkedListNode.RotateLinkListAtKthNode(head, 4));


            //int[] arr = {1,2 , 7,9,100};
            //Console.WriteLine(Search.FindValOrNextSmallest(arr,99));

            //TreeNode<int> node = TreeNode<int>.GetSampleTree();

            //node.PrintInorderRecursively(node);
            //Console.WriteLine();


            //node.PrintLevelorderIteratively(node);
            //node.PrintLevelorderRecursively(node);
            //Console.WriteLine(TreeNode<int>.HeightOfTreeNode(node.right));
            //Console.WriteLine(BitTest.itoa(4));
            //TestTreeConstruction();

            //int[] arr = {2, 2,2, 7, 8, 9 };
            //int[] arr = { 1,2, 3,4};
            //Console.WriteLine(Search.RotateArrayPivot(arr, 0, arr.Length-1));
            ArrayTest();
            Console.Read();
        }
        private static void ArrayTest()
        {
            int[,] arr = new int[3, 3]
            {
                {1,2,3 },
                {4,5,6 },
                {7,8,9 }
            };

            int[,] arr1 = new int[4, 3]
            {
                {1,2,3 },
                {4,5,6 },
                {7,8,9 },
                {10,11,12 }
            };

            int[,] arr2 = new int[2, 3]
            {
                {1,2,3 },
                {4,5,6 }
            };

            int[,] arr3 = new int[5, 2]
            {
                {1,2 },
                {3,4 },
                {5,6 },
                {7,8 },
                {9,10 },
            };

            int[,] arr4 = new int[4, 4]
            {
                {1,2,3,4 },
                {5,6,7,8 },
                {9,10,11,12 },
                {13,14,15,16 }
            };

            MatrixProblems.RotateMatrix90Degrees(arr4);
        }
        private static void StockProblemTest()
        {
            //int[] arr = { 0,1,2,-5, 7,6 };
            //int[] arr1 = { 0 };
            //int[] arr2 = { -1,-2 };
            //int[] arr3 = { -1};
            //int[] arr4 = { 2, 1 };
            //int[] arr5 = { 1,2 };
            //int[] arr6 = { 1, 2 ,-3};
            //int[] arr7 = { 0, 1, 2, -5, -8, 7, 6 };
            //Console.WriteLine(StockProblem.ContiguosMaxSum(arr));
            //Console.WriteLine(StockProblem.ContiguosMaxSum(arr1));
            //Console.WriteLine(StockProblem.ContiguosMaxSum(arr2));
            //Console.WriteLine(StockProblem.ContiguosMaxSum(arr3));
            //Console.WriteLine(StockProblem.ContiguosMaxSum(arr4));
            //Console.WriteLine(StockProblem.ContiguosMaxSum(arr5));
            //Console.WriteLine(StockProblem.ContiguosMaxSum(arr6));
            //Console.WriteLine(StockProblem.ContiguosMaxSum(arr7));

            //Console.WriteLine(StockProblem.ContiguosMaxSumIndexes(arr));
            //Console.WriteLine(StockProblem.ContiguosMaxSumIndexes(arr1));
            //Console.WriteLine(StockProblem.ContiguosMaxSumIndexes(arr2));
            //Console.WriteLine(StockProblem.ContiguosMaxSumIndexes(arr3));
            //Console.WriteLine(StockProblem.ContiguosMaxSumIndexes(arr4));
            //Console.WriteLine(StockProblem.ContiguosMaxSumIndexes(arr5));
            //Console.WriteLine(StockProblem.ContiguosMaxSumIndexes(arr6));
            //Console.WriteLine(StockProblem.ContiguosMaxSumIndexes(arr7));

            int[] arr = { 0, 1, 2, -5, -8, 7, 6 };
            int[] arr1 = { 1,2,5,7,6 };
            int[] arr2 = { 5,7,6,1,2 };
            int[] arr3 = { 2,1 };

            Console.WriteLine(StockProblem.FindMaxProfitByBuyingAndSellingOnce(arr));
            Console.WriteLine(StockProblem.FindMaxProfitByBuyingAndSellingOnce(arr1));
            Console.WriteLine(StockProblem.FindMaxProfitByBuyingAndSellingOnce(arr2));
            Console.WriteLine(StockProblem.FindMaxProfitByBuyingAndSellingOnce(arr3));

            Console.WriteLine(StockProblem.FindMaxProfitByBuyingAndSellingOnceAndTrackingFromLast(arr));
            Console.WriteLine(StockProblem.FindMaxProfitByBuyingAndSellingOnceAndTrackingFromLast(arr1));
            Console.WriteLine(StockProblem.FindMaxProfitByBuyingAndSellingOnceAndTrackingFromLast(arr2));
            Console.WriteLine(StockProblem.FindMaxProfitByBuyingAndSellingOnceAndTrackingFromLast(arr3));

            Console.WriteLine(StockProblem.FindMaxProfitByBuyingAndSellingManyTimes(arr));
            Console.WriteLine(StockProblem.FindMaxProfitByBuyingAndSellingManyTimes(arr1));
            Console.WriteLine(StockProblem.FindMaxProfitByBuyingAndSellingManyTimes(arr2));
            Console.WriteLine(StockProblem.FindMaxProfitByBuyingAndSellingManyTimes(arr3));

        }
        private static void TestTreeConstruction()
        {
            //int[] inorder = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //int[] preorder = { 5, 4, 2, 1, 3, 7, 6, 8, 9 };
            TreeNode<int> node = TreeNode<int>.GetSampleTree();
            node.PrintInorderIteratively(node);
            Console.WriteLine();
            node.PrintPreorderIteratively(node);
            Console.WriteLine();
            node.PrintPostorderRecursively(node);
            Console.WriteLine();
            int[] inorder = {5,14,16,20,100,150,160,170,200,300,600};
            int[] preorder = { 100,20,14,5,16,300,200,150,160,170,600 };
            int[] postorder = { 5, 16, 14, 20, 170, 160, 150, 200, 600, 300, 100 };
            //TreeNode<int> root = TreeNode<int>.ConstructTreeGivenInOrderAndPreOrder(inorder, 0, inorder.Length - 1, preorder, 0, preorder.Length - 1);
            //TreeNode<int> root = TreeNode<int>.ConstructTreeGivenInOrderAndPostOrder(inorder, 0, inorder.Length - 1, postorder, postorder.Length -1, 0);
            preorder = new int[]{10, 5,1, 7, 40, 50};
            TreeNode<int> root = TreeNode<int>.ConstructTreeGivenPreOrderForBST(preorder, 0, preorder.Length - 1);
            root.PrintInorderIteratively(root);
        }
        private static void PrintArray<T>(IEnumerable<T> arr)
        {
            foreach (T t in arr)
            {
                Console.WriteLine(t);
            }
        }
        private static void TestMain()
        {
            //StringTest.ReadInput();
            //BitTest.OverFlowTest();

            //Console.WriteLine(BitTest.GetMaxPowLessThanN((ulong)10185461537550311607));
            //Console.WriteLine(BitTest.CheckIfNPowerOfTwo((ulong)10185461537550311607));
            //Console.WriteLine ( BitTest.Test(6070205350162300895ul));

            uint[] arr = { 1, 2, 3, 4, 3, 4 }; //{ 1,1,2,3,5,3,4 };
            //PrintArray(BitTest.FindDuplicates(arr, 4));
            Tuple<uint, uint> tuple = BitTest.FindDuplicates(arr, 4);


            //int[] arr = { 3, 1, 2, 4 };
            //Sorting.QuickSort(arr);

            //MyLinkedListNode head = MyLinkedListNode.CreateTestLinkList();
            //MyLinkedListNode.PrintLinkedList(head);
            //MyLinkedListNode.PrintLinkedList(MyLinkedListNode.MutableClone(head));
            //HashSet<string> set = MyHashSet.climbStairs(60);
            //Console.WriteLine(set.Count);
            //foreach(string s in set)
            //{
            //    Console.WriteLine(s);
            //}
            //Console.WriteLine(set.Count);
            //int[] arr = {1,2 };
            //Console.WriteLine(MyArray.FindMissingNumber(arr));
            //int[] inOrder = { 1, 2, 3 };
            //int[] preOrder = { 2, 1, 3 };
        }

        public static void isBSTTreeTest()
        {
            //TreeNode<int> node = TreeNode<int>.GetSampleTree();
            //Console.WriteLine(TreeNode<int>.IsBST_Wrong(node));

            //TreeNode<int> node1 = TreeNode<int>.GetSampleNonBSTTree();
            //Console.WriteLine(TreeNode<int>.IsBST_Wrong(node1));

            TreeNode<int> node = TreeNode<int>.GetSampleTree();
            Console.WriteLine(TreeNode<int>.IsBST(node));

            TreeNode<int> node1 = TreeNode<int>.GetSampleNonBSTTree();
            Console.WriteLine(TreeNode<int>.IsBST(node1));
        }

        static void TestTree()
        {
            TreeNode<int> node = TreeNode<int>.GetSampleTree();

            node.PrintInorderRecursively(node);
            Console.WriteLine();
            node.PrintPostorderRecursively(node);
            Console.WriteLine();
            node.PrintPreorderRecursively(node);
            Console.WriteLine();
        }

        public static void InorderPredecessorTest()
        {
            TreeNode<int> node = TreeNode<int>.GetSampleTree();
            Console.WriteLine(TreeNode<int>.InorderPredecessor(node, 180));
        }

        static void ReturnZerosLastTest()
        {
            int[] input = { 2, 0, 4, 6, 5, 0, 9, 10, 1, 0, 3, 0, 2 };
            int[] output = ReturnZerosLast(input);

            for (int i = 0; i < input.Length; i++)
                Console.Write(input[i] + " ");
            Console.WriteLine();
            for (int i = 0; i < output.Length; i++)
                Console.Write(output[i] + " ");

            Console.Read();
        }
            static int[] ReturnZerosLast(int[] arr)
        {
            int[] outArr = new int[arr.Length];
            int outArrMarker = 0;
            int numOfZeros = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != 0)
                    outArr[outArrMarker++] = arr[i];
                else
                    numOfZeros++;
            }

            while (outArrMarker < arr.Length)
                outArr[outArrMarker++] = 0;

            return outArr;
        }
    }
}
