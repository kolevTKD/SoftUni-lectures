using System;

namespace _01.SumSeconds
{
    class SumSeconds
    {
        static void Main(string[] args)
        {
            int firstCompetitor = int.Parse(Console.ReadLine());
            int secondCompetitor = int.Parse(Console.ReadLine());
            int thirdCompetitor = int.Parse(Console.ReadLine());
            int minSecConverter = 60;
            int totalTime = firstCompetitor + secondCompetitor + thirdCompetitor;

            int minutes = totalTime / minSecConverter;
            int seconds = totalTime % minSecConverter;

            if (seconds < 10)
            {
                Console.WriteLine($"{minutes}:0{seconds}");
            }

            else
            {
                Console.WriteLine($"{minutes}:{seconds}");
            }
        }
    }
}
