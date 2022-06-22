using System;
using System.Linq;

namespace _02.ShootForTheWin
{
    class ShootForTheWin
    {
        static void Main(string[] args)
        {
            int[] targets = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string command = Console.ReadLine();
            string end = "End";
            int shotTargets = 0;

            while (command != end)
            {
                int index = int.Parse(command);

                if (index >= 0 && index < targets.Length)
                {
                    int targetValue = targets[index];
                    targets[index] = -1;
                    shotTargets++;

                    for (int i = 0; i < targets.Length; i++)
                    {
                        if (targets[i] != -1)
                        {
                            if (targets[i] > targetValue)
                            {
                                targets[i] -= targetValue;
                            }

                            else if (targets[i] <= targetValue)
                            {
                                targets[i] += targetValue;
                            }
                        }
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Shot targets: {shotTargets} -> {string.Join(' ', targets)}");
        }
    }
}
