namespace CarDealer
{
	using System.Xml.Serialization;
	using System.Xml;

	using AutoMapper;

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
				string inputXml = ReadXml(path);

				Console.WriteLine(ImportSales(context, inputXml));
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