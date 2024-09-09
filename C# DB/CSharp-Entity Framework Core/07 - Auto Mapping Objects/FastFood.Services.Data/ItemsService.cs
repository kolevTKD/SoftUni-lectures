﻿namespace FastFood.Services.Data
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;

    using FastFood.Data;
    using Models;
    using Web.ViewModels.Items;

    public class ItemsService : IItemService
    {
        private readonly IMapper mapper;
        private readonly FastFoodContext context;

        public ItemsService(IMapper mapper, FastFoodContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }
        public async Task CreateAsync(CreateItemInputModel model)
        {
            Item item = this.mapper.Map<Item>(model);

            await this.context.Items.AddAsync(item);
            await this.context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ItemsAllViewModel>> GetAllAsync()
            => await context.Items
                .ProjectTo<ItemsAllViewModel>(mapper.ConfigurationProvider)
                .ToArrayAsync();

        public async Task<IEnumerable<CreateItemViewModel>> GetAllCategoriesAsync()
            => await context.Categories
                .ProjectTo<CreateItemViewModel>(mapper.ConfigurationProvider)
                .ToArrayAsync();
    }
}
