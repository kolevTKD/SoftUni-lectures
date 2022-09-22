using System;
using System.Linq;

namespace _04.MatrixShuffling
{
    internal class MatrixShuffling
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            string[,] matrix = new string[rows, cols]; 

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] values = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = values[col];
                }
            }

            while (true)
            {
                string[] cmdArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string cmd = cmdArgs[0];

                if (cmd == "END")
                {
                    break;
                }

                if (isValidCmd(cmdArgs, matrix))
                {
                    int row1 = int.Parse(cmdArgs[1]);
                    int col1 = int.Parse(cmdArgs[2]);
                    int row2 = int.Parse(cmdArgs[3]);
                    int col2 = int.Parse(cmdArgs[4]);
                    string temp = matrix[row1, col1];
                    matrix[row1, col1] = matrix[row2, col2];
                    matrix[row2, col2] = temp;

                    Print(matrix);
                }

                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }

        static bool isValidCmd(string[] cmdArgs, string[,] matrix)
        {
            return
                cmdArgs[0] == "swap" && cmdArgs.Length == 5 &&
                int.Parse(cmdArgs[1]) >= 0 && int.Parse(cmdArgs[1]) < matrix.GetLength(0) &&
                int.Parse(cmdArgs[2]) >= 0 && int.Parse(cmdArgs[2]) < matrix.GetLength(1) &&
                int.Parse(cmdArgs[3]) >= 0 && int.Parse(cmdArgs[3]) < matrix.GetLength(0) &&
                int.Parse(cmdArgs[4]) >= 0 && int.Parse(cmdArgs[4]) < matrix.GetLength(1);
        }

        static void Print(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
