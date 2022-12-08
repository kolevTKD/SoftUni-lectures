using System;

namespace P02.Graphic_Editor.Models
{
    using Contracts;
    public class GraphicEditor
    {
        public void DrawShape(IShape shape)
        {
            Console.WriteLine($"I'm {shape.GetType().Name}");
        }
    }
}
