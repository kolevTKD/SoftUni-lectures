namespace _03.ShoppingSpree
{
    using Models;
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] peopleMoneyInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            string[] productCostInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            List<Person> peopleShopping = new List<Person>();
            List<Product> products = new List<Product>();

            try
            {
                foreach (string personMoney in peopleMoneyInput)
                {
                    string[] personInfo = personMoney.Split('=', StringSplitOptions.RemoveEmptyEntries);
                    string personName = personInfo[0];
                    decimal money = decimal.Parse(personInfo[1]);

                    Person person = new Person(personName, money);
                    peopleShopping.Add(person);
                }

                foreach (string productCost in productCostInput)
                {
                    string[] productInfo = productCost.Split('=', StringSplitOptions.RemoveEmptyEntries);
                    string productName = productInfo[0];
                    decimal cost = decimal.Parse(productInfo[1]);

                    Product product = new Product(productName, cost);
                    products.Add(product);
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                return;
            }

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] personBuying = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string personName = personBuying[0];
                string productName = personBuying[1];

                Person person = peopleShopping.Find(p => p.Name == personName);
                Product product = products.Find(p => p.Name == productName);

                Console.WriteLine(Person.CheckProduct(person, product));
            }

            foreach (Person person in peopleShopping)
            {
                Console.Write($"{person.Name} - ");

                if (person.Products.Count == 0)
                {
                    Console.WriteLine("Nothing bought");
                }
                else
                {
                    Console.WriteLine(String.Join(", ", person.Products));
                }
            }
        }
    }
}
