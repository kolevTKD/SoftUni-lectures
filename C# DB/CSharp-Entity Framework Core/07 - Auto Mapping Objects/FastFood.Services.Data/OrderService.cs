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
            // Create the Order entity and set basic properties
            var order = new Order
            {
                Customer = model.Customer,
                EmployeeId = model.EmployeeId,
                DateTime = model.OrderDate
            };

            // Retrieve the item based on ItemId from the input model
            var item = await this.context.Items
                .FirstOrDefaultAsync(i => i.Id == model.ItemId);

            if (item == null)
            {
                throw new Exception("Invalid ItemId.");
            }

            // Create an OrderItem entity and link it to the Order
            var orderItem = new OrderItem
            {
                ItemId = item.Id,
                Quantity = model.Quantity,
                Order = order
            };

            // Initialize the OrderItems collection and add the OrderItem
            order.OrderItems = new List<OrderItem> { orderItem };

            // Add the new order to the database
            await this.context.Orders.AddAsync(order);
            await this.context.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrderAllViewModel>> GetAllAsync()
            => await this.context.Orders
                .ProjectTo<OrderAllViewModel>(mapper.ConfigurationProvider)
                .ToArrayAsync();

        public async Task<CreateOrderViewModel> GetAllItemsEmployeesAsync()
        {
            var items = await this.context.Items
                .ProjectTo<ItemsAllViewModel>(mapper.ConfigurationProvider)
                .ToListAsync();

            var employees = await this.context.Employees
                .ProjectTo<EmployeesAllViewModel>(mapper.ConfigurationProvider)
                .ToListAsync();

            return new CreateOrderViewModel
            {
                Items = items,
                Employees = employees
            };
        }
    }
}
