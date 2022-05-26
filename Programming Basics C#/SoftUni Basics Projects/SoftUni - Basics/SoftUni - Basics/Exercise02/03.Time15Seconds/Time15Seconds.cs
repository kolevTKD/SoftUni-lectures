using System;

namespace _03.Time15Seconds
{
    class Time15Seconds
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            int fifteenMins = minutes + 15;

            if (fifteenMins > 59)
            {
                hours++;
                fifteenMins -= 60;
            }

            if (hours > 23)
            {
                hours = 0;
            }

            Console.WriteLine($"{hours}:{fifteenMins:D2}");
        }
    }
}
