using System;

namespace _02.SleepyCat
{
    class SleepyTomCat
    {
        static void Main(string[] args)
        {
            int daysOff = int.Parse(Console.ReadLine());
            int daysInYear = 365;
            int workDays = daysInYear - daysOff;
            int playtimePerWorkDayMin = 63;
            int playtimePerDayOffMin = 127;
            int playtimeYearly = 30000;
            int hoursToMinsConv = 60;
            int playtimeWorkDays = workDays * playtimePerWorkDayMin;
            int playtimeDaysOff = daysOff * playtimePerDayOffMin;
            int totalPlaytime = playtimeWorkDays + playtimeDaysOff;
            int hoursMore = Math.Abs(totalPlaytime - playtimeYearly);
            int hours = 0;
            int minutes = 0;

            if (totalPlaytime > playtimeYearly)
            {
                hours = hoursMore / hoursToMinsConv;
                minutes = hoursMore % hoursToMinsConv;
                Console.WriteLine("Tom will run away");
                Console.WriteLine($"{hours} hours and {minutes} minutes more for play");
            }

            else
            {
                hours = hoursMore / hoursToMinsConv;
                minutes = hoursMore % hoursToMinsConv;
                Console.WriteLine("Tom sleeps well");
                Console.WriteLine($"{hours} hours and {minutes} minutes less for play");
            }
        }
    }
}
