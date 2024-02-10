using Microsoft.EntityFrameworkCore;
using ProductShop.DBContexts;
using ProductShop.Entities;

namespace ProductShop.Repositories
{
    public class ProviderRepository : IProviderRepository
    {
        private readonly ProductShopContext _context;
        public ProviderRepository(ProductShopContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddNewProviderAsync(Provider provider)
        {
            _context.Providers.Add(provider);
        }

        public async Task DeleteProviderAsync(Provider provider)
        {
            _context.Providers.Remove(provider);
        }

        public async Task<Provider?> GetProviderByIdAsync(int id)
        {
            var provider = await _context.Providers.FirstOrDefaultAsync(p => p.Id == id);
            if (provider == null)
            {
                return null;
            }
            return provider;
        }

        public async Task<IEnumerable<Provider>> GetProvidersAsync()
        {
            return await _context.Providers.ToListAsync();
        }

        public async Task<bool> SaveChangeAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
