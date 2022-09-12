using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._1.CompanyRoster
{
    internal class CompanyRoster
    {
        static void Main(string[] args)
        {
            int employeesNum = int.Parse(Console.ReadLine());
            List<Employee> employees = new List<Employee>();
            List<Department> departments = new List<Department>();

            for (int i = 1; i <= employeesNum; i++)
            {
                string[] currEmployee = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = currEmployee[0];
                double salary = double.Parse(currEmployee[1]);
                string department = currEmployee[2];

                Employee employee = new Employee(name, salary, department);
                employees.Add(employee);

                bool depExists = departments.Any(x => x.Name == department) ? true : false;

                if (!depExists)
                {
                    departments.Add(new Department() { Name = department, Members = new List<Employee>() });
                }

                foreach (var dep in departments)
                {
                    if (employee.Department == dep.Name)
                    {
                        dep.Members.Add(employee);
                    }
                }
            }

            double highestSalary = 0;
            string bestDep = string.Empty;

            foreach (Department department in departments)
            {
                double avgSalary = 0;

                foreach (Employee employee in department.Members)
                {
                    avgSalary += employee.Salary;
                }

                avgSalary /= department.Members.Count;

                if (avgSalary >= highestSalary)
                {
                    highestSalary = avgSalary;
                    bestDep = department.Name;
                }
            }

            Console.WriteLine($"Highest Average Salary: {bestDep}");
            Department best = departments.Find(x => x.Name == bestDep);
            best.Members = best.Members.OrderByDescending(x => x.Salary).ToList();

            foreach (Employee member in best.Members)
            {
                Console.WriteLine($"{member.Name} {member.Salary:f2}");
            }
            
        }
    }

    class Employee
    {
        public Employee(string name, double salary, string department)
        {
            Name = name;
            Salary = salary;
            Department = department;
        }

        public string Name { get; set; }
        public double Salary { get; set; }
        public string Department { get; set; }

    }

    class Department
    {
        public Department()
        {
            Members = new List<Employee>();
        }

        public string Name { get; set; }
        public List<Employee> Members { get; set; }
    }
}
