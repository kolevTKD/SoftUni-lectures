namespace EntityRelationsDemo.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Town? CurrentResidence { get; set; }
        public Town? PlaceOfBirth { get; set; }
    }
}
