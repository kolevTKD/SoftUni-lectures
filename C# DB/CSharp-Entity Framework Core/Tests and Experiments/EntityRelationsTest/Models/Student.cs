using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityRelationsTest.Models
{
    public class Student
    {
        public Student()
        {
            Projects = new HashSet<Project>();
            StudentLecturer = new HashSet<StudentLecturer>();
        }
        //[Key]
        public int Id { get; set; }
        public string FacultyNo { get; set; }
        public string Name { get; set; }
        public int ProjectId { get; set; }

        //[ForeignKey(nameof(ProjectId))]
        public virtual ICollection<Project> Projects { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }

        public int LecturerId { get; set; }
        public virtual ICollection<StudentLecturer> StudentLecturer { get; set; }
    }
}
