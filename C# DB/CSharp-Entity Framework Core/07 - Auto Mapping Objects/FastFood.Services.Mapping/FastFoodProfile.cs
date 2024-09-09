﻿namespace FastFood.Services.Mapping
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
            //Positions
            CreateMap<CreatePositionInputModel, Position>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.PositionName));

            CreateMap<Position, PositionsAllViewModel>();

            //Categories
            CreateMap<CreateCategoryInputModel, Category>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.CategoryName));

            CreateMap<Category, CategoryAllViewModel>();

            //Items
            CreateMap<Item, CreateItemViewModel>();

            CreateMap<CreateItemInputModel, Item>();

            CreateMap<Item, ItemsAllViewModel>()
                .ForMember(d => d.Category, opt => opt.MapFrom(s => s.Category.Name));

            CreateMap<Category, CreateItemViewModel>()
                .ForMember(d => d.CategoryId, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.CategoryName, opt => opt.MapFrom(s => s.Name));

            //Orders

            // Mapping from order entity to order list view model
            CreateMap<Order, OrderAllViewModel>()
                .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer))
                .ForMember(dest => dest.Employee, opt => opt.MapFrom(src => src.Employee.Name))
                .ForMember(dest => dest.DateTime, opt => opt.MapFrom(src => src.DateTime.ToString("yyyy-MM-dd")));

            // Mapping from order entity to create order view model
            CreateMap<Order, CreateOrderViewModel>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.OrderItems!.Select(oi => new ItemsAllViewModel
                {
                    Name = oi.Item.Name, // Ensure correct mapping from Item entity
                    Price = oi.Item.Price,
                    Category = oi.Item.Category.Name
                }).ToList()))
                .ForMember(dest => dest.Employees, opt => opt.Ignore());




            CreateMap<Order, CreateOrderViewModel>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.OrderItems.Select(oi => new ItemsAllViewModel { Id = oi.Item.Id, Name = oi.Item.Name }).ToList()))
                .ForMember(dest => dest.Employees, opt => opt.MapFrom(src => new List<EmployeesAllViewModel> { new EmployeesAllViewModel { Name = src.Employee.Name, Age = src.Employee.Age, Address = src.Employee.Address, Position = src.Employee.Position.Name } }));

            CreateMap<CreateOrderInputModel, Order>()
                .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.EmployeeId))
                .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => new List<OrderItem>
                {
                    new OrderItem
                    {
                        ItemId = src.ItemId.ToString(), // Make sure you convert to the correct type if necessary
                        Quantity = src.Quantity
                    }
                }))
                .ForMember(dest => dest.DateTime, opt => opt.MapFrom(src => DateTime.UtcNow)); // Or any specific date handling


            CreateMap<CreateOrderInputModel, Order>()
                .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.EmployeeId))
                .ForMember(dest => dest.OrderItems, opt => opt.Ignore()); // Handling OrderItems separately



            CreateMap<Order, OrderAllViewModel>();

            CreateMap<CreateOrderInputModel, Order>()
                .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.EmployeeId)); // Ensure correct mapping

            //Employees
            CreateMap<Employee, RegisterEmployeeViewModel>();

            CreateMap<Employee, EmployeesAllViewModel>()
                .ForMember(d => d.Position, opt => opt.MapFrom(s => s.Position.Name));

            CreateMap<Position, RegisterEmployeeViewModel>()
                .ForMember(d => d.PositionId, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.PositionName, opt => opt.MapFrom(s => s.Name));

            CreateMap<RegisterEmployeeInputModel, Employee>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.PositionName));

            CreateMap<Employee, EmployeesAllViewModel>();
            CreateMap<Position, RegisterEmployeeViewModel>();
        }
    }
}
