using System;
using System.Linq;

namespace _04._2.CenterPoint
{
    internal class CenterPoint
    {
        static void Main(string[] args)
        {
            double p1x = double.Parse(Console.ReadLine());
            double p2y = double.Parse(Console.ReadLine());
            double p3x = double.Parse(Console.ReadLine());
            double p4y = double.Parse(Console.ReadLine());
            
            Console.WriteLine($"({string.Join(", ", ClosestSet(p1x, p2y, p3x, p4y).ToArray())})");
        }

        static double[] ClosestSet(double p1x, double p2y, double p3x, double p4y)
        {
            double[] closestPoint = new double[2];

            if (Math.Abs(p1x) + Math.Abs(p2y) <= Math.Abs(p3x) + Math.Abs(p4y))
            {
                closestPoint[0] = p1x;
                closestPoint[1] = p2y;
            }

            else
            {
                closestPoint[0] = p3x;
                closestPoint[1] = p4y;
            }

            return closestPoint;
        }
    }
}
