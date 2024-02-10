using ProductShop.Entities;
using ProductShop.Models;

namespace ProductShop.Repositories
{
    public interface IReturnedProductRepository
    {
        Task<bool> SaveChangeAsync();
        Task AddReturndeProductAsync(ReturnedProduct product);
        Task<IEnumerable<ReturnedProduct>> GetReturnedProductAsync();
    }
}
