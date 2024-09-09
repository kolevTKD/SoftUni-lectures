namespace FastFood.Web.Controllers
{
    using System;

    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;

    using Data;
    using Services.Data;
    using ViewModels.Categories;

    public class CategoriesController : Controller
    {
        private readonly ICategoryService categoriesService;

        public CategoriesController(ICategoryService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryInputModel model)
        {
            if (!ModelState.IsValid)
            {
                RedirectToAction("Error", "Home");
            }

            await categoriesService.CreateAsync(model);

            return RedirectToAction("All");
        }

        public async Task<IActionResult> All()
        {
            IEnumerable<CategoryAllViewModel> categories =
                await categoriesService.GetAllAsync();

            return View(categories);
        }
    }
}
