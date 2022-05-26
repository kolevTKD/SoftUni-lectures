using System;

namespace _07.TrekkingMania
{
    class TrekkingMania
    {
        static void Main(string[] args)
        {
            int groupsCount = int.Parse(Console.ReadLine());

            int musala = 0;
            int monblan = 0;
            int kilimandzharo = 0;
            int k2 = 0;
            int everest = 0;
            int climbersTotal = 0;
            
            for (int i = 1; i <= groupsCount; i++)
            {
                int group = int.Parse(Console.ReadLine());
                climbersTotal += group;

                if (group >= 1 && group <= 5)
                {
                    musala += group;
                }
                else if (group >= 6 && group <= 12)
                {
                    monblan += group;
                }
                else if (group >= 13 && group <= 25)
                {
                    kilimandzharo += group;
                }
                else if (group >= 26 && group <= 40)
                {
                    k2 += group;
                }
                else if (group >= 41 && group <= 1000)
                {
                    everest += group;
                }
            }
            double musalaP = (double)musala / climbersTotal * 100;
            double monblanP = (double)monblan / climbersTotal * 100;
            double kilimandzharoP = (double)kilimandzharo / climbersTotal * 100;
            double k2P = (double)k2 / climbersTotal * 100;
            double everestP = (double)everest / climbersTotal * 100;
            Console.WriteLine($"{musalaP:f2}%");
            Console.WriteLine($"{monblanP:f2}%");
            Console.WriteLine($"{kilimandzharoP:f2}%");
            Console.WriteLine($"{k2P:f2}%");
            Console.WriteLine($"{everestP:f2}%");
        }
    }
}
