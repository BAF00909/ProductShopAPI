using ProductShop.Entities;
using ProductShop.Models;

namespace ProductShop.Repositories
{
    public interface IProductGroupRepository
    {
        Task<bool> SaveChangeAsync();
        Task<IEnumerable<ProductGroup>> GetProductGroups();
        Task AddNewProductGroupAsync(ProductGroup productGroup);
        Task<ProductGroup?> GetProductGroupByIdAsync(int id);
        Task DeleteGroupAsync(ProductGroup group);
    }
}
