namespace P01_StudentSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Common;

    public class Student
    {
        public Student()
        {
            StudentsCourses = new HashSet<StudentCourse>();
            Homeworks = new HashSet<Homework>();
        }

        [Key]
        public int StudentId { get; set; }

        [MaxLength(ValidationConstants.STUDENT_NAME_MAX_LENGTH)]
        [Required]
        public string Name { get; set; }

        [MaxLength(ValidationConstants.PHONE_EXACT_LENGTH)]
        //[MinLength(ValidationConstants.PHONE_EXACT_LENGTH)]
        public string? PhoneNumber { get; set; }

        [Required]
        public DateTime RegisteredOn { get; set; }
        public DateTime? Birthday { get; set; }
        public virtual ICollection<StudentCourse> StudentsCourses { get; set; }
        public virtual ICollection<Homework> Homeworks { get; set; }
    }
}
