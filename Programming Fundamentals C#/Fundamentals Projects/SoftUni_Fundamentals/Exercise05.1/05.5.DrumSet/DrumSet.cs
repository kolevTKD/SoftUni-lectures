using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._5.DrumSet
{
    internal class DrumSet
    {
        static void Main(string[] args)
        {
            double savings = double.Parse(Console.ReadLine());
            List<int> drumSet = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<int> initialDrums = new List<int>();
            initialDrums.AddRange(drumSet);

            while (true)
            {
                string end = Console.ReadLine();

                if (end == "Hit it again, Gabsy!")
                {
                    break;
                }

                int hitPower = int.Parse(end);

                for (int index = 0; index < drumSet.Count; index++)
                {
                    drumSet[index] -= hitPower;

                    if (drumSet[index] <= 0)
                    {
                        int price = initialDrums[index] * 3;

                        if (savings - price >= 0)
                        {
                            savings -= price;
                            drumSet[index] = initialDrums[index];
                        }

                        else
                        {
                            drumSet.RemoveAt(index);
                            initialDrums.RemoveAt(index);
                            index--;
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(' ', drumSet));
            Console.WriteLine($"Gabsy has {savings:f2}lv.");
        }
    }
}
