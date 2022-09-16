using System;

namespace _06.JaggedArrayModification
{
    internal class JaggedArrayModification
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[][] matrix = new int[size][];

            for (int row = 0; row < matrix.Length; row++)
            {
                string[] rowData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                matrix[row] = new int[rowData.Length];

                for (int col = 0; col < rowData.Length; col++)
                {
                    matrix[row][col] = int.Parse(rowData[col]);
                }
            }

            while (true)
            {
                string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = commands[0];

                if (command == "END")
                {
                    break;
                }

                int atRow = int.Parse(commands[1]);
                int atCol = int.Parse(commands[2]);
                int value = int.Parse(commands[3]);

                if (atRow < 0 || atRow >= matrix.Length || atCol < 0 || atCol >= matrix[atRow].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }

                if (command == "Add")
                {
                    matrix[atRow][atCol] += value;
                }

                else if (command == "Subtract")
                {
                    matrix[atRow][atCol] -= value;
                }
            }

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write($"{matrix[row][col]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
