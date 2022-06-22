using System;
using System.Linq;

namespace _11.ArrayManipulator
{
    class ArrayManipulator
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

                else if (command[0] == "max")
                {
                    MaxValue(numbers, command[1]);
                }

                else if (command[0] == "min")
                {
                    MinValue(numbers, command[1]);
                }

                else if (command[0] == "first")
                {
                    int givenCount = int.Parse(command[1]);
                    First(numbers, givenCount, command[2]);
                }

                else if (command[0] == "last")
                {
                    int givenCount = int.Parse(command[1]);
                    Last(numbers, givenCount, command[2]);
                }

                command = Console.ReadLine().Split();
            }

            Console.WriteLine($"[{string.Join(", ", numbers)}]");
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

            for (int i = splitIndex + 1; i < numArray.Length; i++)
            {
                exchangedArray[index] = numArray[i];
                index++;
            }

            for (int i = 0; i <= splitIndex; i++)
            {
                exchangedArray[index] = numArray[i];
                index++;
            }

            return exchangedArray;
        }

        static void MaxValue(int[] numbers, string evenOdd)
        {
            int evenIndex = -1;
            int oddIndex = -1;
            int maxValue = int.MinValue;
            bool containsNum = false;

            if (evenOdd == "even")
            {
                for (int index = 0; index < numbers.Length; index++)
                {
                    if (numbers[index] % 2 == 0)
                    {
                        containsNum = true;
                        if (numbers[index] >= maxValue)
                        {
                            maxValue = numbers[index];
                            evenIndex = index;
                        }
                    }
                }

                if (!containsNum)
                {
                    Console.WriteLine("No matches");
                    return;
                }

                Console.WriteLine(evenIndex);
            }

            else if (evenOdd == "odd")
            {
                for (int index = 0; index < numbers.Length; index++)
                {
                    if (numbers[index] % 2 == 1)
                    {
                        containsNum = true;
                        if (numbers[index] >= maxValue)
                        {
                            maxValue = numbers[index];
                            oddIndex = index;
                        }
                    }
                }

                if (!containsNum)
                {
                    Console.WriteLine("No matches");
                    return;
                }

                Console.WriteLine(oddIndex);
            }
        }

        static void MinValue(int[] numbers, string evenOdd)
        {
            int evenIndex = -1;
            int oddIndex = -1;
            int minValue = int.MaxValue;
            bool containsNum = false;

            if (evenOdd == "even")
            {
                for (int index = 0; index < numbers.Length; index++)
                {
                    if (numbers[index] % 2 == 0)
                    {
                        containsNum = true;
                        if (numbers[index] <= minValue)
                        {
                            minValue = numbers[index];
                            evenIndex = index;
                        }
                    }
                }

                if (!containsNum)
                {
                    Console.WriteLine("No matches");
                    return;
                }

                Console.WriteLine(evenIndex);
            }

            else if (evenOdd == "odd")
            {
                for (int index = 0; index < numbers.Length; index++)
                {
                    if (numbers[index] % 2 == 1)
                    {
                        containsNum = true;
                        if (numbers[index] <= minValue)
                        {
                            minValue = numbers[index];
                            oddIndex = index;
                        }
                    }
                }

                if (!containsNum)
                {
                    Console.WriteLine("No matches");
                    return;
                }

                Console.WriteLine(oddIndex);
            }
        }

        static void First(int[] numbers, int count, string evenOdd)
        {
            int[] evenNums = new int[count];
            int evensCount = 0;
            int[] oddNums = new int[count];
            int oddsCount = 0;

            if (count > numbers.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            if (evenOdd == "even")
            {
                for (int index = 0; index < numbers.Length; index++)
                {
                    if (numbers[index] % 2 == 0)
                    {
                        evensCount++;
                    }

                    if (evensCount == count)
                    {
                        break;
                    }
                }

                if (evensCount == 0)
                {
                    Console.WriteLine("[]");
                    return;
                }

                else if (evensCount < count)
                {
                    evenNums = new int[evensCount];
                }

                int currIndex = 0;

                for (int index = 0; index < numbers.Length; index++)
                {
                    if (numbers[index] % 2 == 0)
                    {
                        evenNums[currIndex] = numbers[index];
                        currIndex++;
                    }

                    if (currIndex == count)
                    {
                        break;
                    }
                }
                Console.WriteLine($"[{string.Join(", ", evenNums)}]");
            }

            else if (evenOdd == "odd")
            {
                for (int index = 0; index < numbers.Length; index++)
                {
                    if (numbers[index] % 2 == 1)
                    {
                        oddsCount++;
                    }

                    if (oddsCount == count)
                    {
                        break;
                    }
                }

                if (oddsCount == 0)
                {
                    Console.WriteLine("[]");
                    return;
                }

                else if (oddsCount < count)
                {
                    oddNums = new int[oddsCount];
                }

                int currIndex = 0;

                for (int index = 0; index < numbers.Length; index++)
                {
                    if (numbers[index] % 2 == 1)
                    {
                        oddNums[currIndex] = numbers[index];
                        currIndex++;
                    }

                    if (currIndex == count)
                    {
                        break;
                    }
                }
                Console.WriteLine($"[{string.Join(", ", oddNums)}]");
            }
        }

        static void Last(int[] numbers, int count, string evenOdd)
        {
            int[] evenNums = new int[count];
            int evensCount = 0;
            int[] oddNums = new int[count];
            int oddsCount = 0;

            if (count > numbers.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            if (evenOdd == "even")
            {
                for (int index = numbers.Length - 1; index >= 0; index--)
                {
                    if (numbers[index] % 2 == 0)
                    {
                        evensCount++;
                    }

                    if (evensCount == count)
                    {
                        break;
                    }
                }

                if (evensCount == 0)
                {
                    Console.WriteLine("[]");
                    return;
                }

                else if (evensCount < count)
                {
                    evenNums = new int[evensCount];
                }

                int currIndex = evenNums.Length - 1;

                for (int index = numbers.Length - 1; index >= 0; index--)
                {
                    if (numbers[index] % 2 == 0)
                    {
                        evenNums[currIndex] = numbers[index];
                        currIndex--;
                    }

                    if (currIndex < 0)
                    {
                        break;
                    }
                }

                Console.WriteLine($"[{string.Join(", ", evenNums)}]");
            }

            else if (evenOdd == "odd")
            {
                for (int index = numbers.Length - 1; index >= 0; index--)
                {
                    if (numbers[index] % 2 == 1)
                    {
                        oddsCount++;
                    }

                    if (oddsCount == count)
                    {
                        break;
                    }
                }

                if (oddsCount == 0)
                {
                    Console.WriteLine("[]");
                    return;
                }

                else if (oddsCount < count)
                {
                    oddNums = new int[oddsCount];
                }

                int currIndex = oddNums.Length - 1;

                for (int index = numbers.Length - 1; index >= 0; index--)
                {
                    if (numbers[index] % 2 == 1)
                    {
                        oddNums[currIndex] = numbers[index];
                        currIndex--;
                    }

                    if (currIndex < 0)
                    {
                        break;
                    }
                }

                Console.WriteLine($"[{string.Join(", ", oddNums)}]");
            }
        }
    }
}


