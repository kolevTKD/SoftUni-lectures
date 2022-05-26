using System;

namespace _03_Vacation
{
    class Vacation
    {
        static void Main(string[] args)
        {
            int pplCount = int.Parse(Console.ReadLine());
            string groupType = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();
            string students = "Students";
            string business = "Business";
            string regular = "Regular";
            string friday = "Friday";
            string saturday = "Saturday";
            string sunday = "Sunday";
            double price = 0;
            double total = 0;
            double discount = 0;

            if(groupType == students)
            {
                if(dayOfWeek == friday)
                {
                    price = 8.45;
                }

                else if(dayOfWeek == saturday)
                {
                    price = 9.8;
                }

                else if(dayOfWeek == sunday)
                {
                    price = 10.46;
                }

                if(pplCount >= 30)
                {
                    discount = 0.85;
                    total = pplCount * price * discount;
                }

                else
                {
                    total = pplCount * price;
                }
            }

            else if(groupType == business)
            {
                if (dayOfWeek == friday)
                {
                    price = 10.9;
                }

                else if (dayOfWeek == saturday)
                {
                    price = 15.6;
                }

                else if (dayOfWeek == sunday)
                {
                    price = 16;
                }

                if(pplCount >= 100)
                {
                    discount = 10 * price;
                    total = pplCount * price - discount;
                }

                else
                {
                    total = pplCount * price;
                }
            }

            else if(groupType == regular)
            {
                if (dayOfWeek == friday)
                {
                    price = 15;
                }

                else if (dayOfWeek == saturday)
                {
                    price = 20;
                }

                else if (dayOfWeek == sunday)
                {
                    price = 22.5;
                }

                if(pplCount >= 10 && pplCount <= 20)
                {
                    discount = 0.95;
                    total = pplCount * price * discount;
                }

                else
                {
                    total = pplCount * price;
                }
            }

            Console.WriteLine($"Total price: {total:f2}");
        }
    }
}
