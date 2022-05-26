using System;

namespace _10.WeatherForecast2
{
    class WeatherForecast2
    {
        static void Main(string[] args)
        {
            double inputDegrees = double.Parse(Console.ReadLine());
            bool hot = inputDegrees >= 26 && inputDegrees <= 35;
            bool warm = inputDegrees >= 20.1 && inputDegrees <= 25.9;
            bool mild = inputDegrees >= 15 && inputDegrees <= 20;
            bool cool = inputDegrees >= 12 && inputDegrees <= 14.9;
            bool cold = inputDegrees >= 5 && inputDegrees <= 11.9;
            string weather = null;

            if (hot)
            {
                weather = "Hot";
            }

            else if (warm)
            {
                weather = "Warm";
            }

            else if (mild)
            {
                weather = "Mild";
            }

            else if (cool)
            {
                weather = "Cool";
            }

            else if (cold)
            {
                weather = "Cold";
            }

            else
            {
                weather = "unknown";
            }

            Console.WriteLine(weather);
        }
    }
}
