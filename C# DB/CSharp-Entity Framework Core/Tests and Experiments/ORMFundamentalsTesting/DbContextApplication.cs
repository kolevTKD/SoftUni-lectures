namespace ORMFundamentalsTesting
{
    using Microsoft.EntityFrameworkCore;

    public class DbContextApplication : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
