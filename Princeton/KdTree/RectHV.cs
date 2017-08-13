using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Princeton
{
    public class RectHV
    {
        private double pxmin, pymin, pxmax, pymax;
        // construct the rectangle [xmin, xmax] x [ymin, ymax] // throw a java.lang.IllegalArgumentException if (xmin > xmax) or (ymin > ymax)
        public RectHV(double xmin, double ymin,
            double xmax, double ymax)
        {
            this.pxmin = xmin;
            this.pymin = ymin;
            this.pxmax = xmax;
            this.pymax = ymax;
        }
        // minimum x-coordinate of rectangle 
        public double xmin()
        {
            return this.pxmin;
        }
        // minimum y-coordinate of rectangle  
        public double ymin()
        {
            return this.pymin;
        }
        // maximum x-coordinate of rectangle 
        public double xmax()
        {
            return this.pxmax;
        }
        // maximum y-coordinate of rectangle                 
        public double ymax()
        {
            return this.pymax;
        }
        // does this rectangle contain the point p (either inside or on boundary)?                 
        public bool Contains(Point2D p)
        {
            return ((this.xmin() <= p.x()) && (p.x() <= this.xmax())
                        && (this.ymin() <= p.y()) && (p.y() <= this.ymax())
                );
        }

        public int ContainsInX(Point2D p)
        {
            if ((this.xmin() <= p.x()) && (p.x() <= this.xmax()))
                return 0;
            else if (p.x() > this.xmax())
                return 1;
            else return -1;
        }

        public int ContainsInY(Point2D p)
        {
            if ((this.ymin() <= p.y()) && (p.y() <= this.ymax()))
                return 0;
            else if (p.y() > this.ymax())
                return 1;
            else return -1;
        }
        // does this rectangle intersect that rectangle (at one or more points)?      
        public bool Intersects(RectHV that)
        {
            return ((this.Contains(new Point2D(xmin(), ymin()))) || (this.Contains(new Point2D(xmax(), ymax())))
                 || (that.Contains(new Point2D(that.xmin(), that.ymin()))) || (that.Contains(new Point2D(that.xmax(), that.ymax()))));
        }
        // Euclidean distance from point p to closest point in rectangle 
        public double distanceTo(Point2D p)
        {
            double d1 = p.distanceTo(new Point2D(xmin(), ymin()));
            double d2 = p.distanceTo(new Point2D(xmax(), ymax()));

            return (d1 < d2 ? d1 : d2);
        }
        // square of Euclidean distance from point p to closest point in rectangle 
        public double distanceSquaredTo(Point2D p)
        {
            double d1 = p.distanceSquaredTo(new Point2D(xmin(), ymin()));
            double d2 = p.distanceSquaredTo(new Point2D(xmax(), ymax()));

            return (d1 < d2 ? d1 : d2);

        }

        // does this rectangle equal that object? 
        public override bool Equals(Object that)
        {
            return (this.ToString().Equals(that.ToString()));

        }             
       //public void draw()    // draw to standard draw 

       public override string ToString()
        {
            /* DO NOT MODIFY */
            return "((" + xmin() + ", " + ymin() + ")" + "," + "(" + xmax() + ", " + ymax() + "))";
        }

    }
}
