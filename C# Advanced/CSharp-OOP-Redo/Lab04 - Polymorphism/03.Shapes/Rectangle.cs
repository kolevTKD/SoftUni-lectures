namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public Rectangle(double height, double width)
            : base()
        {
            Height = height;
            Width = width;
        }

        public double Height
        {
            get => height;
            private set => height = value;
        }
        public double Width
        {
            get => width;
            private set => width = value;
        }

        public override double CalculateArea() => Width * Height;
        public override double CalculatePerimeter() => 2 * (Width + Height);
        public override string Draw() => $"Drawing {typeof(Rectangle).Name}";
    }
}
