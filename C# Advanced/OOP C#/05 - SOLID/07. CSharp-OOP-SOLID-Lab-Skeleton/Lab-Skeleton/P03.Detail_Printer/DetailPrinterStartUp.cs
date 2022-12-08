namespace P03.DetailPrinter
{
    using System.Collections.Generic;

    using P03.Detail_Printer.Models;
    using P03.Detail_Printer.Models.Contracts;
    class DetailPrinterStartUp
    {
        static void Main()
        {
            IEmployee employee = new Employee("Kiril");
            IEmployee manager = new Manager("Denis", new List<string>() { "doc01", "doc02", "doc03" });
            IEmployee recruit = new Recruit("Spas", 19);

            List<IEmployee> employees = new List<IEmployee>() { employee, manager, recruit };

            DetailsPrinter dp = new DetailsPrinter(employees);
            dp.PrintDetails();

        }
    }
}
