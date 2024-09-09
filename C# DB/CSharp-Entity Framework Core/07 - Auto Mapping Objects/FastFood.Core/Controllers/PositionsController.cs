namespace FastFood.Web.Controllers
{
    using System.Linq;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.AspNetCore.Mvc;

    using Data;
    using FastFood.Models;
    using FastFood.Services.Data;
    using ViewModels.Positions;

    public class PositionsController : Controller
    {
        private readonly IPositionService positionsService;

        public PositionsController(IPositionService positionsService)
        {
            this.positionsService = positionsService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePositionInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            await positionsService.CreateAsync(model);

            return RedirectToAction("All", "Positions");
        }

        public async Task<IActionResult> All()
        {
            IEnumerable<PositionsAllViewModel> positions =
                await positionsService.GetAllAsync();

            return View(positions);
        }
    }
}
