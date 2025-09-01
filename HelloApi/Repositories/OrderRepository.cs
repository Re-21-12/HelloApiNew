using HelloApi.Data;
using HelloApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HelloApi.Repositories
{
    public class OrderRepository : Repository<Order>
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetOrdersByPersonIdAsync(int personId)
        {
            return await _context.Orders
                .Where(o => o.PersonId == personId)
                .ToListAsync();
        }

    }
}
