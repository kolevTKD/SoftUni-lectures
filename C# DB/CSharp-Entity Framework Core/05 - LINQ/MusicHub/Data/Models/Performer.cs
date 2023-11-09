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

        [MaxLength(ValidationConstants.MAX_PERFORMER_FIRSTNAME_LENGTH)]
        public string FirstName { get; set; }

        [MaxLength(ValidationConstants.MAX_PERFORMER_LASTNAME_LENGTH)]
        public string LastName { get; set; }

        public int Age { get; set; }

        public decimal NetWorth { get; set; }

        public virtual ICollection<SongPerformer> PerformerSongs { get; set; }
    }
}
