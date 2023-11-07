namespace P02_FootballBetting.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Common;
    public class Position
    {
        public Position()
        {
            Players = new HashSet<Player>();
        }

        [Key]
        public int PositionId { get; set; }

        [Required]
        [MaxLength(ValidationConstants.MAX_POSITION_NAME_LENGTH)]
        public string Name { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
}
