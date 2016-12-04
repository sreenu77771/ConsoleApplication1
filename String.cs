using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class StringTest
    {

        public static void ReadInput()
        {
            int numOfTestCases = Int32.Parse(Console.ReadLine());
            
            for(int i=0; i< numOfTestCases; i++)
            {
                string line = Console.ReadLine();
                if(line.Length % 2 != 0)
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
            foreach(char t in x)
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
        }
}
