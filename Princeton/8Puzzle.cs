using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Princeton
{
    public class Board
    {
        private static Random rand = new Random();
        int n;
        int[,] blocks;

        public int N
        {
            get
            {
                return n;
            }            
        }

        public int[,] Blocks
        {
            get
            {
                return blocks;
            }            
        }

        // construct a board from an n-by-n array of blocks // (where blocks[i][j] = block in row i, column j)
        public Board(int[,] blocks)
        {
            this.n = blocks.GetLength(0);
            this.blocks = new int[n,n];
            for (int i=0; i<n; i++ )
            {
                for (int j = 0; j < n; j++)
                {
                    this.blocks[i,j] = blocks[i,j];
                }
            }

        }
        // board dimension n      
        public int dimension()
        {
            return n;
        }
        // number of blocks out of place
                    
        public int hamming()
        {
            int misMatch = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    //if (!((i == n - 1) && (j == n - 1)))
                    //{
                        if(this.blocks[i,j] != 0 && this.blocks[i,j] != ((n*i)+j+1))
                        {
                            misMatch++;
                        }
                    //}
                }
            }
            return misMatch;
        }

        //sum of Manhattan distances between blocks and goal
        public int manhattan()
        {
            //var space = FindSpace();
            //int x = space.Item1;
            //int y = space.Item2;
            int manhattan = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int goalI = (blocks[i,j] -1) / n;
                    int goalJ = (blocks[i, j] - 1) % n; ;

                    if (this.blocks[i, j] != 0 && this.blocks[i, j] != ((n * i) + j + 1))
                    {
                        manhattan += Math.Abs(i - goalI) + Math.Abs(j - goalJ);
                    }
                }
            }

            return manhattan;

        }
        
        private Tuple<int, int> FindSpace()
        {
            int i = 0; int j = 0;
            bool found = false;
            while(i< n && !found)
            {
                j = 0;
                while (j < n && !found)
                {
                    if (this.blocks[i, j] == 0)
                    {
                        found = true;
                        break;
                    }
                    j++;
                }
                
                if(!found)
                    i++;
            }

            return new Tuple<int, int>(i, j);
        }

        //// is this board the goal board?   
        public bool isGoal()
        {
            return (this.hamming() == 0);
        }

        // a board that is obtained by exchanging any pair of blocks      
        public Board twin()
        {
            int[,] twinBlocks = Clone();

            
            if (twinBlocks[0, 0] != 0 && twinBlocks[0, 1] != 0)
                swap(twinBlocks, 0, 0, 0, 1);
            else
                swap(twinBlocks, 1, 0, 1, 1);

            Board twin = new Board(twinBlocks);
            return twin;
        }

        private int[,] Clone()
        {
            int[,] twinBlocks = new int[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    twinBlocks[i, j] = blocks[i, j];
            return twinBlocks;
        }

        // does this board equal y?           
        public override bool Equals(object y)
        { 
            if (y == this) return true;
            if (y == null || y.GetType() != this.GetType()) return false;
            if (n != ((Board)y).n) return false;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (this.blocks[i,j] != ((Board)y).blocks[i,j])
                        return false;
            return true;
        }

        // all neighboring boards
        public IEnumerable<Board> neighbors()
        {
            var space = FindSpace();
            int x = space.Item1;
            int y = space.Item2;

            List<Board> boards = new List<Board>();
            int[][] directions = { new int[]{0,1} , new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 }};

            foreach(var v in directions)
            {
                int[,] blocksClone = Clone();

                if ((x + v[0] < n) && (x + v[0] >=0) && (y + v[1] < n) && (y + v[1] >=0 )) 
                {
                    swap(blocksClone, x, y, x + v[0], y + v[1]);
                    boards.Add(new Board(blocksClone));
                }               
            }

            return boards;

        }

        // string representation of this board (in the output format specified below)
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(n).Append('\n');
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    sb.Append(' ').Append(blocks[i,j]).Append(' ');
                sb.Append('\n');
            }
            return sb.ToString();
        }

        public static void Display(int[,] t)
        {
            int n = t.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(t[i,j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("*************************");
        }
        public static int[,] CreateRandomArray(int n, bool shuffle)
        {

            int[,] t = new int[n,n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                  //if (!((i == n - 1) && (j == n - 1)))
                    if (((i != n - 1) || (j != n - 1)))
                    {
                        t[i, j] = (n * i) + j + 1;
                    }
                }
            }

            if(shuffle)
                Shuffle(t);

            return t;
        }

        public static void Shuffle(int[,] t)
        {
            Shuffle(t, t.GetLength(0) * t.GetLength(0));
        }
        public static void Shuffle(int[,] t, int times)
        {
            int n = t.GetLength(0);            
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {                    
                    if (times <= 0) break;
                    swap(t, i, j, rand.Next(n - 1), rand.Next(n - 1));
                    times--;
                }
            }
        }

        private static void swap(int[,] arr, int x1, int y1, int x2, int y2 )
        {
            int temp = arr[x1,y1];
            arr[x1,y1] = arr[x2,y2];
            arr[x2,y2] = temp;
        }

        // unit tests (not graded)
        public static void InternalMain()
        {
            int[,] t = CreateRandomArray(3, false);
            Display(t);
            Shuffle(t);
            Display(t);
            Board b = new Board(t);
            Console.WriteLine(b.hamming());
            Console.WriteLine(b.manhattan());
            Display(b.twin().blocks);
            Display(b.blocks);
            foreach(var board in b.neighbors())
            {
                Display(board.blocks);
            }
            Console.Read();
        }


    }

    public class Solver
    {
        MinHeap<Node> pq1;
        MinHeap<Node> pqAlt;

        int totalMoves = 0;
        // find a solution to the initial board (using the A* algorithm)
        public Solver(Board initial)
        {
            
           pq1 = new MinHeap<Node>(initial.N * initial.N);
           pqAlt = new MinHeap<Node>(initial.N * initial.N);

            Node n = new Node(initial, -1, null);
            Node nAlt = new Node(initial.twin(), -1, null);
            pq1.insert(n);
            pqAlt.insert(nAlt);

            
            while(!pq1.min().board.isGoal() && !pqAlt.min().board.isGoal())
            {
                Node temp = pq1.DelMin();

                totalMoves++;
                foreach( var t in temp.board.neighbors())
                {
                    if(temp.prev == null || !t.Equals(temp.prev.board))
                    {
                        pq1.insert(new Node(t, totalMoves, temp));
                    }
                }

                temp = pqAlt.DelMin();
                foreach (var t in temp.board.neighbors())
                {
                    if (temp.prev == null || !t.Equals(temp.prev.board))
                    {
                        pqAlt.insert(new Node(t, totalMoves, temp));
                    }
                }
            }

        }

        // is the initial board solvable?        
        public bool isSolvable()
        {
            return this.pq1.min().board.isGoal();
        }
        //// min number of moves to solve initial board; -1 if unsolvable 
        public int moves()
        {
            return this.totalMoves;
        }

        //// sequence of boards in a shortest solution; null if unsolvable              
        public IEnumerable<Board> solution()
        {
            Stack<Board> b = new Stack<Board>();

            if(isSolvable())
            {
                Node temp = pq1.DelMin();
                while(temp != null)
                {
                    b.Push(temp.board);
                    temp = temp.prev; 
                }

                return b;
            }
            else
            {
                return null;
            }
        }

        // unit tests (not graded)
        public static void InternalMain()
        {
            //int[,] t = Board.CreateRandomArray(3, false);
            //Board.Display(t);
            //Board.Shuffle(t);

            int[,] t = new int[3, 3];
            t = new int[,] { { 0,1,3},
                               {4,2,5 },
                                {7,8,6 } };

            Board.Display(t);
            Board b = new Board(t);

            Solver s = new Princeton.Solver(b);
            Console.WriteLine(s.isSolvable());

            foreach(var v in s.solution())
            {
                Board.Display(v.Blocks); 
            }


        }

        private class Node : IComparable<Node>
        {
            public int moves = -1;
            public Board board;
            public Node prev;

            public Node(Board b, int m, Node p)
            {
                this.board = b;
                this.moves = m;
                this.prev = p;
            }

            private class ManhattanComparator : IComparer<Node>
            {
                public int Compare(Node o1, Node o2)
                {
                    int num1 = o1.board.manhattan() + o1.moves;
                    int num2 = o2.board.manhattan() + o2.moves;
                    if (num1 == num2)
                    {
                        if (o1.board.hamming() == o2.board.hamming()) return 0;
                        if (o1.board.hamming() < o2.board.hamming()) return -1;
                        return 1;
                    }
                    if (num1 < num2) return -1;
                    return 1;
                }
            }

            public int CompareTo(Node o2)
            {
                Node o1 = this;
                int num1 = o1.board.manhattan() + o1.moves;
                int num2 = o2.board.manhattan() + o2.moves;
                if (num1 == num2)
                {
                    if (o1.board.hamming() == o2.board.hamming()) return 0;
                    if (o1.board.hamming() < o2.board.hamming()) return -1;
                    return 1;
                }
                if (num1 < num2) return -1;
                return 1;
            }
        }
    }


}
