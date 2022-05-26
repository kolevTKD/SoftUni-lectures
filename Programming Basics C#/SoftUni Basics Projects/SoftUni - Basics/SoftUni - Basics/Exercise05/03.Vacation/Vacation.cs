using System;

namespace _03.Vacation
{
    class Vacation
    {
        static void Main(string[] args)
        {
            double moneyNeeded = double.Parse(Console.ReadLine());
            double moneyAvalible = double.Parse(Console.ReadLine());

            int savingCounter = 0;
            int spendingCounter = 0;
            int totalDays = 0;

            string save = "save";
            string spend = "spend";

            while (moneyAvalible <= moneyNeeded && spendingCounter != 5)
            {
                string action = Console.ReadLine();
                double actionMoney = double.Parse(Console.ReadLine());
                totalDays++;

                if (action == save)
                {
                    savingCounter++;
                    moneyAvalible += actionMoney;
                    spendingCounter = 0;

                    if (moneyAvalible >= moneyNeeded)
                    {
                        break;
                    }
                }

                else if (action == spend)
                {
                    spendingCounter++;
                    moneyAvalible -= actionMoney;

                    if (spendingCounter == 5)
                    {
                        break;
                    }

                    if (moneyAvalible <= 0)
                    {
                        moneyAvalible = 0;
                    }

                    savingCounter = 0;
                }
            }
            if (moneyAvalible >= moneyNeeded)
            {
                Console.WriteLine($"You saved the money for {totalDays} days.");
            }

            else if (spendingCounter == 5)
            {
                Console.WriteLine("You can't save the money.");
                Console.WriteLine(totalDays);
            }
        }
    }
}
