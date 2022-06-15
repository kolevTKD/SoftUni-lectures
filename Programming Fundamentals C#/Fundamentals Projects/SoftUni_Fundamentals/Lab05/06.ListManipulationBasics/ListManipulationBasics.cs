using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ListManipulationBasics
{
    class ListManipulationBasics
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string[] command = Console.ReadLine().Split();
            string end = "end";

            while (command[0] != end)
            {
                switch(command[0])
                {
                    case "Add":
                        numbers.Add(int.Parse(command[1]));
                        break;

                    case "Remove":
                        numbers.Remove(int.Parse(command[1]));
                        break;

                    case "RemoveAt":
                        numbers.RemoveAt(int.Parse(command[1]));
                        break;

                    case "Insert":
                        numbers.Insert(int.Parse(command[2]), int.Parse(command[1]));
                        break;
                }

                command = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(" ", numbers)); ;
        }
    }
}
