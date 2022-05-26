using System;

namespace _03.MobileOperator
{
    class MobileOperator
    {
        static void Main(string[] args)
        {
            string one = "one";
            string two = "two";
            string small = "Small";
            string middle = "Middle";
            string large = "Large";
            string extraLarge = "ExtraLarge";
            string yes = "yes";
            string no = "no";

            string term = Console.ReadLine();
            string contractType = Console.ReadLine();
            string addedMobileInternet = Console.ReadLine();
            int monthsToPay = int.Parse(Console.ReadLine());

            double tax = 0;
            double markup = 0;
            double total = 0;

            bool isAdded = false;

            if (term == one)
            {
                if (contractType == small)
                {
                    tax = 9.98;
                }

                else if (contractType == middle)
                {
                    tax = 18.99;
                }

                else if (contractType == large)
                {
                    tax = 25.98;
                }

                else if (contractType == extraLarge)
                {
                    tax = 35.99;
                }
            }

            else if (term == two)
            {
                if (contractType == small)
                {
                    tax = 8.58;
                }

                else if (contractType == middle)
                {
                    tax = 17.09;
                }

                else if (contractType == large)
                {
                    tax = 23.59;
                }

                else if (contractType == extraLarge)
                {
                    tax = 31.79;
                }
            }

            if (addedMobileInternet == yes)
            {
                isAdded = true;
            }
            else if (addedMobileInternet == no)
            {
                total += tax;
            }

            if (isAdded)
            {
                if (tax <= 10.00)
                {
                    markup = 5.5;
                }

                else if (tax <= 30.00)
                {
                    markup = 4.35;
                }

                else if (tax > 30.00)
                {
                    markup = 3.85;
                }

                total = markup + tax;
            }

            total *= monthsToPay;

            if (term == two)
            {
                total *= 0.9625;
            }

            Console.WriteLine($"{total:f2} lv.");
        }
    }
}
