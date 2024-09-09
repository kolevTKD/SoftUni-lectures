namespace FastFood.Web.Controllers
{
    using System;

    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;

    using Data;
    using Services.Data;
    using ViewModels.Employees;

    public class EmployeesController : Controller
    {
        private readonly IEmployeeService employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            IEnumerable<RegisterEmployeeViewModel> allPositions =
                await employeeService.GetAllPositionsAsync();

            return View(allPositions);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterEmployeeInputModel model)
        {
            if (!ModelState.IsValid)
            {
                RedirectToAction("Error", "Home");
            }

            await this.employeeService.RegisterAsync(model);

            return RedirectToAction("All");
        }

        public async Task<IActionResult> All()
        {
            IEnumerable<EmployeesAllViewModel> employees =
                await employeeService.GetAllAsync();

            return View(employees);
        }
    }
}
