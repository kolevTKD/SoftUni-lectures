using System;
using System.Linq;
using System.Text;

namespace _05.Digits_LettersAndOthers
{
    class DigitsLettersAndOthers
    {
        static void Main(string[] args)
        {
            string inputSequence = Console.ReadLine();

            char[] digits = inputSequence.Where(ch => char.IsDigit(ch)).ToArray();
            char[] letters = inputSequence.Where(ch => char.IsLetter(ch)).ToArray();
            char[] others = inputSequence.Where(ch => !char.IsLetterOrDigit(ch)).ToArray();

            Console.WriteLine(digits);
            Console.WriteLine(letters);
            Console.WriteLine(others);
            
        }
    }
}
