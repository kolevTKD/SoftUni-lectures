namespace BorderControl.IO
{
    using System;

    using BorderControl.IO.Contracts;

    public class ConsoleReader : IReader
    {
        public string ReadLine() => Console.ReadLine();
    }
}
