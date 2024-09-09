using AutoMapper;
using AutoMapper.QueryableExtensions;
using JSONProcessingTest.Data;
using JSONProcessingTest.DTOs;
using Newtonsoft.Json;
using System.Text.Json;

namespace JSONProcessingTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (SoftUniContext context = new SoftUniContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<MapProfile>();
                });

                var employees = context.Employees
                    .ProjectTo<EmployeeDto>(config)
                    .ToArray();

                string path = @"..\..\..\employees.txt";

                //System.Text.Json
                //string serializedEmployees = JsonSerializer.Serialize(employees);

                //File.WriteAllText(path, serializedEmployees);

                //List<EmployeeDto> DTOs = JsonSerializer.Deserialize<List<EmployeeDto>>(serializedEmployees);

                //int rowNumber = 1;
                //foreach (EmployeeDto employee in DTOs)
                //{
                //    Console.WriteLine($"{rowNumber++}: {employee.FullName}");
                //}

                //Newtonsoft.Json
                string serializedEmployees = JsonConvert.SerializeObject(employees, Formatting.Indented);
                Console.WriteLine(serializedEmployees);

                File.WriteAllText(path, serializedEmployees);

                List<EmployeeDto> DTOs = JsonConvert.DeserializeObject<List<EmployeeDto>>(serializedEmployees);

                int rowNumber = 1;

                //foreach (EmployeeDto employee in DTOs)
                //{
                //    Console.WriteLine($"{rowNumber++}: {employee.FullName} - {employee.DepartmentName}");
                //}
            }
        }
    }
}
