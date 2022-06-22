using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ChangeList
{
    class ChangeList
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string[] command = Console.ReadLine().Split();
            string end = "end";

            while (command[0] != end)
            {
                int element = int.Parse(command[1]);

                if (command[0] == "Delete")
                {
                    numbers.RemoveAll(el => el == element);
                }

                else if (command[0] == "Insert")
                {
                    int index = int.Parse(command[2]);
                    numbers.Insert(index, element);
                }
                command = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
