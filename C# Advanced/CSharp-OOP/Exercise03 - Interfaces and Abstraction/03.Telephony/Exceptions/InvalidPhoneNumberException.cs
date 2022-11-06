
namespace _03.Telephony.Exceptions
{
    using System;
    public class InvalidPhoneNumberException : Exception
    {
        private const string DEFAULT_EXCEPTION_MESSAGE = "Invalid number!";

        public InvalidPhoneNumberException()
            : base(DEFAULT_EXCEPTION_MESSAGE)
        {
        }

        public InvalidPhoneNumberException(string message)
            : base(message)
        {
        }
    }
}
