namespace _03.Telephony.IO
{
    using System;

    using _03.Telephony.IO.Contracts;
    public class ConsoleWriter : IWriter
    {
        public void Write(string text) => Console.Write(text);
        public void WriteLine(string text) => Console.WriteLine(text);
    }
}
