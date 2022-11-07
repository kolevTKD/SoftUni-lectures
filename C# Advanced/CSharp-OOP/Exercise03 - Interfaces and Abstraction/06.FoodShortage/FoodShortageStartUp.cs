namespace FoodShortage
{
    using Core;
    using IO;
    using IO.Contracts;
    public class FoodShortageStartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            Engine engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}
