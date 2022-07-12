using System;

namespace _03.SquareOfStars
{
    class SquareOfStars
    {
        static void Main(string[] args)
        {
            int side = int.Parse(Console.ReadLine());

            for (int i = 1; i <= side; i++)
            {
                for (int j = 1; j <= side; j++)
                {
                    Console.Write("<3 ", side);
                }
                Console.WriteLine();
            }
        }
    }
}
