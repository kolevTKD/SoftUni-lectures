namespace AdvancedQuryingTesting
{
    using Microsoft.EntityFrameworkCore;

    using Data;
    using System.Text;

    public class StartUp
    {
        static async Task Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();

            //var employees = await context.Employees.FromSqlRaw("SELECT * FROM Employees WHERE DepartmentId = 7").ToListAsync();

            //int departmentId = int.Parse(Console.ReadLine());
            //var employeesIParameterized = await context.Employees.FromSqlRaw("SELECT * FROM Employees WHERE DepartmentId = {0}", departmentId).ToListAsync();

            string departmentName = Console.ReadLine();

            //Working SQL Injection
            //var employeesInterpolated = await context.Employees.FromSqlRaw($"SELECT e.* FROM Employees e JOIN Departments d ON e.DepartmentId = d.DepartmentId WHERE d.Name = '{departmentName}'").ToListAsync();

            //Not working SQL Injection
            //var employeesSqlRaw = await context.Employees.FromSqlRaw("SELECT e.* FROM Employees e JOIN Departments d ON e.DepartmentId = d.DepartmentId WHERE d.Name = '{0}'", departmentName).ToListAsync();

            //Not working SQL Injection
            var employeesInterpolated = await context.Employees.FromSqlInterpolated($"SELECT e.* FROM Employees e JOIN Departments d ON e.DepartmentId = d.DepartmentId WHERE d.Name = {departmentName}").ToListAsync();

            StringBuilder sb = new StringBuilder();

            int rowNumber = 1;
            foreach (var employee in employeesInterpolated)
            {
                sb.AppendLine($"{rowNumber++}.{employee.FirstName} {employee.MiddleName} {employee.LastName} {employee.Salary:F2}");
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}