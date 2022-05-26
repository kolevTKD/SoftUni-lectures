using System;

namespace _04_PrintAndSum
{
    class PrintAndSum
    {
        static void Main(string[] args)
        {
            int sequenceBeginning = int.Parse(Console.ReadLine());
            int sequenceEnding = int.Parse(Console.ReadLine());
            int sum = 0;

            for(int currentNum = sequenceBeginning; currentNum <= sequenceEnding; currentNum++)
            {
                Console.Write($"{currentNum} ");
                sum += currentNum;
            }

            Console.WriteLine();
            Console.Write($"Sum: {sum}");
        }
    }
}
