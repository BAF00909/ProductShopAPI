using ProductShop.Entities;

namespace ProductShop.Repositories
{
    public interface IReasonReturnRepository
    {
        Task<bool> SaveChangeAsync();
        Task<IEnumerable<ReasonReturn>> GetReasonReturnAsync();
        Task AddNewReasonReturn(ReasonReturn reason);
    }
}
