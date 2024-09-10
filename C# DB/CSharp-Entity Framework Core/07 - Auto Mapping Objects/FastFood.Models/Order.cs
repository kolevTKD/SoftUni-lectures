namespace FastFood.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Enums;
    using Common.EntityConfiguration;

    public class Order
    {
        public Order()
        {
            //Id = Guid.NewGuid().ToString();
            OrderItems = new HashSet<OrderItem>();
        }

        [Key]
        //[MaxLength(EntitiesValidation.GUID_MAX_LENGTH)]
        public int Id { get; set; }

        public string Customer { get; set; } = null!;

        public DateTime DateTime { get; set; }

        public OrderType Type { get; set; }

        [NotMapped]
        public decimal TotalPrice { get; set; }

        [ForeignKey(nameof(Employee))]
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; } = null!;

        public virtual ICollection<OrderItem>? OrderItems { get; set; }
    }
}