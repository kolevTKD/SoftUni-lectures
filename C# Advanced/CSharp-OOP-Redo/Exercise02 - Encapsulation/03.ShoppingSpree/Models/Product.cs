namespace _03.ShoppingSpree.Models
{
    using System;
    public class Product
    {
        private string name;
        private decimal cost;
        public Product(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
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

        public decimal Cost
        {
            get => cost;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.MONEY_CANNOT_BE_NEGATIVE);
                }
                else
                {
                    cost = value;
                }
            }
        }
    }
}
