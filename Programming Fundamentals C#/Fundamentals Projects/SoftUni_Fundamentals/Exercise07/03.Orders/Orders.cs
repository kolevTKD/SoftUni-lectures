using System;
using System.Collections.Generic;

namespace _03.Orders
{
    class Orders
    {
        static void Main(string[] args)
        {
            string[] currentProduct = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string end = "buy";
            Dictionary<string, double> products = new Dictionary<string, double>();
            Dictionary<string, int> newProducts = new Dictionary<string, int>();

            while (currentProduct[0] != end)
            {
                string productName = currentProduct[0];
                double productPrice = double.Parse(currentProduct[1]);
                int productQuantity = int.Parse(currentProduct[2]);

                if (!products.ContainsKey(productName))
                {
                    products.Add(productName, productPrice);
                    newProducts.Add(productName, productQuantity);
                }

                else if (products.ContainsKey(productName))
                {
                    newProducts[productName] += productQuantity;

                    if (!products.ContainsValue(productPrice))
                    {
                        products[productName] = productPrice;
                    }
                }

                currentProduct = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var product in products)
            {
                foreach (var newProduct in newProducts)
                {
                    if (product.Key == newProduct.Key)
                    {
                        Console.WriteLine($"{product.Key} -> {product.Value * newProduct.Value:f2}");
                    }
                }
            }
        }
    }
}
