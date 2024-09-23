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
			CreateMap<ImportCustomerDto, Customer>()
				.ForMember(d => d.BirthDate, opt => opt.MapFrom(s => DateTime.Parse(s.BirthDate).ToString()));

			// Sale
			CreateMap<ImportSaleDto, Sale>();

			// 14-Export Cars with Distance
			CreateMap<Car, ExportCarWithDistanceDto>();

			// 15-Export Cars from Make BMW
			CreateMap<Car, ExportCarFromMakeBmwDto>();

			//16-Export Local Suppliers
			CreateMap<Supplier, ExportLocalSupplierDto>()
				.ForMember(d => d.PartsCount, opt => opt.MapFrom(s => s.Parts.Count));

			//17-Export Cars with Their List of Parts
			CreateMap<Part, InsidePartDto>();
			CreateMap<Car, ExportCarPartDto>()
				.ForMember(d => d.Parts, opt => opt.MapFrom
					(s => s.PartsCars
						.Select(pc => pc.Part)
						.OrderByDescending(p => p.Price)
						.ToArray()));

			//18-Export Sales with Applied Discount
			CreateMap<Sale, ExportSaleWithDiscountDto>()
				.ForMember(d => d.CustomerName, opt => opt.MapFrom(s => s.Customer.Name))
				.ForMember(d => d.Price, opt => opt.MapFrom(s => Math.Round(s.Car.PartsCars.Sum(p => p.Part.Price), 2)))
				.ForMember(d => d.PriceWithDiscount, opt => opt.MapFrom(s => (double)Math.Round((s.Car.PartsCars.Sum(p => p.Part.Price) * (1 - (s.Discount / 100))), 4)));

			CreateMap<Car, InsideCarDto>();
		}
	}
}
