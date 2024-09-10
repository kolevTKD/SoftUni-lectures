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
            try
            {
                // Ensure employee exists and is valid
                var employee = await this.context.Employees.FindAsync(model.EmployeeId);
                if (employee == null)
                {
                    throw new Exception("Invalid EmployeeId.");
                }

                // Create new order
                var order = this.mapper.Map<Order>(model);
                order.Employee = employee; // Associate the employee object

                // Handling OrderItems
                var orderItem = new OrderItem
                {
                    ItemId = model.ItemId, // Ensure ItemId matches the model and database
                    Quantity = model.Quantity
                };

                // Initialize OrderItems list if null
                order.OrderItems = new List<OrderItem> { orderItem };

                // Save the new order to the database
                await this.context.Orders.AddAsync(order);
                await this.context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // Log the detailed exception message
                var innerException = ex.InnerException?.Message;
                throw new Exception($"An error occurred: {innerException}", ex);
            }
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
