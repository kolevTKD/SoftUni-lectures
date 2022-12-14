namespace CommandPattern.Core
{
    using System;
    using CommandPattern.Core.Contracts;
    using CommandPattern.Utilities.Contracts;
    using IO;
    using IO.Contracts;


    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;
        private readonly IReader reader;
        private readonly IWriter writer;

        private Engine()
        {
            this.reader = new ConsoleReader();
            this.writer = new ConsoleWriter();
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
                try
                {
                    string inputLine = this.reader.ReadLine();
                    string result = commandInterpreter.Read(inputLine);
                    this.writer.WriteLine(result);
                }
                catch (InvalidOperationException ioe)
                {
                    this.writer.WriteLine(ioe.Message);
                }
            }
        }
    }
}
