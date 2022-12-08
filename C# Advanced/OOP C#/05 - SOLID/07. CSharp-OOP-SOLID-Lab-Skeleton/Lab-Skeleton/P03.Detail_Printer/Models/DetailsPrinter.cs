using P03.Detail_Printer.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03.Detail_Printer.Models
{
    public class DetailsPrinter
    {
        private IList<IEmployee> employees;

        public DetailsPrinter(IList<IEmployee> employees)
        {
            this.employees = employees;
        }

        public void PrintDetails()
        {
            foreach (IEmployee employee in employees)
            {
                Console.WriteLine(employee);
                //if (employee is Manager)
                //{
                //    PrintManager((Manager)employee);
                //}
                //else
                //{
                //    PrintEmployee(employee);
                //}
            }
        }

        //private void PrintEmployee(Employee employee)
        //{
        //    Console.WriteLine(employee.Name);
        //}

        //private void PrintManager(Manager manager)
        //{
        //    Console.WriteLine(manager.Name);
        //    Console.WriteLine(string.Join(Environment.NewLine, manager.Documents));
        //}
    }
}
