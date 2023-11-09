namespace P03_SalesDatabase.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Common;

    public class Store
    {
        public Store()
        {
            Sales = new HashSet<Sale>();
        }

        [Key]
        public int StoreId { get; set; }

        [Required]
        [MaxLength(ValidationConstants.MAX_STORE_NAME_LENGTH)]
        public string Name { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
