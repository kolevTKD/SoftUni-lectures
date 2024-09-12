namespace CarDealer
{
	using AutoMapper;

	using DTOs.Export;
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

			// Customer
			CreateMap<ImportCustomerDto, Customer>();

			// Sale
			CreateMap<ImportSaleDto, Sale>();

			// 6-Export Ordered Customers
			CreateMap<Customer, ExportOrderedCustomersDto>()
				.ForMember(d => d.BirthDate, opt => opt.MapFrom(s => s.BirthDate.ToString("dd/MM/yyyy")));

			// 7-Export Cars from Make Toyota
			CreateMap<Car, ExportToyotaCarDto>()
				.ForMember(d => d.TraveledDistance, opt => opt.MapFrom(s => s.TraveledDistance));

			// 08-Export Local Suppliers
			CreateMap<Supplier, ExportLocalSupplierDto>()
				.ForMember(d => d.PartsCount, opt => opt.MapFrom(s => s.Parts.Count));

			//09-Export Cars with Their List of Parts
			CreateMap<Car, ExportCarInfoDto>();
			CreateMap<Part, ExportPartInfoDto>()
				.ForMember(d => d.Price, opt => opt.MapFrom(s => s.Price.ToString("F2")));
			CreateMap<Car, ExportCarPartWrapperDto>()
				.ForMember(d => d.Car, opt => opt.MapFrom(s => s))
				.ForMember(d => d.Parts, opt => opt.MapFrom(s => s.PartsCars.Select(pc => pc.Part)));
		}
	}
}
