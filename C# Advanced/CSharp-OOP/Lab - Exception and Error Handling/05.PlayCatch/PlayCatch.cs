namespace PlayCatch
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PlayCatch
    {
        static void Main(string[] args)
        {
            int[] numsArr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(n => int.Parse(n)).ToArray();
            int exceptionCounter = 0;
            

            while (exceptionCounter < 3)
            {
                try
                {
                    string[] cmdArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    string cmd = cmdArgs[0];
                    int index = int.Parse(cmdArgs[1]);

                    if (cmd == "Replace")
                    {
                        int element = int.Parse(cmdArgs[2]);

                        Replace(index, element, numsArr);
                    }

                    else if (cmd == "Print")
                    {
                        int endIndex = int.Parse(cmdArgs[2]);

                        Print(index, endIndex, numsArr);
                    }

                    else if (cmd == "Show")
                    {
                        Show(index, numsArr);
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("The index does not exist!");
                    exceptionCounter++;
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("The index does not exist!");
                    exceptionCounter++;
                }
                catch (FormatException)
                {
                    Console.WriteLine("The variable is not in the correct format!");
                    exceptionCounter++;
                }
            }

            Console.WriteLine(string.Join(", ", numsArr));
        }

        public static void Replace(int index, int element, int[] nums) => nums[index] = element;

        public static void Print(int startIndex, int endIndex, int[] nums)
        {
            string[] numsString = nums.Select(n => n.ToString()).ToArray();
            
            int count = endIndex - startIndex + 1;
            Console.WriteLine(String.Join(", ", numsString, startIndex, count));
        }

        public static void Show(int index, int[] nums) => Console.WriteLine(nums[index]);

    }
}
