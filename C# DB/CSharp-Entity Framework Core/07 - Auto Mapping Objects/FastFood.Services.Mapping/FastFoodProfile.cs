namespace FastFood.Services.Mapping
{
    using AutoMapper;

    using Models;
    using Web.ViewModels.Items;
    using Web.ViewModels.Categories;
    using Web.ViewModels.Positions;
    using Web.ViewModels.Orders;
    using Web.ViewModels.Employees;

    public class FastFoodProfile : Profile
    {
        public FastFoodProfile()
        {
            // Positions
            CreateMap<CreatePositionInputModel, Position>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.PositionName));

            CreateMap<Position, PositionsAllViewModel>();

            // Categories
            CreateMap<CreateCategoryInputModel, Category>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.CategoryName));

            CreateMap<Category, CategoryAllViewModel>();

            // Items
            CreateMap<Item, ItemsAllViewModel>()
                .ForMember(d => d.Category, opt => opt.MapFrom(s => s.Category.Name));

            CreateMap<CreateItemInputModel, Item>();

            CreateMap<Category, CreateItemViewModel>()
                .ForMember(d => d.CategoryId, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.CategoryName, opt => opt.MapFrom(s => s.Name));

            // Orders
            CreateMap<CreateOrderInputModel, Order>()
                .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.EmployeeId))
                .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => new List<OrderItem>
                {
                new OrderItem
                {
                    ItemId = src.ItemId, // Ensure proper conversion if needed
                    Quantity = src.Quantity
                }
                }))
                .ForMember(dest => dest.DateTime, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<Order, CreateOrderViewModel>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.OrderItems.Select(oi => new ItemsAllViewModel
                {
                    Id = oi.Item.Id,
                    Name = oi.Item.Name,
                    Price = oi.Item.Price,
                    Category = oi.Item.Category.Name
                }).ToList()))
                .ForMember(dest => dest.Employees, opt => opt.MapFrom(src => new List<EmployeesAllViewModel> { new EmployeesAllViewModel
            {
                Name = src.Employee.Name,
                Age = src.Employee.Age,
                Address = src.Employee.Address,
                Position = src.Employee.Position.Name
            }}));

            CreateMap<Order, OrderAllViewModel>()
                .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer))
                .ForMember(dest => dest.Employee, opt => opt.MapFrom(src => src.Employee.Name))
                .ForMember(dest => dest.DateTime, opt => opt.MapFrom(src => src.DateTime.ToString("yyyy-MM-dd")));

            // Employees
            CreateMap<Employee, EmployeesAllViewModel>()
                .ForMember(d => d.Position, opt => opt.MapFrom(s => s.Position.Name));

            CreateMap<RegisterEmployeeInputModel, Employee>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.PositionId, opt => opt.MapFrom(src => src.PositionId));

            CreateMap<Position, RegisterEmployeeViewModel>()
                .ForMember(d => d.PositionId, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.PositionName, opt => opt.MapFrom(s => s.Name));
        }
    }
}
