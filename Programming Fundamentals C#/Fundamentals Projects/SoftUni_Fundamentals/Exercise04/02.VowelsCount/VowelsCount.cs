using System;
using System.Linq;

namespace _02.VowelsCount
{
    class VowelsCount
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToLower();
            VowelsCount1(input); //Method1
            Console.WriteLine(VowelsCount2(input)); //Method2
        }

        static void VowelsCount1(string text) //Method1
        {
            Console.WriteLine(text.Count(vowel => "aeiou".Contains(vowel)));
        }

        static int VowelsCount2(string text) //Method2
        {
            int count = 0;

            foreach (char vowel in text)
            {
                if ("aeiou".Contains(vowel))
                {
                    count++;
                }
            }
            return count;
        }
    }
}
