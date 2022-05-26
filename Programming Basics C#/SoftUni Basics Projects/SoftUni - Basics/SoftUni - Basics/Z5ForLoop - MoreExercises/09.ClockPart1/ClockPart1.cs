using System;

namespace _09.ClockPart1
{
    class ClockPart1
    {
        static void Main(string[] args)
        {
            for (int i = 0; i <= 23; i++)
            {
                for (int j = 0; j <= 59; j++)
                {
                    Console.WriteLine($"{i} : {j}");
                }
            }
        }
    }
}
