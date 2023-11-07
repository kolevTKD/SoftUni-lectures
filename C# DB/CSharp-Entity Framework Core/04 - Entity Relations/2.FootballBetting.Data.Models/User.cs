namespace P02_FootballBetting.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Common;

    public class User
    {
        public User()
        {
            Bets = new HashSet<Bet>();
        }

        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(ValidationConstants.MAX_USER_USERNAME_LENGTH)]
        public string Username { get; set; }

        [Required]
        [MaxLength(ValidationConstants.MAX_USER_PASSWORD_LENGTH)]
        public string Password { get; set; }

        [Required]
        [MaxLength(ValidationConstants.MAX_USER_EMAIL_LENGTH)]
        public string Email { get; set; }

        [Required]
        [MaxLength(ValidationConstants.MAX_USER_NAME_LENGTH)]
        public string Name { get; set; }

        public decimal Balance { get; set; }

        public virtual ICollection<Bet> Bets { get; set; }
    }
}
