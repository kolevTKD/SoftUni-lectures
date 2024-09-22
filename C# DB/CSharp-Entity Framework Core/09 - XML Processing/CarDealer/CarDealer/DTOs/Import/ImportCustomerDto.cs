namespace CarDealer.DTOs.Import
{
	using System.Xml.Serialization;

	[XmlType("Customer")]
	public class ImportCustomerDto
	{
		[XmlElement("name")]
		public string Name { get; set; } = null!;

		[XmlElement("birthDate")]
		public string BirthDate { get; set; } = null!;

		[XmlElement("isYoungDriver")]
		public bool IsYoungDriver { get; set; }
	}
}
