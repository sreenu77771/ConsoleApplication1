using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class FastCollinearPoints
{
    private LineSegment[] lineSegments;
    public FastCollinearPoints(Point[] points)
    {
        checkNull(points);
        checkDuplicate(points);
        int N = points.Length;

        Array.Sort<Point>(points);

        List<LineSegment> list = new List<LineSegment>();
        
        for (int i = 0; i < N; i++)
        {
            Point[] sortedPoints = Point.Clone(points);
            Array.Sort<Point>(sortedPoints, points[i].slopeOrder());

            int x = 1;
            while(x < N)
            {
                List<Point> collinearPoints = new List<Point>();
                double slopeRef = points[i].slopeTo(sortedPoints[x]);
                do
                {
                    collinearPoints.Add(sortedPoints[x++]);

                } while (x < N && points[i].slopeTo(sortedPoints[x]) == slopeRef);
                if (collinearPoints.Count >=3 && points[i].CompareTo(collinearPoints[0]) < 0)
                {
                    list.Add(new LineSegment(points[i], collinearPoints[collinearPoints.Count - 1]));
                }
            }
        }

        this.lineSegments = list.ToArray<LineSegment>();
    }

    private void checkNull(Point[] points)
    {
        if (points == null) throw new NullReferenceException();
        foreach (var p in points)
        {
            if (p == null) throw new NullReferenceException();
        }
    }

    private void checkDuplicate(Point[] points)
    {
        Array.Sort<Point>(points);
        for (int i = 1; i < points.Length; i++)
        {
            if (points[i - 1].CompareTo(points[i]) == 0) throw new ArgumentException();
        }
    }

    /**
     * The number of line segments.
     */
    public int numberOfSegments()
    {
        return lineSegments.Length;
    }

    /**
     * The line segments.
     */
    public LineSegment[] segments()
    {
        return (LineSegment[])lineSegments.Clone();
    }

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
            points[i - 1] = new Point(x, y);
        }

        FastCollinearPoints bp = new FastCollinearPoints(points);

        foreach (var segment in bp.lineSegments)
        {
            Console.WriteLine($"{segment.toString()}");
        }

        Console.ReadLine();


    }

}

