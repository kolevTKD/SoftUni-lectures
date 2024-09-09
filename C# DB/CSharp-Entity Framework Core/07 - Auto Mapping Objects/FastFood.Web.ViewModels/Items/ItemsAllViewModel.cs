namespace FastFood.Web.ViewModels.Items
{
    public class ItemsAllViewModel
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public string Category { get; set; } = null!;
    }
}
