using System;

using System.Collections.Generic;
using System.Globalization;
using System.Linq;

using System.Text;

using System.Threading.Tasks;



namespace ConsoleApplication1

{

    /// <summary>

    /// The algorithm to find a pair of closest points 

    /// </summary>

    public static class ClosestPair

    {

        /// <summary>

        /// Find a pair of closest points from the list of points.

        /// </summary>

        /// <param name="points"></param>

        /// <returns></returns>

        public static Point[] Find(List<Point> points)

        {

            if (points == null || points.Count < 2)

            {

                throw new ArgumentException("We need at least two points.");

            }



            // A list of points sorted by X

            List<Point> pointsSortedByX = new List<Point>(points); // copy from points

            pointsSortedByX.Sort(new XPointComparer()); // sort by x

            // A list of points sorted by Y

            List<Point> pointsSortedByY = new List<Point>(points);

            pointsSortedByY.Sort(new YPointComparer());



            return FindClosestPair(pointsSortedByX, pointsSortedByY);

        }



        /// <summary>

        /// Find the closest pair of points

        /// </summary>

        /// <param name="pointsSortedByX">the points sorted by x-coodinate</param>

        /// <param name="pointsSortedByY"the points sorted by y-coodinate></param>

        /// <returns></returns>

        static Point[] FindClosestPair(List<Point> pointsSortedByX, List<Point> pointsSortedByY)

        {
            Point[] bestPair = new Point[2];

            // Less than 2 points, can't find a pair of points, return  null

            if (pointsSortedByX.Count < 2)

            {

                return null;

            }



            // only 2 points, then that 2 points are the pair of closest points

            if (pointsSortedByX.Count == 2)

            {
                bestPair[0] = pointsSortedByX[0];
                bestPair[1] = pointsSortedByX[1];

                return bestPair;

            }



            // split the points to two parts by x-coordinate of point

            var leftPointsSortedByX = pointsSortedByX.Take(pointsSortedByX.Count / 2).ToList();

            var rightPointsSortedByX = pointsSortedByX.Skip(pointsSortedByX.Count / 2).ToList();

            // the x-coordination of the middle line

            var middleX = leftPointsSortedByX.Last().x;



            // split the points which sorted by y-corrdination by the middle line

            var leftPointsSortedByY = pointsSortedByY.Where(p => p.x <= middleX).ToList();

            var rightPointsSortedByY = pointsSortedByY.Where(p => p.x > middleX).ToList();



            // find closest pair points from left and right

            var leftPair = FindClosestPair(leftPointsSortedByX, leftPointsSortedByY);

            var rightPair = FindClosestPair(rightPointsSortedByX, rightPointsSortedByY);



            // get the closer pair from left and right.

            if (leftPair == null)

            {

                bestPair = rightPair;

            }

            else if (rightPair == null)

            {

                bestPair = leftPair;

            }

            else

            {
                double leftPairdist = leftPair[0].Distance(leftPair[1]);
                double rightPairdist = rightPair[0].Distance(rightPair[1]);
                bestPair = leftPairdist < rightPairdist ? leftPair : rightPair;
            }



            return FindCloserPairFromDividerArea(pointsSortedByY, middleX, bestPair);

        }



        /// <summary>

        /// Check if there is a closer distance that arround the divider

        /// </summary>

        /// <param name="pointsSortedByY">The points list which sorted by y-coodinate already</param>

        /// <param name="middleX">The x-coodinate of the middle line which split the points into two parts</param>

        /// <param name="closestPair">The closest pair between left part and right part</param>

        /// <returns>

        /// a pair points which distance closer than minDistanse

        /// return null if could not find any

        /// </returns>

        static Point[] FindCloserPairFromDividerArea(List<Point> pointsSortedByY,

            double middleX, Point[] closestPair)

        {

            double closePairDistance = closestPair[0].Distance(closestPair[1]);
            // find all the points within minDistanse of line middleX.

            var pointsInDividerArea = pointsSortedByY.Where(p => Math.Abs(middleX - p.x) <= closePairDistance);



            // Check all points sorted by y-coodinate

            for (int i = 0; i < pointsSortedByY.Count - 1; i++)

            {

                // need to check only the 7 points

                for (int j = i + 1; j < i + 8 && j < pointsSortedByY.Count; j++)

                {

                    // Check if this pair of points closer than minDistanse

                    if (pointsSortedByY[i].Distance(pointsSortedByY[j]) < closePairDistance)

                    {

                        closestPair[0] = pointsSortedByY[i];
                        closestPair[1] = pointsSortedByY[j];

                    }

                }

            }

            return closestPair;

        }


        private static Point[] NaiveClosestPair(List<Point> points)
        {
            Point[] closestPair = new Point[2];
            var minDistance = Double.MaxValue;

            for (int i = 0; i < points.Count; i++)
            {
                for (int j = i + 1; j < points.Count; j++)
                {
                    var dist = points[i].Distance(points[j]);
                    if (dist < minDistance)
                    {
                        minDistance = dist;
                        closestPair[0] = points[i];
                        closestPair[1] = points[j];
                    }
                }
            }
           
            return closestPair;
        }
    
    public static void InternalMain()

        {

            //Point[] P =

            //{

            //    new Point( 2, 3 ),

            //    new Point( 12, 30 ),

            //    new Point( 40, 50 ),

            //    new Point( 5, 1 ),

            //    new Point( 12, 10 ),

            //    new Point( 3, 4 )

            //};


            Point[] P =
            {
                new Point(0, 2),
                new Point(6, 67),
                new Point(43, 71),
                new Point(39, 107),
                new Point(189, 140)
            };

            List<Point> points = new List<Point>();
            points.AddRange(P);
            int n = P.Length;
            //var r = Find(points);
            //Console.WriteLine("The smallest distance is " + r[0].Distance(r[1]));

            var r = NaiveClosestPair(points);
            Console.WriteLine("The smallest distance is " + r[0].Distance(r[1]));

        }

    }

}