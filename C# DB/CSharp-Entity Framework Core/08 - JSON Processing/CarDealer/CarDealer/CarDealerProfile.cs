namespace CarDealer
{
	using AutoMapper;

	using DTOs.Import;
	using Models;

	public class CarDealerProfile : Profile
	{
		public CarDealerProfile()
		{
			// Supplier
			CreateMap<ImportSupplierDto, Supplier>();

			// Part
			CreateMap<ImportPartDto, Part>();

			// Car
			CreateMap<ImportCarDto, Car>();
			//CreateMap<ImportCarDto, PartCar>()
			//	.ForMember(d => d.PartId, opt => opt.MapFrom(s => s.PartsId));
		}
	}
}
