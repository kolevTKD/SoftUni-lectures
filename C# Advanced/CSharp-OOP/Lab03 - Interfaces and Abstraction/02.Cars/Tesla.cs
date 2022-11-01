using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Tesla : IElectricCar, ICar
    {
        public Tesla(string model, string color, int battery)
        {
            Model = model;
            Color = color;
            Battery = battery;
        }
        public string Model { get; private set; }
        public string Color { get; private set; }
        public int Battery { get; private set; }

        public string Start() => "Engine start";
        public string Stop() => "Breaaak!";

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Color} {GetType().Name} {Model} with {Battery} Batteries")
                .AppendLine($"{Start()}")
                .AppendLine($"{Stop()}");

            return sb.ToString().TrimEnd();
        }
    }
}
