using System;
using System.Text;

namespace _02._5.DecryptingMessages
{
    class DecryptingMessages
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int linesCount = int.Parse(Console.ReadLine());
            StringBuilder message = new StringBuilder();

            for (int line = 1; line <= linesCount; line++)
            {
                char letter = char.Parse(Console.ReadLine());
                message.Append((char)(letter + key));
            }

            Console.WriteLine(message);
        }
    }
}
