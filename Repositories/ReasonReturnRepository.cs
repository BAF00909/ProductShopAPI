﻿using Microsoft.EntityFrameworkCore;
using ProductShop.DBContexts;
using ProductShop.Entities;

namespace ProductShop.Repositories
{
    public class ReasonReturnRepository : IReasonReturnRepository
    {
        private readonly ProductShopContext _context;
        public ReasonReturnRepository(ProductShopContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddNewReasonReturn(ReasonReturn reason)
        {
            _context.ReasonsReturn.Add(reason);
        }

        public async Task<IEnumerable<ReasonReturn>> GetReasonReturnAsync()
        {
            return await _context.ReasonsReturn.ToListAsync();
        }

        public async Task<bool> SaveChangeAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

    }
}