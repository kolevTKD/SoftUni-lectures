namespace EntityRelationsTest.Models
{
    public class Student
    {
        public Student()
        {
            Projects = new HashSet<Project>();
        }

        public int Id { get; set; }
        public string FacultyNo { get; set; }
        public string Name { get; set; }
        public int ProjectId { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}
