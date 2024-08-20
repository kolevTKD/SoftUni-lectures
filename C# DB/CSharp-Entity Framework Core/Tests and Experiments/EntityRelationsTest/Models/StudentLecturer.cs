namespace EntityRelationsTest.Models
{
    public class StudentLecturer
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int LecturerId { get; set; }
        public Lecturer Lecturer { get; set; }

    }
}
