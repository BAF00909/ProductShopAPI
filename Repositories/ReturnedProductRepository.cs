﻿using Microsoft.EntityFrameworkCore;
using ProductShop.DBContexts;
using ProductShop.Entities;
using ProductShop.Models;

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
                .Include(p => p.ReasonReturn)
                .Include(p => p.SoltProduct).Include(p => p.Employee).ToListAsync();
        }

        public async Task<ReturnedProduct?> GetReturnedProductByIdAsync(int id)
        {
            var product =  await _context.ReturnedProducts
                .Include(p => p.ReasonReturn)
                .Include(p => p.Employee)
                .Include(p => p.SoltProduct)
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
