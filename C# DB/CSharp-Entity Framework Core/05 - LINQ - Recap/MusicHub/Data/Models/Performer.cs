namespace MusicHub.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Performer
    {
        public Performer()
        {
            PerformerSongs = new HashSet<SongPerformer>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.PERFORMER_FIRST_LAST_NAME_MAX_LENGTH)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(ValidationConstants.PERFORMER_FIRST_LAST_NAME_MAX_LENGTH)]
        public string LastName { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public decimal NetWorth { get; set; }

        public virtual ICollection<SongPerformer> PerformerSongs { get; set; }
    }
}
