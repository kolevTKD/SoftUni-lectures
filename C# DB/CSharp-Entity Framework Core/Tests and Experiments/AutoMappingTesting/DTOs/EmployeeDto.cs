namespace AutoMappingTesting.DTOs
{
    public class EmployeeDto 
    {
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        
        //When changing the name of the property, that's relevant to the column's name, the AutoMapper is able to map it to the according object (DepartmentName)
        public string DepartmentName { get; set; }
        public decimal Salary { get; set; }
    }
}
