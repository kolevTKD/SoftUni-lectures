using System;

namespace _07.Shopping
{
    class Shopping
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int gpu = int.Parse(Console.ReadLine());
            int cpu = int.Parse(Console.ReadLine());
            int ram = int.Parse(Console.ReadLine());
            double thirtyfivePercent = 0.35;
            double tenPercent = 0.1;
            double fifteenPercent = 0.15;

            int gpuPrice = 250;
            double gpuTotal = gpu * gpuPrice;
            double cpuPrice = gpuTotal * thirtyfivePercent;
            double ramPrice = gpuTotal * tenPercent;
            double cpuTotal = cpu * cpuPrice;
            double ramTotal = ram * ramPrice;
            double subTotal = gpuTotal + cpuTotal + ramTotal;

            if (gpu > cpu)
            {
                double discount = subTotal * fifteenPercent;
                double total = subTotal - discount;
                double remainder = budget - total;
                double neededSum = total - budget;
                double absNeededSum = Math.Abs(neededSum);

                if (budget >= total)
                {
                    Console.WriteLine($"You have {remainder:f2} leva left!");
                }

                else if (budget < total)
                {
                    Console.WriteLine($"Not enough money! You need {absNeededSum:f2} leva more!");
                }
            }

            else if (gpu <= cpu)
            {
                if (budget >= subTotal)
                {
                    double remainder = budget - subTotal;
                    Console.WriteLine($"You have {remainder:f2} leva left!");
                }

                else if (budget < subTotal)
                {
                    double neededSum = subTotal - budget;
                    double absNeededSum = Math.Abs(neededSum);
                    Console.WriteLine($"Not enough money! You need {absNeededSum:f2} leva more!");
                }
            }
        }
    }
}
