namespace FastFood.Web.ViewModels.Orders
{
    using System.Collections.Generic;

    using Employees;
    using Items;

    public class CreateOrderViewModel
    {
        public List<ItemsAllViewModel> Items { get; set; } = null!;

        public List<EmployeesAllViewModel> Employees { get; set; } = null!;
    }
}
