using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05._1.Messaging
{
    internal class Messaging
    {
        static void Main(string[] args)
        {
            List<int> inputNumbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            string inputMessage = Console.ReadLine();
            StringBuilder message = new StringBuilder();

            for (int index = 0; index < inputNumbers.Count; index++)
            {
                int sum = 0;
                string element = inputNumbers[index].ToString();

                foreach (var digit in element)
                {
                    sum += (int)char.GetNumericValue(digit);
                }

                if (sum >= inputMessage.Length)
                {
                    int diff = sum - inputMessage.Length;
                    sum = diff;
                }

                char letter = inputMessage[sum];
                inputMessage = inputMessage.Remove(sum, 1);
                message.Append(letter);
            }

            Console.WriteLine(message);
        }
    }
}
