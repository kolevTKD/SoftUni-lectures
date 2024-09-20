namespace ProductShop
{
	using AutoMapper;

	using DTOs.Import;
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
		}
	}
}
