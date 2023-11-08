namespace P01_HospitalDatabase.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Common;

    public class Medicament
    {
        [Key]
        public int MedicamentId { get; set; }

        [Required]
        [MaxLength(ValidationConstants.MAX_NAME_LENGTH)]
        public string Name { get; set; }

        public virtual ICollection<PatientMedicament> Prescriptions { get; set; }
    }
}
