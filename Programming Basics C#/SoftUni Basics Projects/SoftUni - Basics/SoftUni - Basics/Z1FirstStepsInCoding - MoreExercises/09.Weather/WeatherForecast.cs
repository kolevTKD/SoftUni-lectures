using System;

namespace _09.Weather
{
    class WeatherForecast
    {
        static void Main(string[] args)
        {
            string inputWeather = Console.ReadLine();
            string sunny = "sunny";

            if (inputWeather == sunny)
            {
                Console.WriteLine("It's warm outside!");
            }

            else
            {
                Console.WriteLine("It's cold outside!");
            }
        }
    }
}
