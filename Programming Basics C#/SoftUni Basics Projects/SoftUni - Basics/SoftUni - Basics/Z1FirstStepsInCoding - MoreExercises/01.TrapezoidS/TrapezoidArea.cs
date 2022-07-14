using System;

namespace _01.TrapezoidS
{
    class TrapezoidArea
    {
        static void Main(string[] args)
        {
            double sideA = double.Parse(Console.ReadLine());
            double sideB = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double perimeter = (sideA + sideB) * height / 2;
            Console.WriteLine($"{perimeter:f2}");
        }
    }
}
