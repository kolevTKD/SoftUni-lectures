namespace ProductShop.DTOs.Export
{
	using Newtonsoft.Json;

	public class ExportSoldProductsDto
	{
		[JsonProperty("firstName")]
		public string? SellerFirstName { get; set; }

		[JsonProperty("lastName")]
		public string SellerLastName { get; set; } = null!;

		[JsonProperty("soldProducts")]
		public ICollection<SoldProductHelperDto> SoldProducts { get; set; } = null!;
	}
}
