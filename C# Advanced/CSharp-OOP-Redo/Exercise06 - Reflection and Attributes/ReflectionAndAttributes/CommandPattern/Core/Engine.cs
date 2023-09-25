namespace CommandPattern.Core
{
    using Contracts;
    using IO;
    using IO.Contracts;
    using Utilities.Contracts;

    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;
        private readonly IReader reader;
        private readonly IWriter writer;

        private Engine()
        {
            reader = new ConsoleReader();
            writer = new ConsoleWriter();
        }
        public Engine(ICommandInterpreter commandInterpreter)
            : this()
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            while (true)
            {
                string input = reader.ReadLine();
                writer.WriteLine(commandInterpreter.Read(input));
            }
        }
    }
}
