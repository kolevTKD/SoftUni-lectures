namespace CarDealer.DTOs.Export
{
	using System.Xml.Serialization;

	[XmlType("customer")]
	public class ExportCustomerSaleDto
	{
		[XmlAttribute("full-name")]
		public string Name { get; set; } = null!;

		[XmlAttribute("bought-cars")]
		public int Sales { get; set; }

		[XmlAttribute("spent-money")]
		public decimal SpentMoney { get; set; }
	}
}
