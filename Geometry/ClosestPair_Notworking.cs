using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class ClosestPairCalc
    {        
        double bestDistance = 0.0;
        Point[] bestPair = new Point[2];

        public double FindClosestPair(Point[] points)
        {
            if (points == null) throw new ArgumentException("constructor argument is null");
            for (int i = 0; i < points.Length; i++)
            {
                if (points[i] == null) throw new ArgumentException("array element " + i + " is null");
            }

            int n = points.Length;
            if (n <= 1) throw new ArgumentException("single element as input"); ;


            

        // sort by x-coordinate (breaking ties by y-coordinate)
        Point[] pointsByX = new Point[n];
            for (int i = 0; i < n; i++)
                pointsByX[i] = points[i];

            Array.Sort(pointsByX, new XPointComparer());

            // check for coincident points
            for (int i = 0; i < n - 1; i++)
            {
                if (pointsByX[i].Equals(pointsByX[i + 1]))
                {

                    bestPair[0] = pointsByX[i];
                    bestPair[1] = pointsByX[i + 1];
                }
            }

            // sort by y-coordinate (but not yet sorted) 
            Point[] pointsByY = new Point[n];
            for (int i = 0; i < n; i++)
                pointsByY[i] = pointsByX[i];

            // auxiliary array
            Point[] aux = new Point[n];

            return Closest(pointsByX, pointsByY, aux, 0, n - 1);
        }

        private double Closest(Point[] pointsByX, Point[] pointsByY, Point[] aux, int lo, int hi)
        {
            if (hi <= lo) return Double.PositiveInfinity;

            Point[] bestPair = new Point[2];

            int mid = lo + (hi - lo) / 2;
            Point median = pointsByX[mid];

            // compute closest pair with both endpoints in left subarray or both in right subarray
            double delta1 = Closest(pointsByX, pointsByY, aux, lo, mid);
            double delta2 = Closest(pointsByX, pointsByY, aux, mid + 1, hi);
            double delta = Math.Min(delta1, delta2);

            // merge back so that pointsByY[lo..hi] are sorted by y-coordinate
            Merge(pointsByY, aux, lo, mid, hi);

            // aux[0..m-1] = sequence of points closer than delta, sorted by y-coordinate
            int m = 0;
            for (int i = lo; i <= hi; i++)
            {
                if (Math.Abs(pointsByY[i].x - median.x) < delta)
                    aux[m++] = pointsByY[i];
            }

            // compare each point to its neighbors with y-coordinate closer than delta
            for (int i = 0; i < m; i++)
            {
                // a geometric packing argument shows that this loop iterates at most 7 times
                for (int j = i + 1; (j < m) && (aux[j].y - aux[i].y < delta); j++)
                {
                    double distance = aux[i].Distance(aux[j]);
                    if (distance < delta)
                    {
                        delta = distance;
                        if (distance < bestDistance)
                        {
                            bestDistance = delta;
                            bestPair[0] = aux[i];
                            bestPair[1] = aux[j];
                        }
                    }
                }
            }
            return delta;
        }

        private static void Merge(Point[] a, Point[] aux, int lo, int mid, int hi)
        {
            // copy to aux[]
            for (int k = lo; k <= hi; k++)
            {
                aux[k] = a[k];
            }

            // merge back to a[] 
            int i = lo, j = mid + 1;
            for (int k = lo; k <= hi; k++)
            {
                if (i > mid) a[k] = aux[j++];
                else if (j > hi) a[k] = aux[i++];
                else if (less(aux[j], aux[i])) a[k] = aux[j++];
                else a[k] = aux[i++];
            }
        }

        // is v < w ?
        private static bool less(Point v, Point w)
        {
            return v.CompareTo(w) < 0;
        }
    }
}
