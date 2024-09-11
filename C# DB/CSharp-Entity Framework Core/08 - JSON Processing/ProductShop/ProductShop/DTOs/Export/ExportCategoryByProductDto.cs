namespace ProductShop.DTOs.Export
{
	using Newtonsoft.Json;

	public class ExportCategoryByProductDto
	{
		[JsonProperty("category")]
		public string CategoryName { get; set; } = null!;

		[JsonProperty("productsCount")]
		public int ProductsCount { get; set; }

		[JsonProperty("averagePrice")]
		public string AveragePrice { get; set; } = null!;

		[JsonProperty("totalRevenue")]
		public string TotalRevenue { get; set; } = null!;
	}
}
