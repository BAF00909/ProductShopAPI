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

        public async Task DeleteProductAsync(Product product)
        {
            _context.Products.Remove(product);
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _context.Products.Include(p => p.ProductGroup).Include(p => p.Supply).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IQueryable<Product>> GetProductsAsync(
            int? id = null, int? art = null, string? productName = null,
            DateTime? dateInStart = null, DateTime? dateInFinish = null, int? count = null, decimal? cost = null,
            int? productGroupId = null, int? supplyId = null
            )
        {
            var result = _context.Products
                .Include(p => p.ProductGroup)
                .Include(p => p.Supply).AsQueryable();
            if(id.HasValue)
            {
                result = result.Where(p => p.Id == id);
            }
            if (art.HasValue)
            {
                result = result.Where(p => p.Art == art);
            }
            if (!string.IsNullOrEmpty(productName))
            {
                result = result.Where(p => p.ProductName == productName);
            }
            if (dateInStart.HasValue)
            {
                result = result.Where(p => p.DateIn >= dateInStart);
            }
            if (dateInFinish.HasValue)
            {
                result = result.Where(p => p.DateIn <= dateInFinish);
            }
            if (count.HasValue)
            {
                result = result.Where(p => p.Count == count);
            }
            if (cost.HasValue)
            {
                result = result.Where(p => p.Cost == cost);
            }
            if (productGroupId.HasValue)
            {
                result = result.Where(p => p.ProductGroupId == productGroupId);
            }
            if (supplyId.HasValue)
            {
                result = result.Where(p => p.SupplyId == supplyId);
            }

            return result;
        }

        public async Task<bool> SaveChangeAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
