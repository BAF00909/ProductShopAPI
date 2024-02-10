using Microsoft.EntityFrameworkCore;
using ProductShop.DBContexts;
using ProductShop.Entities;

namespace ProductShop.Repositories
{
    public class OverdueProductRepository : IOverdueProductRepository
    {
        private readonly ProductShopContext _context;
        public OverdueProductRepository(ProductShopContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task AddOverdueProductAsync(OverdueProduct product)
        {
            _context.OverdueProducts.Add(product);
        }

        public async Task DeleteOverdueProductAsync(OverdueProduct product)
        {
            _context.OverdueProducts.Remove(product);
        }

        public async Task<OverdueProduct?> GetOverdueProductByIdAsync(int id)
        {
            return await _context.OverdueProducts.Where(p => p.Id == id).Include(p => p.Product).Include(p => p.Employee).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<OverdueProduct>> GetOverdueProductsAsync()
        {
            return await _context.OverdueProducts.Include(p => p.Product).Include(p => p.Employee).ToListAsync();
        }

        public async Task<bool> SaveChangeAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
