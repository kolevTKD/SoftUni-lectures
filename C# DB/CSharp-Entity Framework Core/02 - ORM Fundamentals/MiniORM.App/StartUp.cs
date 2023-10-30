using MiniORM.App;
using MiniORM.App.Data;
using MiniORM.App.Data.Entities;

var context = new SoftUniDbContext(Config.CONNECTION_STRING);

context.Employees.Add(new Employee
{
    FirstName = "Gosho",
    LastName = "Inserted",
    DepartmentId = context.Departments.First().Id,
    IsEmployed = true,
});

var employee = context.Employees.Last();
employee.FirstName = "Modified";

context.SaveChanges();

//Employee newEmployee = context
//            .Employees.First(e => e.FirstName == "Modified");
//context.Employees.Remove(newEmployee);

//context.SaveChanges();