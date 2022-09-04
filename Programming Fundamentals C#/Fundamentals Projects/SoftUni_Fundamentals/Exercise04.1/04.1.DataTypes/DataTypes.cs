using System;

namespace _04._1.DataTypes
{
    internal class DataTypes
    {
        static void Main(string[] args)
        {
            string dataType = Console.ReadLine();
            string input = Console.ReadLine();
            string result = "";
            bool successParse = false;

            if (dataType == "int")
            {
                successParse = int.TryParse(input, out int intResult);

                if (successParse)
                {
                    intResult *= 2;
                    result = intResult.ToString();
                }
            }

            else if (dataType == "real")
            {
                successParse = double.TryParse(input, out double doubleResult);

                if (successParse)
                {
                    doubleResult *= 1.5;
                    result = $"{doubleResult:f2}";
                }
            }

            else
            {
                result = input.Insert(0, "$");
                result = result.Insert(result.Length, "$");
            }

            Console.WriteLine(result);
        }
    }
}
