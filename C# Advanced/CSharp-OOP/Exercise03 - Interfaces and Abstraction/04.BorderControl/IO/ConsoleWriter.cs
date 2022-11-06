﻿namespace BorderControl.IO
{
    using System;

    using BorderControl.IO.Contracts;
    public class ConsoleWriter : IWriter
    {
        public void Write(string text) => Console.Write(text);
        public void WriteLine(string text) => Console.WriteLine(text);
    }
}
