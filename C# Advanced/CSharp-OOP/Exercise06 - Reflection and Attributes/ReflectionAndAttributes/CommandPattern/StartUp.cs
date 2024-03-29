﻿namespace CommandPattern
{
    using CommandPattern.Utilities.Contracts;
    using Core;
    using Core.Contracts;
    using Utilities;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            ICommandInterpreter command = new CommandInterpreter();
            IEngine engine = new Engine(command);
            engine.Run();
        }
    }
}
