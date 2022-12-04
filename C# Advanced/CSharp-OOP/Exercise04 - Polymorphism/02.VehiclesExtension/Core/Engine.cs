namespace VehiclesExtension.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Core.Contracts;
    using Factories.Contracts;
    using IO.Contracts;
    using Models.Contracts;
    using VehiclesExtension.Exceptions;
    using VehiclesExtension.Models;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IVehicleFactory vehicleFactory;

        private readonly ICollection<IVehicle> vehicles;

        private Engine()
        {
            this.vehicles = new HashSet<IVehicle>();
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
            this.vehicles.Add(this.BuildVehicleViaFactory());
            this.vehicles.Add(this.BuildVehicleViaFactory());
            this.vehicles.Add(this.BuildVehicleViaFactory());

            int lines = int.Parse(this.reader.ReadLine());

            for (int line = 0; line < lines; line++)
            {
                try
                {
                    this.ProcessCommand();
                }
                catch (InvalidVehicleTypeException ivte)
                {
                    this.writer.WriteLine(ivte.Message);
                }
                catch (VehicleNeedsRefuelingException vnre)
                {
                    this.writer.WriteLine(vnre.Message);
                }
                catch(InvalidFuelQuantityException ifqe)
                {
                    this.writer.WriteLine(ifqe.Message);
                }
                catch(ImmersiveFuelAmountException ifae)
                {
                    this.writer.WriteLine(ifae.Message);
                }
                catch(Exception)
                {
                    throw;
                }
            }

            this.PrintAllVehicles();
        }

        private void ProcessCommand()
        {
            string[] cmdArgs = this.reader.ReadLine().Split(' ');
            string cmd = cmdArgs[0];
            string vehicleType = cmdArgs[1];
            double quantity = double.Parse(cmdArgs[2]);

            IVehicle vehicleToProcess = this.vehicles.FirstOrDefault(v => v.GetType().Name == vehicleType);

            if (vehicleToProcess == null)
            {
                throw new InvalidVehicleTypeException();
            }

            if (cmd == "Drive")
            {
                this.writer.WriteLine(vehicleToProcess.Drive(quantity));
            }

            else if (cmd == "DriveEmpty")
            {
                Bus bus = vehicleToProcess as Bus;
                this.writer.WriteLine(bus.DriveEmpty(quantity));
            }

            else if (cmd == "Refuel")
            {
                vehicleToProcess.Refuel(quantity);
            }
        }

        private IVehicle BuildVehicleViaFactory()
        {
            string[] vehicleInfo = this.reader.ReadLine().Split(' ');
            string vehicleType = vehicleInfo[0];
            double fuelQuantity = double.Parse(vehicleInfo[1]);
            double fuelConsumption = double.Parse(vehicleInfo[2]);
            double tankCapacity = double.Parse(vehicleInfo[3]);

            IVehicle vehicle = this.vehicleFactory.CreateVehicle(vehicleType, fuelQuantity, fuelConsumption, tankCapacity);

            return vehicle;
        }

        private void PrintAllVehicles()
        {
            foreach (IVehicle vehicle in this.vehicles)
            {
                this.writer.WriteLine(vehicle.ToString());
            }
        }
    }
}
