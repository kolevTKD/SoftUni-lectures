﻿namespace ORMFundamentalsTesting
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DepartmentId { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        public Department Department { get; set; }
    }
}
