using System;

namespace _01.ReverseStrings
{
    class ReverseStrings
    {
        static void Main(string[] args)
        {
            string inputLine = Console.ReadLine();
            string end = "end";

            while (inputLine != end)
            {
                string reversed = "";

                for (int index = inputLine.Length - 1; index >= 0; index--)
                {
                    reversed += inputLine[index];
                }

                Console.WriteLine($"{inputLine} = {reversed}");
                inputLine = Console.ReadLine();
            }

            //while (inputLine != end)
            //{
            //    string reversed = "";
            //    for (int index = 0; index <= inputLine.Length - 1; index++)
            //    {
            //        reversed += inputLine[inputLine.Length - index - 1];
            //    }

            //    Console.WriteLine($"{inputLine} = {reversed}");
            //    inputLine = Console.ReadLine();
            //}
        }
    }
}
