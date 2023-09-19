namespace Vehicles.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Exceptions;
    using Factories.Contracts;
    using IO.Contracts;
    using Models.Contracts;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IVehicleFactory vehicleFactory;

        private readonly ICollection<IVehicle> vehicles;

        private Engine()
        {
            vehicles = new HashSet<IVehicle>();
        }
        public Engine(IReader reader, IWriter writer, IVehicleFactory vehicleFactory)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
            this.vehicleFactory = vehicleFactory;
        }

        public void Run()
        {
            vehicles.Add(CreateVehicleViaFactory());
            vehicles.Add(CreateVehicleViaFactory());

            int lines = int.Parse(reader.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                try
                {
                    ProcessCommand();
                }
                catch (VehicleNeedsRefuelingException vnre)
                {
                    writer.WriteLine(vnre.Message);
                }
                catch (VehicleNotSupportedException vnse)
                {
                    writer.WriteLine(vnse.Message);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            PrintVehicles();
        }

        private IVehicle CreateVehicleViaFactory()
        {
            string[] vehicleInfo = reader.ReadLine().Split(' ');
            string type = vehicleInfo[0];
            double fuelQuantity = double.Parse(vehicleInfo[1]);
            double fuelConsumptionLKm = double.Parse(vehicleInfo[2]);

            IVehicle vehicle = vehicleFactory.CreateVehicle(type, fuelQuantity, fuelConsumptionLKm);

            return vehicle;
        }

        private void ProcessCommand()
        {
            string[] cmdArgs = reader.ReadLine().Split(' ');
            string cmd = cmdArgs[0];
            string type = cmdArgs[1];
            double arg = double.Parse(cmdArgs[2]);

            IVehicle vehicleToProcess = vehicles.FirstOrDefault(v => v.GetType().Name == type);

            if (vehicleToProcess != null)
            {
                if (cmd == "Drive")
                {
                    writer.WriteLine(vehicleToProcess.Drive(arg));
                }
                else if (cmd == "Refuel")
                {
                    vehicleToProcess.Refuel(arg);
                }
            }
            else
            {
                throw new VehicleNotSupportedException();
            }
        }

        private void PrintVehicles()
        {
            foreach (IVehicle vehicle in vehicles)
            {
                writer.WriteLine(vehicle.ToString());
            }
        }
    }
}
