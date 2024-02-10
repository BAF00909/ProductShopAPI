using ProductShop.Entities;
using ProductShop.Models;

namespace ProductShop.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployeeAsync();
        Task AddEmployeeAsync(Employee newEmployee);
        Task<bool> SaveChangeAsync();
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task EmployeeDeleteAsync(Employee employee);
    }
}
