using EFCoreTesting.Data;
using EFCoreTesting.Models;
using Microsoft.EntityFrameworkCore;

using (SoftUniContext context = new SoftUniContext())
{
    //await context.Projects.AddAsync(new Project()
    //{
    //    Name = "Judge",
    //    StartDate = DateTime.Today,
    //});

    //await context.SaveChangesAsync();

    //Project judgeProject = await context.Projects
    //    .FirstOrDefaultAsync(p => p.Name == "Judge");

    //if (judgeProject != null)
    //{
    //    judgeProject.Name = "Judge Updated";

    //    await context.SaveChangesAsync();
    //}
    
    Project judgeProject = await context.Projects
        .FirstOrDefaultAsync(p => p.Name == "Judge");

    if (judgeProject != null)
    {
        context.Projects
            .Remove(judgeProject);

        await context.SaveChangesAsync();
    }



    //DateTime oldEmployeeDate = new DateTime(2000, 1, 1);
    //List<Employee> employees = await context.Employees.Where(e => e.HireDate < oldEmployeeDate).ToListAsync();

    //foreach (Employee employee in employees)
    //{
    //    Console.WriteLine($"{employee.FirstName} {employee.LastName}");
    //}

    //Project project = await context.Projects.FindAsync(2);

    //Console.WriteLine(project.Name);

    //Employee person = await context.Employees.FindAsync(30);
    //Console.WriteLine($"{person.FirstName} {person.LastName}");

    //Console.WriteLine();

    //var richBoy = await context.Employees
    //    .AsNoTracking()
    //    .OrderByDescending(e => e.Salary)
    //    .Select(e => new
    //    {
    //        FirstName = e.FirstName,
    //        LastName = e.LastName,
    //        Salary = e.Salary,
    //    }).FirstOrDefaultAsync();

    //Console.WriteLine($"{richBoy.FirstName} {richBoy.LastName}: {richBoy.Salary}");

    //Paging example

    //int employeesCount = await context.Employees.CountAsync();
    //int pageLength = 10;
    //int pages = employeesCount / pageLength;

    //for (int i = 0; i < pages; i++)
    //{
    //    var employees = await context.Employees
    //        .AsNoTracking()
    //        .OrderBy(e => e.FirstName)
    //        .ThenBy(e => e.LastName)
    //        .Select(e => new
    //        {
    //            FirstName = e.FirstName,
    //            LastName = e.LastName,
    //            Salary = e.Salary,
    //        }).Skip(i * pageLength)
    //        .Take(pageLength)
    //        .ToListAsync();

    //    foreach (var employee in employees)
    //    {
    //        Console.WriteLine($"{employee.FirstName} {employee.LastName}: {employee.Salary}");
    //    }

    //    Console.ReadLine();

    //    Console.Clear();

    //    //Prints the query behind the code

    //    //var employees = context.Employees
    //    //    .AsNoTracking()
    //    //    .OrderBy(e => e.FirstName)
    //    //    .ThenBy(e => e.LastName)
    //    //    .Select(e => new
    //    //    {
    //    //        FirstName = e.FirstName,
    //    //        LastName = e.LastName,
    //    //        Salary = e.Salary,
    //    //    }).Skip(i * pageLength)
    //    //    .Take(pageLength)
    //    //    .ToQueryString();

    //    //Console.WriteLine(employees);
    //}
}