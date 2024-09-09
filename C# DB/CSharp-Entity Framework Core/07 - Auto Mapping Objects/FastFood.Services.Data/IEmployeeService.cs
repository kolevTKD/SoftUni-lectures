using FastFood.Web.ViewModels.Employees;

namespace FastFood.Services.Data
{
    public interface IEmployeeService
    {
        Task<IEnumerable<RegisterEmployeeViewModel>> GetAllPositionsAsync();

        Task RegisterAsync(RegisterEmployeeInputModel model);

        Task<IEnumerable<EmployeesAllViewModel>> GetAllAsync();
    }
}
