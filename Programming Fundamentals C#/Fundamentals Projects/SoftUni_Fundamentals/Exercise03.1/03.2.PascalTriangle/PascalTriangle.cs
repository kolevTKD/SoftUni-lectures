using System;

namespace _03._2.PascalTriangle
{
    class PascalTriangle
    {
        static void Main(string[] args)
        {
            int triangleRows = int.Parse(Console.ReadLine());
            long[][] pascalTriangle = new long[triangleRows][];

            for (int i = 0; i < triangleRows; i++)
            {
                long[] row = new long[i + 1];
                row[0] = 1;
                row[i] = 1;

                for (int j = 1; j < i; j++)
                {
                    row[j] = pascalTriangle[i - 1][j] + pascalTriangle[i - 1][j - 1];
                }

                pascalTriangle[i] = row;
            }

            foreach(var element in pascalTriangle)
            {
                Console.WriteLine(string.Join(' ', element));
            }
        }
    }
}
