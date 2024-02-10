using Microsoft.EntityFrameworkCore;
using ProductShop.DBContexts;
using ProductShop.Entities;
using ProductShop.Models;

namespace ProductShop.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductShopContext _context;
        public ProductRepository(ProductShopContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task AddProductAsync(Product product)
        {
            _context.Products.Add(product);
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _context.Products.Include(p => p.ProductGroup).Include(p => p.Supply).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.Products.Include(p => p.ProductGroup).Include(p => p.Supply).ToListAsync();
        }

        public async Task<bool> SaveChangeAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
