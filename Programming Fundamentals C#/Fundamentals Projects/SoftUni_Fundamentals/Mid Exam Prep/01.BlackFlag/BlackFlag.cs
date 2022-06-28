using System;

namespace _01.BlackFlag
{
    class BlackFlag
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int plunderPerDay = int.Parse(Console.ReadLine());
            double expectedPlunder = double.Parse(Console.ReadLine());
            double totalPlunder = 0;

            for (int day = 1; day <= days; day++)
            {
                totalPlunder += plunderPerDay;

                if (day % 3 == 0)
                {
                    totalPlunder += plunderPerDay * 0.5;
                }

                if (day % 5 == 0)
                {
                    totalPlunder *= 0.7;
                }
            }

            if (totalPlunder >= expectedPlunder)
            {
                Console.WriteLine($"Ahoy! {totalPlunder:f2} plunder gained.");
                return;
            }

            double plunderPercent = totalPlunder / expectedPlunder * 100;
            Console.WriteLine($"Collected only {plunderPercent:f2}% of the plunder.");
        }
    }
}
