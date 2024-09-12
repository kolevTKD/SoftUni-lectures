using Newtonsoft.Json;

namespace CarDealer.DTOs.Export
{
	public class ExportCarPartWrapperDto
	{
		[JsonProperty("car")]
		public ExportCarInfoDto Car { get; set; } = null!;

		[JsonProperty("parts")]
		public ICollection<ExportPartInfoDto> Parts { get; set; } = null!;
	}
}
