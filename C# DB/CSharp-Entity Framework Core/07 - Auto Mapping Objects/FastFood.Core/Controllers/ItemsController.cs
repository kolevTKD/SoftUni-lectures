namespace FastFood.Web.Controllers
{
    using FastFood.Services.Data;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels.Items;

    public class ItemsController : Controller
    {
        private readonly IItemService itemsService;

        public ItemsController(IItemService itemsService)
        {
            this.itemsService = itemsService;
        }

        public async Task<IActionResult> Create()
        {
            IEnumerable<CreateItemViewModel> availableCategories =
                await this.itemsService.GetAllCategoriesAsync();

            return View(availableCategories);    
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateItemInputModel model)
        {
            if (!ModelState.IsValid)
            {
                RedirectToAction("Error", "Home");
            }

            await this.itemsService.CreateAsync(model);

            return RedirectToAction("All");
        }

        public async Task<IActionResult> All()
        {
            IEnumerable<ItemsAllViewModel> items = await itemsService
                .GetAllAsync();

            return View(items);
        }
    }
}
