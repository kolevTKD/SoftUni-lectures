using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.AppendArrays
{
    class AppendArrays
    {
        static void Main(string[] args)
        {
            List<string> numbers = Console.ReadLine().Split('|').Reverse().ToList();
            List<int> numsList = new List<int>();

            foreach (string number in numbers)
            {
                numsList.AddRange(number.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());
            }

            Console.WriteLine(string.Join(" ", numsList));
        }
    }
}
