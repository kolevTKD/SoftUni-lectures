namespace BirthdayCelebrations
{
    using System;
    using BirthdayCelebrations.Core;
    using BirthdayCelebrations.IO;
    using BirthdayCelebrations.IO.Contracts;
    public class BirthdayCelebrationsStartUp
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
