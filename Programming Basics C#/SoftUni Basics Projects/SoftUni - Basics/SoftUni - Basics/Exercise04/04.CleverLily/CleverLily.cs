using System;

namespace _04.CleverLily
{
    class CleverLily
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double dishwasherPrice = double.Parse(Console.ReadLine());
            int pricePerToy = int.Parse(Console.ReadLine());
            int moneyRecieved = 0;
            int toy = 0;
            int savedMoney = 0;

            for (int i = 1; i <= age; i++)
            {
                bool isEven = i % 2 == 0;
                bool isOdd = i % 2 == 1;

                if (isEven)
                {
                    moneyRecieved += 10;
                    savedMoney += moneyRecieved;
                    savedMoney--;
                }
                else if (isOdd)
                {
                    toy++;
                }
            }
            double toysSold = toy * pricePerToy;
            double totalSum = toysSold + savedMoney;
            bool isEnough = dishwasherPrice <= totalSum;

            if (isEnough)
            {
                double remainder = totalSum - dishwasherPrice;
                Console.WriteLine($"Yes! {remainder:f2}");
            }
            else
            {
                double needed = dishwasherPrice - totalSum;
                Console.WriteLine($"No! {needed:f2}");
            }
        }
    }
}
