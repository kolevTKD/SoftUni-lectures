namespace P04.Recharge
{
    using System;

    public class Employee : Worker, ISleeper
    {
        public Employee(string id) : base(id)
        {
        }

        public override void Sleep()
        {
            Console.WriteLine($"{GetType().Name} is sleeping.");
        }

        public override void Work(int hours)
        {
            base.WorkingHours += hours;
        }
    }
}
