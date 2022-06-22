using System;
using System.Linq;

namespace _02.ArrayModifier
{
    class ArrayModifier
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            string command = commands[0];
            string end = "end";
            int index1 = 0;
            int index2 = 0;
            int num1 = 0;
            int num2 = 0;

            while (command != end)
            {
                if (command != "decrease")
                {
                    index1 = int.Parse(commands[1]);
                    index2 = int.Parse(commands[2]);
                    num1 = numbers[index1];
                    num2 = numbers[index2];
                }

                switch (command)
                {
                    case "swap":
                        numbers[index1] = num2;
                        numbers[index2] = num1;
                        break;

                    case "multiply":
                        int sum = num1 * num2;
                        numbers[index1] = sum;
                        break;

                    case "decrease":
                        for (int index = 0; index < numbers.Length; index++)
                        {
                            numbers[index]--;
                        }
                        break;
                }

                commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                command = commands[0];
            }
            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
