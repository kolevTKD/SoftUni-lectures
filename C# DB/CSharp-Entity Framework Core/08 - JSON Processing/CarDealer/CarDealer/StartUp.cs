namespace CarDealer
{
	using AutoMapper;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Serialization;

	using Data;
	using DTOs.Import;
	using Models;

	public class StartUp
	{
		public static void Main()
		{
			using (CarDealerContext context = new CarDealerContext())
			{
				string path = @"..\..\..\Datasets\";
				string inputJson = ReadJson(path);

				Console.WriteLine(ImportCars(context, inputJson));
			}
		}

		public static string ImportSuppliers(CarDealerContext context, string inputJson) //01-Import Suppliers
		{
			IMapper mapper = CreateMapper();
			IContractResolver contractResolver = ConfigureCamelCaseNaming();

			ICollection<Supplier> validSuppliers = new HashSet<Supplier>();

			ImportSupplierDto[] importSupplierDtos = JsonConvert.DeserializeObject<ImportSupplierDto[]>(inputJson, new JsonSerializerSettings()
			{
				ContractResolver = contractResolver
			});

			foreach (ImportSupplierDto supplierDto in importSupplierDtos)
			{
				Supplier supplier = mapper.Map<Supplier>(supplierDto);

				validSuppliers.Add(supplier);
			}

			context.BulkInsert(validSuppliers);

			return $"Successfully imported {validSuppliers.Count}.";
		}
		public static string ImportParts(CarDealerContext context, string inputJson) //02-Import Parts
		{
			IMapper mapper = CreateMapper();
			IContractResolver contractResolver = ConfigureCamelCaseNaming();

			ICollection<Part> validParts = new HashSet<Part>();

			ImportPartDto[] importPartDtos = JsonConvert.DeserializeObject<ImportPartDto[]>(inputJson, new JsonSerializerSettings
			{
				ContractResolver = contractResolver
			});

			foreach (ImportPartDto importPartDto in importPartDtos)
			{
				if(context.Suppliers.Find(importPartDto.SupplierId) != null)
				{
					Part part = mapper.Map<Part>(importPartDto);

					validParts.Add(part);
				}
			}

			context.BulkInsert(validParts);

			return $"Successfully imported {validParts.Count}.";
		}
		public static string ImportCars(CarDealerContext context, string inputJson) //03-Import Cars
		{
			IMapper mapper = CreateMapper();
			IContractResolver contractResolver = ConfigureCamelCaseNaming();

			ICollection<Car> validCars = new HashSet<Car>();

			ImportCarDto[] importCarDtos = JsonConvert.DeserializeObject<ImportCarDto[]>(inputJson, new JsonSerializerSettings()
			{
				ContractResolver = contractResolver
			});

			foreach (ImportCarDto importCarDto in importCarDtos)
			{
				Car car = mapper.Map<Car>(importCarDto);

				foreach (int id in importCarDto.PartsId)
				{
					if (context.Parts.Any(p => p.Id == id))
					{
						car.PartsCars.Add(new PartCar
						{
							PartId = id
						});
					}
				}

				validCars.Add(car);
			}

			context.Cars.AddRange(validCars);
			context.SaveChanges();

			//context.BulkInsert(validCars); - DOES NOT work in Judge!

			return $"Successfully imported {validCars.Count}.";
		}
		private static string ReadJson(string path)
			=> File.ReadAllText(Path.Combine(path, Console.ReadLine()));
		private static void WriteJson(string outputJson)
		{
			string path = Path.Combine(@"..\..\..\Results\", Console.ReadLine());
			File.WriteAllText(path, outputJson);
		}
		private static IMapper CreateMapper()
		{
			return new Mapper(new MapperConfiguration(cfg =>
			{
				cfg.AddProfile<CarDealerProfile>();
			}));
		}
		private static IContractResolver ConfigureCamelCaseNaming()
		{
			return new DefaultContractResolver()
			{
				NamingStrategy = new CamelCaseNamingStrategy(false, true)
			};
		}
	}
}