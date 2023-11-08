namespace P01_HospitalDatabase.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Common;

    public class Doctor
    {
        public Doctor()
        {
            Visitations = new HashSet<Visitation>();
        }

        [Key]
        public int DoctorId { get; set; }

        [Required]
        [MaxLength(ValidationConstants.MAX_DOC_NAME_LENGTH)]
        public string Name { get; set; }

        [Required]
        [MaxLength(ValidationConstants.MAX_DOC_SPECIALTY_NAME_LENGTH)]
        public string Specialty { get; set; }

        public virtual ICollection<Visitation> Visitations { get; set; }
    }
}
