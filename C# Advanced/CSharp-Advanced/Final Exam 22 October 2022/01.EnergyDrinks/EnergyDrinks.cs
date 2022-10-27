using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.EnergyDrinks
{
    public class EnergyDrinks
    {
        static void Main(string[] args)
        {
            int[] caffeineMGSeq = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] energyDrinksSeq = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<int> energyDrinks = new Queue<int>(energyDrinksSeq);
            Stack<int> caffeineMGs = new Stack<int>(caffeineMGSeq);
            int stamatTake = 0;

            while ((energyDrinks.Count != 0) & (caffeineMGs.Count != 0))
            {
                int currNrgDrink = energyDrinks.Peek();
                int currMg = caffeineMGs.Peek();
                int totalCurrMgs = currNrgDrink * currMg;

                if (stamatTake + totalCurrMgs <= 300)
                {
                    stamatTake += totalCurrMgs;
                    energyDrinks.Dequeue();
                }

                else
                {
                    energyDrinks.Dequeue();
                    energyDrinks.Enqueue(currNrgDrink);

                    if (stamatTake >= 30)
                    {
                        stamatTake -= 30;
                    }

                    else
                    {
                        stamatTake = 0;
                    }
                }

                caffeineMGs.Pop();
            }

            if (energyDrinks.Count > 0)
            {
                Console.WriteLine($"Drinks left: {string.Join(", ", energyDrinks)}");
            }

            else if (energyDrinks.Count == 0)
            {
                Console.WriteLine("At least Stamat wasn't exceeding the maximum caffeine.");
            }

            Console.WriteLine($"Stamat is going to sleep with {stamatTake} mg caffeine.");
        }
    }
}
