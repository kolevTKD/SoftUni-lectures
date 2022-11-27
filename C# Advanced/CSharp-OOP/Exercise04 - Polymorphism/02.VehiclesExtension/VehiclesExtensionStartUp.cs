namespace VehiclesExtension
{
    using Core;
    using Factories;
    using Factories.Contracts;
    using IO;
    using IO.Contracts;
    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IVehicleFactory vehicleFactory = new VehicleFactory();

            Engine engine = new Engine(reader, writer, vehicleFactory);
            engine.Run();
        }
    }
}
