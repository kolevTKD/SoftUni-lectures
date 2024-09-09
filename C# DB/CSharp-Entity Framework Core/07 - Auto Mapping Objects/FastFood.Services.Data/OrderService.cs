namespace FastFood.Services.Data
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;

    using FastFood.Data;
    using Models;
    using Web.ViewModels.Orders;
    using Web.ViewModels.Items;
    using Web.ViewModels.Employees;

    public class OrderService : IOrderService
    {
        private readonly IMapper mapper;
        private readonly FastFoodContext context;

        public OrderService(IMapper mapper, FastFoodContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task CreateAsync(CreateOrderInputModel model)
        {
            Order order = this.mapper.Map<Order>(model);

            await this.context.Orders.AddAsync(order);
            await this.context.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrderAllViewModel>> GetAllAsync()
                => await this.context.Orders
                    .ProjectTo<OrderAllViewModel>(mapper.ConfigurationProvider)
                    .ToArrayAsync();

        public async Task<CreateOrderViewModel> GetAllItemsEmployeesAsync()
        {
            // Project Items and Employees to their ViewModel types
            var items = await this.context.Items
                .ProjectTo<ItemsAllViewModel>(mapper.ConfigurationProvider)
                .ToListAsync();

            var employees = await this.context.Employees
                .ProjectTo<EmployeesAllViewModel>(mapper.ConfigurationProvider)
                .ToListAsync();

            var createOrderViewModel = new CreateOrderViewModel
            {
                Items = items, // Already in the correct format
                Employees = employees // Already in the correct format
            };

            return createOrderViewModel;
        }

    }
}
