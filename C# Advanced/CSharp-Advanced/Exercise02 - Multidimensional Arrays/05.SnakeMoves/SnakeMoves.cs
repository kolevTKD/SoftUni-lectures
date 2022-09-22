using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.SnakeMoves
{
    internal class SnakeMoves
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            char[] word = Console.ReadLine().ToCharArray();
            char[,] snakePath = new char[rows, cols];
            Queue<char> snake = new Queue<char>(word);

            for (int row = 0; row < snakePath.GetLength(0); row++)
            {
                if (row % 2 == 1)
                {
                    for (int col = snakePath.GetLength(1) - 1; col >= 0; col--)
                    {
                        char currentLetter = snake.Dequeue();
                        snakePath[row, col] = currentLetter;
                        snake.Enqueue(currentLetter);
                    }

                    continue;
                }

                for (int col = 0; col < snakePath.GetLength(1); col++)
                {
                    char currentLetter = snake.Dequeue();
                    snakePath[row, col] = currentLetter;
                    snake.Enqueue(currentLetter);
                }
            }

            for (int row = 0; row < snakePath.GetLength(0); row++)
            {
                for (int col = 0; col < snakePath.GetLength(1); col++)
                {
                    Console.Write(snakePath[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
