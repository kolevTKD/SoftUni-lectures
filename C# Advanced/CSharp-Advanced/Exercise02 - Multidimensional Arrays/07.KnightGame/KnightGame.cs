using System;

namespace _07.KnightGame
{
    internal class KnightGame
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            if (size < 3)
            {
                Console.WriteLine(0);

                return;
            }

            char[,] chessBoard = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                string cells = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    chessBoard[row, col] = cells[col];
                }
            }

            int knightsRemoved = 0;

            while (true)
            {
                int countMost = 0;
                int rowMost = 0;
                int colMost = 0;

                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        if (chessBoard[row, col] == 'K')
                        {
                            int takenKnights = KnightsTaken(chessBoard, row, col, size);

                            if (countMost < takenKnights)
                            {
                                countMost = takenKnights;
                                rowMost = row;
                                colMost = col;
                            }
                        }
                    }
                }

                if (countMost == 0)
                {
                    break;
                }

                else
                {
                    chessBoard[rowMost, colMost] = '0';
                    knightsRemoved++;
                }
            }

            Console.WriteLine(knightsRemoved);
        }

        static int KnightsTaken(char[,] chessBoard, int row, int col, int size)
        {
            int knightsTaken = 0;

            if (IsValidPos(row - 2, col - 1, size))
            {
                if (chessBoard[row - 2, col - 1] == 'K') //top-left
                {
                    knightsTaken++;
                }
            }

            if (IsValidPos(row - 2, col + 1, size))
            {
                if (chessBoard[row - 2, col + 1] == 'K') //top-right
                {
                    knightsTaken++;
                }
            }

            if (IsValidPos(row - 1, col - 2, size))
            {
                if (chessBoard[row - 1, col - 2] == 'K') //left-up
                {
                    knightsTaken++;
                }
            }

            if (IsValidPos(row + 1, col - 2, size))
            {
                if (chessBoard[row + 1, col - 2] == 'K') //left-down
                {
                    knightsTaken++;
                }
            }

            if (IsValidPos(row - 1, col + 2, size))
            {
                if (chessBoard[row - 1, col + 2] == 'K') //right-up
                {
                    knightsTaken++;
                }
            }

            if (IsValidPos(row + 1, col + 2, size))
            {
                if (chessBoard[row + 1, col + 2] == 'K') //right-down
                {
                    knightsTaken++;
                }
            }

            if (IsValidPos(row + 2, col - 1, size))
            {
                if (chessBoard[row + 2, col - 1] == 'K') //down-left
                {
                    knightsTaken++;
                }
            }

            if (IsValidPos(row + 2, col + 1, size))
            {
                if (chessBoard[row + 2, col + 1] == 'K') //down-right
                {
                    knightsTaken++;
                }
            }

            return knightsTaken;
        }

        static bool IsValidPos(int row, int col, int size)
        {
            return row >= 0 && row < size && col >= 0 && col < size;
        }
    }
}
