using ProductShop.Entities;

namespace ProductShop.Repositories
{
    public interface IOverdueProductRepository
    {
        Task<bool> SaveChangeAsync();
        Task<IEnumerable<OverdueProduct>> GetOverdueProductsAsync();
        Task AddOverdueProductAsync(OverdueProduct product);
        Task DeleteOverdueProductAsync(OverdueProduct product);
        Task<OverdueProduct?> GetOverdueProductByIdAsync(int id);
    }
}
