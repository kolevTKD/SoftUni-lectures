using System;
using System.Linq;

namespace _06.JaggedArrayManipulator
{
    internal class JaggedArrayManipulator
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[][] jaggedArray = new int[size][];

            for (int row = 0; row < jaggedArray.GetLength(0); row++)
            {
                int[] values = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
                jaggedArray[row] = new int[values.Length];

                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    jaggedArray[row][col] = values[col];
                }
            }

            for (int row = 0; row < jaggedArray.GetLength(0) - 1; row++)
            {
                if (jaggedArray[row].Length > 0)
                {
                    if (jaggedArray[row].Length == jaggedArray[row + 1].Length)
                    {
                        Multiply(jaggedArray, row);
                    }

                    else
                    {
                        Divide(jaggedArray, row);
                    }
                }
            }

            while (true)
            {
                string[] cmdArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (cmdArgs[0] == "End")
                {
                    break;
                }

                string cmd = cmdArgs[0];
                int cmdRow = int.Parse(cmdArgs[1]);
                int cmdCol = int.Parse(cmdArgs[2]);
                int cmdValue = int.Parse(cmdArgs[3]);

                if (IsValidCmd(jaggedArray, cmdRow, cmdCol))
                {
                    if (cmd == "Add")
                    {
                        jaggedArray[cmdRow][cmdCol] += cmdValue;
                    }

                    else if (cmd == "Subtract")
                    {
                        jaggedArray[cmdRow][cmdCol] -= cmdValue;
                    }
                }
            }

            Print(jaggedArray);
        }

        static void Multiply(int[][] jaggedArray, int currRow)
        {
            for (int row = currRow; row <= currRow + 1; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    jaggedArray[row][col] *= 2;
                }
            }
        }

        static void Divide(int[][] jaggedArray, int currRow)
        {
            for (int row = currRow; row <= currRow + 1; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    if (jaggedArray[row][col] != 0)
                    {
                        jaggedArray[row][col] /= 2;
                    }
                }
            }
        }

        static bool IsValidCmd(int[][] jaggedArray, int cmdRow, int cmdCol)
        {
            return
                cmdRow >= 0 && cmdRow < jaggedArray.GetLength(0)
                && cmdCol >= 0 && cmdCol < jaggedArray[cmdRow].Length;
        }

        static void Print(int[][] jaggedArray)
        {
            for (int row = 0; row < jaggedArray.GetLength(0); row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    Console.Write($"{jaggedArray[row][col]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
