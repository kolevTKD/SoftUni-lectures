namespace CarDealer
{
	using System.Text;
	using System.Xml.Serialization;
	using System.Xml;

	using AutoMapper;
	using AutoMapper.QueryableExtensions;
	using Microsoft.EntityFrameworkCore;

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
				//string inputXml = ReadXml(path);

				//Console.WriteLine(ImportSales(context, inputXml));

				WriteXml(GetSalesWithAppliedDiscount(context));
			}
		}

		public static string ImportSuppliers(CarDealerContext context, string inputXml) //09-Import Suppliers
		{
			IMapper mapper = CreateMapper();

			XmlRootAttribute root = new XmlRootAttribute("Suppliers");
			XmlSerializer serializer = new XmlSerializer(typeof(ImportSupplierDto[]), root);

			ICollection<Supplier> validSuppliers = new HashSet<Supplier>();

			using (StringReader reader = new StringReader(inputXml))
			{
				ImportSupplierDto[] importSupplierDtos = (ImportSupplierDto[])serializer.Deserialize(reader);

				foreach (ImportSupplierDto supplierDto in importSupplierDtos)
				{
					if (String.IsNullOrEmpty(supplierDto.Name))
					{
						continue;
					}

					Supplier supplier = mapper.Map<Supplier>(supplierDto);
					validSuppliers.Add(supplier);
				}

				context.Suppliers.AddRange(validSuppliers);
				context.SaveChanges();
			}

			return $"Successfully imported {validSuppliers.Count}";
		}

		public static string ImportParts(CarDealerContext context, string inputXml) //10-Import Parts
		{
			IMapper mapper = CreateMapper();

			XmlRootAttribute root = new XmlRootAttribute("Parts");
			XmlSerializer serializer = new XmlSerializer(typeof(ImportPartDto[]), root);

			ICollection<Part> validParts = new HashSet<Part>();

			using (StringReader reader = new StringReader(inputXml))
			{
				ImportPartDto[] importPartDtos = (ImportPartDto[])serializer.Deserialize(reader);

				foreach (ImportPartDto importPartDto in importPartDtos)
				{
					if (String.IsNullOrEmpty(importPartDto.Name))
					{
						continue;
					}

					if (!importPartDto.SupplierId.HasValue ||
						!context.Suppliers.Any(s => s.Id == importPartDto.SupplierId))
					{
						continue;
					}

					Part part = mapper.Map<Part>(importPartDto);
					validParts.Add(part);
				}

				context.Parts.AddRange(validParts);
				context.SaveChanges();
			}

			return $"Successfully imported {validParts.Count}";
		}

		public static string ImportCars(CarDealerContext context, string inputXml) //11-Import Cars
		{
			IMapper mapper = CreateMapper();

			XmlRootAttribute root = new XmlRootAttribute("Cars");
			XmlSerializer serializer = new XmlSerializer(typeof(ImportCarDto[]), root);

			ICollection<Car> validCars = new HashSet<Car>();

			using (StringReader reader = new StringReader(inputXml))
			{
				ImportCarDto[] importCarDtos = (ImportCarDto[])serializer.Deserialize(reader);

				foreach (ImportCarDto importCarDto in importCarDtos)
				{
					if (String.IsNullOrEmpty(importCarDto.Make) ||
						String.IsNullOrEmpty(importCarDto.Model))
					{
						continue;
					}

					Car car = mapper.Map<Car>(importCarDto);

					foreach (PartIdDto carPartDto in importCarDto.Parts.DistinctBy(cp => cp.Id))
					{
						if (!context.Parts.Any(p => p.Id == carPartDto.Id))
						{
							continue;
						}

						PartCar carPart = new PartCar()
						{
							PartId = carPartDto.Id
						};

						car.PartsCars.Add(carPart);
					}

					validCars.Add(car);
				}

				context.Cars.AddRange(validCars);
				context.SaveChanges();
			}

			return $"Successfully imported {validCars.Count}";
		}

		public static string ImportCustomers(CarDealerContext context, string inputXml) //12-Import Customers
		{
			IMapper mapper = CreateMapper();

			XmlRootAttribute root = new XmlRootAttribute("Customers");
			XmlSerializer serializer = new XmlSerializer(typeof(ImportCustomerDto[]), root);

			ICollection<Customer> validCustomers = new HashSet<Customer>();

			using (StringReader reader = new StringReader(inputXml))
			{
				ImportCustomerDto[] importCustomerDtos = (ImportCustomerDto[])serializer.Deserialize(reader);

				foreach (ImportCustomerDto importCustomerDto in importCustomerDtos)
				{
					if (String.IsNullOrEmpty(importCustomerDto.Name))
					{
						continue;
					}

					Customer customer = mapper.Map<Customer>(importCustomerDto);
					validCustomers.Add(customer);
				}

				context.Customers.AddRange(validCustomers);
				context.SaveChanges();
			}

			return $"Successfully imported {validCustomers.Count}";
		}

		public static string ImportSales(CarDealerContext context, string inputXml) //13-Import Sales
		{
			IMapper mapper = CreateMapper();

			XmlRootAttribute root = new XmlRootAttribute("Sales");
			XmlSerializer serializer = new XmlSerializer(typeof(ImportSaleDto[]), root);

			ICollection<Sale> validSales = new HashSet<Sale>();

			using (StringReader reader = new StringReader(inputXml))
			{
				ImportSaleDto[] importSaleDtos = (ImportSaleDto[])serializer.Deserialize(reader);

				foreach (ImportSaleDto importSaleDto in importSaleDtos)
				{
					if (!context.Cars.Any(s => s.Id == importSaleDto.CarId))
					{
						continue;
					}

					Sale sale = mapper.Map<Sale>(importSaleDto);
					validSales.Add(sale);
				}

				context.Sales.AddRange(validSales);
				context.SaveChanges();
			}

			return $"Successfully imported {validSales.Count}";
		}

		public static string GetCarsWithDistance(CarDealerContext context) //14-Export Cars With Distance
		{
			IMapper mapper = CreateMapper();

			ExportCarWithDistanceDto[] exportCarDtos = context.Cars
				.AsNoTracking()
				.Where(c => c.TraveledDistance > 2000000)
				.OrderBy(c => c.Make)
				.ThenBy(c => c.Model)
				.Take(10)
				.ProjectTo<ExportCarWithDistanceDto>(mapper.ConfigurationProvider)
				.ToArray();

			XmlRootAttribute root = new XmlRootAttribute("cars");
			XmlSerializer serializer = new XmlSerializer(typeof(ExportCarWithDistanceDto[]), root);

			StringBuilder sb = new StringBuilder();
			using (StringWriter writer = new StringWriter(sb))
			{
				serializer.Serialize(writer, exportCarDtos, ConfigureNamespaces());
			}

			return sb.ToString().TrimEnd();
		}

		public static string GetCarsFromMakeBmw(CarDealerContext context) //15-Export Cars from Make BMW
		{
			IMapper mapper = CreateMapper();

			ExportCarFromMakeBmwDto[] exportBmws = context.Cars
				.AsNoTracking()
				.Where(c => c.Make == "BMW")
				.OrderBy(c => c.Model)
				.ThenByDescending(c => c.TraveledDistance)
				.ProjectTo<ExportCarFromMakeBmwDto>(mapper.ConfigurationProvider)
				.ToArray();

			XmlRootAttribute root = new XmlRootAttribute("cars");
			XmlSerializer serializer = new XmlSerializer(typeof(ExportCarFromMakeBmwDto[]), root);

			StringBuilder sb = new StringBuilder();
			using (StringWriter writer = new StringWriter(sb))
			{
				serializer.Serialize(writer, exportBmws, ConfigureNamespaces());
			}

			return sb.ToString().TrimEnd();
		}

		public static string GetLocalSuppliers(CarDealerContext context) //16-Export Local Suppliers
		{
			IMapper mapper = CreateMapper();

			ExportLocalSupplierDto[] localSupplierDtos = context.Suppliers
				.AsNoTracking()
				.Where(s => s.IsImporter == false)
				.ProjectTo<ExportLocalSupplierDto>(mapper.ConfigurationProvider)
				.ToArray();

			XmlRootAttribute root = new XmlRootAttribute("suppliers");
			XmlSerializer serializer = new XmlSerializer(typeof(ExportLocalSupplierDto[]), root);

			StringBuilder sb = new StringBuilder();
			using (StringWriter writer = new StringWriter(sb))
			{
				serializer.Serialize(writer, localSupplierDtos, ConfigureNamespaces());
			}

			return sb.ToString().TrimEnd();
		}

		public static string GetCarsWithTheirListOfParts(CarDealerContext context) //17-Export Cars with Their List of Parts
		{
			IMapper mapper = CreateMapper();

			ExportCarPartDto[] exportCarPartDtos = context.Cars
				.AsNoTracking()
				.OrderByDescending(c => c.TraveledDistance)
				.ThenBy(c => c.Model)
				.Take(5)
				.ProjectTo<ExportCarPartDto>(mapper.ConfigurationProvider)
				.ToArray();

			XmlRootAttribute root = new XmlRootAttribute("cars");
			XmlSerializer serializer = new XmlSerializer(typeof(ExportCarPartDto[]), root);

			StringBuilder sb = new StringBuilder();
			using (StringWriter writer = new StringWriter(sb))
			{
				serializer.Serialize(writer, exportCarPartDtos, ConfigureNamespaces());
			}

			return sb.ToString().TrimEnd();
		}

		public static string GetTotalSalesByCustomer(CarDealerContext context) //18-Export Total Sales by Customer
		{
			var customers = context.Customers
			.Where(c => c.Sales.Any())
			.Select(c => new
			{
				fullName = c.Name,
				boughtCars = c.Sales.Count(),
				moneyCars = c.IsYoungDriver
				? c.Sales.SelectMany(s => s.Car.PartsCars.Select(p => Math.Round(p.Part.Price * 0.95m, 2)))
				: c.Sales.SelectMany(s => s.Car.PartsCars.Select(p => Math.Round(p.Part.Price, 2)))
			})
			.ToArray();

			ExportCustomerSaleDto[] customerSaleDtos = customers
				.Select(o => new ExportCustomerSaleDto
				{
					Name = o.fullName,
					Sales = o.boughtCars,
					SpentMoney = o.moneyCars.Sum()
				})
				.OrderByDescending(o => o.SpentMoney)
				.ToArray();

			XmlRootAttribute root = new XmlRootAttribute("customers");
			XmlSerializer serializer = new XmlSerializer(typeof(ExportCustomerSaleDto[]), root);

			StringBuilder sb = new StringBuilder();
			using (StringWriter writer = new StringWriter(sb))
			{
				serializer.Serialize(writer, customerSaleDtos, ConfigureNamespaces());
			}

			return sb.ToString().TrimEnd();
		}

		public static string GetSalesWithAppliedDiscount(CarDealerContext context) //19-Export Sales with Applied Discount
		{
			IMapper mapper = CreateMapper();

			ExportSaleWithDiscountDto[] exportSaleDtos = context.Sales
				.AsNoTracking()
				.ProjectTo<ExportSaleWithDiscountDto>(mapper.ConfigurationProvider)
				.ToArray();

			XmlRootAttribute root = new XmlRootAttribute("sales");
			XmlSerializer serializer = new XmlSerializer(typeof(ExportSaleWithDiscountDto[]), root);

			StringBuilder sb = new StringBuilder();
			using (StringWriter writer = new StringWriter(sb))
			{
				serializer.Serialize(writer, exportSaleDtos, ConfigureNamespaces());
			}

			return sb.ToString().TrimEnd();
		}

		private static IMapper CreateMapper()
		{
			return new Mapper(new MapperConfiguration(cfg =>
			{
				cfg.AddProfile<CarDealerProfile>();
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