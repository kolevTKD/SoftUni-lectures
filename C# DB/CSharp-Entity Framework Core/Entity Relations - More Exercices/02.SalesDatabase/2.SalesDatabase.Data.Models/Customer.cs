namespace P03_SalesDatabase.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Common;

    public class Customer
    {
        public Customer()
        {
            Sales = new HashSet<Sale>();
        }

        [Key]
        public int CustomerId { get; set; }

        [Required]
        [MaxLength(ValidationConstants.MAX_CUSTOMER_NAME_LENGTH)]
        public string Name { get; set; }

        [MaxLength(ValidationConstants.MAX_CUSTOMER_EMAIL_LENGTH)]
        public string Email { get; set; }

        [MaxLength(ValidationConstants.MAX_CUSTOMER_CREDIT_CARD_NO_LENGTH)]
        public string CreditCardNumber { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
