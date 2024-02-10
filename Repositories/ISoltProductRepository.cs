﻿using ProductShop.Entities;

namespace ProductShop.Repositories
{
    public interface ISoltProductRepository
    {
        Task<bool> SaveChangeAsync();
        Task<IEnumerable<SoltProduct>> GetSoltProductsAsync();
        Task AddSoltProductAsync(SoltProduct product);
    }
}
