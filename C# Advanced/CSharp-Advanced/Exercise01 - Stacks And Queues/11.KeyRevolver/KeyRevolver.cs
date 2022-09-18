using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.KeyRevolver
{
    internal class KeyRevolver
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());
            int[] bulletsOrder = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] locksOrder = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int treasureValue = int.Parse(Console.ReadLine());
            int bulletsUsed = 0;
            Stack<int> bullets = new Stack<int>(bulletsOrder);
            Queue<int> locks = new Queue<int>(locksOrder);

            while (bullets.Count > 0)
            {
                int currentBullet = bullets.Peek();
                int currentLock = locks.Peek();

                if (currentBullet <= currentLock)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }

                else
                {
                    Console.WriteLine("Ping!");
                }

                bullets.Pop();
                bulletsUsed++;

                if (bullets.Any())
                {
                    if (bulletsUsed % barrelSize == 0)
                    {
                        Console.WriteLine("Reloading!");
                    }
                }

                if (!locks.Any() || !bullets.Any())
                {
                    break;
                }
            }

            if (bullets.Count == 0 && locks.Count != 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }

            else
            {
                int moneyEarned = treasureValue - (bulletsUsed * bulletPrice);
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${moneyEarned}");
            }
        }
    }
}
