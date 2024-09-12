namespace CarDealer.DTOs.Export
{
	public class ExportOrderedCustomersDto
	{
		public string Name { get; set; } = null!;
		public string BirthDate { get; set; } = null!;
		public bool IsYoungDriver { get; set; }
	}
}
