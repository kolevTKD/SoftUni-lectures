using System;

namespace _10.XPokemon
{
    class XPokemon
    {
        static void Main(string[] args)
        {
            int power = int.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());
            int currentPower = power;
            int targetsPoked = 0;

            while (currentPower >= distance)
            {
                currentPower -= distance;
                targetsPoked++;

                if (currentPower == power * 0.5 && exhaustionFactor > 0)
                {
                    currentPower /= exhaustionFactor;
                }
            }

            Console.WriteLine(currentPower);
            Console.WriteLine(targetsPoked);
        }
    }
}
