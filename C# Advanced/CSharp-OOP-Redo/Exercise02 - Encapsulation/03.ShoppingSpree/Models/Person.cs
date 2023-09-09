namespace _03.ShoppingSpree.Models
{
    using System;
    using System.Collections.Generic;

    public class Person
    {
        private string name;
        private decimal money;
        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            Products = new List<string>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NAME_CANNOT_BE_EMPTY);
                }
                else
                {
                    name = value;
                }
            }
        }
        public decimal Money
        {
            get => money;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.MONEY_CANNOT_BE_NEGATIVE);
                }
                else
                {
                    money = value;
                }
            }
        }
        public List<string> Products { get; private set; }

        public static string CheckProduct(Person person, Product product)
        {
            if (person.Money < product.Cost)
            {
                return
                    $"{person.Name} can't afford {product.Name}";
            }
            else
            {
                person.Money -= product.Cost;
                person.Products.Add(product.Name);

            return
                $"{person.Name} bought {product.Name}";
            }
        }
    }
}
