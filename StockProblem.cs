using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class StockProblem
    {
        public static int ContiguosMaxSum(int[] arr)
        {
            //int min = arr[0];
            int currSum = arr[0];
            int maxSum = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                if ((currSum + arr[i]) > 0)
                    currSum += arr[i];
                else
                {
                    if (currSum > maxSum)
                        maxSum = currSum;
                    currSum = 0;
                }
            }

            //max could be at the end when there are no -ve values so edge case to check it
            if (currSum > maxSum) maxSum = currSum;

            return maxSum;
        }

        //TO Do - Rewrite
        public static Tuple<int, int> ContiguosMaxSumIndexes(int[] arr)
        {
            //int min = arr[0];
            int currSum = arr[0];
            int maxSum = int.MinValue;
            int start = 0;
            int end = 0;
            int currentStart = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                if ((currSum == 0) && arr[i] > 0) currentStart = i;
                if ((currSum + arr[i]) > 0)
                {
                    currSum += arr[i];
                }
                else
                {
                    if (currSum > maxSum)
                    {
                        maxSum = currSum;
                        end = --i;
                        start = currentStart;
                    }

                    currSum = 0;
                }
            }

            //max could be at the end when there are no -ve values so edge case to check it
            if (currSum > maxSum)
            {
                maxSum = currSum;
                end = arr.Length - 1;
                start = currentStart;
            }
            if (maxSum == int.MinValue)
                return new Tuple<int, int>(-1, -1);

            return new Tuple<int, int>(start, end);
        }

        internal struct Loc
        {
            internal int x;
            internal int y;
            internal Loc(int px, int py)
            {
                x = px;
                y = py;
            }
        }

        //look at below alternate imp
        internal static Tuple<Loc, int> FindMaxProfitByBuyingAndSellingOnceUsingStruct(int[] arr)
        {
            if (arr.Length < 2) return new Tuple<Loc, int>(new Loc(-1, -1), -1);
            int min = arr[0];
            int max = arr[1];
            Loc l = new Loc(0, 0);

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i]; l.x = i;
                    max = arr[i]; l.y = i;
                }
                if (arr[i] > max)
                {
                    max = arr[i]; l.y = i;
                }
            }

            if (min == max) new Tuple<Loc, int>(new Loc(-1, -1), -1);
            return new Tuple<Loc, int>(l, max - min);

        }
        //look at above bleow imp, this is testing
        internal static Tuple<Tuple<int, int>, int> FindMaxProfitByBuyingAndSellingOnce(int[] arr)
        {
            if (arr.Length < 2) return new Tuple<Tuple<int, int>, int>(new Tuple<int, int>(-1, -1), -1);
            int min = arr[0];
            int max = arr[0];
            int minLoc = 0;
            int maxLoc = 0;
            int cmin = min;
            int cmax = max;
            int cminLoc = 0;
            int cmaxLoc = 0;

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < cmin)
                {
                    cmin = arr[i]; cminLoc = i;
                    cmax = arr[i]; cmaxLoc = i;
                }

                if (arr[i] > cmax)
                {
                    cmax = arr[i]; cmaxLoc = i;
                }

                if ((cmax - cmin) > (max - min))
                {
                    max = cmax;
                    min = cmin;
                    minLoc = cminLoc;
                    maxLoc = cmaxLoc;
                }
            }

            if (min == max) return new Tuple<Tuple<int, int>, int>(new Tuple<int, int>(-1, -1), -1);
            return new Tuple<Tuple<int, int>, int>(new Tuple<int, int>(minLoc, maxLoc), (max - min));

        }

        
        internal static Tuple<Tuple<int, int>, int> FindMaxProfitByBuyingAndSellingOnceAndTrackingFromLast(int[] arr)
        {
            if (arr.Length < 2) return new Tuple<Tuple<int, int>, int>(new Tuple<int, int>(-1, -1), -1);
            int last = arr.Length - 1;
            int min = arr[last];
            int max = arr[last];
            int minLoc = last;
            int maxLoc = last;

            for (int i = arr.Length - 2; i >=0; i--)
            {
                if (arr[i] > max)
                {
                    min = arr[i]; minLoc = i;
                    max = arr[i]; maxLoc = i;
                }
                if (arr[i] < min)
                {
                    min = arr[i]; minLoc = i;
                }
            }

            if (min == max) return new Tuple<Tuple<int, int>, int>(new Tuple<int, int>(-1, -1), -1);
            return new Tuple<Tuple<int, int>, int>(new Tuple<int, int>(minLoc, maxLoc), (max - min));
        }

        //TO Add comments
        internal static int FindMaxProfitByBuyingAndSellingManyTimes(int[] arr)
        {
            if (arr.Length < 2) return 0;
            int totalProfit = 0;
            int min = arr[0];
            int max = arr[0];

            for(int i=1; i<arr.Length; i++)
            {
                if(arr[i] > max)
                {
                    max = arr[i];
                }
                else if(arr[i] < max)
                {

                    totalProfit += (max - min);
                    min = arr[i];
                    max = arr[i];
                }
            }
            //edge case when we end array with increasing number.
            totalProfit += (max - min);
            return totalProfit;
        }
    }
}
