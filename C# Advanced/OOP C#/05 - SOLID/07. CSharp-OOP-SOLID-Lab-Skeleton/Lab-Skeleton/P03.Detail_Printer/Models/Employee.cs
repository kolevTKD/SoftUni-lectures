namespace P03.Detail_Printer.Models
{
    using Contracts;
    public class Employee : IEmployee
    {
        public Employee(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public override string ToString() => $"{this.Name}";
    }
}
