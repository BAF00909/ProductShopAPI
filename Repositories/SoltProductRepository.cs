using Microsoft.EntityFrameworkCore;
using ProductShop.DBContexts;
using ProductShop.Entities;

namespace ProductShop.Repositories
{
    public class SoltProductRepository : ISoltProductRepository
    {
        private readonly ProductShopContext _context;
        public SoltProductRepository(ProductShopContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task AddSoltProductAsync(SoltProduct product)
        {
            _context.SoltProducts.Add(product);
        }

        public async Task DeleteSoltProductAsync(SoltProduct product)
        {
            _context.SoltProducts.Remove(product);
        }

        public async Task<SoltProduct?> GetSoltProductByIdAsync(int id)
        {
            var soltProduct = await _context.SoltProducts.Include(s => s.Product).Include(s => s.Employee).FirstOrDefaultAsync(s => s.Id == id);
            if (soltProduct == null)
            {
                return null;
            }
            return soltProduct;
        }

        public async Task<IEnumerable<SoltProduct>> GetSoltProductsAsync()
        {
            return await _context.SoltProducts.Include(p => p.Product).Include(p => p.Employee).ToListAsync();
        }

        public async Task<bool> SaveChangeAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
