namespace XMLProcessingTest.DTOs
{
	using System.Xml.Serialization;

	public class EmployeeDto
	{
		[XmlElement("Name")]
		public string FullName { get; set; }

		[XmlElement("Salary")]
		public decimal Salary { get; set; }
	}
}
