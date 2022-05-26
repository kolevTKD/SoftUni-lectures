using System;

namespace _06.Cake
{
    class Cake
    {
        static void Main(string[] args)
        {
            int cakeWidth = int.Parse(Console.ReadLine());
            int cakeLength = int.Parse(Console.ReadLine());
            int cakeSize = cakeWidth * cakeLength;
            string stop = "STOP";

            while (cakeSize > 0)
            {
                string input = Console.ReadLine();

                if (input == stop)
                {
                    break;
                }

                int piecesTaken = int.Parse(input);
                cakeSize -= piecesTaken;

                if (cakeSize < 0)
                {
                    break;
                }
            }

            if (cakeSize >= 0)
            {
                Console.WriteLine($"{cakeSize} pieces are left.");
            }

            else
            {
                int piecesNeeded = Math.Abs(cakeSize);
                Console.WriteLine($"No more cake left! You need {piecesNeeded} pieces more.");
            }
        }
    }
}
