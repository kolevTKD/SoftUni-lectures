namespace EntityRelationsTest.Models
{
    public class Project
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}
