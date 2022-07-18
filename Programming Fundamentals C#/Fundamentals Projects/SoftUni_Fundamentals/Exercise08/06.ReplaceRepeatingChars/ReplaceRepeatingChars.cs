using System;
using System.Text;

namespace _06.ReplaceRepeatingChars
{
    class ReplaceRepeatingChars
    {
        static void Main(string[] args)
        {
            string sequence = Console.ReadLine();
            StringBuilder reducedSequence = new StringBuilder();
            reducedSequence.Append(sequence[0]);

            for (int index = 1; index < sequence.Length; index++)
            {
                if (sequence[index] == sequence[index - 1])
                {
                    continue;
                }

                reducedSequence.Append(sequence[index]);
            }

            Console.WriteLine(reducedSequence);
        }
    }
}
