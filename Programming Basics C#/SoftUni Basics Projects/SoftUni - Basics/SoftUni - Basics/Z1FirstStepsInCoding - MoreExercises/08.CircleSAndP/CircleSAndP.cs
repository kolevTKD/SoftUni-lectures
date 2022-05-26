using System;

namespace _08.CircleSAndP
{
    class CircleSAndP
    {
        static void Main(string[] args)
        {
            double circleRadius = double.Parse(Console.ReadLine());
            double circleArea = Math.PI * Math.Pow(circleRadius, 2);
            double circlePerimeter = 2 * Math.PI * circleRadius;

            Console.WriteLine($"{circleArea:f2}");
            Console.WriteLine($"{circlePerimeter:f2}");
        }
    }
}
