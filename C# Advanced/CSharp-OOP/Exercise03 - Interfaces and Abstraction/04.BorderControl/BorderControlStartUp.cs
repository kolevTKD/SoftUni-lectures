namespace BorderControl
{
    using BorderControl.Core;
    using BorderControl.IO;
    using BorderControl.IO.Contracts;
    public class StartUp
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
