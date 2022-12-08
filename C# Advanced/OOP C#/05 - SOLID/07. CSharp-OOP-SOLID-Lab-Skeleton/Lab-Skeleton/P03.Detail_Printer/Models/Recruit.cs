namespace P03.Detail_Printer.Models
{
    using Contracts;
    public class Recruit : Employee
    {
        public Recruit(string name, int age)
            : base(name)
        {
            this.Age = age;
        }
        public int Age { get; set; }

        public override string ToString() => base.ToString() + $" {this.Age}";
        
    }
}
