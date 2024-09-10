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
		}
	}
}
