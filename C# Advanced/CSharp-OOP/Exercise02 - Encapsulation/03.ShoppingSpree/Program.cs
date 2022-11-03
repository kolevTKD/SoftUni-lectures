using System;
using System.Collections.Generic;
using _03.ShoppingSpree.Models;

namespace _03.ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> customers = new List<Person>();
            List<Product> products = new List<Product>();
            try
            {
                string[] customersMoney = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

                foreach (string client in customersMoney)
                {
                    string[] currClient = client.Split('=');
                    Person person = new Person(currClient[0], double.Parse(currClient[1]));
                    customers.Add(person);
                }

                string[] productCosts = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

                foreach (string item in productCosts)
                {
                    string[] currProduct = item.Split('=');
                    Product product = new Product(currProduct[0], double.Parse(currProduct[1]));
                    products.Add(product);
                }
            }
            catch(ArgumentException ae)
            {
                Console.WriteLine(ae.Message);

                return;
            }

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] clientProduct = input.Split(' ');
                string clientName = clientProduct[0];
                string productName = clientProduct[1];

                Person currentClient = customers.Find(c => c.Name == clientName);
                Product currentProduct = products.Find(p => p.Name == productName);

                Console.WriteLine(Person.CheckProduct(currentClient, currentProduct));

                input = Console.ReadLine();
            }

            foreach (var customer in customers)
            {
                Console.Write($"{customer.Name} - ");

                if (customer.Products.Count == 0)
                {
                    Console.WriteLine("Nothing bought");
                }

                else
                {
                    Console.WriteLine(string.Join(", ", customer.Products));
                }
            }
        }
    }
}
