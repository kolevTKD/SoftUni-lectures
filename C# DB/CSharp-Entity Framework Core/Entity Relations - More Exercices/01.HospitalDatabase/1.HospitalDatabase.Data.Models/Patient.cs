namespace P01_HospitalDatabase.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Common;

    public class Patient
    {
        public Patient()
        {
            Diagnoses = new HashSet<Diagnose>();
            Visitations = new HashSet<Visitation>();
        }

        [Key]
        public int PatientId { get; set; }

        [Required]
        [MaxLength(ValidationConstants.MAX_NAME_LENGTH)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(ValidationConstants.MAX_NAME_LENGTH)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(ValidationConstants.MAX_ADDRESS_LENGTH)]
        public string Address { get; set; }

        [Required]
        [MaxLength(ValidationConstants.MAX_EMAIL_LENGTH)]
        public string Email { get; set; }

        public bool HasInsurance { get; set; }

        public virtual ICollection<Diagnose> Diagnoses { get; set; }

        public virtual ICollection<Visitation> Visitations { get; set; }

        public virtual ICollection<PatientMedicament> Prescriptions { get; set; }
    }
}