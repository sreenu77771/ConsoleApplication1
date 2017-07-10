using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class RecursionPractice
    {
//        Given a string, compute recursively(no loops) the number of lowercase 'x' chars in the string.

//countX("xxhixx") → 4
//countX("xhixhix") → 3
//countX("hi") → 0
        public static int countX(String str)
        {
            if (str == null || str == "")
                return 0;
            int sum = 0;
            if (str[0] == 'x') sum = 1;
            return sum + countX(str.Substring(1));
        }

        //Tail Recursion
        public static int countXWithoutSubString(String str, int strlen)
        {
            if (strlen == 0) return 0;
            int val = 0;
            if (str[strlen-1] == 'x') val = 1;
            return val + countXWithoutSubString(str, --strlen);
        }

        //Forward Recursion
        public static void countXWithoutSubStringForward(String str, int strlen, ref int sum)
        {
            if (strlen != 0)
            {
                if (str[strlen - 1] == 'x') sum += 1;
                countXWithoutSubStringForward(str, --strlen, ref sum);
            }
            return;
        }

        public static int countHi(String str)
        {
            if (str.Length < 2) return 0;

            if (str.Substring(0, 2) == "hi")
                return 1 + countHi(str.Substring(2));
            
            return countHi(str.Substring(1));
        }

        //        Given a string, compute recursively(no loops) a new string where all appearances of "pi" have been replaced by "3.14".

        //changePi("xpix") → "x3.14x"
        //changePi("pipi") → "3.143.14"
        //changePi("pip") → "3.14p"
        public static String changePi(String str)
        {
            if (str == null || str == "")
                return "";
            if (str.Length <3 && str != "pi") return str;
            if (str.Substring(0, 2) == "pi")
                return "3.14" + changePi(str.Substring(2));
            else if(str[1] == 'p')
                return str[0] + changePi(str.Substring(1));
            else
                return str.Substring(0, 2) + changePi(str.Substring(2));
        }

        //        Given an array of ints, compute recursively the number of times that the value 11 appears in the array.We'll use the convention of considering only the part of the array that begins at the given index. In this way, a recursive call can pass index+1 to move down the array. The initial call will pass in index as 0.

        //array11([1, 2, 11], 0) → 1
        //array11([11, 11], 0) → 2
        //array11([1, 2, 3, 4], 0) → 0
        public static int array11(int[] nums, int index)
        {
            if (nums == null || nums.Length == 0) return 0;
            int count = 0;
            if (index >= nums.Length)
                return count;

            if (nums[index] == 11) count++;

            return count + array11(nums, ++index);
        }


//        Given a string, compute recursively a new string where identical chars that are adjacent in the original string are separated from each other by a "*".

//pairStar("hello") → "hel*lo"
//pairStar("xxyy") → "x*xy*y"
//pairStar("aaaa") → "a*a*a*a"
        public static String pairStar(String str)
        {
            if (str == null || str == "")
                return "";

            if (str.Length < 2) return str;

            if (str.Length < 3 && str[0] != str[1])
                return str;
            else if(str.Length < 3 && str[0] == str[1])
                return  (str[0] + "*" + str[1]);

            //var r = pairStar(str.Substring(1));

            //if (str[0] == r[0]) return str[0] + "*" + r;
            //else return str[0] +  r;

            if (str[0] == str[1]) return (str[0] + "*" ) + str.Substring(1);
            else return (str[0] ) + str.Substring(1);

        }

        public static int factorial(int n)
        {
            if (n == 1) return 1;
            return n * factorial(n - 1);
        }


    }
}
