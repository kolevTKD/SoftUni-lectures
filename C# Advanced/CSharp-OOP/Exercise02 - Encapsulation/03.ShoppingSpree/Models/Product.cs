using System;
using System.Collections.Generic;
using System.Text;

namespace _03.ShoppingSpree.Models
{
    public class Product
    {
        private string name;
        private double cost;

        public Product(string name, double cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionsMessages.NAME_CANNOT_BE_EMPTY);
                }

                this.name = value;
            }
        }

        public double Cost
        {
            get
            {
                return this.cost;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionsMessages.MONEY_CANNOT_BE_NEGATIVE);
                }

                this.cost = value;
            }
        }
    }
}
