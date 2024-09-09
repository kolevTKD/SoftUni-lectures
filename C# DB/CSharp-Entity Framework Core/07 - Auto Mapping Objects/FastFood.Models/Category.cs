﻿namespace FastFood.Models
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

        [MaxLength(EntitiesValidation.CATEGORY_NAME_MAX_LENGTH)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Item> Items { get; set; }
    }
}
