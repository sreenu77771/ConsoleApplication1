using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class StringTest
    {


        //todo
        //http://www.geeksforgeeks.org/length-of-shortest-chain-to-reach-a-target-word/
        //This is just BFS
        public static int ShortestChainToReachTargetWord(string start, string end, List<string> dict)
        {
            //List<string> result = new List<string>();
            //result.Add(start);

            //Queue<string> q = new Queue<string>();
            //q.Enqueue(start);

            return 0;
        }
        public static void ReadInput()
        {
            int numOfTestCases = Int32.Parse(Console.ReadLine());

            for (int i = 0; i < numOfTestCases; i++)
            {
                string line = Console.ReadLine();
                if (line.Length % 2 != 0)
                {
                    Console.WriteLine(-1);
                }
                else
                {
                    Console.WriteLine(HowManyCharsToChangeForAnagram(line.Substring(0, line.Length / 2), line.Substring(line.Length / 2, line.Length / 2)));
                }
            }
        }
        //consider input contains only [a-z]
        public static int HowManyCharsToChangeForAnagram(string x, string y)
        {
            int[] arr = new int['z' - 'a'];
            foreach (char t in y)
            {
                arr[t - 'a']++;
            }
            string missingChars = string.Empty;
            foreach (char t in x)
            {
                if (arr[t - 'a'] > 0)
                {
                    arr[t - 'a']--;
                }
                else
                {
                    missingChars += t;
                }
            }

            return missingChars.ToCharArray().Length;
        }

        static Dictionary<string, string[]> bigDict = new Dictionary<string, string[]>();
        //public static string[] ReturnForwardSubSequences(string teststring)
        //{
        //    for (int i = teststring.Length -1; i >= 0; i--)
        //    {
        //        bigDict.Add(teststring.Substring(i, teststring.Length - i), 
        //            FindSequences(teststring.Substring(i, teststring.Length - i)));
        //    }
        //}

        //public static string[] FindSequences(string teststring)
        //{
        //    if (teststring.Length == 1)
        //    {
        //        string[] temp = new string[] { teststring };                
        //        return temp;
        //    }
        //    else
        //    {
        //        List<string> tempList = new List<string>();
        //        for(int i=0; i< teststring.Length; i++)
        //        {
        //            for (int j = i; i < teststring.Length; j--)
        //            {
        //                if()
        //            }
        //        }
        //    }

        public static List<string> Combinations(string source)
        {
            List<string> result = new List<string>();
            Combinations("", source, result);
            return result;
        }

        private static void Combinations(string selected, string tobeselected, List<string> result)
        {
            if (tobeselected == string.Empty)
                result.Add(selected);
            else
            {
                Combinations(selected + tobeselected[0], tobeselected.Substring(1), result);
                Combinations(selected, tobeselected.Substring(1), result);
            }
        }

        public static List<string> Permutations(string source)
        {
            List<string> result = new List<string>();
            Permutations("", source, result);
            return result;
        }

        private static void Permutations(string selected, string tobeselected, List<string> result)
        {
            if (tobeselected == string.Empty)
                result.Add(selected);
            else
            {
                for (int i = 0; i < tobeselected.Length; i++)
                {
                    Permutations(selected + tobeselected[i], tobeselected.Replace(tobeselected[i].ToString(), ""), result);
                }
            }
        }

        public static List<string> PermutationsWithRepetetion(string source)
        {
            //ex AABC
            //find different chars and their occurrence count
            List<Tuple<char, int>> listOfCharsWithCount =
                source.GroupBy(c => c).Select(c => new Tuple<char, int>(c.First(), c.Count())).ToList();

            char[] differentChars = listOfCharsWithCount.Select(c => c.Item1).ToArray();
            int[] differentCharsCount = listOfCharsWithCount.Select(c => c.Item2).ToArray();
            List<string> result = new List<string>();
            PermutationsWithRepetetion(differentChars, differentCharsCount, 0, "".ToArray<char>(), result);
            return result;
        }

        private static void PermutationsWithRepetetion(char[] differentChars, int[] count, int level, char[] result, List<string> resultList)
        {
            if (level == result.Length)
            {
                resultList.Add(new string(result));
                Console.WriteLine(result);
                return;
            }

            for (int i = 0; i < differentChars.Length; i++)
            {
                if (count[i] == 0) continue;
                //resultString += differentChars[i].ToString();
                result[i] = differentChars[i];
                count[i] = count[i] - 1;
                PermutationsWithRepetetion(differentChars, count,  ++level, result, resultList);
                count[i] = count[i] + 1;
            }
        }
    }
    
}
