using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Backtracking
    {
        public static Stack<char> Solve(int[] puzzle)
        {
            int goal = puzzle.Length - 1;
            if (goal < 0) return null;
            bool[] vis = new bool[puzzle.Length];
            return Solve(puzzle, 0, goal, vis);
        }

        public static Stack<char> Solve(int[] puzzle, int here, int goal, bool[] visited)
        {
            Stack<char> solution = null;
            if (here == goal) return new Stack<char>();
            visited[here] = true;

            //dont assign to here wrong
            //here = here + puzzle[here];
            //Don't modify and use non-local variables
            //You can modify them or use them, just not both

            //note same thing applies for visited.

            //try going right
            int right = here + puzzle[here];
            if (right < puzzle.Length && visited[right] != true)
            {
                bool[] b = new bool[visited.Length];
                visited.CopyTo(b, 0);
                Console.Write("Going right from " + here + ":" + puzzle[here]);
                Console.WriteLine();
                solution = Solve(puzzle, right, goal, b);
                if (solution != null)
                {
                    Console.WriteLine("  Pushing R");
                    solution.Push('R');
                    return solution;
                }
            }

            //try going left
            int left = here - puzzle[here];
            if (left >= 0 && visited[left] != true)
            {
                bool[] b = new bool[visited.Length];
                visited.CopyTo(b, 0);
                Console.Write("Going left from " + here + ":" + puzzle[here]);
                Console.WriteLine();

                solution = Solve(puzzle, left, goal, b);
                if (solution != null)
                {
                    Console.WriteLine("  Pushing L");
                    solution.Push('L');
                    return solution;
                }
            }


            return null;
        }

        public static List<List<int>> FindAllSolutions(int[] puzzle)
        {
            int goal = puzzle.Length - 1;
            if (goal < 0) return null;
            List<List<int>> list = new List<List<int>>();
            List<int> path = new List<int>();
            path.Add(0);
            FindAllSolutions(puzzle, path, goal, list);
            return list;
        }
        public static void FindAllSolutions(int[] puzzle, List<int> path, int goal, List<List<int>> list)
        {
            int here = 0;
            if (path.Count > 0)
                here = path[path.Count - 1];

            if (here == goal)
            {
                list.Add(path);
                return;
            }
           
            int right = here + puzzle[here];
            if (right < puzzle.Length && !path.Contains(right))
            {
                List<int> copyPath = new List<int>();
                copyPath.AddRange(path);
                copyPath.Add(right);
                Console.WriteLine("  Pushing R");  
                FindAllSolutions(puzzle, copyPath, goal, list);
                //return;
            
            }

            //try going left
            int left = here - puzzle[here];
            if (left >= 0 && !path.Contains(left))
            {
                List<int> copyPath = new List<int>();
                copyPath.AddRange(path);
                copyPath.Add(left);
                Console.WriteLine("  Pushing L");
                FindAllSolutions(puzzle, copyPath, goal, list);
                //return;
            }
            return;
        }

        //test methods

        public static void testSolve_FindAllSolutions()
        {
            //int[] puzzle = new int[] { 3, 1, 3, 3, 5, 3, 2, 1, 3, 0 };
            int[] puzzle =  new int[] { 3, 6, 4, 1, 3, 4, 2, 5, 3, 0 };

            List<List<int>> list = FindAllSolutions(puzzle);
            foreach(var l in list)
            {
                foreach(int i in l)
                {
                    Console.Write(" " + i);
                }
                Console.WriteLine();
            }

        }
        public static void testSolve_JustOneSolution()
        {
            int[] puzzle = new int[] { 3, 1, 3, 3, 5, 3, 2, 1, 3, 0 };
            String expected = "RRLR";
            String actual = str(Solve(puzzle));
            Console.Write(string.Compare(expected, actual));

            puzzle = new int[] { 3, 1, 2, 2, 0 };
            expected = "RLRR";
            actual = str(Solve(puzzle));
            Console.Write(string.Compare(expected, actual));

            puzzle = new int[] { 1, 1, 1, 1, 1, 0 };
            expected = "RRRRR";
            actual = str(Solve(puzzle));
            Console.Write(string.Compare(expected, actual));

            puzzle = new int[] { 4, 5, 1, 1, 1, 0, 1, 0 };
            expected = "RLLLRR";
            actual = str(Solve(puzzle));
            Console.Write(string.Compare(expected, actual));
        }

        static String str(Stack<char> stack)
        {
            if (stack == null) return null;
            String result = "";
            foreach(char ch in stack)
            {
                // This appends to the front of the string because
                // the Stack iterator iterates from bottom to top!
                result = ch + result;
            }
            return result;
        }
        static String str(Stack<char> stack, int[] puzzle)
        {
            if (stack == null) return null;
            int here = 0;
            String result = "";
            result = here + ":" + puzzle[here] + " ";
            foreach(char ch in stack)
            {
                if (ch == 'L')
                {
                    result += "L ";
                    here -= puzzle[here];
                }
                else
                {
                    result += "R ";
                    here += puzzle[here];
                }
                result += here + ":" + puzzle[here] + " ";
            }
            return result.Trim();
        }

    }
}
