namespace SumOfIntegers
{
    using System;

    public class SumOfIntegers
    {
        static void Main(string[] args)
        {
            string[] elements = Console.ReadLine().Split(' ');
            string currentElement = string.Empty;

            int totalSum = 0;

            for (int currEl = 0; currEl < elements.Length; currEl++)
            {
                try
                {
                    int num = int.Parse(currentElement = elements[currEl]);
                    totalSum += num;

                }
                catch (FormatException)
                {
                    Console.WriteLine($"The element '{currentElement}' is in wrong format!");
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"The element '{currentElement}' is out of range!");
                }
                finally
                {
                    Console.WriteLine($"Element '{currentElement}' processed - current sum: {totalSum}");
                }
            }

            Console.WriteLine($"The total sum of all integers is: {totalSum}");
        }
    }
}
