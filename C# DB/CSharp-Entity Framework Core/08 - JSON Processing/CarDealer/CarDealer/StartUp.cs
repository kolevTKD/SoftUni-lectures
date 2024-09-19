namespace CarDealer
{
	using AutoMapper;
	using AutoMapper.QueryableExtensions;
	using Microsoft.EntityFrameworkCore;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Serialization;

	using Data;
	using DTOs.Export;
	using DTOs.Import;
	using Models;

	public class StartUp
	{
		public static void Main()
		{
			using (CarDealerContext context = new CarDealerContext())
			{
				//string path = @"..\..\..\Datasets\";
				//string inputJson = ReadJson(path);

				//Console.WriteLine(ImportSales(context, inputJson));

				WriteJson(GetSalesWithAppliedDiscount(context));
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

		public static string ImportCustomers(CarDealerContext context, string inputJson) //04-Import Customers
		{
			IMapper mapper = CreateMapper();
			IContractResolver contractResolver = ConfigureCamelCaseNaming();

			ICollection<Customer> validCustomers = new HashSet<Customer>();

			ImportCustomerDto[] importCustomerDtos = JsonConvert.DeserializeObject<ImportCustomerDto[]>(inputJson, new JsonSerializerSettings()
			{
				ContractResolver = contractResolver
			});

			foreach (ImportCustomerDto importCustomerDto in importCustomerDtos)
			{
				Customer customer = mapper.Map<Customer>(importCustomerDto);

				validCustomers.Add(customer);
			}

			context.Customers.AddRange(validCustomers);
			context.SaveChanges();

			return $"Successfully imported {validCustomers.Count}.";
		}

		public static string ImportSales(CarDealerContext context, string inputJson) //05-Import Sales
		{
			IMapper mapper = CreateMapper();
			IContractResolver contractResolver = ConfigureCamelCaseNaming();

			ICollection<Sale> validSales = new HashSet<Sale>();

			ImportSaleDto[] importSaleDtos = JsonConvert.DeserializeObject<ImportSaleDto[]>(inputJson, new JsonSerializerSettings()
			{
				ContractResolver = contractResolver
			});

			foreach (ImportSaleDto importSaleDto in importSaleDtos)
			{
				Sale sale = mapper.Map<Sale>(importSaleDto);

				validSales.Add(sale);
			}

			context.Sales.AddRange(validSales);
			context.SaveChanges();

			return $"Successfully imported {validSales.Count}.";
		}

		public static string GetOrderedCustomers(CarDealerContext context) //06-Export Ordered Customers
		{
			IMapper mapper = CreateMapper();

			ExportOrderedCustomersDto[] orderedCustomers = context.Customers
				.AsNoTracking()
				.OrderBy(c => c.BirthDate)
				.ThenBy(c => c.IsYoungDriver)
				.ProjectTo<ExportOrderedCustomersDto>(mapper.ConfigurationProvider)
				.ToArray();

			return JsonConvert.SerializeObject(orderedCustomers, Formatting.Indented);
		}

		public static string GetCarsFromMakeToyota(CarDealerContext context) //07-Export Cars from Make toyota
		{
			IMapper mapper = CreateMapper();

			ExportToyotaCarDto[] exportToyotas = context.Cars
				.AsNoTracking()
				.Where(c => c.Make.ToLower() == "toyota")
				.OrderBy(c => c.Model)
				.ThenByDescending(c => c.TraveledDistance)
				.ProjectTo<ExportToyotaCarDto>(mapper.ConfigurationProvider)
				.ToArray();

			return JsonConvert.SerializeObject(exportToyotas, Formatting.Indented);
		}

		public static string GetLocalSuppliers(CarDealerContext context) //08-Export Local Suppliers
		{
			IMapper mapper = CreateMapper();

			ExportLocalSupplierDto[] localSuppliers = context.Suppliers
				.AsNoTracking()
				.Where(s => s.IsImporter == false)
				.ProjectTo<ExportLocalSupplierDto>(mapper.ConfigurationProvider)
				.ToArray();

			return JsonConvert.SerializeObject(localSuppliers, Formatting.Indented);
		}

		public static string GetCarsWithTheirListOfParts(CarDealerContext context) //09-Export Cars with Their List of Parts
		{
			IMapper mapper = CreateMapper();

			ExportCarPartWrapperDto[] carInfos = context.Cars
				.AsNoTracking()
				.ProjectTo<ExportCarPartWrapperDto>(mapper.ConfigurationProvider)
				.ToArray();

			return JsonConvert.SerializeObject(carInfos, Formatting.Indented);
		}

		public static string GetTotalSalesByCustomer(CarDealerContext context) //10-Export Total Sales by Customer
		{
			IContractResolver contractResolver = ConfigureCamelCaseNaming();

			var exportCustomerSales = context.Customers
				.AsNoTracking()
				.Where(c => c.Sales.Any())
				.Select(c => new
				{
					FullName = c.Name,
					BoughtCars = c.Sales.Count(),
					SpentMoney = c.Sales.SelectMany(s => s.Car.PartsCars).Sum(pc => pc.Part.Price)

				})
				.OrderByDescending(c => c.SpentMoney)
				.ThenByDescending(c => c.BoughtCars)
				.ToArray();

			return JsonConvert.SerializeObject(exportCustomerSales, Formatting.Indented, new JsonSerializerSettings()
			{
				ContractResolver = contractResolver
			});
		}

		public static string GetSalesWithAppliedDiscount(CarDealerContext context) //11-Export Sales with Applied Discount
		{
			IContractResolver contractResolver = ConfigureCamelCaseNaming();

			var salesWithDiscount = context.Sales
				.AsNoTracking()
				.Take(10)
				.Select(s => new
				{
					car = new
					{
						Make = s.Car.Make,
						Model = s.Car.Model,
						TraveledDistance = s.Car.TraveledDistance
					},
					customerName = s.Customer.Name,
					discount = s.Discount.ToString("F2"),
					price = s.Car.PartsCars.Sum(pc => pc.Part.Price).ToString("F2"),
					priceWithDiscount = ((s.Car.PartsCars.Sum(pc => pc.Part.Price) * (1 - s.Discount / 100))).ToString("F2")
				})
				.ToArray();

			return JsonConvert.SerializeObject(salesWithDiscount, Formatting.Indented);
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