namespace FastFood.Web.ViewModels.Employees
{
    using System.ComponentModel.DataAnnotations;

    using Common.EntityConfiguration;

    public class RegisterEmployeeInputModel
    {
        [MinLength(ViewModelsValidation.EMPLOYEE_NAME_MIN_LENGTH)]
        [MaxLength(ViewModelsValidation.EMPLOYEE_NAME_MAX_LENGTH)]
        public string Name { get; set; } = null!;

        [Range(15, 80)]
        public int Age { get; set; }

        public int PositionId { get; set; }

        public string PositionName { get; set; } = null!;

        [MinLength(ViewModelsValidation.EMPLOYEE_ADDRESS_MIN_LENGTH)]
        [MaxLength(ViewModelsValidation.EMPLOYEE_ADDRESS_MAX_LENGTH)]
        public string Address { get; set; } = null!;
    }
}
