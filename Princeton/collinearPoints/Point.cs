/******************************************************************************
 *  Compilation:  javac Point.java
 *  Execution:    java Point
 *  Dependencies: none
 *  
 *  An immutable data type for points in the plane.
 *  For use on Coursera, Algorithms Part I programming assignment.
 *
 ******************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using StdLib;

public class Point : IComparable<Point>{

    private readonly int x;     // x-coordinate of this point
    private readonly int y;     // y-coordinate of this point

/**
 * Initializes a new point.
 *
 * @param  x the <em>x</em>-coordinate of the point
 * @param  y the <em>y</em>-coordinate of the point
 */
public Point(int x, int y)
{
    /* DO NOT MODIFY */
    this.x = x;
    this.y = y;
}

    public Point(Point p)
    {
        /* DO NOT MODIFY */
        this.x = p.x;
        this.y = p.y;
    }

    /**
     * Returns the slope between this point and the specified point.
     * Formally, if the two points are (x0, y0) and (x1, y1), then the slope
     * is (y1 - y0) / (x1 - x0). For completeness, the slope is defined to be
     * +0.0 if the line segment connecting the two points is horizontal;
     * Double.POSITIVE_INFINITY if the line segment is vertical;
     * and Double.NEGATIVE_INFINITY if (x0, y0) and (x1, y1) are equal.
     *
     * @param  that the other point
     * @return the slope between this point and the specified point
     */
    public double slopeTo(Point that)
{
    if (that == null)
    {
        throw new NullReferenceException();
    }
    if ((this.y - that.y) == 0) return 0.0;
    if ((this.x - that.x) == 0) return double.PositiveInfinity;
    if (((this.y - that.y) == 0) && ((this.x - that.x) == 0)) return double.NegativeInfinity;

    return ((this.y - that.y) * 1.0 / (this.x - that.x));
}

/**
 * Compares two points by y-coordinate, breaking ties by x-coordinate.
 * Formally, the invoking point (x0, y0) is less than the argument point
 * (x1, y1) if and only if either y0 < y1 or if y0 = y1 and x0 < x1.
 *
 * @param  that the other point
 * @return the value <tt>0</tt> if this point is equal to the argument
 *         point (x0 = x1 and y0 = y1);
 *         a negative integer if this point is less than the argument
 *         point; and a positive integer if this point is greater than the
 *         argument point
 */
public int CompareTo(Point that)
{
    if ((this.y == that.y) && (this.x == that.x)) return 0;
    else if (((this.y == that.y) && (this.x == that.x)) || (this.y < that.y)) return -1;
    else return 1;
}

    /**
     * Compares two points by the slope they make with this point.
     * The slope is defined as in the slopeTo() method.
     *
     * @return the Comparator that defines this ordering on points
     */
    public IComparer<Point> slopeOrder()
    {
        /* YOUR CODE HERE */
        return new SlopeComparator(this);
    }

    private class SlopeComparator : IComparer<Point> {

        private  Point point;

        internal SlopeComparator(Point point)
        {
            this.point = point;
        }
        
        public int Compare(Point p1, Point p2)
    {
        double slope1 = p1.slopeTo(point);
        double slope2 = p2.slopeTo(point);
        return ((slope1 == slope2) ? 0 : (slope1 > slope2 ? 1 : -1));
    }
}

/**
 * Returns a string representation of this point.
 * This method is provide for debugging;
 * your program should not rely on the format of the string representation.
 *
 * @return a string representation of this point
 */
public override string ToString()
{
    /* DO NOT MODIFY */
    return "(" + x + ", " + y + ")";
}

    public static Point[] Clone(Point[] points)
    {
        Point[] clone = new Point[points.Length];
        for (int i = 0; i < points.Length; i++)
        {
            clone[i] = new Point(points[i]);
        }
        return clone;
    }
    public static void DisplayPoints(Point[] points)
    {
        foreach (var p in points)
        {
            Console.Write($"({p.x}, {p.y}) -->");
        }
        Console.WriteLine();
    }

    /**
     * Unit tests the Point data type.
     */
    public static void Main(String[] args)
    {
        int N = 5;
        Point[] points = new Point[N];
        
        //for (int i = 0; i < N; i++)
        //{
        //    int x = StdRandom.Uniform(100);
        //    int y = StdRandom.Uniform(100);
        //    points[i] = new Point(x, y);
        //}

        for (int i = 1; i <= N; i++)
        {
            int x = i;
            int y = i;
            points[i-1] = new Point(x, y);
        }

        DisplayPoints(points);

        Point[] pointsClone = (Point[])points.Clone();

        Array.Sort<Point>(points);
        Point[] sortedPoints = (Point[])points.Clone();

        DisplayPoints(sortedPoints);

        foreach (var p in pointsClone)
        {
            Array.Sort<Point>(pointsClone, p.slopeOrder());

            DisplayPoints(pointsClone);
        }
    }
    
}

//public class PointComparer : IComparer<Point>
//{
//    public int Compare(Point x, Point y)
//    {
//        double val = slopeTo(x) - slopeTo(y);
//        if (val > 0) return 1;
//        else if (val < 0) return -1;
//        else return 0;
//    }
//}
