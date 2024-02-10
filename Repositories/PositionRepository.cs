using Microsoft.EntityFrameworkCore;
using ProductShop.DBContexts;
using ProductShop.Entities;
using ProductShop.Models;

namespace ProductShop.Repositories
{
    public class PositionRepository : IPositionRepository
    {
        private readonly ProductShopContext _context;
        public PositionRepository(ProductShopContext constext)
        {
            _context = constext ?? throw new ArgumentNullException(nameof(constext));
        }
        public async Task AddPositionAsync(Position newPosition)
        {
            _context.Positions.Add(newPosition);
        }

        public async Task DeletePositionAsync(Position position)
        {
            _context.Positions.Remove(position);
        }

        public async Task<Position?> GetPositionByIdAsync(int id)
        {
            return await _context.Positions.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Position>> GetPositionsAsync()
        {
            return await _context.Positions.ToListAsync();
        }

        public async Task<bool> SaveChangeAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
