using System;
using System.Text;

namespace _05.MultiplyBigNumber
{
    class MultiplyBigNumber
    {
        static void Main(string[] args)
        {
            string bigNumber = Console.ReadLine();
            int multiplier = int.Parse(Console.ReadLine());

            if (multiplier == 0)
            {
                Console.WriteLine(0);
                return;
            }

            StringBuilder resultNumber = new StringBuilder();
            int remainder = 0;

            for (int index = bigNumber.Length - 1; index >= 0; index--)
            {
                int currentDigit = (int)char.GetNumericValue(bigNumber[index]);
                int currentResult = multiplier * currentDigit + remainder;
                resultNumber.Append(currentResult % 10);

                remainder = currentResult / 10;
            }

            if (remainder != 0)
            {
                resultNumber.Append(remainder);
            }

            StringBuilder reversed = new StringBuilder();

            for (int i = resultNumber.Length - 1; i >= 0; i--)
            {
                reversed.Append(resultNumber[i]);
            }

            Console.WriteLine(reversed);

            //for (int index = bigNumber.Length - 1; index >= 0; index--)
            //{
            //    int currentDigit = (int)char.GetNumericValue(bigNumber[index]);
            //    int currentResult = multiplier * currentDigit + remainder;
            //    resultNumber.Insert(0, currentResult % 10);

            //    remainder = currentResult / 10;
            //}

            //if (remainder != 0)
            //{
            //    resultNumber.Insert(0, remainder);
            //}

            //Console.WriteLine(resultNumber);
        }
    }
}
