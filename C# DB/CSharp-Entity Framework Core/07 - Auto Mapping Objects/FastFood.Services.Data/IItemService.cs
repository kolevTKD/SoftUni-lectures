namespace FastFood.Services.Data
{
    using FastFood.Web.ViewModels.Items;

    public interface IItemService
    {
        Task<IEnumerable<CreateItemViewModel>> GetAllCategoriesAsync();

        Task CreateAsync(CreateItemInputModel model);

        Task<IEnumerable<ItemsAllViewModel>> GetAllAsync();
    }
}
