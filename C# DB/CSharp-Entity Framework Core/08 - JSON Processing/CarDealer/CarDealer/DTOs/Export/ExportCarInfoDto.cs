using CarDealer.Models;

namespace CarDealer.DTOs.Export
{
	public class ExportCarInfoDto
	{
		public string Make { get; set; } = null!;
		public string Model { get; set; } = null!;
		public long TraveledDistance { get; set; }
	}
}
