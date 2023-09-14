namespace Shapes
{
    using System;

    using Models;
    using Models.Contracts;

    public class StartUp
    {
        static void Main(string[] args)
        {
            int radius = int.Parse(Console.ReadLine());
            IDrawable circle = new Circle(radius);

            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            IDrawable rectangle = new Rectangle(width, height);

            circle.Draw();
            rectangle.Draw();
        }
    }
}
