using Microsoft.EntityFrameworkCore;
using ProductShop.DBContexts;
using ProductShop.Entities;

namespace ProductShop.Repositories
{
    public class SupplyRepository : ISupplyRepository
    {
        private readonly ProductShopContext _context;
        public SupplyRepository(ProductShopContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task AddSupplyAsync(Supply supply)
        {
            _context.Supplies.Add(supply);
        }

        public async Task<IEnumerable<Supply>> GetSuppliesAsync()
        {
            // var result = await _context.Supplies.Include(s => s.Provider).ToListAsync();
            return await _context.Supplies.Include(s => s.Provider).Include(s => s.EmployeeAccepted).ToListAsync();
        }

        public async Task<bool> SaveChangeAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
