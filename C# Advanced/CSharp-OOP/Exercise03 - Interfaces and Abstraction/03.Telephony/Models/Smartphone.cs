namespace _03.Telephony.Models
{
    using System.Linq;

    using Contracts;
    using _03.Telephony.Exceptions;

    public class Smartphone : ISmartphone
    {
        public string Call(string phoneNumber)
        {
            if (!this.ValidatePhone(phoneNumber))
            {
                throw new InvalidPhoneNumberException();
            }

            return $"Calling... {phoneNumber}";
        }

        public string Browse(string website)
        {
            if (!this.ValidateUrl(website))
            {
                throw new InvalidURLException();
            }

            return $"Browsing: {website}!";
        }

        private bool ValidatePhone(string phoneNumber) => phoneNumber.All(ch => char.IsDigit(ch));
        private bool ValidateUrl(string website) => website.All(ch => !char.IsDigit(ch));
    }
}
