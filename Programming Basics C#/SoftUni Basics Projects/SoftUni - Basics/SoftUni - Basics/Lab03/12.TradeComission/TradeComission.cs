using System;

namespace _12.TradeComission
{
    class TradeComission
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            double sales = double.Parse(Console.ReadLine());
            bool salesTo500 = sales >= 0 && sales <= 500;
            bool salesTo1k = sales > 500 && sales <= 1000;
            bool salesTo10k = sales > 1000 && sales <= 10000;
            bool greaterOf10k = sales > 10000;
            bool isValidSale = !salesTo500 && !salesTo1k && !salesTo10k && !greaterOf10k;
            bool isValidCity = city != "Sofia" && city != "Varna" && city != "Plovdiv";
            double sofiaComission = 0;
            double varnaComission = 0;
            double plovdivComission = 0;

            if (isValidSale || isValidCity)
            {
                Console.WriteLine("error");
            }

            switch (salesTo500)
            {
                case true:
                    switch (city)
                    {
                        case "Sofia":
                            sofiaComission = 0.055;
                            double totalSComission = sales * sofiaComission;
                            Console.WriteLine($"{totalSComission:f2}");
                            break;

                        case "Varna":
                            varnaComission = 0.045;
                            double totalVComission = sales * varnaComission;
                            Console.WriteLine($"{totalVComission:f2}");
                            break;

                        case "Plovdiv":
                            plovdivComission = 0.055;
                            double totalPComission = sales * plovdivComission;
                            Console.WriteLine($"{totalPComission:f2}");
                            break;


                    }
                    break;
            }
            switch (salesTo1k)
            {
                case true:
                    switch (city)
                    {
                        case "Sofia":
                            sofiaComission = 0.07;
                            double totalSComission = sales * sofiaComission;
                            Console.WriteLine($"{totalSComission:f2}");
                            break;

                        case "Varna":
                            varnaComission = 0.075;
                            double totalVComission = sales * varnaComission;
                            Console.WriteLine($"{totalVComission:f2}");
                            break;

                        case "Plovdiv":
                            plovdivComission = 0.08;
                            double totalPComission = sales * plovdivComission;
                            Console.WriteLine($"{totalPComission:f2}");
                            break;


                    }
                    break;
            }
            switch (salesTo10k)
            {
                case true:
                    switch (city)
                    {
                        case "Sofia":
                            sofiaComission = 0.08;
                            double totalSComission = sales * sofiaComission;
                            Console.WriteLine($"{totalSComission:f2}");
                            break;

                        case "Varna":
                            varnaComission = 0.1;
                            double totalVComission = sales * varnaComission;
                            Console.WriteLine($"{totalVComission:f2}");
                            break;

                        case "Plovdiv":
                            plovdivComission = 0.12;
                            double totalPComission = sales * plovdivComission;
                            Console.WriteLine($"{totalPComission:f2}");
                            break;


                    }
                    break;
            }
            switch (greaterOf10k)
            {
                case true:
                    switch (city)
                    {
                        case "Sofia":
                            sofiaComission = 0.12;
                            double totalSComission = sales * sofiaComission;
                            Console.WriteLine($"{totalSComission:f2}");
                            break;

                        case "Varna":
                            varnaComission = 0.13;
                            double totalVComission = sales * varnaComission;
                            Console.WriteLine($"{totalVComission:f2}");
                            break;

                        case "Plovdiv":
                            plovdivComission = 0.145;
                            double totalPComission = sales * plovdivComission;
                            Console.WriteLine($"{totalPComission:f2}");
                            break;
                    }
                    break;
            }
        }
    }
}
