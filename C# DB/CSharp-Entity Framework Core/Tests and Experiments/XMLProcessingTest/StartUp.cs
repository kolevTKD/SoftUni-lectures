using System.Xml.Linq;
using System.Xml.Serialization;

using AutoMapper;
using Microsoft.EntityFrameworkCore;

using XMLProcessingTest;
using XMLProcessingTest.Data;
using XMLProcessingTest.DTOs;

var config = new MapperConfiguration(cfg =>
{
	cfg.AddProfile<MapProfile>();
});

using (SoftUniContext context = new SoftUniContext())
{
	var employees = await context.Employees
		.Where(e => e.DepartmentId == 3)
		.Include(e => e.Department)
		.ToArrayAsync();

	var employeesSerializer = new EmployeesDto()
	{
		Department = employees.FirstOrDefault()?.Department?.Name,
		Employees = employees.Select(e => new EmployeeDto()
		{
			FullName = $"{e.FirstName} {e.LastName}",
			Salary = e.Salary
		}).ToArray()
	};

	XmlSerializer serializer = new XmlSerializer(typeof(EmployeesDto));

	using (StreamWriter writer = new StreamWriter(@"..\..\..\employees.xml"))
	{
		serializer.Serialize(writer, employeesSerializer);
	}

	XmlSerializer deserializer = new XmlSerializer(typeof(EmployeesDto));

	using (StreamReader reader = new StreamReader(@"..\..\..\employees.xml"))
	{
		var dto = (EmployeesDto)deserializer.Deserialize(reader);
	}

	//XDocument doc = XDocument.Load(@"..\..\..\employees.xml");

	//var dto = new EmployeesDto() { Department = doc.Root.Attribute("Department").Value };
	//var employeesCollection = new List<EmployeeDto>();
	//var employeesDeserializer = doc.Root.Elements("Employee");

	//foreach (var employee in employeesDeserializer)
	//{
	//	employeesCollection.Add(new EmployeeDto()
	//	{
	//		FullName = employee.Element("Name").Value,
	//		Salary = decimal.Parse(employee.Element("Salary").Value)
	//	});
	//}

	//dto.Employees = employeesCollection.ToArray();


}
