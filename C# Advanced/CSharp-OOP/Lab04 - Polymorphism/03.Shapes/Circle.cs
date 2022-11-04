using System;

namespace Shapes
{
    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
            : base()
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get => this.radius;
            private set => this.radius = value;
        }

        public override double CalculateArea() => Math.PI * Math.Pow(this.Radius, 2);

        public override double CalculatePerimeter() => 2 * (Math.PI * this.Radius);

        public override string Draw() => $"Drawing {typeof(Circle).Name}";
    }
}
