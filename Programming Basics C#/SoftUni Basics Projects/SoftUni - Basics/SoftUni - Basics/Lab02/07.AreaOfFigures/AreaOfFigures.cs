using System;

namespace _07.AreaOfFigures
{
    class AreaOfFigures
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string square = "square";
            string rectangle = "rectangle";
            string circle = "circle";
            string triangle = "triangle";

            double area = 0;

            if (input == square)
            {
                double sideA = double.Parse(Console.ReadLine());
                area = sideA * sideA;
            }

            else if (input == rectangle)
            {
                double sideA = double.Parse(Console.ReadLine());
                double sideB = double.Parse(Console.ReadLine());
                area = sideA * sideB;
            }

            else if (input == circle)
            {
                double radiusR = double.Parse(Console.ReadLine());
                area = Math.PI * Math.Pow(radiusR, 2);
            }

            else if (input == triangle)
            {
                double sideA = double.Parse(Console.ReadLine());
                double heightH = double.Parse(Console.ReadLine());
                area = 0.5 * sideA * heightH;
            }

            Console.WriteLine($"{area:f3}");
        }
    }
}
