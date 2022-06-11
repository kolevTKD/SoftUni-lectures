using System;

namespace _06.CalculateRectangleArea
{
    class CalculateRectangleArea
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double heigth = double.Parse(Console.ReadLine());
            double area = RectArea(width, heigth);
            Console.WriteLine(area);
        }

        static double RectArea(double width, double heigth)
        {
            return width * heigth;
        }
    }
}
