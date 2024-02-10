using Microsoft.EntityFrameworkCore;
using ProductShop.DBContexts;
using ProductShop.Entities;
using ProductShop.Models;

namespace ProductShop.Repositories
{
    public class ProductGroupRepository : IProductGroupRepository
    {
        private readonly ProductShopContext _context;
        public ProductGroupRepository(ProductShopContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddNewProductGroupAsync(ProductGroup productGroup)
        {
            _context.ProductGroups.Add(productGroup);
        }

        public async Task DeleteGroupAsync(ProductGroup group)
        {
            _context.ProductGroups.Remove(group);
        }

        public async Task<ProductGroup?> GetProductGroupByIdAsync(int id)
        {
            return await _context.ProductGroups.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<ProductGroup>> GetProductGroups()
        {
            return await _context.ProductGroups.ToListAsync();
        }

        public async Task<bool> SaveChangeAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
