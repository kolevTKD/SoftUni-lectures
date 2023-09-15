namespace Telephony.Models
{
    using System.Linq;

    using Contracts;
    using Exceptions;

    public class StationaryPhone : IStationaryPhone
    {
        public string CallNumber(string phoneNumber)
        {
            if (!IsValidNumber(phoneNumber))
            {
                throw new InvalidNumberException();
            }

            return $"Dialing... {phoneNumber}";
        }

        private bool IsValidNumber(string phoneNumber) => phoneNumber.All(ch => char.IsDigit(ch));
    }
}
