namespace Telephony.Exceptions
{
    using System;
    public class InvalidNumberException : Exception
    {
        private const string DEFAULT_MESSAGE = "Invalid number!";

        public InvalidNumberException()
            : base(DEFAULT_MESSAGE)
        {
        }

        public InvalidNumberException(string message)
            : base(message)
        {
        }
    }
}
