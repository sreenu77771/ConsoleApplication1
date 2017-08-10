using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Princeton.KdTree
{
    public class PointSET 
    {
        // construct an empty set of points 
        public PointSET()
        {

        }

        // is the set empty? 
        public bool isEmpty()
        {

        }
        // number of points in the set 
        public int size()
        {

        }
        // add the point to the set (if it is not already in the set)
        public void insert(Point2D p)
        {

        }
        // does the set contain point p? 
        public bool contains(Point2D p)
        {

        }
        //public void draw()                         // draw all points to standard draw 

        // all points that are inside the rectangle (or on the boundary) 
        public IEnumerator<Point2D> range(RectHV rect)
        {

        }

        // a nearest neighbor in the set to point p; null if the set is empty 
        public Point2D nearest(Point2D p)
        {

        }

        // unit testing of the methods (optional) 
        public static void InternalMain()
        {
        }
    }
}
