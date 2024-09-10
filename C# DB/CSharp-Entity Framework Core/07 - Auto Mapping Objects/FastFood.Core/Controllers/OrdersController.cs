namespace FastFood.Web.Controllers
{
    using System;
    using System.Linq;
    using AutoMapper;
    using Data;
    using FastFood.Services.Data;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels.Orders;

    public class OrdersController : Controller
    {
        private readonly IOrderService orderService;

        public OrdersController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            CreateOrderViewModel employeesItems =
                await this.orderService.GetAllItemsEmployeesAsync();

            return View(employeesItems);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderInputModel model)
        {
            if (!ModelState.IsValid)
            {
                RedirectToAction("Error", "Home");
            }

            if (model.OrderDate == default)
            {
                model.OrderDate = DateTime.Now;
            }

            await this.orderService.CreateAsync(model);

            return RedirectToAction("All", "Orders");
        }

        public async Task<IActionResult> All()
        {
            IEnumerable<OrderAllViewModel> orders =
                await this.orderService.GetAllAsync();

            return View(orders);
        }
    }
}
