using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MemoryGame
{
    class MemoryGame
    {
        static void Main(string[] args)
        {
            List<string> initialList = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            string[] indices = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            string end = "end";
            int moves = 0;

            while (indices[0] != end)
            {
                moves++;
                int index1 = int.Parse(indices[0]);
                int index2 = int.Parse(indices[1]);

                if (index1 == index2
                    || index1 < 0 || index1 >= initialList.Count
                    || index2 < 0 || index2 >= initialList.Count)
                {
                    initialList.Insert(initialList.Count / 2, $"-{moves}a");
                    initialList.Insert(initialList.Count / 2, $"-{moves}a");
                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                }

                else if (initialList[index1] == initialList[index2])
                {
                    string element = initialList[index1];
                    Console.WriteLine($"Congrats! You have found matching elements - {element}!");
                    initialList.RemoveAll(el => el == element);
                }

                else if (initialList[index1] != initialList[index2])
                {
                    Console.WriteLine("Try again!");
                }

                if (initialList.Count == 0)
                {
                    Console.WriteLine($"You have won in {moves} turns!");

                    return;
                }

                indices = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            Console.WriteLine("Sorry you lose :(");
            Console.WriteLine(string.Join(' ', initialList));
        }
    }
}
