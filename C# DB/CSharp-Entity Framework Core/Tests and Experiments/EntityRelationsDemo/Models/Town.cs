using System.ComponentModel.DataAnnotations.Schema;

namespace EntityRelationsDemo.Models
{
    public class Town
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [InverseProperty("CurrentResidence")]
        public ICollection<Student> CurrentResidences { get; set; }

        [InverseProperty("PlaceOfBirth")]
        public ICollection<Student> PlacesOfBirth { get; set; }
    }
}
