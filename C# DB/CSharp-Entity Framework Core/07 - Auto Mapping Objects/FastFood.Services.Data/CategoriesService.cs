namespace FastFood.Services.Data
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;

    using FastFood.Data;
    using Models;
    using Web.ViewModels.Categories;

    public class CategoriesService : ICategoryService
    {
        private readonly IMapper mapper;
        private readonly FastFoodContext context;

        public CategoriesService(IMapper mapper, FastFoodContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task CreateAsync(CreateCategoryInputModel inputModel)
        {
            Category category = this.mapper.Map<Category>(inputModel);

            await this.context.Categories.AddAsync(category);
            await this.context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CategoryAllViewModel>> GetAllAsync()
            => await this.context.Categories
                .ProjectTo<CategoryAllViewModel>(mapper.ConfigurationProvider)
                .ToArrayAsync();
    }
}
