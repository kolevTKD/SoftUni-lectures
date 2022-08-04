using System;

namespace _02._1.DataTypeFinder
{
    class DataTypeFinder
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string end = "END";
            string dataType = "";

            while (input != end)
            {
                if (int.TryParse(input, out int intResult))
                {
                    dataType = "integer";
                }

                else if (float.TryParse(input, out float floatResult))
                {
                    dataType = "floating point";
                }

                else if (char.TryParse(input, out char charResult))
                {
                    dataType = "character";
                }

                else if (bool.TryParse(input, out bool boolResult))
                {
                    dataType = "boolean";
                }

                else
                {
                    dataType = "string";
                }

                Console.WriteLine($"{input} is {dataType} type");
                input = Console.ReadLine();
            }
        }
    }
}
