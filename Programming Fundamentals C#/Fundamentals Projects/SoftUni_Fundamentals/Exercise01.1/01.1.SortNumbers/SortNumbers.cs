using System;
using System.Collections.Generic;

namespace _01._1.SortNumbers
{
    class SortNumbers
    {
        static void Main(string[] args)
        {
            double num1 = double.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());
            double num3 = double.Parse(Console.ReadLine());
            List<double> sortedNums = new List<double>(3);
            Sorted(sortedNums, num1, num2, num3);
        }

        static void Sorted(List<double> sortedNums, double num1, double num2, double num3)
        {
            sortedNums.Add(num1);
            sortedNums.Add(num2);
            sortedNums.Add(num3);
            sortedNums.Sort();
            sortedNums.Reverse();

            foreach (double number in sortedNums)
            {
                Console.WriteLine(number);
            }
            return;
        }
    }
}
