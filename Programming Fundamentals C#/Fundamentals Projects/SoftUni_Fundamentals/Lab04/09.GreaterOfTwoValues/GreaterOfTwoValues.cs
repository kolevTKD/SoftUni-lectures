using System;

namespace _09.GreaterOfTwoValues
{
    class GreaterOfTwoValues
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();

            switch(type)
            {
                case "int":
                    int firstInt = int.Parse(Console.ReadLine());
                    int secondInt = int.Parse(Console.ReadLine());
                    Console.WriteLine(GetMax(firstInt, secondInt));
                    break;

                case "char":
                    char firstChar = char.Parse(Console.ReadLine());
                    char secondChar = char.Parse(Console.ReadLine());
                    Console.WriteLine(GetMax(firstChar, secondChar));
                    break;

                case "string":
                    string first = Console.ReadLine();
                    string second = Console.ReadLine();
                    Console.WriteLine(GetMax(first, second));
                    break;
            }
        }

        static int GetMax(int first, int second)
        {
            if (first > second)
            {
                return first;
            }

            return second;
        }

        static char GetMax(char first, char second)
        {
            if (first > second)
            {
                return first;
            }

            return second;
        }

        static string GetMax(string first, string second)
        {
            int result = first.CompareTo(second);

            if (result > 0)
            {
                return first;
            }

            return second;
        }
    }
}
