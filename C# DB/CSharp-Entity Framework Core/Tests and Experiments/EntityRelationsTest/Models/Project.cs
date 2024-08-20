using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityRelationsTest.Models
{
    public class Project
    {
        //[Key]
        public int Id { get; set; }
        public int Name { get; set; }
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}
