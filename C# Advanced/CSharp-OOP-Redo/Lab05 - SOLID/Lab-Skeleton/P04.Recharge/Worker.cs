namespace P04.Recharge
{
    using System;

    public abstract class Worker : ISleeper
    {
        private string id;

        public Worker(string id)
        {
            this.id = id;
        }

        public int WorkingHours { get; protected set; }

        public virtual void Work(int hours)
        {
            this.WorkingHours += hours;
        }

        public virtual void Sleep()
        {
            Console.WriteLine($"{GetType().Name} is sleeping.");
        }
    }
}
