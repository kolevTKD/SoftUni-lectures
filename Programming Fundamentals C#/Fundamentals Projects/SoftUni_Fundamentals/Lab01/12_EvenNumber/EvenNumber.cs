using System;

namespace _12_EvenNumber
{
    class EvenNumber
    {
        static void Main(string[] args)
        {
            int inputNum = int.Parse(Console.ReadLine());

            while (inputNum % 2 != 0)
            {

                Console.WriteLine("Please write an even number.");

                inputNum = int.Parse(Console.ReadLine());

                if (inputNum % 2 == 0)
                {
                    break;
                }
            }

            if (inputNum % 2 == 0)
            {
                int absInput = Math.Abs(inputNum);
                Console.WriteLine($"The number is: {absInput}");
                return;
            }
        }
    }
}
