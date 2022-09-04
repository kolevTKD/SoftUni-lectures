using System;
using System.Linq;

namespace _04._3.LongerLine
{
    internal class LongerLine
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());
            double x4 = double.Parse(Console.ReadLine());
            double y4 = double.Parse(Console.ReadLine());

            LongestLine(x1, y1, x2, y2, x3, y3, x4, y4);

        }

        static void LongestLine(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
        {
            double[] point1 = new double[2] {x1, y1 };
            double[] point2 = new double[2] {x2, y2 };
            double[] point3 = new double[2] {x3, y3 };
            double[] point4 = new double[2] {x4, y4 };
            double absPoint1 = Math.Abs(point1.Sum());
            double absPoint2 = Math.Abs(point2.Sum());
            double absPoint3 = Math.Abs(point3.Sum());
            double absPoint4 = Math.Abs(point4.Sum());

            if (absPoint1 + absPoint2 >= absPoint3 + absPoint4) // ако първата линия е по-дълга от втората
            {
                if (absPoint1 <= absPoint2) // ако първата точка е по-близо до центъра от втората
                {
                    Console.WriteLine($"({string.Join(", ", point1)})({string.Join(", ", point2)})");
                }

                else // ако втората точка е по-близо до центъра от първата
                {
                    Console.WriteLine($"({string.Join(", ", point2)})({string.Join(", ", point1)})");
                }
            }

            else // ако втората линия е по-дълга от първата
            {
                if (absPoint3 <= absPoint4) // ако първата точка е по-близо до центъра от втората
                {
                    Console.WriteLine($"({string.Join(", ", point3)})({string.Join(", ", point4)})");
                }

                else // ако втората точка е по-близо до центъра от първата
                {
                    Console.WriteLine($"({string.Join(", ", point4)})({string.Join(", ", point3)})");
                }
            }
        }
    }
}
