using System;

namespace _01_Ages
{
    class Ages
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            bool baby = age >= 0 && age <= 2;
            bool child = age >= 3 && age <= 13;
            bool teenager = age >= 14 && age <= 19;
            bool adult = age >= 20 && age <= 65;
            bool elder = age >= 66;
            string aged = null;

            if(baby)
            {
                aged = "baby";
            }

            else if(child)
            {
                aged = "child"; 
            }

            else if(teenager)
            {
                aged = "teenager";
            }

            else if(adult)
            {
                aged = "adult";
            }

            else if(elder)
            {
                aged = "elder";
            }

            Console.WriteLine(aged);
        }
    }
}
