using System;

namespace _03.Logistics
{
    class Logistics
    {
        static void Main(string[] args)
        {
            int cargosNum = int.Parse(Console.ReadLine());
            int pricePerTon = 0;
            double totalTons = 0;
            int bus = 0;
            int truck = 0;
            int train = 0;
            int tonsPerCargo = 0;
            double totalPrice = 0;
            double avgPrice = 0;
            double busPrice = 0;
            double truckPrice = 0;
            double trainPrice = 0;

            for (int cargos = 1; cargos <= cargosNum; cargos++)
            {
                tonsPerCargo = int.Parse(Console.ReadLine());

                if (tonsPerCargo <= 3)
                {
                    pricePerTon = 200;
                    bus += tonsPerCargo;
                    busPrice += tonsPerCargo * pricePerTon;
                }

                else if (tonsPerCargo >= 4 && tonsPerCargo <= 11)
                {
                    pricePerTon = 175;
                    truck += tonsPerCargo;
                    truckPrice += tonsPerCargo * pricePerTon;
                }

                else if (tonsPerCargo >= 12)
                {
                    pricePerTon = 120;
                    train += tonsPerCargo;
                    trainPrice += tonsPerCargo * pricePerTon;
                }

                totalTons += tonsPerCargo;
            }

            totalPrice += busPrice + truckPrice + trainPrice;
            avgPrice = totalPrice / totalTons;

            double busP = bus / totalTons * 100;
            double truckP = truck / totalTons * 100;
            double trainP = train / totalTons * 100;

            Console.WriteLine($"{avgPrice:f2}");
            Console.WriteLine($"{busP:f2}%");
            Console.WriteLine($"{truckP:f2}%");
            Console.WriteLine($"{trainP:f2}%");
        }
    }
}
