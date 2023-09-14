namespace Cars.Models
{
    using Contracts;
    using System.Text;

    public class Tesla : IElectricCar
    {
        public Tesla(string model, string color, int batteries)
        {
            Model = model;
            Color = color;
            Battery = batteries;
        }

        public string Model { get; private set; }
        public string Color { get; private set; }
        public int Battery { get; private set; }

        public string Start() => "Engine start";
        public string Stop() => "Breaaak!";
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Color} {nameof(Tesla)} {Model} with {Battery} Batteries")
              .AppendLine($"{Start()}")
              .AppendLine($"{Stop()}");

            return sb.ToString().Trim();
        }

    }
}
