namespace ProductShop
{
	using AutoMapper;
	using Newtonsoft.Json;

	using Data;
	using DTOs.Import;
	using Models;

	public class StartUp
	{
		public static void Main()
		{
			using (ProductShopContext context = new ProductShopContext())
			{
				string path = @"..\..\..\Datasets\users.json";
				string inputJson = ReadJson(path);


				Console.WriteLine(ImportUsers(context, inputJson));
			}
		}

		public static string ImportUsers(ProductShopContext context, string inputJson)
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
			context.SaveChanges();

			return $"Successfully imported {validUsers.Count}";
		}

		private static string ReadJson(string path)
			=> File.ReadAllText(path);

		private static IMapper CreateMapper()
		{
			return new Mapper(new MapperConfiguration(cfg =>
			{
				cfg.AddProfile<ProductShopProfile>();
			}));
		}
	}
}