using System;
using System.Collections.Generic;
using System.Text;

namespace _03.ShoppingSpree.Models
{
    public class Person
    {
        private string name;
        private double money;

        public Person(string name, double money)
        {
            this.Name = name;
            this.Money = money;
            this.Products = new List<string>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionsMessages.NAME_CANNOT_BE_EMPTY);
                }

                this.name = value;
            }
        }

        public double Money
        {
            get
            {
                return this.money;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionsMessages.MONEY_CANNOT_BE_NEGATIVE);
                }

                this.money = value;
            }
        }

        public List<string> Products { get; set; }

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
