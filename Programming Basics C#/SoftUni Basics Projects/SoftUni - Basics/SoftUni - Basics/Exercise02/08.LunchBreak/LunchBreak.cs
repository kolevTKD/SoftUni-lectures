using System;

namespace _08.LunchBreak
{
    class LunchBreak
    {
        static void Main(string[] args)
        {
            string showName = Console.ReadLine();
            double episodeDuration = double.Parse(Console.ReadLine());
            double breakDuration = double.Parse(Console.ReadLine());
            int lunchDivider = 8;
            int restDivider = 4;
            double lunchTime = breakDuration / lunchDivider;
            double restTime = breakDuration / restDivider;
            double freeTime = breakDuration - lunchTime - restTime;
            double remainingTime = freeTime - episodeDuration;
            double neededTime = episodeDuration - freeTime;
            double absNeededTime = Math.Abs(neededTime);
            double ceiAbsNeededTime = Math.Ceiling(absNeededTime);
            double ceiRemainingTime = Math.Ceiling(remainingTime);

            if (freeTime >= episodeDuration)
            {
                Console.WriteLine($"You have enough time to watch {showName} and left with {ceiRemainingTime} minutes free time.");
            }

            else
            {
                Console.WriteLine($"You don't have enough time to watch {showName}, you need {ceiAbsNeededTime} more minutes.");
            }
        }
    }
}
