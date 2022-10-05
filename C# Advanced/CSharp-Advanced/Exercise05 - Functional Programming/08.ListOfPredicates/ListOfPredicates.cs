using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.ListOfPredicates
{
    internal class ListOfPredicates
    {
        static void Main(string[] args)
        {
            int endOfRange = int.Parse(Console.ReadLine());
            HashSet<int> dividers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToHashSet();
            List<Predicate<int>> predicates = new List<Predicate<int>>();

            foreach (int num in dividers)
            {
                Predicate<int> isDivisible = n => n % num == 0;
                predicates.Add(isDivisible);
            }

            List<int> range = Enumerable.Range(1, endOfRange).ToList();
            List<int> validNums = new List<int>();

            foreach (int num in range)
            {
                bool isValid = true;

                foreach (Predicate<int> predicate in predicates)
                {

                    if (!predicate(num))
                    {
                        isValid = false;

                        break;
                    }

                }

                if (isValid)
                {
                    validNums.Add(num);
                }
            }

            Console.WriteLine(string.Join(' ', validNums));
        }
    }
}
