namespace FastFood.Web.ViewModels.Orders
{
    using System.ComponentModel.DataAnnotations;

    public class CreateOrderInputModel
    {
        public string Customer { get; set; } = null!;

        public string ItemId { get; set; }

        public string EmployeeId { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
