namespace P03_SalesDatabase.Data.Models
{
    using Common;
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        public Product()
        {
            Sales = new HashSet<Sale>();
        }

        [Key]
        public int ProductId { get; set; }

        [Required]
        [MaxLength(ValidationConstants.MAX_PRODUCT_NAME_LENGTH)]
        public string Name { get; set; }

        public double Quantity { get; set; }
        
        public decimal Price { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}