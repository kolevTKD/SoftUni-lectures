using System;
using System.Collections.Generic;

namespace _06._5.ShoppingSpree
{
    internal class ShoppingSpree
    {
        static void Main(string[] args)
        {
            string[] peopleInShop = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            string[] productsToBuy = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            for (int index = 0; index < peopleInShop.Length; index++)
            {
                string[] currentPersonInfo = peopleInShop[index].Split('=', StringSplitOptions.RemoveEmptyEntries);
                string name = currentPersonInfo[0];
                double money = double.Parse(currentPersonInfo[1]);
                Person person = new Person(name, money, new List<string>());
                people.Add(person);
            }

            for (int index = 0; index < productsToBuy.Length; index++)
            {
                string[] currentProduct = productsToBuy[index].Split('=', StringSplitOptions.RemoveEmptyEntries);
                string name = currentProduct[0];
                double cost = double.Parse(currentProduct[1]);
                Product product = new Product(name, cost);
                products.Add(product);
            }

            while (true)
            {
                string[] personBuy = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (personBuy[0] == "END")
                {
                    break;
                }

                string name = personBuy[0];
                string productName = personBuy[1];

                foreach (Person person in people)
                {
                    if (name == person.Name)
                    {
                        foreach (Product product in products)
                        {
                            if (productName == product.Name && person.Money - product.Cost >= 0)
                            {
                                person.BagOfProducts.Add(product.Name);
                                person.Money -= product.Cost;
                                Console.WriteLine($"{person.Name} bought {product.Name}");
                                break;
                            }

                            else if (productName == product.Name && person.Money - product.Cost < 0)
                            {
                                Console.WriteLine($"{person.Name} can't afford {product.Name}");
                                break;
                            }
                        }
                    }
                }
            }

            foreach (Person person in people)
            {
                if (person.BagOfProducts.Count != 0)
                {
                    Console.WriteLine($"{person.Name} - {string.Join(", ", person.BagOfProducts)}");
                    continue;
                }

                Console.WriteLine($"{person.Name} - Nothing bought");
            }
        }
    }

    class Person
    {
        public Person(string name, double money, List<string> bagOfProducts)
        {
            Name = name;
            Money = money;
            BagOfProducts = bagOfProducts;
        }
        public string Name { get; set; }
        public double Money { get; set; }
        public List<string> BagOfProducts { get; set; }
    }

    class Product
    {
        public Product(string name, double cost)
        {
            Name = name;
            Cost = cost;
        }
        public string Name { get; set; }
        public double Cost { get; set; }
    }
}
