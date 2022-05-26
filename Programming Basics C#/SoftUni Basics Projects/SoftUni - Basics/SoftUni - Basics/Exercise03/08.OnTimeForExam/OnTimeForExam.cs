using System;

namespace _08.OnTimeForExam
{
    class OnTimeForExam
    {
        static void Main(string[] args)
        {
            int hourOfExam = int.Parse(Console.ReadLine());
            int minuteOfExam = int.Parse(Console.ReadLine());
            int hourOfArrive = int.Parse(Console.ReadLine());
            int minuteOfArrive = int.Parse(Console.ReadLine());

            int examTimeAsMinutes = hourOfExam * 60 + minuteOfExam;
            int arrivalTimeAsMinutes = hourOfArrive * 60 + minuteOfArrive;
            int differnceExamArrival = examTimeAsMinutes - arrivalTimeAsMinutes;
            int differenceHours = differnceExamArrival / 60;
            int differenceMinutes = differnceExamArrival % 60;
            int absDifferenceHours = Math.Abs(differenceHours);
            int absDifferenceMinutes = Math.Abs(differenceMinutes);


            string arrival = null;
            string message = null;

            if (differnceExamArrival == 0)
            {
                arrival = "On Time";
            }
            else if (differnceExamArrival > 0)
            {

                if (differnceExamArrival <= 30)
                {
                    arrival = "On time";
                    message = $"{differenceMinutes} minutes before the start";
                }
                else
                {
                    arrival = "Early";
                    if (differenceHours >= 1)
                    {
                        message = $"{differenceHours}:{differenceMinutes:d2} hours before the start";
                    }
                    else if (differenceHours == 0)
                    {
                        message = $"{differenceMinutes} minutes before the start";
                    }

                }
            }
            else if (differnceExamArrival < 0)
            {
                arrival = "Late";
                if (absDifferenceHours >= 1)
                {
                    message = $"{absDifferenceHours}:{absDifferenceMinutes:d2} hours after the start";
                }
                else if (absDifferenceHours == 0)
                {
                    message = $"{absDifferenceMinutes} minutes after the start";
                }

            }
            Console.WriteLine(arrival);
            Console.WriteLine(message);
        }
    }
}
