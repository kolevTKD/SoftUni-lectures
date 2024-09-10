namespace FastFood.Web.ViewModels.Items
{
    public class ItemsAllViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public string Category { get; set; } = null!;
    }
}
