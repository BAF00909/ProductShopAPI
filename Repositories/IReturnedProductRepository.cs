using ProductShop.Entities;
using ProductShop.Models;

namespace ProductShop.Repositories
{
    public interface IReturnedProductRepository
    {
        Task<bool> SaveChangeAsync();
        Task AddReturndeProductAsync(ReturnedProduct product);
        Task<IEnumerable<ReturnedProduct>> GetReturnedProductAsync();
        Task<ReturnedProduct?> GetReturnedProductByIdAsync(int id);
        Task DeleteReturnedProductAsync(ReturnedProduct product);
    }
}
