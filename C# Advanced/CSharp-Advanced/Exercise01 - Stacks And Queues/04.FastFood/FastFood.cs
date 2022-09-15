using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FastFood
{
    internal class FastFood
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());
            int[] ordersQuantity = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<int> orders = new Queue<int>(ordersQuantity);

            Console.WriteLine(orders.Max());

            for (int i = 0; i < ordersQuantity.Length; i++)
            {
                if (foodQuantity - orders.Peek() >= 0)
                {
                    int currentOrder = orders.Dequeue();
                    foodQuantity -= currentOrder;
                }
            }

            if (orders.Count == 0)
            {
                Console.WriteLine("Orders complete");

                return;
            }

            Console.WriteLine($"Orders left: {string.Join(' ', orders)}");
        }
    }
}
