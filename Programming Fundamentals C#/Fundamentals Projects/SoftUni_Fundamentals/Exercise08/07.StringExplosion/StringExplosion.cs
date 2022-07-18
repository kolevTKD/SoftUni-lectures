using System;
using System.Text;

namespace _07.StringExplosion
{
    class StringExplosion
    {
        static void Main(string[] args)
        {
            string textSequence = Console.ReadLine();
            StringBuilder exploded = new StringBuilder();
            int power = 0;

            for (int index = 0; index < textSequence.Length; index++)
            {
                if (textSequence[index] == '>')
                {
                    power += int.Parse(textSequence[index + 1].ToString());
                    exploded.Append(textSequence[index]);
                }

                else if (power == 0)
                {
                    exploded.Append(textSequence[index]);
                }

                else
                {
                    power--;
                }
            }

            Console.WriteLine(exploded);
        }
    }
}
