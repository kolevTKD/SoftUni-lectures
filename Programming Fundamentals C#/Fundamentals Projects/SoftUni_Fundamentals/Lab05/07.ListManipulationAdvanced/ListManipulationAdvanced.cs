using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.ListManipulationAdvanced
{
    class ListManipulationAdvanced
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string[] command = Console.ReadLine().Split();
            string end = "end";
            bool isChanged = false;

            while (command[0] != end)
            {
                switch (command[0])
                {
                    case "Add":
                        numbers.Add(int.Parse(command[1]));
                        isChanged = true;
                        break;

                    case "Remove":
                        numbers.Remove(int.Parse(command[1]));
                        isChanged = true;
                        break;

                    case "RemoveAt":
                        numbers.RemoveAt(int.Parse(command[1]));
                        isChanged = true;
                        break;

                    case "Insert":
                        numbers.Insert(int.Parse(command[2]), int.Parse(command[1]));
                        isChanged = true;
                        break;
                        
                    case "Contains":
                        Console.WriteLine(Contains(numbers, int.Parse(command[1])) ? "Yes" : "No such number");
                        break;

                    case "PrintEven":
                        PrintEven(numbers);
                        break;

                    case "PrintOdd":
                        PrintOdd(numbers);
                        break;

                    case "GetSum":
                        GetSum(numbers);
                        break;

                    case "Filter":
                        Filter(command[1], int.Parse(command[2]), numbers);
                        break;
                }

                command = Console.ReadLine().Split();
            }

            if (isChanged)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
        }

        static bool Contains(List<int> numbers, int number)
        {
            bool isContaining = numbers.Contains(number);
            return isContaining;
        }

        static void PrintEven(List<int> numbers)
        {
            List<int> evens = new List<int>();

            for (int index = 0; index < numbers.Count; index++)
            {
                if (numbers[index] % 2 == 0)
                {
                    evens.Add(numbers[index]);
                }
            }

            Console.WriteLine(string.Join(" ", evens));
            return;
        }

        static void PrintOdd(List<int> numbers)
        {
            List<int> odds = new List<int>();

            for (int index = 0; index < numbers.Count; index++)
            {
                if (numbers[index] % 2 == 1)
                {
                    odds.Add(numbers[index]);
                }
            }

            Console.WriteLine(string.Join(" ", odds));
            return;
        }

        static void GetSum(List<int> numbers)
        {
            int sum = 0;

            for (int index = 0; index < numbers.Count; index++)
            {
                sum += numbers[index];
            }

            Console.WriteLine(sum);
        }

        static void Filter(string condition, int number, List<int> numbers)
        {
            List<int> filtered = new List<int>();

            for (int index = 0; index < numbers.Count; index++)
            {
                switch(condition)
                {
                    case "<":
                        if (numbers[index] < number)
                        {
                            filtered.Add(numbers[index]);
                        }
                        break;

                    case ">":
                        if (numbers[index] > number)
                        {
                            filtered.Add(numbers[index]);
                        }
                        break;

                    case "<=":
                        if (numbers[index] <= number)
                        {
                            filtered.Add(numbers[index]);
                        }
                        break;

                    case ">=":
                        if (numbers[index] >= number)
                        {
                            filtered.Add(numbers[index]);
                        }
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", filtered));
        }
    }
}
