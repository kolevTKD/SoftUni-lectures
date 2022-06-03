using System;

namespace _09.FitnessCenter
{
    class FitnessCenter
    {
        static void Main(string[] args)
        {
            int visitors = int.Parse(Console.ReadLine());
            string back = "Back";
            string chest = "Chest";
            string legs = "Legs";
            string abs = "Abs";
            string shake = "Protein shake";
            string bar = "Protein bar";
            int backC = 0;
            int chestC = 0;
            int legsC = 0;
            int absC = 0;
            int shakeC = 0;
            int barC = 0;
            int trainC = 0;
            int buyC = 0;

            for (int currentVisitor = 1; currentVisitor <= visitors; currentVisitor++)
            {
                string action = Console.ReadLine();

                if (action == back)
                {
                    backC++;
                    trainC++;
                }

                else if (action == chest)
                {
                    chestC++;
                    trainC++;
                }

                else if (action == legs)
                {
                    legsC++;
                    trainC++;
                }

                else if (action == abs)
                {
                    absC++;
                    trainC++;
                }

                else if (action == shake)
                {
                    shakeC++;
                    buyC++;
                }

                else if (action == bar)
                {
                    barC++;
                    buyC++;
                }
            }

            double workOutP = (double)trainC / visitors * 100;
            double proteinP = (double)buyC / visitors * 100;

            Console.WriteLine($"{backC} - back");
            Console.WriteLine($"{chestC} - chest");
            Console.WriteLine($"{legsC} - legs");
            Console.WriteLine($"{absC} - abs");
            Console.WriteLine($"{shakeC} - protein shake");
            Console.WriteLine($"{barC} - protein bar");
            Console.WriteLine($"{workOutP:f2}% - work out");
            Console.WriteLine($"{proteinP:f2}% - protein");
        }
    }
}
