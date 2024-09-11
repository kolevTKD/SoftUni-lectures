namespace ProductShop
{
	using AutoMapper;

	using DTOs.Import;
	using Models;
	using ProductShop.DTOs.Export;

	public class ProductShopProfile : Profile
	{
		public ProductShopProfile()
		{
			// User
			CreateMap<ImportUserDto, User>();

			// Product
			CreateMap<ImportProductDto, Product>();

			CreateMap<Product, ExportProductInRangeDto>() //05
				.ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
				.ForMember(d => d.Price, opt => opt.MapFrom(s => s.Price))
				.ForMember(d => d.SellerName, opt => opt.MapFrom(s => $"{s.Seller.FirstName} {s.Seller.LastName}"));

			CreateMap<User, ExportSoldProductsDto>() //06
				.ForMember(d => d.SellerFirstName, opt => opt.MapFrom(s => s.FirstName))
				.ForMember(d => d.SellerLastName, opt => opt.MapFrom(s => s.LastName))
				.ForMember(d => d.SoldProducts, opt => opt.MapFrom(s => s.ProductsSold.Where(p => p.Buyer != null)));

			CreateMap<Product, SoldProductHelperDto>()
				.ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
				.ForMember(d => d.Price, opt => opt.MapFrom(s => s.Price))
				.ForMember(d => d.BuyerFirstName, opt => opt.MapFrom(s => s.Buyer.FirstName))
				.ForMember(d => d.BuyerLastName, opt => opt.MapFrom(s => s.Buyer.LastName));
				

			//Category
			CreateMap<ImportCategoryDto, Category>();

			//CategoryProduct
			CreateMap<ImportCategoryProductDto, CategoryProduct>();
		}
	}
}
