namespace P02.Graphic_Editor
{
    using Models;
    using Models.Contracts;

    class GraphicEditorStartUp
    {
        static void Main()
        {
            IShape circle = new Circle();
            IShape rectangle = new Rectangle();
            IShape square = new Square();

            GraphicEditor ge = new GraphicEditor();

            ge.DrawShape(circle);
            ge.DrawShape(rectangle);
            ge.DrawShape(square);
        }
    }
}
