using System;

namespace _05.AverageNumber
{
    class AverageNumber
    {
        static void Main(string[] args)
        {
            int numCount = int.Parse(Console.ReadLine());
            double total = 0;
            double avg = 0;

            for (int i = 1; i <= numCount; i++)
            {
                int newNum = int.Parse(Console.ReadLine());
                total += newNum;
                avg = total / i;
            }

            Console.WriteLine($"{avg:f2}");
        }
    }
}
