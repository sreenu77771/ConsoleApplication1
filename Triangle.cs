using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Triangle
    {
        public static List<List<int>> PrintPascalTriangle(int size)
        {
            List<List<int>> list = new List<List<int>>();
            PrintPascalTriangle1(size, 0, list);
            return list;
        }

        public static void PrintPascalTriangle(int size, List<List<int>> list)
        {
            if (size <= 0)
            {
                list.Add(new List<int>{ 1});
                return;
            }
            
            PrintPascalTriangle(--size, list);
            int count = list.Count;
            List<int> prevList = list[count - 1];
            List<int> nextList = new List<int>();
            nextList.Add(1);
            for (int i = 0; (i + 1) < prevList.Count; i++)
            {
                nextList.Add(prevList[i] + prevList[i + 1]);
            }
            nextList.Add(1);

            list.Add(nextList);
        }

        public static void PrintPascalTriangle1(int size, int current, List<List<int>> list)
        {
            if (current >  size)
            {                
                return;
            }

            if (current == 0)
            {
                list.Add(new List<int> { 1 });
            }
            else
            {
                int count = list.Count;
                List<int> prevList = list[count - 1];
                List<int> nextList = new List<int>();
                nextList.Add(1);
                for (int i = 0; (i + 1) < prevList.Count; i++)
                {
                    nextList.Add(prevList[i] + prevList[i + 1]);
                }
                nextList.Add(1);

                list.Add(nextList);
            }
            PrintPascalTriangle1(size, current+1, list);
        }
    }
}
