using System;
using System.Collections.Generic;

namespace _04.ProductShop
{
    internal class ProductShop
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> productsInShops = new SortedDictionary<string, Dictionary<string, double>>();

            while (true)
            {
                string[] shopsAndProducts = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

                if (shopsAndProducts[0] == "Revision")
                {
                    break;
                }

                string shopName = shopsAndProducts[0];
                string productName = shopsAndProducts[1];
                double price = double.Parse(shopsAndProducts[2]);

                if (!productsInShops.ContainsKey(shopName))
                {
                    productsInShops.Add(shopName, new Dictionary<string, double>());
                }

                productsInShops[shopName].Add(productName, price);
            }

            foreach (var shop in productsInShops)
            {
                Console.WriteLine($"{shop.Key}->");

                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
