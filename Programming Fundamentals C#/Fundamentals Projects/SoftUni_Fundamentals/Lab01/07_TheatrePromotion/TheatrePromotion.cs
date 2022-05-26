using System;

namespace _07_TheatrePromotion
{
    class TheatrePromotion
    {
        static void Main(string[] args)
        {
            string typeOfDay = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            int ticketPrice = 0;
            bool error = false;

            if (typeOfDay == "Weekday")
            {
                if((age >= 0 && age <= 18) || (age > 64 && age <= 122))
                {
                    ticketPrice = 12;
                }

                else if(age > 18 && age <= 64)
                {
                    ticketPrice = 18;
                }
                else
                {
                    error = true;
                }
            }

            else if(typeOfDay == "Weekend")
            {
                if ((age >= 0 && age <= 18) || (age > 64 && age <= 122))
                {
                    ticketPrice = 15;
                }

                else if(age > 18 && age <= 64)
                {
                    ticketPrice = 20;
                }

                else
                {
                    error = true;
                }
            }
            else if(typeOfDay == "Holiday")
            {
                if(age >= 0 && age <= 18)
                {
                    ticketPrice = 5;
                }

                else if(age > 18 && age <= 64)
                {
                    ticketPrice = 12;
                }

                else if(age > 64 && age <= 122)
                {
                    ticketPrice = 10;
                }

                else
                {
                    error = true;
                }
            }
            if(error)
            {
                Console.WriteLine("Error!");
            }
            else
            {
                Console.WriteLine($"{ticketPrice}$");
            }
        }
    }
}
