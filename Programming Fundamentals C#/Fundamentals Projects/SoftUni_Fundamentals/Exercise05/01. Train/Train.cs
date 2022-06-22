using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Train
{
    class Train
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine().Split().Select(int.Parse).ToList();
            int capacity = int.Parse(Console.ReadLine());
            string[] command = Console.ReadLine().Split();

            while (command[0] != "end")
            {
                if (command[0] == "Add")
                {
                    int passengers = int.Parse(command[1]);
                    AddingWagons(wagons, passengers);
                }

                else if (command.Length == 1)
                {
                    int passengers = int.Parse(command[0]);
                    AddingPassengers(wagons, passengers, capacity);
                }
                command = Console.ReadLine().Split();
            }
            Console.WriteLine(string.Join(" ", wagons));
        }

        static List<int> AddingWagons(List<int> wagons, int passengers)
        {
            wagons.Add(passengers);
            return wagons;
        }

        static List<int> AddingPassengers(List<int> wagons, int passengers, int capacity)
        {
            for (int index = 0; index < wagons.Count; index++)
            {
                if (wagons[index] + passengers <= capacity)
                {
                    wagons[index] += passengers;
                    break;
                }
            }
            return wagons;
        }
    }
}
