using System;

namespace _01.PoolPipes
{
    class PipesInPool
    {
        static void Main(string[] args)
        {
            int poolVolume = int.Parse(Console.ReadLine());
            int flowRateP1 = int.Parse(Console.ReadLine());
            int flowRateP2 = int.Parse(Console.ReadLine());
            double hoursFilling = double.Parse(Console.ReadLine());
            double fillingP1 = flowRateP1 * hoursFilling;
            double fillingP2 = flowRateP2 * hoursFilling;
            double totalLitersFilled = fillingP1 + fillingP2;
            double percentageFilled = totalLitersFilled / poolVolume * 100;
            double percentageP1 = fillingP1 / totalLitersFilled * 100;
            double percentageP2 = fillingP2 / totalLitersFilled * 100;

            if (totalLitersFilled <= poolVolume)
            {
                Console.WriteLine($"The pool is {percentageFilled}% full. Pipe 1: {percentageP1:f2}%. Pipe 2: {percentageP2:f2}%.");
            }

            else
            {
                double litersOverflew = totalLitersFilled - poolVolume;
                Console.WriteLine($"For {hoursFilling} hours the pool overflows with {litersOverflew:f2} liters.");
            }
        }
    }
}
