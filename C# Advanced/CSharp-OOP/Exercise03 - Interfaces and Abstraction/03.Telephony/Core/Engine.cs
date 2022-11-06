namespace _03.Telephony.Core
{
    using System;

    using _03.Telephony.Core.Contracts;
    using _03.Telephony.Exceptions;
    using _03.Telephony.IO.Contracts;
    using _03.Telephony.Models;
    using _03.Telephony.Models.Contracts;

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
            string[] phoneNumbers = this.reader.ReadLine().Split(' ');
            string[] urls = this.reader.ReadLine().Split(' ');

            foreach (var number in phoneNumbers)
            {
                try
                {
                    if (number.Length == 10)
                    {
                        this.writer.WriteLine(this.smartphone.Call(number));
                    }

                    else if (number.Length == 7)
                    {
                        this.writer.WriteLine(this.stationaryPhone.Call(number));
                    }

                    else
                    {
                        throw new InvalidPhoneNumberException();
                    }
                }
                catch (InvalidPhoneNumberException ipne)
                {
                    this.writer.WriteLine(ipne.Message);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            foreach (var url in urls)
            {
                try
                {
                    this.writer.WriteLine(this.smartphone.Browse(url));
                }
                catch(InvalidURLException iue)
                {
                    this.writer.WriteLine(iue.Message);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
