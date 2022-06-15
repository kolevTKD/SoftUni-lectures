using System;
using System.Collections.Generic;

namespace _04.ListOfProducts
{
    class ListOfProducts
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<string> products = new List<string>();

            for (int index = 0; index < count; index++)
            {
                string product = Console.ReadLine();
                products.Add(product);
            }

            products.Sort();
            int counter = 1;

            foreach (string product in products)
            {
                Console.WriteLine($"{counter}.{product}");
                counter++;
            }
        }
    }
}
