using System;
using System.Linq;

namespace _03._1.EncryptSortAndPrintArray
{
    class EncryptSortAndPrintArray
    {
        static void Main(string[] args)
        {
            int stringCount = int.Parse(Console.ReadLine());
            int[] values = new int[stringCount];

            for (int i = 0; i < stringCount; i++)
            {
                string input = Console.ReadLine();
                int sum = 0;

                foreach (char letter in input)
                {
                    if ("aeiouAEIOU".Contains(letter))
                    {
                        sum += letter * input.Length;
                    }

                    else
                    {
                        sum += letter / input.Length;
                    }
                }
                values[i] = sum;
            }

            //Array.Sort(values);
            int[] sortedValues = values.OrderBy(value => value).ToArray();
            Console.WriteLine(string.Join(Environment.NewLine, sortedValues));
        }
    }
}
