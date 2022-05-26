using System;

namespace _06.Bills
{
    class Bills
    {
        static void Main(string[] args)
        {
            int months = int.Parse(Console.ReadLine());
            double waterPerMonth = 20;
            double internetPerMonth = 15;
            double totalElectricity = 0;
            double totalWater = 0;
            double totalInternet = 0;
            double totalOther = 0;
            double total = 0;

            for (int i = 1; i <= months; i++)
            {
                double electricityPerMonth = double.Parse(Console.ReadLine());
                double otherPerMonth = (electricityPerMonth + waterPerMonth + internetPerMonth) * 1.2;
                double totalPerMonth = electricityPerMonth + waterPerMonth + internetPerMonth + otherPerMonth;
                total += totalPerMonth;
                totalElectricity += electricityPerMonth;
                totalWater += waterPerMonth;
                totalInternet += internetPerMonth;
                totalOther += otherPerMonth;
            }

            double avgTotal = (totalElectricity + totalWater + totalInternet + totalOther) / months;

            Console.WriteLine($"Electricity: {totalElectricity:f2} lv");
            Console.WriteLine($"Water: {totalWater:f2} lv");
            Console.WriteLine($"Internet: {totalInternet:f2} lv");
            Console.WriteLine($"Other: {totalOther:f2} lv");
            Console.WriteLine($"Average: {avgTotal:f2} lv");
        }
    }
}
