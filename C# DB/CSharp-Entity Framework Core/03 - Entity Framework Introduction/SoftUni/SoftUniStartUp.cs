namespace SoftUni
{
    using System.Globalization;
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
                Console.WriteLine(GetEmployeesByFirstNameStartingWithSa(context));
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

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employeesWithManagers = context.Employees
                .AsNoTracking()
                .Take(10)
                .Select(e => new
                {
                    EFirstName = e.FirstName,
                    ELastName = e.LastName,
                    MFirstName = e.Manager!.FirstName,
                    MLastName = e.Manager!.LastName,
                    Projects = e.EmployeesProjects
                        .Where(ep => ep.Project.StartDate.Year >= 2001 &&
                                     ep.Project.StartDate.Year <= 2003)
                        .Select(p => new
                        {
                            ProjectName = p.Project.Name,
                            ProjectStartDate = p.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                            ProjectEndDate = p.Project.EndDate.HasValue
                            ? p.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                            : "not finished"
                        }).ToList()

                }).ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employeesWithManagers)
            {
                sb.AppendLine($"{employee.EFirstName} {employee.ELastName} - Manager: {employee.MFirstName} {employee.MLastName}");

                foreach (var project in employee.Projects)
                {
                    sb.AppendLine($"--{project.ProjectName} - {project.ProjectStartDate} - {project.ProjectEndDate}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addressInfos = context.Addresses
                .AsNoTracking()
                .OrderByDescending(a => a.Employees.Count)
                .ThenBy(a => a.Town!.Name)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .Select(a => new
                {
                    a.AddressText,
                    TownName = a.Town!.Name,
                    EmployeesCount = a.Employees.Count
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var addressInfo in addressInfos)
            {
                sb.AppendLine($"{addressInfo.AddressText}, {addressInfo.TownName} - {addressInfo.EmployeesCount} employees");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            Employee employee147 = context.Employees
                .AsNoTracking()
                .Include(e => e.EmployeesProjects)
                .ThenInclude(ep => ep.Project)
                .FirstOrDefault(e => e.EmployeeId == 147)!;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{employee147.FirstName} {employee147.LastName} - {employee147.JobTitle}");

            foreach (var project in employee147.EmployeesProjects.OrderBy(p => p.Project.Name))
            {
                sb.AppendLine(project.Project.Name);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departmentsInfo = context.Departments
                .AsNoTracking()
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    DepartmentName = d.Name,
                    DMFirstName = d.Manager.FirstName,
                    DMLastName = d.Manager.LastName,
                    Employees = d.Employees
                        .Select(e => new
                        {
                            EFirstName = e.FirstName,
                            ELastName = e.LastName,
                            EJobTitle = e.JobTitle
                        })
                        .OrderBy(e => e.EFirstName)
                        .ThenBy(e => e.ELastName)
                        .ToList()
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var department in departmentsInfo)
            {
                sb.AppendLine($"{department.DepartmentName} - {department.DMFirstName}  {department.DMLastName}");

                foreach (var employee in department.Employees)
                {
                    sb.AppendLine($"{employee.EFirstName} {employee.ELastName} - {employee.EJobTitle}");
                }
            }

            return sb.ToString();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            var latestProjects = context.Projects
                .AsNoTracking()
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .Select(p => new
                {
                    ProjectName = p.Name,
                    ProjectDescription = p.Description,
                    ProjectStartDate = p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                })
                .OrderBy(p => p.ProjectName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var project in latestProjects)
            {
                sb.AppendLine(project.ProjectName)
                  .AppendLine(project.ProjectDescription)
                  .AppendLine(project.ProjectStartDate);
            }

            return sb.ToString().TrimEnd();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            var employeesWithIncreasedSalaries = context.Employees
                .AsNoTracking()
                .Where(e => e.Department.Name == "Engineering" ||
                            e.Department.Name == "Tool Design" ||
                            e.Department.Name == "Marketing" ||
                            e.Department.Name == "Information Services")
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Salary = e.Salary + e.Salary * 0.12M
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employeesWithIncreasedSalaries)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:F2})");
            }

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employeesStartingWith = context.Employees
                .AsNoTracking()
                .Where(e => e.FirstName.ToLower().StartsWith("sa"))
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    JobTitle = e.JobTitle,
                    Salary = e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employeesStartingWith)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }
    }
}