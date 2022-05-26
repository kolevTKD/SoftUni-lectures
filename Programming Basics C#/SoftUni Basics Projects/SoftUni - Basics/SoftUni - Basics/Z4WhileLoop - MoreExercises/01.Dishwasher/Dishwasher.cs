using System;

namespace _01.Dishwasher
{
    class Dishwasher
    {
        static void Main(string[] args)
        {
            int dishDetergentBottles = int.Parse(Console.ReadLine());
            int mlPerBottle = 750;
            int detergentPerPlate = 5;
            int detergentPerPot = 15;
            int washesCount = 0;
            int platesNum = 0;
            int potsNum = 0;
            string end = "End";
            string input = null;
            double totalDetergent = dishDetergentBottles * mlPerBottle;
            double detergentUsed = 0;

            while (input != end)
            {
                input = Console.ReadLine();

                if (input == end)
                {
                    break;
                }
                int dishesNum = int.Parse(input);
                washesCount++;

                if (washesCount % 3 == 0)
                {
                    potsNum += dishesNum;
                    detergentUsed = dishesNum * detergentPerPot;
                }
                else
                {
                    platesNum += dishesNum;
                    detergentUsed = dishesNum * detergentPerPlate;
                }

                totalDetergent -= detergentUsed;

                if (totalDetergent < 0)
                {
                    break;
                }
                detergentUsed = 0;
            }

            if (totalDetergent >= 0)
            {
                Console.WriteLine("Detergent was enough!");
                Console.WriteLine($"{platesNum} dishes and {potsNum} pots were washed.");
                Console.WriteLine($"Leftover detergent {totalDetergent} ml.");
            }
            else
            {
                Console.WriteLine($"Not enough detergent, {Math.Abs(totalDetergent)} ml. more necessary!");
            }
        }
    }
}
