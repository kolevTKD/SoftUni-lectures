namespace ProductShop
{
	using AutoMapper;
	using AutoMapper.QueryableExtensions;
	using Microsoft.EntityFrameworkCore;
	using Newtonsoft.Json;

	using Data;
	using DTOs.Import;
	using Models;
	using ProductShop.DTOs.Export;

	public class StartUp
	{
		public static void Main()
		{
			using (ProductShopContext context = new ProductShopContext())
			{
				//string path = @"..\..\..\Datasets\categories-products.json";
				//string inputJson = ReadJson(path);

				WriteJson(GetSoldProducts(context));
			}
		}

		public static string ImportUsers(ProductShopContext context, string inputJson) //01-Import Users
		{
			IMapper mapper = CreateMapper();

			ImportUserDto[] importUserDtos = JsonConvert.DeserializeObject<ImportUserDto[]>(inputJson);

			ICollection<User> validUsers = new HashSet<User>();

			foreach (ImportUserDto userDto in importUserDtos)
			{
				User user = mapper.Map<User>(userDto);

				validUsers.Add(user);
			}

			context.BulkInsert(validUsers);

			return $"Successfully imported {validUsers.Count}";
		}

		public static string ImportProducts(ProductShopContext context, string inputJson) //02-Import Products
		{
			IMapper mapper = CreateMapper();

			ImportProductDto[] importProductDtos = JsonConvert.DeserializeObject<ImportProductDto[]>(inputJson);

			ICollection<Product> validProducts = new HashSet<Product>();

			foreach (ImportProductDto productDto in importProductDtos)
			{
				Product product = mapper.Map<Product>(productDto);

				validProducts.Add(product);
			}

			context.BulkInsert(validProducts);

			return $"Successfully imported {validProducts.Count}";
		}

		public static string ImportCategories(ProductShopContext context, string inputJson) //03-Import Categories
		{
			IMapper mapper = CreateMapper();

			ImportCategoryDto[] importCategoryDtos = JsonConvert.DeserializeObject<ImportCategoryDto[]>(inputJson);

			ICollection<Category> validCategories = new HashSet<Category>();

			foreach (ImportCategoryDto categoryDto in importCategoryDtos)
			{
				Category category = mapper.Map<Category>(categoryDto);

				if (String.IsNullOrEmpty(category.Name))
				{
					continue;
				}

				validCategories.Add(category);
			}

			context.BulkInsert(validCategories);

			return $"Successfully imported {validCategories.Count}";
		}

		public static string ImportCategoryProducts(ProductShopContext context, string inputJson) //04-Import CategoryProducts
		{
			IMapper mapper = CreateMapper();

			ImportCategoryProductDto[] importCategoryProductDtos = JsonConvert.DeserializeObject<ImportCategoryProductDto[]>(inputJson);

			ICollection<CategoryProduct> validCategoryProducts = new HashSet<CategoryProduct>();

			foreach (ImportCategoryProductDto categoryProductDto in importCategoryProductDtos)
			{
				CategoryProduct categoryProduct = mapper.Map<CategoryProduct>(categoryProductDto);

				validCategoryProducts.Add(categoryProduct);
			}

			context.BulkInsert(validCategoryProducts);

			return $"Successfully imported {validCategoryProducts.Count}";
		}

		public static string GetProductsInRange(ProductShopContext context) //05-Export Products in Range
		{
			IMapper mapper = CreateMapper();

			ExportProductInRangeDto[] productDtos = context.Products
				.AsNoTracking()
				.Where(p => p.Price >= 500 && p.Price <= 1000)
				.OrderBy(p => p.Price)
				.ProjectTo<ExportProductInRangeDto>(mapper.ConfigurationProvider)
				.ToArray();

			return JsonConvert.SerializeObject(productDtos, Formatting.Indented);
		}

		public static string GetSoldProducts(ProductShopContext context) //06-Export Sold Products
		{
			IMapper mapper = CreateMapper();

			ExportSoldProductsDto[] soldProductsDtos = context.Users
				.AsNoTracking()
				.Where(u => u.ProductsSold.Any(p => p.Buyer != null))
				.OrderBy(u => u.LastName)
				.ThenBy(u => u.FirstName)
				.ProjectTo<ExportSoldProductsDto>(mapper.ConfigurationProvider)
				.ToArray();

			return JsonConvert.SerializeObject(soldProductsDtos, Formatting.Indented);
		}

		private static string ReadJson(string path)
			=> File.ReadAllText(path);

		private static void WriteJson(string outputJson)
		{
			string path = Path.Combine(@"..\..\..\Results\", Console.ReadLine());
			File.WriteAllText(path, outputJson);
		}

		private static IMapper CreateMapper()
		{
			return new Mapper(new MapperConfiguration(cfg =>
			{
				cfg.AddProfile<ProductShopProfile>();
			}));
		}
	}
}