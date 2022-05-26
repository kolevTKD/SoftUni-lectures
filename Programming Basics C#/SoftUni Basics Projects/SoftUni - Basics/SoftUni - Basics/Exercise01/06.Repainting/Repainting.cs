using System;

namespace _06.Repainting
{
    class Repainting
    {
        static void Main(string[] args)
        {
            int nylonSqMeters = int.Parse(Console.ReadLine());
            int paintInLiters = int.Parse(Console.ReadLine());
            int thinnerInLiters = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());

            double nylonPerSq = 1.50;
            double paintPerLiter = 14.50;
            double thinnerPerLiter = 5.00;
            double bags = 0.40;

            double nylonInCaseSqMeters = 2;
            double paintInCase = paintInLiters * 0.1;
            double thirtyPercent = 0.3;

            double nylonTotal = (nylonSqMeters + nylonInCaseSqMeters) * nylonPerSq;
            double paintTotal = (paintInLiters + paintInCase) * paintPerLiter;
            double thinnerTotal = thinnerInLiters * thinnerPerLiter;
            double totalMaterials = nylonTotal + paintTotal + thinnerTotal + bags;
            double workersFee = (totalMaterials * thirtyPercent) * hours;
            double total = totalMaterials + workersFee;

            Console.WriteLine(total);
        }
    }
}
