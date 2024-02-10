using ProductShop.Entities;

namespace ProductShop.Repositories
{
    public interface ISupplyRepository
    {
        Task<bool> SaveChangeAsync();
        Task AddSupplyAsync(Supply supply);
        Task<IEnumerable<Supply>> GetSuppliesAsync();
    }
}
