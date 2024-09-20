namespace ProductShop
{
	using System.Xml.Serialization;

	using AutoMapper;
	using Data;
	using DTOs.Import;
	using Models;

	public class StartUp
	{
		public static void Main()
		{
			using (ProductShopContext context = new ProductShopContext())
			{
				string path = @"..\..\..\Datasets\";
				string inputXml = ReadXml(path);

				Console.WriteLine(ImportCategoryProducts(context, inputXml));
			}
		}

		public static string ImportUsers(ProductShopContext context, string inputXml)
		{
			IMapper mapper = CreateMapper();

			XmlRootAttribute root = new XmlRootAttribute("Users");
			XmlSerializer serializer = new XmlSerializer(typeof(ImportUserDto[]), root);

			StringReader reader = new StringReader(inputXml);

			ImportUserDto[] userDtos = (ImportUserDto[])serializer.Deserialize(reader);

			ICollection<User> validUsers = new HashSet<User>();

			foreach (ImportUserDto userDto in userDtos)
			{
				if (String.IsNullOrEmpty(userDto.FirstName) || String.IsNullOrEmpty(userDto.LastName))
				{
					continue;
				}

				User user = mapper.Map<User>(userDto);
				validUsers.Add(user);
			}

			context.Users.AddRange(validUsers);
			context.SaveChanges();

			return $"Successfully imported {validUsers.Count}";
		}

		public static string ImportProducts(ProductShopContext context, string inputXml)
		{
			IMapper mapper = CreateMapper();

			XmlRootAttribute root = new XmlRootAttribute("Products");
			XmlSerializer serializer = new XmlSerializer(typeof(ImportProductDto[]), root);

			StringReader reader = new StringReader(inputXml);

			ImportProductDto[] productDtos = (ImportProductDto[])serializer.Deserialize(reader);

			ICollection<Product> validProducts = new HashSet<Product>();

			foreach (ImportProductDto productDto in productDtos)
			{
				if (String.IsNullOrEmpty(productDto.Name))
				{
					continue;
				}

				Product product = mapper.Map<Product>(productDto);
				validProducts.Add(product);
			}

			context.Products.AddRange(validProducts);
			context.SaveChanges();

			return $"Successfully imported {validProducts.Count}";
		}

		public static string ImportCategories(ProductShopContext context, string inputXml)
		{
			IMapper mapper = CreateMapper();

			XmlRootAttribute root = new XmlRootAttribute("Categories");
			XmlSerializer serializer = new XmlSerializer(typeof(ImportCategoryDto[]), root);

			StringReader reader = new StringReader(inputXml);
			ImportCategoryDto[] categoryDtos = (ImportCategoryDto[])serializer.Deserialize(reader);

			ICollection<Category> validCategories = new HashSet<Category>();

			foreach (ImportCategoryDto categoryDto in categoryDtos)
			{
				if (String.IsNullOrEmpty(categoryDto.Name))
				{
					continue;
				}

				Category category = mapper.Map<Category>(categoryDto);
				validCategories.Add(category);
			}

			context.Categories.AddRange(validCategories);
			context.SaveChanges();

			return $"Successfully imported {validCategories.Count}";
		}

		public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
		{
			IMapper mapper = CreateMapper();

			XmlRootAttribute root = new XmlRootAttribute("CategoryProducts");
			XmlSerializer serializer = new XmlSerializer(typeof(ImportCategoryProductDto[]), root);

			StringReader reader = new StringReader(inputXml);

			ImportCategoryProductDto[] categoryProductDtos = (ImportCategoryProductDto[])serializer.Deserialize(reader);

			ICollection<CategoryProduct> validCategoryProducts = new HashSet<CategoryProduct>();

			foreach (ImportCategoryProductDto categoryProductDto in categoryProductDtos)
			{
				if (!context.Categories.Any(c => c.Id == categoryProductDto.CategoryId) ||
					!context.Products.Any(p => p.Id == categoryProductDto.ProductId))
				{
					continue;
				}

				CategoryProduct categoryProduct = mapper.Map<CategoryProduct>(categoryProductDto);
				validCategoryProducts.Add(categoryProduct);
			}

			context.CategoryProducts.AddRange(validCategoryProducts);
			context.SaveChanges();

			return $"Successfully imported {validCategoryProducts.Count}";
		}

		private static IMapper CreateMapper()
		{
			return new Mapper(new MapperConfiguration(cfg =>
			{
				cfg.AddProfile<ProductShopProfile>();
			}));
		}

		private static string ReadXml(string path)
			=> File.ReadAllText(Path.Combine(path, Console.ReadLine()));
	}
}