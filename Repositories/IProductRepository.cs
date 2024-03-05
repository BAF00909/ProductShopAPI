using ProductShop.Entities;
using ProductShop.Models;

namespace ProductShop.Repositories
{
    public interface IProductRepository
    {
        Task<bool> SaveChangeAsync();
        Task AddProductAsync(Product product);
        Task<IQueryable<Product>> GetProductsAsync(
            int? id, int? art, string? productName, DateTime? dateInStart, DateTime? dateInFinish, int? count, decimal? cost, int? productGroupId, int? supplyId
            );
        Task<Product?> GetProductByIdAsync(int id);
        Task DeleteProductAsync(Product product);
    }
}
