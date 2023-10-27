// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using ORMFundamentalsTesting;

Console.WriteLine("Hello, World!");

var context = new DbContextApplication();

var result = from employee 
             in context.Employees 
             where employee.FirstName == "Pesho" 
             select employee; //Classic LINQ example.

var result1 = context.Employees.Where(e => e.FirstName == "Pesho").ToList(); //Modern LINQ example, same functionallity as the classic (No ToList() method to be 100% equal).

var employee1 = context.Employees.Find(2);

var employee2 = await context.Employees.FirstOrDefaultAsync(e => e.Id == 2);

Console.WriteLine(employee2?.FirstName);