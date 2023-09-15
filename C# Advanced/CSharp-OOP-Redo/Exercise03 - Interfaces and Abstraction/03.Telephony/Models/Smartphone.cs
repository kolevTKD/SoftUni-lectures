namespace Telephony.Models
{
    using System.Linq;

    using Contracts;
    using Exceptions;

    public class Smartphone : ISmartphone
    {
        public string CallNumber(string phoneNumber)
        {
            if (!IsValidNumber(phoneNumber))
            {
                throw new InvalidNumberException();
            }

            return $"Calling... {phoneNumber}";
        }

        public string BrowseURL(string url)
        {
            if (!IsValidURL(url))
            {
                throw new InvalidUrlException();
            }

            return $"Browsing: {url}!";
        }

        private bool IsValidNumber(string phoneNumber) => phoneNumber.All(ch => char.IsDigit(ch));
        private bool IsValidURL(string url) => !url.Any(ch => char.IsDigit(ch));
    }
}
