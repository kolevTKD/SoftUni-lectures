namespace AutoMappingTesting
{
    using AutoMapper;
    using AutoMappingTesting.DTOs;
    using Microsoft.EntityFrameworkCore;

    using Data;
    using AutoMappingTesting.Models;
    using AutoMapper.QueryableExtensions;

    public class StartUp
    {
        static async Task Main(string[] args)
        {
            using (SoftUniContext context = new SoftUniContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<MapProfile>();
                });

                var employees = await context.Employees
                    .ProjectTo<EmployeeDto>(config) //Working like an automatic .Select()
                    .ToListAsync(); //Simple Syntax

                //var mapper = config.CreateMapper();

                //List<EmployeeDto> employeesDto = new List<EmployeeDto>();

                //foreach (var employee in employees)
                //{
                //    //AutoMapping example 1
                //    //employeesDto.Add(new EmployeeDto()
                //    //{
                //    //    Department = employee.Department.Name,
                //    //    FirstName = employee.FirstName,
                //    //    MiddleName = employee.MiddleName,
                //    //    LastName = employee.LastName,
                //    //    Salary = employee.Salary
                //    //});

                //    //AutoMapping example 1.1
                //    employeesDto.Add(mapper.Map<EmployeeDto>(employee)); //Complicated Syntax
                //}

                //Manual mapping example
                //var employees = await context.Employees
                //    .Select(e => new EmployeeDto()
                //    {
                //        FullName = $"{e.FirstName} {e.MiddleName} {e.LastName}",
                //        Department = e.Department.Name,
                //        Salary = e.Salary
                //    })
                //    .ToListAsync();


            }
        }
    }
}
