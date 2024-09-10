namespace FastFood.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Common.EntityConfiguration;

    public class Item
    {
        public Item()
        {
            //Id = Guid.NewGuid().ToString();
            OrderItems = new HashSet<OrderItem>();
        }

        [Key]
        //[MaxLength(EntitiesValidation.GUID_MAX_LENGTH)]
        public int Id { get; set; }

        [MaxLength(EntitiesValidation.ITEM_NAME_MAX_LENGTH)]
        public string? Name { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; } = null!;

        public decimal Price { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}