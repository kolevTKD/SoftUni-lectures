using System;

namespace _10.HighJump
{
    class HighJump
    {
        static void Main(string[] args)
        {
            int heightTarget = int.Parse(Console.ReadLine());
            int currentHeight = heightTarget - 30;
            int fails = 0;
            int totalJumps = 0;

            while (fails < 3)
            {
                int currentJump = int.Parse(Console.ReadLine());

                if (currentJump > currentHeight)
                {
                    totalJumps++;
                    fails = 0;
                }

                else if (currentJump <= currentHeight)
                {
                    totalJumps++;
                    fails++;
                    continue;
                }

                if (currentHeight == heightTarget && currentJump > heightTarget)
                {
                    Console.WriteLine($"Tihomir succeeded, he jumped over {currentHeight}cm after {totalJumps} jumps.");
                    return;
                }

                else if (fails == 3)
                {
                    break;
                }

                currentHeight += 5;
            }
            Console.WriteLine($"Tihomir failed at {currentHeight}cm after {totalJumps} jumps.");

        }
    }
}
