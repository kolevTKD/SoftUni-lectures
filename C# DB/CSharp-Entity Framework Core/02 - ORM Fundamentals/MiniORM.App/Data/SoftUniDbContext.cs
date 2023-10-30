namespace MiniORM.App.Data;

using Entities;

public class SoftUniDbContext : DbContext
{
    public SoftUniDbContext(string connectionStirng)
        : base(connectionStirng)
    {
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<EmployeeProject> EmployeesProjects { get; set; }
}
