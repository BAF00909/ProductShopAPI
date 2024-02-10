using ProductShop.Entities;
using ProductShop.Models;

namespace ProductShop.Repositories
{
    public interface IPositionRepository
    {
        Task<bool> SaveChangeAsync();
        Task AddPositionAsync(Position newPosition);
        Task<IEnumerable<Position>> GetPositionsAsync();
        Task<Position> GetPositionByIdAsync(int id);
        Task DeletePositionAsync(Position position);
    }
}
