namespace _03.Telephony.Models
{
    using System.Linq;

    using Contracts;
    using _03.Telephony.Exceptions;

    public class StationaryPhone : IStationaryPhone
    {
        public string Call(string phoneNumber)
        {
            if (!ValidatePhone(phoneNumber))
            {
                throw new InvalidPhoneNumberException();
            }

            return $"Dialing... {phoneNumber}";
        }

        private bool ValidatePhone(string phoneNumber) => phoneNumber.All(ch => char.IsDigit(ch));
    }
}
