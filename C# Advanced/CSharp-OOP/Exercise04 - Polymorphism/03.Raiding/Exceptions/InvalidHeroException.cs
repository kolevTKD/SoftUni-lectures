namespace Raiding.Exceptions
{
    using System;
    public class InvalidHeroException : Exception
    {
        private const string BASE_MESSAGE = "Invalid hero!";

        public InvalidHeroException()
            : base(BASE_MESSAGE)
        {
        }
    }
}
