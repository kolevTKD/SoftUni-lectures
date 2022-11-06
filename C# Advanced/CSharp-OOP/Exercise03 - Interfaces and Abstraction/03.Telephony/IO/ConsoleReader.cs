namespace _03.Telephony.IO
{
    using System;

    using _03.Telephony.IO.Contracts;

    public class ConsoleReader : IReader
    {
        public string ReadLine() => Console.ReadLine();
    }
}
