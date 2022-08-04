using System;

namespace _02._3.FloatingEquality
{
    class FloatingEquality
    {
        static void Main(string[] args)
        {
            double num1 = double.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());
            double eps = 0.000001f;
            bool areNumsEqual = false;

            if (Math.Abs(num1 - num2) < eps)
            {
                areNumsEqual = true;
            }

            Console.WriteLine(areNumsEqual);
        }
    }
}
