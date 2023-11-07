namespace P02_FootballBetting.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Common;

    public class Country
    {
        public Country()
        {
            Towns = new HashSet<Town>();
        }

        [Key]
        public int CountryId { get; set; }

        [Required]
        [MaxLength(ValidationConstants.MAX_COUNTRY_NAME_LENGTH)]
        public string Name { get; set; }

        public virtual ICollection<Town> Towns { get; set; }
    }
}
