namespace EntityRelationsTest.Models
{
    public class Lecturer
    {
        public Lecturer()
        {
            StudentLecturer = new HashSet<StudentLecturer>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public int StudentId { get; set; }
        public virtual ICollection<StudentLecturer> StudentLecturer { get; set; }
    }
}
