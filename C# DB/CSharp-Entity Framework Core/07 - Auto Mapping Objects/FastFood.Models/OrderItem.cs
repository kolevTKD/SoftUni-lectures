namespace FastFood.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class OrderItem
    {
        [ForeignKey(nameof(Order))]
        public string OrderId { get; set; } = null!;

        public virtual Order Order { get; set; } = null!;

        [ForeignKey(nameof(Item))]
        public string ItemId { get; set; } = null!;

        public virtual Item Item { get; set; } = null!;

        public int Quantity { get; set; }
    }
}