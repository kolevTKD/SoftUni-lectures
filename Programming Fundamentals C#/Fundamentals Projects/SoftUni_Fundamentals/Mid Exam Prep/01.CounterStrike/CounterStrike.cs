using System;

namespace _01.CounterStrike
{
    class CounterStrike
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());
            string command = string.Empty;
            string end = "End of battle";
            int wonBattles = 0;

            while (true)
            {
                command = Console.ReadLine();

                if (command == end)
                {
                    Console.WriteLine($"Won battles: {wonBattles}. Energy left: {energy}");
                    break;
                }

                int distance = int.Parse(command);

                if (energy - distance < 0)
                {
                    Console.WriteLine($"Not enough energy! Game ends with {wonBattles} won battles and {energy} energy");

                    return;
                }

                if (energy - distance >= 0)
                {
                    wonBattles++;
                    energy -= distance;
                }

                if (wonBattles % 3 == 0)
                {
                    energy += wonBattles;
                }
            }
        }
    }
}
