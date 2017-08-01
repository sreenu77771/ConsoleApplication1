using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Point : IComparable<Point>
    {
        internal int x;
        internal int y;

        internal Point()
        {
        }

        internal Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int CompareTo(Point other)
        {
            return new XPointComparer().Compare(this, other);
        }

        public bool Equals(Point p)
        {
            if (p == null) return false;
            return (this.x == p.x) && (this.y == p.y);
        }
        
        public double Distance(Point q)
        {
            return Math.Round(Math.Sqrt(Math.Pow((q.x - this.x), 2) + Math.Pow((q.y - this.y), 2)), 4);
        }

    }

    public class XPointComparer : IComparer<Point>
    {
        public int Compare(Point px, Point py)
        {
            if (px == null || py == null) throw new ArgumentException();
            if (px.Equals(py)) return 0;
            else if (px.x > py.x) return 1;
            else if (px.x < py.x) return -1;
            else if (px.y > py.y) return 1;
            else return -1;
        }
    }

    public class YPointComparer : IComparer<Point>
    {
        public int Compare(Point px, Point py)
        {
            if (px == null || py == null) throw new ArgumentException();
            if (px.Equals(py)) return 0;
            else if (px.y > py.y) return 1;
            else if (px.y < py.y) return -1;
            else if (px.x > py.x) return 1;
            else return -1;
        }
    }
}
