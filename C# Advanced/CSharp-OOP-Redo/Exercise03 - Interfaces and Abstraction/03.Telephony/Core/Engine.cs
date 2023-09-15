namespace Telephony.Core
{
    using System;

    using Contracts;
    using Exceptions;
    using IO.Contracts;
    using Models;
    using Models.Contracts;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly IStationaryPhone stationaryPhone;
        private readonly ISmartphone smartphone;

        private Engine()
        {
            this.stationaryPhone = new StationaryPhone();
            this.smartphone = new Smartphone();
        }
        public Engine(IReader reader, IWriter writer)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {

            string[] phoneNumbers = this.reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] urls = this.reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (string phoneNumber in phoneNumbers)
            {
                try
                {
                    Call(phoneNumber);
                }
                catch (InvalidNumberException ine)
                {
                    this.writer.WriteLine(ine.Message);
                }
            }

            foreach (string url in urls)
            {
                try
                {
                    this.writer.WriteLine(smartphone.BrowseURL(url));
                }
                catch (InvalidUrlException iue)
                {
                    this.writer.WriteLine(iue.Message);
                }
            }
        }

        private void Call(string phoneNumber)
        {
            if (phoneNumber.Length == 10)
            {
                this.writer.WriteLine(smartphone.CallNumber(phoneNumber));
            }
            else if (phoneNumber.Length == 7)
            {
                this.writer.WriteLine(stationaryPhone.CallNumber(phoneNumber));
            }
        }
    }
}
