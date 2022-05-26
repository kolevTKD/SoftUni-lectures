using System;

namespace _09.LeftAndRightSum
{
    class LeftAndRightSum
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int sumLeft = 0;
            int sumRight = 0;

            for (int i = 0; i < a; i++)
            {
                int left = int.Parse(Console.ReadLine());
                sumLeft += left;
            }

            for (int i = 0; i < a; i++)
            {
                int right = int.Parse(Console.ReadLine());
                sumRight += right;
            }

            if (sumLeft == sumRight)
            {
                Console.WriteLine($"Yes, sum = {sumLeft}");
            }

            else
            {
                int absDiff = Math.Abs(sumLeft - sumRight);
                Console.WriteLine($"No, diff = {absDiff}");
            }
        }
    }
}
