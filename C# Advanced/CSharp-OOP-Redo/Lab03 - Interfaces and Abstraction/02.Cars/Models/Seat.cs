namespace Cars.Models
{
    using Contracts;
    using System.Text;

    public class Seat : ICar
    {
        public Seat(string model, string color)
        {
            Model = model;
            Color = color;
        }

        public string Model { get; private set; }
        public string Color { get; private set; }

        public string Start() => "Engine start";
        public string Stop() => "Breaaak!";
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Color} {nameof(Seat)} {Model}")
              .AppendLine($"{Start()}")
              .AppendLine($"{Stop()}");

            return sb.ToString().Trim();
        }
    }
}
