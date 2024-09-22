namespace ProductShop
{
	using System.Text;
	using System.Xml;
	using System.Xml.Serialization;

	using AutoMapper;
	using AutoMapper.QueryableExtensions;
	using Microsoft.EntityFrameworkCore;

	using Data;
	using DTOs.Import;
	using DTOs.Export;
	using Models;

	public class StartUp
	{
		public static void Main()
		{
			using (ProductShopContext context = new ProductShopContext())
			{
				//string path = @"..\..\..\Datasets\";
				//string inputXml = ReadXml(path);

				//Console.WriteLine(ImportCategoryProducts(context, inputXml));

				WriteXml(GetUsersWithProducts(context));
			}
		}

		public static string ImportUsers(ProductShopContext context, string inputXml) //01-Import Users
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

		public static string ImportProducts(ProductShopContext context, string inputXml) //02-Import Products
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

		public static string ImportCategories(ProductShopContext context, string inputXml) //03-Import Categories
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

		public static string ImportCategoryProducts(ProductShopContext context, string inputXml) //04-Import Categories and Products
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

		public static string GetProductsInRange(ProductShopContext context) //05-Export Products in Range
		{
			IMapper mapper = CreateMapper();

			ExportProductInRangeDto[] exportProductDtos = context.Products
				.AsNoTracking()
				.Where(p => p.Price >= 500 && p.Price <= 1000)
				.OrderBy(p => p.Price)
				.Take(10)
				.ProjectTo<ExportProductInRangeDto>(mapper.ConfigurationProvider)
				.ToArray();

			XmlRootAttribute root = new XmlRootAttribute("Products");

			XmlSerializer serializer = new XmlSerializer(typeof(ExportProductInRangeDto[]), root);

			StringBuilder sb = new StringBuilder();
			using (StringWriter writer = new StringWriter(sb))
			{
				serializer.Serialize(writer, exportProductDtos, ConfigureNamespaces());
			}

			return sb.ToString().TrimEnd();
		}

		public static string GetSoldProducts(ProductShopContext context) //06-Export Sold Products
		{
			IMapper mapper = CreateMapper();

			ExportSoldProductDto[] soldProductDtos = context.Users
				.AsNoTracking()
				.Where(u => u.ProductsSold.Any())
				.OrderBy(u => u.LastName)
				.ThenBy(u => u.FirstName)
				.Take(5)
				.ProjectTo<ExportSoldProductDto>(mapper.ConfigurationProvider)
				.ToArray();

			XmlRootAttribute root = new XmlRootAttribute("Users");
			XmlSerializer serializer = new XmlSerializer(typeof(ExportSoldProductDto[]), root);

			StringBuilder sb = new StringBuilder();
			using (StringWriter writer = new StringWriter(sb))
			{
				serializer.Serialize(writer, soldProductDtos, ConfigureNamespaces());
			}

			return sb.ToString().TrimEnd();
		}

		public static string GetCategoriesByProductsCount(ProductShopContext context) //07-Export Categories By Products Count
		{
			IMapper mapper = CreateMapper();

			ExportCategoryByProductCountDto[] exportCategoryDtos = context.Categories
				.AsNoTracking()
				.OrderByDescending(c => c.CategoryProducts.Count)
				.ThenBy(c => c.CategoryProducts.Sum(cp => cp.Product.Price))
				.ProjectTo<ExportCategoryByProductCountDto>(mapper.ConfigurationProvider)
				.ToArray();

			XmlRootAttribute root = new XmlRootAttribute("Categories");
			XmlSerializer serializer = new XmlSerializer(typeof(ExportCategoryByProductCountDto[]), root);

			StringBuilder sb = new StringBuilder();
			using (StringWriter writer = new StringWriter(sb))
			{
				serializer.Serialize(writer, exportCategoryDtos, ConfigureNamespaces());
			}

			return sb.ToString().TrimEnd();
		}

		public static string GetUsersWithProducts(ProductShopContext context) //08-Export Users and Products
		{
			var users = context.Users
				.Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
				.Select(u => new UserDto()
				{
					FirstName = u.FirstName,
					LastName = u.LastName,
					Age = u.Age,
					SoldProducts = new SoldProducts()
					{
						Count = u.ProductsSold.Count,
						Products = u.ProductsSold
							.Where(p => p.BuyerId != null)
							.Select(p => new ProductX()
							{
								Name = p.Name,
								Price = p.Price
							})
							.OrderByDescending(p => p.Price)
							.ToArray()
					}
				})
				.OrderByDescending(u => u.SoldProducts.Count)
				.Take(10)
				.ToArray();

			UsersDto info = new UsersDto()
			{
				Count = context.Users.Count(u => u.ProductsSold.Any(p => p.BuyerId != null)),
				UsersInfo = users
			};

			XmlRootAttribute root = new XmlRootAttribute("Users");
			XmlSerializer serializer = new XmlSerializer(typeof(UsersDto), root);

			StringBuilder sb = new StringBuilder();
			using (StringWriter writer = new StringWriter(sb))
			{
				serializer.Serialize(writer, info, ConfigureNamespaces());
			}

			return sb.ToString().TrimEnd();
			//return Serializer<UsersDto>(info, "Users");
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

		private static void WriteXml(string outputXml)
		{
			string path = Path.Combine(@"..\..\..\Results\", Console.ReadLine());
			File.WriteAllText(path, outputXml);
		}

		private static XmlSerializerNamespaces ConfigureNamespaces()
			=> new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
	}
}