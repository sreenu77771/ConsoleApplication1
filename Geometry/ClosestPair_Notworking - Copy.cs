using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class ClosestPair_Notworking1
    {
        public List<Point> _points = new List<Point>();
        public int Distance { get; private set; }
        const double MaxDistance = 10000;

        double bestDistance = 0.0;

        Point[] bestPair = new Point[2];

        public ClosestPair_Notworking1(int n)
        {
            var rand = new Random();
            for (var i = 0; i < n; i++)
            {
                _points.Add(new Point
                {
                    x = rand.Next(-10000, 10000),
                    y = rand.Next(-10000, 10000),
                });
            }
            _points.Sort();
        }

        public ClosestPair_Notworking1()
        {
        }

        public static void InternalMain()
        {
            ClosestPair_Notworking p = new ClosestPair_Notworking();
            p._points =  new List<Point>();
            p._points.Add(new Point(0, 2));
            p._points.Add(new Point(6, 67));
            p._points.Add(new Point(43, 71));
            p._points.Add(new Point(39, 107));
            p._points.Add(new Point(189, 140));
            //{ new Point( 2, 3 ), { 12, 30 }, { 40, 50 }, { 5, 1 }, { 12, 10 }, { 3, 4 } };
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var r = p.Run();
            Console.WriteLine(r);
            //Console.WriteLine(string.Format("{0}\n{1}\n", r[0], r[1]));
            //Console.WriteLine(string.Format("Distance: {0}\n", r[0].Distance(r[1])));
            stopwatch.Stop();
        }

        public double Run()
        {
            return SmartClosestPair(_points.ToArray());
        }

        public double SmartClosestPair(Point[] points)
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
                            // StdOut.println("better distance = " + delta + " from " + best1 + " to " + best2);
                        }
                    }
                }
            }
            return delta;
        }

        // stably merge a[lo .. mid] with a[mid+1 ..hi] using aux[lo .. hi]
        // precondition: a[lo .. mid] and a[mid+1 .. hi] are sorted subarrays
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

        private Point[] SmartClosestPair_NotWorking(List<Point> points)
        {
            double crtMinDist = 20000;
            Point[] closestPair = new Point[2];

            //Point[] sortedPoints = new Point[points.Count];
            //Array.Copy(points, 0, sortedPoints, 0, points.Count);

            List<Point> sortedPoints = new List<Point>();
            sortedPoints.AddRange(points);
            sortedPoints.Sort(new XPointComparer());

            int leftIndex = 0;

            SortedSet<Point> candidates = new SortedSet<Point>(new YPointComparer());
            foreach (var current in sortedPoints)
            {
                // Shrink the candidates
                while (current.x - sortedPoints[leftIndex].x > crtMinDist)
                {
                    candidates.Remove(sortedPoints[leftIndex]);
                    leftIndex++;
                }

                // Compute the y head and the y tail of the candidates set
                var head = new Point { x = current.x, y = (int)checked(current.y - crtMinDist) };
                var tail = new Point { x = current.x, y = (int)checked(current.y + crtMinDist) };

                // We take only the interesting candidates in the y axis                
                var subset = candidates.GetViewBetween(head, tail);
                foreach (var point in subset)
                {
                    var distance = current.Distance(point);
                    if (distance < 0) throw new ApplicationException("number overflow");

                    // Simple min computation
                    if (distance < crtMinDist)
                    {
                        crtMinDist = distance;
                        closestPair[0] = current;
                        closestPair[1] = point;
                    }
                }

                // The current point is now a candidate
                candidates.Add(current);
            }

            return closestPair;
        }

        

        public Point[] Run2()
        {
            return NaiveClosestPair(_points);
        }

        private Point[] NaiveClosestPair(List<Point> points)
        {
            Point[] closestPair = new Point[2];
            var minDistance = Double.MaxValue;
            foreach (var p in points)
            {
                foreach (var q in points)
                {
                    if (p.Equals(q)) continue;

                    var dist = p.Distance(q);
                    if (dist < minDistance)
                    {
                        closestPair[0] = p;
                        closestPair[1] = q;
                    }
                }
            }

            return closestPair;
        }
    }
}
