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
