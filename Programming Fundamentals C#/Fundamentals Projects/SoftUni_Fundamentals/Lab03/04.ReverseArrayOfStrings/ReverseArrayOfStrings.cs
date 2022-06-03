using System;
using System.Linq;

namespace _04.ReverseArrayOfStrings
{
    class ReverseArrayOfStrings
    {
        static void Main(string[] args)
        {
            string[] stringArray = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            for (int index = 0; index < stringArray.Length / 2; index++)
            {
                string oldElement = stringArray[index];
                stringArray[index] = stringArray[stringArray.Length - 1 - index];
                stringArray[stringArray.Length - 1 - index] = oldElement;
            }

            Console.WriteLine(string.Join(" ", stringArray));
        }
    }
}
