﻿using ProductShop.Entities;

namespace ProductShop.Repositories
{
    public interface IReasonReturnRepository
    {
        Task<bool> SaveChangeAsync();
        Task<IEnumerable<ReasonReturn>> GetReasonReturnAsync();
        Task AddNewReasonReturn(ReasonReturn reason);
        Task<ReasonReturn?> GetReasonReturnByIdAsync(int id);
        Task DeleteReasonReturn(ReasonReturn reason);
    }
}
