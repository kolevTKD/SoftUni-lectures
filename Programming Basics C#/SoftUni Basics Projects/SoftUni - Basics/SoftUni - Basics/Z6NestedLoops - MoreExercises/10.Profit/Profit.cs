using System;

namespace _10.Profit
{
    class Profit
    {
        static void Main(string[] args)
        {
            int oneLevsNum = int.Parse(Console.ReadLine());
            int twoLevsNum = int.Parse(Console.ReadLine());
            int fiveLevsNum = int.Parse(Console.ReadLine());
            int sum = int.Parse(Console.ReadLine());

            for (int oneCounts = 0; oneCounts <= oneLevsNum; oneCounts++)
            {
                for (int twoCounts = 0; twoCounts <= twoLevsNum; twoCounts++)
                {
                    for (int fiveCounts = 0; fiveCounts <= fiveLevsNum; fiveCounts++)
                    {
                        if (oneCounts * 1 + twoCounts * 2 + fiveCounts * 5 == sum)
                        {
                            Console.WriteLine($"{oneCounts} * 1 lv. + {twoCounts} * 2 lv. + {fiveCounts} * 5 lv. = {sum} lv.");
                        }
                    }
                }
            }
        }
    }
}
