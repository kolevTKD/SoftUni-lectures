namespace ProductShop
{
	using AutoMapper;

	using DTOs.Import;
	using DTOs.Export;
	using Models;

	public class ProductShopProfile : Profile
	{
		public ProductShopProfile()
		{
			// User
			CreateMap<ImportUserDto, User>();

			// Product
			CreateMap<ImportProductDto, Product>();

			// Category
			CreateMap<ImportCategoryDto, Category>();

			//CategoryProduct
			CreateMap<ImportCategoryProductDto, CategoryProduct>();

			// 05-Export Products in Range
			CreateMap<Product, ExportProductInRangeDto>()
				.ForMember(d => d.Buyer, opt => opt.MapFrom(s => $"{s.Buyer.FirstName} {s.Buyer.LastName}"));

			// 06-Export Sold Products
			CreateMap<User, ExportSoldProductDto>()
				.ForMember(d => d.SoldProducts, opt => opt.MapFrom(s => s.ProductsSold));

			CreateMap<Product, ProductInsideDto>();

			// 07-Export Categories By Products Count
			CreateMap<Category, ExportCategoryByProductCountDto>()
				.ForMember(d => d.Count, opt => opt.MapFrom(s => s.CategoryProducts.Count))
				.ForMember(d => d.AveragePrice, opt => opt.MapFrom(s => s.CategoryProducts.Average(cp => cp.Product.Price)))
				.ForMember(d => d.TotalRevenue, opt => opt.MapFrom(s => s.CategoryProducts.Sum(cp => cp.Product.Price)));
		}
	}
}
