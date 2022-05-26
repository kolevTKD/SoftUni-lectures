using System;

namespace _06.WorldSwimmingRecord
{
    class WorldSwimmingRecord
    {
        static void Main(string[] args)
        {
            double record = double.Parse(Console.ReadLine());
            double meters = double.Parse(Console.ReadLine());
            double meterSec = double.Parse(Console.ReadLine());
            double time = meters * meterSec;
            int resistanceOn15 = 15;
            double secSlower = 12.5;
            double timeSlower = meters / resistanceOn15;
            double floTimeSlower = Math.Floor(timeSlower);
            double totalTimeSlower = floTimeSlower * secSlower;
            double totalTime = time + totalTimeSlower;

            if (record <= totalTime)
            {
                double timeNeeded = totalTime - record;
                Console.WriteLine($"No, he failed! He was {timeNeeded:f2} seconds slower.");
            }

            else
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {totalTime:f2} seconds.");
            }
        }
    }
}
