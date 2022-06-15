using System;
using System.Linq;

namespace _11.ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string[] command = Console.ReadLine().Split();
            string end = "end";

            while (command[0] != end)
            {
                if (command[0] == "exchange")
                {
                    int givenIndex = int.Parse(command[1]);
                    numbers = ExchangedArray(numbers, givenIndex); 
                }

                else if (command[0] == "max" || command[1] == "min")
                {

                }
            }
        }

        static int[] ExchangedArray(int[] numArray, int splitIndex)
        {
            if (splitIndex < 0 || splitIndex >= numArray.Length)
            {
                Console.WriteLine("Invalid index");
                return numArray;
            }

            int[] exchangedArray = new int[numArray.Length];
            int index = 0;

            for (int i = splitIndex; i < numArray.Length; i++)
            {
                exchangedArray[index] = numArray[i];
                index++;
            }

            for (int i = 0; i < splitIndex; i++)
            {
                exchangedArray[index] = numArray[i];
                index++;
            }

            return exchangedArray;
        }

        static void MinMax()
        {
            
        }
    }
}
