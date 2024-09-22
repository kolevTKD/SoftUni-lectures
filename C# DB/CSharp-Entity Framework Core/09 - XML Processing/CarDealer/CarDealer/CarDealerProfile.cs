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

			// Customer
			CreateMap<ImportCustomerDto, Customer>()
				.ForMember(d => d.BirthDate, opt => opt.MapFrom(s => DateTime.Parse(s.BirthDate).ToString()));

			// Sale
			CreateMap<ImportSaleDto, Sale>();
		}
	}
}
