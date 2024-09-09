namespace FastFood.Services.Data
{
    using Web.ViewModels.Orders;

    public interface IOrderService
    {
        Task<CreateOrderViewModel> GetAllItemsEmployeesAsync();

        Task CreateAsync(CreateOrderInputModel model);

        Task<IEnumerable<OrderAllViewModel>> GetAllAsync();
    }
}
