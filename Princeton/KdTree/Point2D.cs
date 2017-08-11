using System;
using System.Collections.Generic;

namespace Princeton
{
    public class Point2D : IComparable<Point2D>
    {

        private double px;
        private double py;
        // construct the point (x, y)
        public Point2D(double x, double y)
        {
            this.px = x;
            this.py = y;
        }
        // x-coordinate 
        public double x()
        {
            return px;
        }
        // y-coordinate
        public double y()
        {
            return py;
        }

        // Euclidean distance between two points                       
        public double distanceTo(Point2D that)
        {
            return Math.Round(Math.Sqrt(Math.Pow((that.x() - this.x()), 2) + Math.Pow(that.y() - this.y(), 2)), 4);
        }
        // square of Euclidean distance between two points     
        public double distanceSquaredTo(Point2D that)
        {
            return Math.Round(Math.Pow((that.x() - this.x()), 2) + Math.Pow(that.y() - this.y(), 2), 4);
        }

        // does this point equal that object? 
        public override bool Equals(Object p)
        {
            var that = p as Point2D;
            return (this.CompareTo(that) == 0);
            //if ((this.y() == that.y()) && (this.x() == that.x())) return true;
            //return false;
        }
        //public void draw()           
        // string representation // draw to standard draw 
        public override string ToString()
        {
            /* DO NOT MODIFY */
            return "(" + x() + ", " + y() + ")";
        }
        public int CompareTo(Point2D that)
        {
            //if ((this.y() == that.y()) && (this.x() == that.x())) return 0;
            //else if (((this.y() == that.y()) && (this.x() == that.x())) || (this.y() < that.y())) return -1;
            //else return 1;

            return new XPoint2DComparer().Compare(this, that);
        }

        //int IComparable<Point2D>.CompareTo(Point2D that)
        //{
        //    if ((this.y() == that.y()) && (this.x() == that.x())) return 0;
        //    else if (((this.y() == that.y()) && (this.x() == that.x())) || (this.y() < that.y())) return -1;
        //    else return 1;
        //}

    }

    public class XPoint2DComparer : IComparer<Point2D>
    {
        public int Compare(Point2D px, Point2D py)
        {
            if (px == null || py == null) throw new ArgumentException();
            if (px.Equals(py)) return 0;
            else if (px.x() > py.x()) return 1;
            else if (px.x() < py.x()) return -1;
            else if (px.y() > py.y()) return 1;
            else return -1;
        }
    }

    public class YPoint2DComparer : IComparer<Point2D>
    {
        public int Compare(Point2D px, Point2D py)
        {
            if (px == null || py == null) throw new ArgumentException();
            if (px.Equals(py)) return 0;
            else if (px.y() > py.y()) return 1;
            else if (px.y() < py.y()) return -1;
            else if (px.x() > py.x()) return 1;
            else return -1;
        }
    }
}
