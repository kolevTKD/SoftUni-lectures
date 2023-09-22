namespace P02.Graphic_Editor
{
    using System;

    public class GraphicEditor
    {
        public void DrawShape(BaseShape shape) => Console.WriteLine($"I'm {shape.GetType().Name}");
    }
}
