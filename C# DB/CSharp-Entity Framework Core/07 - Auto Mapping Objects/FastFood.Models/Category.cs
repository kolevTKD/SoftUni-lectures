namespace FastFood.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Common.EntityConfiguration;

    public class Category
    {
        public Category()
        {
            Items = new HashSet<Item>();
        }

        [Key]
        public int Id { get; set; }

        [StringLength(EntitiesValidation.CATEGORY_NAME_MAX_LENGTH, MinimumLength = 3)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Item> Items { get; set; }
    }
}
