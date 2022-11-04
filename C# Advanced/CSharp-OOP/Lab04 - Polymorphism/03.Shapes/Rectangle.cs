namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public Rectangle(double height, double width)
            : base()
        {
            this.Height = height;
            this.Width = width;
        }

        public double Height
        {
            get => this.height;
            private set => this.height = value;
        }

        public double Width
        {
            get => this.width;
            private set => this.width = value;
        }
        public override double CalculateArea() => this.Width * this.Height;

        public override double CalculatePerimeter() => 2 * (this.Width + this.Height);

        public override string Draw() => $"Drawing {typeof(Rectangle).Name}";
    }
}
