namespace XMLProcessingTest.DTOs
{
	using System.Xml.Serialization;

	[XmlRoot("Employees")]
	public class EmployeesDto
	{
		[XmlAttribute("Department")]
		public string? Department { get; set; }

		[XmlElement("Employee")]
		public EmployeeDto[] Employees { get; set; }
	}
}
