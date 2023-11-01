using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFCoreTesting.Models
{
    [Table("Deleted_Employees")]
    public partial class DeletedEmployee
    {
        [Key]
        public int EmployeeId { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? FirstName { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? LastName { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? MiddleName { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? JobTitle { get; set; }
        public int? DepartmentId { get; set; }
        [Column(TypeName = "money")]
        public decimal? Salary { get; set; }
    }
}
