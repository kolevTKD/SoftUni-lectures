using System;
using System.Text;

namespace _04.CaesarCipher
{
    class CaesarCipher
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            StringBuilder newText = new StringBuilder();

            for (int index = 0; index < text.Length; index++)
            {
                char curr = text[index];
                char newChar = (char)(curr + 3);
                newText.Append(newChar);
            }

            Console.WriteLine(newText);

            //for (int index = 0; index < text.Length; index++)
            //{
            //    char curr = text[index];
            //    char newChar = (char)(curr + 3);
            //    newText += newChar;
            //}

            //Console.WriteLine(text);
        }
    }
}
