namespace P03.DetailPrinter
{
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main()
        {
            IEmployee employee1 = new Employee("Ivo");
            IEmployee employee2 = new Employee("Kiro");
            IEmployee employee3 = new Employee("Spas");

            IEmployee manager1 = new Manager("Nick", new List<string>() { "Manager1 - doc1", "Manager1 - doc2", "Manager1 - doc3", });
            IEmployee manager2 = new Manager("Gabi", new List<string>() { "Manager2 - doc1", "Manager1 - doc2", "Manager1 - doc3", });
            IEmployee manager3 = new Manager("George", new List<string>() { "Manager3 - doc1", "Manager1 - doc2", "Manager1 - doc3", });

            List<IEmployee> employees = new List<IEmployee>();
            employees.Add(employee1);
            employees.Add(employee2);
            employees.Add(employee3);
            employees.Add(manager1);
            employees.Add(manager2);
            employees.Add(manager3);

            DetailsPrinter dp = new DetailsPrinter(employees);
            dp.PrintDetails();
        }
    }
}
