using System;

namespace _11_XOrders
{
    class XOrders
    {
        static void Main(string[] args)
        {
            int ordersCount = int.Parse(Console.ReadLine());
            double total = 0;

            for (int currentOrder = 1; currentOrder <= ordersCount; currentOrder++)
            {
                double pricePerCapsule = double.Parse(Console.ReadLine());
                int days = int.Parse(Console.ReadLine());
                int capsulesCount = int.Parse(Console.ReadLine());
                double capsulesForDays = days * capsulesCount;
                double totalForCapsules = capsulesForDays * pricePerCapsule;
                total += totalForCapsules;

                Console.WriteLine($"The price for the coffee is: ${totalForCapsules:f2}");
            }

            Console.WriteLine($"Total: ${total:f2}");
        }
    }
}
