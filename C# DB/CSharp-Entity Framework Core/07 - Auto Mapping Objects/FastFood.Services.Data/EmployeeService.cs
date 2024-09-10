namespace FastFood.Services.Data
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;

    using FastFood.Data;
    using FastFood.Models;
    using Web.ViewModels.Employees;

    public class EmployeeService : IEmployeeService
    {
        private readonly IMapper mapper;
        private readonly FastFoodContext context;

        public EmployeeService(IMapper mapper, FastFoodContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task RegisterAsync(RegisterEmployeeInputModel model)
        {
            var employee = this.mapper.Map<Employee>(model);

            await this.context.Employees.AddAsync(employee);
            await this.context.SaveChangesAsync();
        }

        public async Task<IEnumerable<EmployeesAllViewModel>> GetAllAsync()
            => await this.context.Employees
                .ProjectTo<EmployeesAllViewModel>(mapper.ConfigurationProvider)
                .ToArrayAsync();

        public async Task<IEnumerable<RegisterEmployeeViewModel>> GetAllPositionsAsync()
            => await this.context.Positions
                .ProjectTo<RegisterEmployeeViewModel>(mapper.ConfigurationProvider)
                .ToArrayAsync();
    }

}
