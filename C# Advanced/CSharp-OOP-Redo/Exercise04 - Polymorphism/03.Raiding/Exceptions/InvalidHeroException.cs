namespace Raiding.Exceptions
{
    using System;

    public class InvalidHeroException : Exception
    {
        private const string INVALID_HERO = "Invalid hero!";

        public InvalidHeroException()
            : base(INVALID_HERO)
        {
        }
        public InvalidHeroException(string message)
            : base(message)
        {
        }
    }
}
