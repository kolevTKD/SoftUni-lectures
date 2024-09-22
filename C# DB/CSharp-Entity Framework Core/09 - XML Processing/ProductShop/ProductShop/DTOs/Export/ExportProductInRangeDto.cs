namespace ProductShop.DTOs.Export
{
	using System.Xml.Serialization;

	[XmlType("Product")]
	public class ExportProductInRangeDto
	{
		[XmlElement("name")]
		public string Name { get; set; } = null!;

		[XmlElement("price")]
		public decimal Price { get; set; }

		[XmlElement("buyer")]
		public string Buyer { get; set; }
	}
}
