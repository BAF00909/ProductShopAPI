using Microsoft.EntityFrameworkCore;
using ProductShop.DBContexts;
using ProductShop.Entities;
using ProductShop.Models;

namespace ProductShop.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ProductShopContext _context;
        public EmployeeRepository(ProductShopContext constext)
        {
            _context = constext ?? throw new ArgumentNullException(nameof(constext));
        }

        public async Task AddEmployeeAsync(Employee newEmployee)
        {
            _context.Employees.Add(newEmployee);
        }

        public async Task EmployeeDeleteAsync(Employee employee)
        {
            _context.Employees.Remove(employee);
        }

        public async Task<IEnumerable<Employee>> GetEmployeeAsync()
        {
            return await _context.Employees.Include(e => e.Position).ToListAsync();
        }

        public async Task<Employee?> GetEmployeeByIdAsync(int id)
        {
            return await _context.Employees.Where(e => e.Id == id).Include(e => e.Position).FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangeAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
