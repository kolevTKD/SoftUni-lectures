namespace CommandPattern.Models
{
    using System;
    using CommandPattern.Models.Contracts;

    public class ExitCommand : ICommand
    {
        private const int DEFAULT_ERROR_CODE = 0;
        public string Execute(string[] args)
        {
            Environment.Exit(DEFAULT_ERROR_CODE);
            return null;
        }
    }
}
