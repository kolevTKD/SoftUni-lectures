namespace FastFood.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Common.EntityConfiguration;

    public class Employee
    {
        public Employee()
        {
            Id = Guid.NewGuid().ToString();
            Orders = new HashSet<Order>();
        }

        [Key]
        [MaxLength(EntitiesValidation.GUID_MAX_LENGTH)]
        public string Id { get; set; }

        public string Name { get; set; } = null!;

        public int Age { get; set; }

        public string Address { get; set; } = null!;

        [ForeignKey(nameof(Position))]
        public int PositionId { get; set; }

        public virtual Position Position { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}