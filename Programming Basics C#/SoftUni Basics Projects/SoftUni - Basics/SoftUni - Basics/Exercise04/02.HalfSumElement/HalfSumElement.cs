using System;

namespace _02.HalfSumElement
{
    class HalfSumElement
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int sum = 0;
            int max = int.MinValue;

            for (int i = 0; i < num; i++)
            {
                int newNum = int.Parse(Console.ReadLine());
                sum += newNum;
                if (newNum > max)
                {
                    max = newNum;
                }
            }

            int sumNoMax = sum - max;

            if (sumNoMax == max)
            {
                Console.WriteLine($"Yes\nSum = {sumNoMax}");
            }

            else
            {
                int diff = Math.Abs(max - sumNoMax);
                Console.WriteLine($"No\nDiff = {diff}");
            }
        }
    }
}
