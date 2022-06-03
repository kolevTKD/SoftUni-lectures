using System;

namespace _04.Gymnastics
{
    class Gymnastics
    {
        static void Main(string[] args)
        {
            string country = Console.ReadLine();
            string instrument = Console.ReadLine();
            double difficulty = 0;
            double performance = 0;
            int max = 20;

            switch (country)
            {
                case "Russia":

                    switch (instrument)
                    {
                        case "ribbon":
                            difficulty = 9.100;
                            performance = 9.400;
                            break;
                        case "hoop":
                            difficulty = 9.300;
                            performance = 9.800;
                            break;
                        case "rope":
                            difficulty = 9.600;
                            performance = 9.000;
                            break;
                    }
                    break;

                case "Bulgaria":

                    switch (instrument)
                    {
                        case "ribbon":
                            difficulty = 9.600;
                            performance = 9.400;
                            break;
                        case "hoop":
                            difficulty = 9.550;
                            performance = 9.750;
                            break;
                        case "rope":
                            difficulty = 9.500;
                            performance = 9.400;
                            break;
                    }
                    break;

                case "Italy":

                    switch (instrument)
                    {
                        case "ribbon":
                            difficulty = 9.200;
                            performance = 9.500;
                            break;
                        case "hoop":
                            difficulty = 9.450;
                            performance = 9.350;
                            break;
                        case "rope":
                            difficulty = 9.700;
                            performance = 9.150;
                            break;
                    }
                    break;
            }

            double sum = difficulty + performance;
            double percentForMax = ((max - sum) / max) * 100;
            Console.WriteLine($"The team of {country} get {sum:f3} on {instrument}.");
            Console.WriteLine($"{percentForMax:f2}%");
        }
    }
}
