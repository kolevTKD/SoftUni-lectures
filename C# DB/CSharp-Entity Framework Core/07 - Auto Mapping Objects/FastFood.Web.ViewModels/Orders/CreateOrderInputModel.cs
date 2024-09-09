namespace FastFood.Web.ViewModels.Orders
{
    using System.ComponentModel.DataAnnotations;

    public class CreateOrderInputModel
    {
        public string Customer { get; set; } = null!;

        public int ItemId { get; set; }

        public int EmployeeId { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
