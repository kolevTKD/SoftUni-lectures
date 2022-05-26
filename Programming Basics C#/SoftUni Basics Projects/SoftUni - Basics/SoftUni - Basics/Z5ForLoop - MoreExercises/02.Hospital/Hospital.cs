using System;

namespace _02.Hospital
{
    class Hospital
    {
        static void Main(string[] args)
        {
            int period = int.Parse(Console.ReadLine());
            int docsNum = 7;
            int dayCounter = 0;
            int treated = 0;
            int untreated = 0;

            for (int days = 1; days <= period; days++)
            {
                dayCounter++;
                if (dayCounter % 3 == 0)
                {
                    if (untreated > treated)
                    {
                        docsNum++;
                    }
                }

                int patientsNum = int.Parse(Console.ReadLine());

                if (patientsNum <= docsNum)
                {
                    treated += patientsNum;
                }

                else if (patientsNum > docsNum)
                {
                    treated += docsNum;
                    untreated += patientsNum - docsNum;
                }
            }

            Console.WriteLine($"Treated patients: {treated}.");
            Console.WriteLine($"Untreated patients: {untreated}.");
        }
    }
}
