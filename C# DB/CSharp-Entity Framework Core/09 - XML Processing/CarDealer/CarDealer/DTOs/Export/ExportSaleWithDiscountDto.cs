using System.Xml.Serialization;

namespace CarDealer.DTOs.Export
{
	[XmlType("sale")]
	public class ExportSaleWithDiscountDto
	{
		[XmlElement("car")]
		public InsideCarDto Car { get; set; }

		[XmlElement("discount")]
		public decimal Discount { get; set; }

		[XmlElement("customer-name")]
		public string CustomerName { get; set; } = null!;

		[XmlElement("price")]
		public decimal Price { get; set; }

		[XmlElement("price-with-discount")]
		public double PriceWithDiscount { get; set; }
	}
}
