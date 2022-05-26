using System;

namespace _04.PersonalTitles
{
    class PersonalTitles
    {
        static void Main(string[] args)
        {
            double age = double.Parse(Console.ReadLine());
            string gender = Console.ReadLine();

            bool sixteenPlus = age >= 16;

            if (sixteenPlus)
            {
                if (gender == "m")
                {
                    Console.WriteLine("Mr.");
                }

                else if (gender == "f")
                {
                    Console.WriteLine("Ms.");
                }
            }

            else
            {
                if (gender == "m")
                {
                    Console.WriteLine("Master");
                }

                else if (gender == "f")
                {
                    Console.WriteLine("Miss");
                }
            }
        }
    }
}
