namespace FastFood.Services.Data
{
    using FastFood.Web.ViewModels.Categories;
    using FastFood.Web.ViewModels.Positions;

    public interface IPositionService
    {
        Task CreateAsync(CreatePositionInputModel inputModel);

        Task<IEnumerable<PositionsAllViewModel>> GetAllAsync();
    }
}
