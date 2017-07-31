using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class BruteCollinearPoints
    {
    private LineSegment[] lineSegments;
    public BruteCollinearPoints(Point[] points)
    {
        checkNull(points);
        checkDuplicate(points);
        int N = points.Length;
        List<LineSegment> list = new List<LineSegment>();
        for (int i=0; i< N-3; i++)
        {
            for(int j=i+1; j< N-2; j++)
            {
                double slopeAB = points[i].slopeTo(points[j]);
                for(int k=j+1; k< N-1; k++)
                {
                    double slopeAC = points[i].slopeTo(points[k]);
                    if (slopeAB != slopeAC) continue;
                    for (int l=k+1; l <N; l++)
                    {
                        double slopeAD = points[i].slopeTo(points[l]);

                        if (slopeAB == slopeAD)
                        {
                            list.Add(new LineSegment(points[i], points[l]));
                        }
                    }
                }
            }
        }

        this.lineSegments = list.ToArray<LineSegment>();
    }

    private void checkNull(Point[] points)
    {
        if (points == null) throw new NullReferenceException();
        foreach(var p in points)
        {
            if(p == null) throw new NullReferenceException();
        }
    }

    private void checkDuplicate(Point[] points)
    {
        Array.Sort<Point>(points);
        for(int i=1; i< points.Length; i++)
        {
            if(points[i-1].CompareTo(points[i]) == 0) throw new ArgumentException();
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

        BruteCollinearPoints bp = new BruteCollinearPoints(points);

        foreach(var segment in bp.lineSegments)
        {
            Console.WriteLine($"{segment.toString()}");
        }

        Console.ReadLine();


    }

}

