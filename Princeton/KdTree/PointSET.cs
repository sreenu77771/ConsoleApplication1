using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Princeton
{
    public class PointSET 
    {
        private SortedSet<Point2D> set = new SortedSet<Point2D>();
        // construct an empty set of points 
        public PointSET()
        {

        }

        // is the set empty? 
        public bool isEmpty()
        {
            return set.Count == 0;
        }
        // number of points in the set 
        public int size()
        {
            return set.Count;
        }
        // add the point to the set (if it is not already in the set)
        public void insert(Point2D p)
        {
            set.Add(p);
        }
        // does the set contain point p? 
        public bool contains(Point2D p)
        {
            return set.Contains(p);
        }
        //public void draw()                         // draw all points to standard draw 

        // all points that are inside the rectangle (or on the boundary) 
        public IEnumerator<Point2D> range(RectHV rect)
        {
            List<Point2D> inRangePoints = new List<Point2D>();
            foreach(var p in set)
            {
                if (rect.Contains(p))
                    inRangePoints.Add(p);
            }
            return inRangePoints.GetEnumerator();
        }

        // a nearest neighbor in the set to point p; null if the set is empty 
        public Point2D nearest(Point2D p)
        {
            double distance = double.MaxValue;
            Point2D nearestPoint = null; 
            foreach (var point in set)
            {
                double d = p.distanceTo(point);
                if (d < distance)
                {
                    distance = d;
                    nearestPoint = point;
                }
            }

            return nearestPoint;
        }

        // unit testing of the methods (optional) 
        public static void InternalMain()
        {
            //List<Point2D>

            PointSET set = new PointSET();
            set.insert(new Point2D(.2, .2));
            set.insert(new Point2D(.1, .2));
            set.insert(new Point2D(.3, .2));
            set.insert(new Point2D(.3, .3));
            set.insert(new Point2D(.4, .4));

            RectHV rect = new RectHV(0, 0, .2, 1);

            var iterator = set.range(rect);

            while(iterator.MoveNext())
            {
                Point2D p = iterator.Current;
                DisplayPoint(p);
            }

            var n = set.nearest(new Point2D(0, 0));
            DisplayPoint(n);

            Console.Read();
        }
        public static void DisplayPoint(Point2D p)
        {
            Console.Write($"({p.x()}, {p.y()}) -->");
        }
        public static void DisplayPoints(Point2D[] points)
        {
            foreach (var p in points)
            {
                Console.Write($"({p.x()}, {p.y()}) -->");
            }
            Console.WriteLine();
        }
    }
}
