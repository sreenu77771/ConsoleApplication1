using System;//
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class FindIfSquare
    {

        public static void InternalMain()
        {
            //string input = Console.ReadLine();
            //string input = "(10,20), (10,10), (20,20), (20,10)";
            //string input = "(1,6), (6,7), (2,7), (9,1)";
            string input = "(4,6), (5,5), (5,6), (4,5)";

            Point[] points = ParseInput(input);

            Console.WriteLine(IsValidSquareAlt(points));
            Console.WriteLine(IsValidSquare(points));

        }

        private static bool IsValidSquare(Point[] points)
        {
            //distances between points
            double[] lengths = new double[6];
            int lenPointer = 0;
            for (int i = 0; i < points.Length; i++)
            {
                for (int j = i + 1; j < points.Length; j++)
                {
                    lengths[lenPointer++] = points[i].Distance(points[j]);
                }
            }

            Array.Sort(lengths);
            return ValidateDistanceForSquare(lengths);
        }

        private static bool IsValidSquareAlt(Point[] points)
        {            
            Array.Sort(points);

            //check all sides distance
            double d01 = points[0].Distance(points[1]);
            double d02 = points[0].Distance(points[2]);
            double d31 = points[3].Distance(points[1]);
            double d32 = points[3].Distance(points[2]);

            double d03 = points[0].Distance(points[3]);
            double d12 = points[1].Distance(points[2]);

            if ((d01 == d02) && (d02 == d31) && (d31 == d32) && (d32 == d01) && (d03 == d12))
                return true;
            return false;
        }

        private static bool ValidateDistanceForSquare(double[] lengths)
        {
            int i = 1;
            while ((i < lengths.Length) && lengths[i - 1].Equals(lengths[i]))
            {
                i++;
            }
            if (i != 4 || !lengths[4].Equals(lengths[5]))
                return false;

            return true;
        }

        private static Point[] ParseInput(string input)
        {
            Point[] points = new Point[4];
            try
            {
                string[] inputTokens = input.Split(new string[]{ ", " }, StringSplitOptions.None);
                int i = 0;
                foreach (var t in inputTokens)
                {
                    var trimmedT = t.Trim(new char[] { ' ', '(', ')' });
                    var splitT = trimmedT.Split(',');
                    int x = Int32.Parse(splitT[0]);
                    int y = Int32.Parse(splitT[1]);
                    points[i++] = new Point(x, y);
                }
            }
            catch (Exception)
            {
                throw new ArgumentException("input in wrong format/ unexpected");
            }
            return points;
        }

    }


}
