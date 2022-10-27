using System;

namespace _02.RallyRacing
{
    internal class RallyRacing
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string racingNum = Console.ReadLine();
            string[,] track = new string[size, size];

            for (int row = 0; row < size; row++)
            {
                string[] currRow = Console.ReadLine().Split();

                for (int col = 0; col < size; col++)
                {
                    track[row, col] = currRow[col];
                }
            }

            string input = Console.ReadLine();
            int carRow = 0;
            int carCol = 0;
            int kmPassed = 0;

            while (true)
            {
                if (input == "End")
                {
                    Console.WriteLine($"Racing car {racingNum} DNF.");
                    break;
                }

                switch (input)
                {
                    case "up":
                        carRow -= 1;
                        break;
                    case "down":
                        carRow += 1;
                        break;
                    case "left":
                        carCol -= 1;
                        break;
                    case "right":
                        carCol += 1;
                        break;
                }

                kmPassed += 10;

                if (track[carRow, carCol] == "T")
                {
                    track[carRow, carCol] = ".";

                    for (int row = 0; row < size; row++)
                    {
                        for (int col = 0; col < size; col++)
                        {
                            if (track[row, col] == "T")
                            {
                                track[row, col] = ".";
                                carRow = row;
                                carCol = col;
                                kmPassed += 20;
                            }
                        }
                    }
                }

                if (track[carRow, carCol] == "F")
                {
                    Console.WriteLine($"Racing car {racingNum} finished the stage!");
                    break;
                }

                input = Console.ReadLine();
            }

            track[carRow, carCol] = "C";

            Console.WriteLine($"Distance covered {kmPassed} km.");

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(track[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
