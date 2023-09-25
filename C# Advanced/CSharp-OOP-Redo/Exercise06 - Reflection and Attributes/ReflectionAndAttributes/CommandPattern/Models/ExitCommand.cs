namespace CommandPattern.Models
{
    using System;

    using Contracts;

    public class ExitCommand : ICommand
    {
        private const int DEFAULT_EXIT_MESSAGE = 0;

        public string Execute(string[] args)
        {
            Environment.Exit(DEFAULT_EXIT_MESSAGE);
            return null;
        }
    }
}
