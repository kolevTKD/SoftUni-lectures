using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SportCar supra = new SportCar(200, 20);
            supra.Drive(1);
            Console.WriteLine(supra.Fuel);
        }
    }
}
