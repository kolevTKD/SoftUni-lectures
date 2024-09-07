namespace FastFood.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Common.EntityConfiguration;

    public class Position
    {
        public Position()
        {
            Employees = new HashSet<Employee>();
        }

        [Key]
        [MaxLength(EntitiesValidation.GUID_MAX_LENGTH)]
        public int Id { get; set; }

        [MaxLength(EntitiesValidation.POSITION_NAME_MAX_LENGTH)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Employee> Employees { get; set; }
    }
}