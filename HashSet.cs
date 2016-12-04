using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class MyHashSet
    {

        public static HashSet<string> climbStairs(int A)
        {
            Dictionary<int, HashSet<string>> dict = new Dictionary<int, HashSet<string>>();

            HashSet<string> OneCombinations = new HashSet<string>();
            OneCombinations.Add("1");

            HashSet<string> TwoCombinations = new HashSet<string>();
            TwoCombinations.Add("2");
            TwoCombinations.Add("11");

            dict.Add(1,OneCombinations);
            dict.Add(2, TwoCombinations);

            for(int i=3; i<= A-1; i++)
            {
                dict.Add(i,PopulateDictForSizeN(dict, i));
            }
            HashSet<string> set = PopulateDictForSizeN(dict, A);
            return set;


        }

        private static HashSet<string> PopulateDictForSizeN(Dictionary<int, HashSet<string>> dict, int a)
        {
            HashSet<string> set = new HashSet<string>();
            for(int i=1; i<= a; i++)
            {
                int k = i;
                int l = (a - k);
                if(dict.ContainsKey(k) && dict.ContainsKey(l))
                {
                    HashSet<string> newSet = GetCombinations(dict, k, l);
                    set.UnionWith(newSet);
                }
            }

            return set;
        }

        private static HashSet<string> GetCombinations(Dictionary<int, HashSet<string>> dict, int k, int l)
        {
            HashSet<string> newSet = new HashSet<string>();
            HashSet<string> kSet = dict[k];
            HashSet<string> lSet = dict[l];

            foreach (string s in kSet)
            {
                foreach (string r in lSet)
                {
                    if(!newSet.Contains(s+r))
                    {
                        newSet.Add(s + r);
                    }
                }
            }

            foreach (string s in lSet)
            {
                foreach (string r in kSet)
                {
                    if (!newSet.Contains(s + r))
                    {
                        newSet.Add(s + r);
                    }
                }
            }

            return newSet;

        }
    }
}
