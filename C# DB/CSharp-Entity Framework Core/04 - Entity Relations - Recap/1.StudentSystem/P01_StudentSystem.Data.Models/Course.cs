namespace P01_StudentSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common;

    public class Course
    {
        public Course()
        {
            StudentsCourses = new HashSet<StudentCourse>();
            Resources = new HashSet<Resource>();
            Homeworks = new HashSet<Homework>();
        }

        [Key]
        public int CourseId { get; set; }

        [MaxLength(ValidationConstants.COURSE_NAME_MAX_LENGTH)]
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public decimal Price { get; set; }
        public virtual ICollection<StudentCourse> StudentsCourses { get; set; }
        public virtual ICollection<Resource> Resources { get; set; }
        public virtual ICollection<Homework> Homeworks { get; set; }
    }
}
