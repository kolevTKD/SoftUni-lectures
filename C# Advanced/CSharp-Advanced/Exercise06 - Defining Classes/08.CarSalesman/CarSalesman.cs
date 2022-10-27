using System;
using System.Collections.Generic;

namespace _08.CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int enginesCount = int.Parse(Console.ReadLine());
            Dictionary<string, Engine> engineModels = new Dictionary<string, Engine>();

            for (int currEngine = 0; currEngine < enginesCount; currEngine++)
            {
                string[] engineInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = engineInfo[0];
                int power = int.Parse(engineInfo[1]);
                int displacement = 0;
                string efficiency = string.Empty;


                if (engineInfo.Length >= 3)
                {
                    displacement = int.Parse(engineInfo[2]);
                }

                if(engineInfo.Length == 4)
                {
                    efficiency = engineInfo[3];
                }

                Engine engine = new Engine(model, power, displacement, efficiency);
                engineModels.Add(model, engine);
            }
        }
    }
}
