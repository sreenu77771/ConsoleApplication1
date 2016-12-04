using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class TreeNode<T> where T : struct, IComparable<T>
    {
        public T data;
        public TreeNode<T> left;
        public TreeNode<T> right;
        public bool visited = false;

        public TreeNode(T pData)
        {
            data = pData;
        }

        public TreeNode()
        {            
        }
        public TreeNode(T pData, T pLeft, T pRight)
        {
            this.data = pData;
            this.left = new TreeNode<T>(pLeft);
            this.right = new TreeNode<T>(pRight);
        }

        public static void AddNodes(TreeNode<T> pData, TreeNode<T> pLeft = null, TreeNode<T> pRight = null)
        {
            
        }

        public TreeNode(T pData, T pLeft)
        {
            this.data = pData;
            this.left = new TreeNode<T>(pLeft);            
        }
        public void PrintInorderRecursively(TreeNode<T> node)
        {
            if (node == null) return;
            if (node.left != null) PrintInorderRecursively(node.left);
            Console.Write(node.data + " ");
            if (node.right != null) PrintInorderRecursively(node.right);
        }

        public void PrintInorderIteratively(TreeNode<T> node)
        {
            //mark left visited as you go left so you wont go to left again. 
            Stack<TreeNode<int>> stack = new Stack<TreeNode<int>>();
            if (node == null) return;
            stack.Push((dynamic)node);

            while (stack.Any())
            {
                TreeNode<int> temp = stack.Peek();
                if (temp.left != null && temp.left.visited == false)
                {
                    stack.Push(temp.left);
                    temp.left.visited = true;
                }
                else
                {
                    Console.Write(temp.data + " ");
                    stack.Pop();
                    if (temp.right != null)
                        stack.Push(temp.right);
                    
                }

            }
        }

        public void PrintPostorderIteratively(TreeNode<T> node)
        {
            //use stack and check on both left and right to see whether to visit that node or not
            Stack<TreeNode<int>> stack = new Stack<TreeNode<int>>();
            if (node == null) return;
            stack.Push((dynamic)node);

            while (stack.Any())
            {
                TreeNode<int> temp = stack.Peek();

                if (temp.left != null && temp.left.visited == false)
                {
                    stack.Push(temp.left);
                    temp.left.visited = true;
                }
                else if (temp.right != null && temp.right.visited == false)
                {
                    stack.Push(temp.right);
                    temp.right.visited = true;
                }
                else
                {
                    Console.Write(temp.data + " ");
                    stack.Pop();
                }
            }
        }

        public void PrintPreorderIteratively(TreeNode<T> node)
        {

            //use simple stack
            Stack<TreeNode<int>> stack = new Stack<TreeNode<int>>();
            if (node == null) return;
            stack.Push((dynamic)node);

            while(stack.Any())
            {
                TreeNode<int> tempNode = stack.Pop();
                Console.Write(tempNode.data + " ");
                if (tempNode.right != null)
                    stack.Push(tempNode.right); 
                if (tempNode.left != null)
                    stack.Push(tempNode.left);                
            }
        }
        public void PrintPostorderRecursively(TreeNode<T> node)
        {
            if (node == null) return;
            if (node.left != null) PrintPostorderRecursively(node.left );
            if (node.right != null) PrintPostorderRecursively(node.right);
            Console.Write(node.data + " ");            
        }

        public void PrintPreorderRecursively(TreeNode<T> node)
        {
            if (node == null) return;
            Console.Write(node.data + " ");
            if (node.left != null) PrintPreorderRecursively(node.left);
            if (node.right != null) PrintPreorderRecursively(node.right);            
        }

        public void PrintLevelorderRecursively(TreeNode<T> node)
        {
            int treeHeight = HeightOfTreeNode(node);
            for (int i = 1; i <= treeHeight; i++)
            {
                PrintGivenLevelRecursively(node, i);
                Console.WriteLine();
            }
        }
        public void PrintGivenLevelRecursively(TreeNode<T> node, int level)
        {
            if (node == null)
                return;
            else if(level ==1 && node != null)
            {
                Console.Write(node.data+ " ");
            }
            else
            {
                PrintGivenLevelRecursively(node.left, level - 1);
                PrintGivenLevelRecursively(node.right, level - 1);
            }
        }
        public void PrintLevelorderIteratively(TreeNode<T> node)
        {
            if (node == null) return;
            Queue<TreeNode<int>> cqueue = new Queue<TreeNode<int>>();
            Queue<TreeNode<int>> nqueue = new Queue<TreeNode<int>>();
            cqueue.Enqueue((dynamic)node);
            while (cqueue.Any())
            {
                while (cqueue.Any())
                {
                    TreeNode<int> temp = cqueue.Dequeue();
                    if (temp.left != null)
                        nqueue.Enqueue(temp.left);
                    if (temp.right != null)
                        nqueue.Enqueue(temp.right);
                    Console.Write(temp.data + " ");
                }
                Console.WriteLine();
                cqueue = nqueue;
                nqueue = new Queue<TreeNode<int>>();
            }            
        }

        public static bool IsBST_Wrong(TreeNode<T> node)
        {
            if (node == null) return true;
            if ((node.left == null) && (node.right == null)) return true;
            if ((node.left == null ? true : (node.left.data.CompareTo(node.data) < 0)) &&
                (node.right == null ? true : (node.right.data.CompareTo(node.data) > 0)))
            {
                return IsBST_Wrong(node.left) && IsBST_Wrong(node.right);
            }
            return false;
        }

        public static int HeightOfTreeNode(TreeNode<T> node)
        {
            if (node == null)
                return 0;
            else if (node.left == null && node.right == null)
                return 1;
            else
                return 1 + Math.Max(HeightOfTreeNode(node.left), HeightOfTreeNode(node.right));
        }

        //public static int HeightOfTreeNodeIterative(TreeNode<T> node, int level)
        //{
        //    if (node == null)
        //        return 0;
        //    else if (node.left == null && node.right == null)
        //        return 1;
        //    else
        //    {
        //        int rightHeight = HeightOfTreeNode(node.right);
        //        int leftHeight =  HeightOfTreeNode(node.right); 
        //        return 1 + Math.Max(leftHeight, rightHeight);
        //    }
        //}

        private static bool IsBSTInternal(TreeNode<T> node, T min, T max)
        {
            if (node == null) return true;
            return (node.data.CompareTo(min) > 0 && node.data.CompareTo(max) < 0 ) && IsBSTInternal(node.left, min, node.data) && IsBSTInternal(node.right, node.data, max);
        }

        //TODo : right generic
        public static bool IsBST(TreeNode<T> node)
        {

            //return IsBSTInternal(node, () => { return int.MinValue; }, () => { return int.MinValue; } );
            return IsBSTInternal(node, (dynamic) int.MinValue, (dynamic)int.MaxValue);
        }

        //public int InorderSuccessor(TreeNode<T> node)
        //{
        //}


        public static TreeNode<int> ConstructTreeGivenInOrderAndPreOrder(int[] inorder, int il, int ih, int[] preorder, int pl, int ph)
        {

            if (preorder == null || preorder.Length == 0) return null;
           
            if ((pl> ph) || (il > ih)) return null;
            
            else
            {
                TreeNode<int> temp = new TreeNode<int>(preorder[pl]);                
                int findIndex = FindIndex(inorder, il, ih, preorder[pl]);
                //construct left using pl+1 and pl+ lefttreesize
                temp.left = ConstructTreeGivenInOrderAndPreOrder(inorder, il, findIndex - 1, preorder, pl+1, pl+(findIndex- il));

                //construct right using pl+ lefttreesize +1 to ph
                temp.right = ConstructTreeGivenInOrderAndPreOrder(inorder, findIndex + 1, ih, preorder, pl+ (findIndex - il)+1, ph);

                return temp;
            }
        }

        public static TreeNode<int> ConstructTreeGivenInOrderAndPostOrder(int[] inorder, int il, int ih, int[] postorder, int pl, int ph)
        {
            if (postorder == null || postorder.Length == 0) return null;

            if ((pl < ph) || (il > ih)) return null;
            else
            {
                TreeNode<int> temp = new TreeNode<int>(postorder[pl]);
                int findIndex = FindIndex(inorder, il, ih, postorder[pl]);

                temp.right = ConstructTreeGivenInOrderAndPostOrder(inorder, findIndex + 1, ih, postorder, pl - 1, pl - (ih -findIndex));
                temp.left = ConstructTreeGivenInOrderAndPostOrder(inorder, il, findIndex - 1, postorder, pl - (ih - findIndex) - 1, ph);

                return temp;
            }
        }

        //Note input is preOrder for BST not plain binary tree. Since BST has property that right node 
        //should be greater than root, we can find index of node which is greater than root and take it
        //as start of right node and below it is left node.

         //if input is preorder of just binary tree then you cannot construct and would need inorder of that
         //tree to construct 
        public static TreeNode<int> ConstructTreeGivenPreOrderForBST(int[] preOrder, int preStart, int preEnd)
        {
            if (preOrder == null || preOrder.Length == 0) return null;

            if (preStart > preEnd) return null;
            else
            {
                TreeNode<int> temp = new TreeNode<int>(preOrder[preStart]);
                if (preStart == preEnd) return temp;

                int largerNumberThanRootIndex = FindLargerNumber(preOrder, preStart, preEnd, preOrder[preStart]);
                temp.left = ConstructTreeGivenPreOrderForBST(preOrder, preStart + 1, largerNumberThanRootIndex-1);
                temp.right = ConstructTreeGivenPreOrderForBST(preOrder, largerNumberThanRootIndex, preEnd);
                return temp;
            }
        }

        private static int FindLargerNumber(int[] preOrder, int preStart, int preEnd, int v)
        {            
            while(preStart <= preEnd)
            {
                if(preOrder[preStart] > v)
                {
                    return preStart;
                }
                preStart++;
            }
            return -1;
        }

        private static int FindIndex(int[] inorder, int il, int ih, int find)
        {
            if (inorder == null || inorder.Length == 0) return -1;
            for(int i=il; i<=ih; i++)
            {
                if (inorder[i] == find) return i;
            }
            return -1;
        }
        //check if tree is sumtree or not
        //public static TreeNode<int> ConstructTreeGivenInOrderAndPreOrder(int[] inorder,int[] preorder)
        //{
        //    wh
        //}

        //summify tree
        //public static TreeNode<int> ConstructTreeGivenInOrderAndPreOrder(int[] inorder,int[] preorder)
        //{
        //    wh
        //}

        //Insertion in tree
        //public static TreeNode<int> ConstructTreeGivenInOrderAndPreOrder(int[] inorder,int[] preorder)
        //{
        //    wh
        //}

        //Deletion in tree
        //public static TreeNode<int> ConstructTreeGivenInOrderAndPreOrder(int[] inorder,int[] preorder)
        //{
        //    wh
        //}

        public static int InorderPredecessor(TreeNode<int> node, int val)
        {
            int p = int.MinValue; //predessor
            if (node == null) throw new Exception("Node null");
            while (node != null)
            {
                if(node.data > val)
                {
                    node = node.left; 
                }
                else if(node.data < val)
                {
                    p = Math.Max(p, node.data);
                    node = node.right;
                }
                else
                {
                    if(node.left == null)
                    {
                        if (p == int.MinValue) throw new Exception("No Predecessor");
                        else return p;
                    }
                    else
                    {
                        TreeNode<int> current = node.left;
                        TreeNode<int> rightNode = current.right;
                        while(rightNode != null)
                        {
                            current = rightNode;
                            rightNode = rightNode.right;
                        }
                        return current.data;
                    }
                }
            }
            //throw new Exception("Find value not found");

            if (p == int.MinValue) throw new Exception("Find value not found");
            else return p;
        }

        
        public static TreeNode<int> GetSampleTree()
        {
            TreeNode<int> root = new TreeNode<int>(100);
            root.left = new TreeNode<int>(20);
            root.left.left = new TreeNode<int>(14, 5, 16);
            
            root.right = new TreeNode<int>(300, 200, 600);
            root.right.left.left = new TreeNode<int>(150);
            root.right.left.left.right = new TreeNode<int>(160);
            root.right.left.left.right.right = new TreeNode<int>(170);

            return root;
        }

        public static TreeNode<int> GetSampleNonBSTTree()
        {
            TreeNode<int> root = new TreeNode<int>(100);
            root.left = new TreeNode<int>(20);
            root.left.left = new TreeNode<int>(14, 5, 190); // 190 is wrong
            root.left.left.right.left = new TreeNode<int>(1); // 1 is wrong
            root.right = new TreeNode<int>(300, 200, 600);
            root.right.left.left = new TreeNode<int>(150);
            root.right.left.left.right = new TreeNode<int>(160);
            root.right.left.left.right.right = new TreeNode<int>(170);

            return root;
        }
    }
}
