namespace FastFood.Web.Controllers
{
    using System;
    using AutoMapper;
    using Data;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels.Categories;

    public class CategoriesController : Controller
    {
        private readonly FastFoodContext _context;
        private readonly IMapper _mapper;

        public CategoriesController(FastFoodContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryInputModel model)
        {
            throw new NotImplementedException();
        }

        public IActionResult All()
        {
            throw new NotImplementedException();
        }
    }
}
