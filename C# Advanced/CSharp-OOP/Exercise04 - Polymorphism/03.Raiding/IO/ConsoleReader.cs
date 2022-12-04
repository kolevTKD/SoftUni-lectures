namespace Raiding.IO
{
    using System;

    using Raiding.IO.Contracts;
    public class ConsoleReader : IReader
    {
        public string ReadLine() => Console.ReadLine();
    }
}
