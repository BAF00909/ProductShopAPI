using ProductShop.Entities;
using ProductShop.Models;

namespace ProductShop.Repositories
{
    public interface IProductRepository
    {
        Task<bool> SaveChangeAsync();
        Task AddProductAsync(Product product);
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product?> GetProductByIdAsync(int id);
        Task DeleteProductAsync(Product product);
    }
}
