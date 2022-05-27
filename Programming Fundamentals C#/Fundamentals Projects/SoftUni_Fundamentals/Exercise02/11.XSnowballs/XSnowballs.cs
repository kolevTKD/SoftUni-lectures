using System;
using System.Numerics;

namespace _11.XSnowballs
{
    class XSnowballs
    {
        static void Main(string[] args)
        {
            int numberOfSnowballs = int.Parse(Console.ReadLine());
            int snowballSnow = 0;
            int snowballTime = 0;
            int snowballQuality = 0;
            BigInteger highestValue = int.MinValue;
            string bestFormula = null;

            for (int currentSnowball = 1; currentSnowball <= numberOfSnowballs; currentSnowball++)
            {
                snowballSnow = int.Parse(Console.ReadLine());
                snowballTime = int.Parse(Console.ReadLine());
                snowballQuality = int.Parse(Console.ReadLine());
                BigInteger snowballValue = BigInteger.Pow((snowballSnow / snowballTime), snowballQuality);

                if (snowballValue >= highestValue)
                {
                    highestValue = snowballValue;
                    bestFormula = $"{snowballSnow} : {snowballTime} = {highestValue} ({snowballQuality})";
                }
            }
            Console.WriteLine(bestFormula);
        }
    }
}
