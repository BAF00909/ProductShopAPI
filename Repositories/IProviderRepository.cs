using ProductShop.Entities;

namespace ProductShop.Repositories
{
    public interface IProviderRepository
    {
        Task<bool> SaveChangeAsync();
        Task<IEnumerable<Provider>> GetProvidersAsync();
        Task AddNewProviderAsync(Provider provider);
        Task DeleteProviderAsync(Provider provider);
        Task<Provider?> GetProviderByIdAsync(int id);
    }
}
