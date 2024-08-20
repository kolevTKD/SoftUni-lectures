namespace EntityRelationsTest.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string AddressText { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
