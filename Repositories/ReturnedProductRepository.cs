using Microsoft.EntityFrameworkCore;
using ProductShop.DBContexts;
using ProductShop.Entities;
using ProductShop.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductShop.Repositories
{
    public class ReturnedProductRepository : IReturnedProductRepository
    {
        private readonly ProductShopContext _context;
        public ReturnedProductRepository(ProductShopContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task AddReturndeProductAsync(ReturnedProduct product)
        {
            _context.ReturnedProducts.Add(product);
        }

        public async Task DeleteReturnedProductAsync(ReturnedProduct product)
        {
            _context.ReturnedProducts.Remove(product);
        }

        public async Task<IEnumerable<ReturnedProduct>> GetReturnedProductAsync()
        {
            return await _context.ReturnedProducts
                .Include(p => p.Employee)
                .Include(p => p.ReasonReturn)
                .Include(p => p.SoltProduct).ThenInclude(rp => rp.Product)
                .Include(p => p.SoltProduct).ThenInclude(rp => rp.Employee)
                .ToListAsync();
        }

        public async Task<ReturnedProduct?> GetReturnedProductByIdAsync(int id)
        {
            var product = await _context.ReturnedProducts
                .Include(r => r.ReasonReturn)
                .Include(r => r.Employee).ThenInclude(e => e.Position)
                .Include(r => r.SoltProduct).ThenInclude(rp => rp.Product)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {
                return null;
            }
            return product;
        }

        public async Task<bool> SaveChangeAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
