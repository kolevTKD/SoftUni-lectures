namespace SoftUni
{
    using System.Text;

    using Data;
    using Models;

    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        static void Main(string[] args)
        {
            using (SoftUniContext context = new SoftUniContext())
            {
                Console.WriteLine(AddNewAddressToEmployee(context));
            }
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employeesFullInformation = context.Employees
                .AsNoTracking()
                .OrderBy(e => e.EmployeeId)
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    MiddleName = e.MiddleName,
                    JobTitle = e.JobTitle,
                    Salary = e.Salary,
                }).ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employeesFullInformation)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employeesWithSalaryOver50000 = context.Employees
                .AsNoTracking()
                .OrderBy(e => e.FirstName)
                .Where(e => e.Salary > 50000)
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    Salary = e.Salary,
                }).ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employeesWithSalaryOver50000)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employeesFromRAndD = context.Employees
                .AsNoTracking()
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .Where(e => e.Department.Name == "Research and Development")
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    DepartmentName = e.Department.Name,
                    Salary = e.Salary

                }).ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employeesFromRAndD)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.DepartmentName} - ${employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Address newAddress = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            Employee? lastNameNakov = context.Employees
                .FirstOrDefault(e => e.LastName == "Nakov");

            if (lastNameNakov != null)
            {
                lastNameNakov.Address = newAddress;
            }

            context.SaveChanges();

            List<string> addressesOfEmployees = context.Employees
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .Select(e => e.Address!.AddressText)
                .ToList();

            return String.Join(Environment.NewLine, addressesOfEmployees);
        }
    }
}