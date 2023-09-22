namespace P02.Graphic_Editor
{
    public class StartUp
    {
        static void Main()
        {
            BaseShape circle = new Circle();
            BaseShape rectangle = new Rectangle();
            BaseShape square = new Square();

            GraphicEditor ge = new GraphicEditor();
            ge.DrawShape(square);
        }
    }
}
