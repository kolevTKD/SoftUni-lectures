﻿namespace FoodShortage.Models
{
    using Contracts;
    public class Citizen : ICitizen, IBuyer
    {
        private const int FOOD = 10;
        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Id { get; private set; }
        public string Birthdate { get; private set; }
        public int Food { get; private set; }

        public void BuyFood() => this.Food += FOOD;
    }
}
