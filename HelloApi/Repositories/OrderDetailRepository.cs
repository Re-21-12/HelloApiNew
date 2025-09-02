using HelloApi.Data;
using HelloApi.Models;
using HelloApi.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace HelloApi.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository

    {
        private readonly AppDbContext _context;

        public OrderDetailRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<OrderDetail> AddOrderDetailAsync(int ItemId, int OrderId, decimal total, decimal price, int quantity)
        {
            var entity = new OrderDetail
            {
                ItemId = ItemId,
                OrderId = OrderId,
                Total = total,
                Price = price,
                Quantity = quantity,
            };
            _context.OrderDetails.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        
        }

        public async Task<IEnumerable<OrderDetail>> GetAllOrderDetailAsync()
        {
            return await _context.OrderDetails.OrderBy(m => m.Id).ToListAsync();
        }
        public async Task<IEnumerable<OrderDetail>> GetByOrderItem(int orderid)
        {
            return await _context.OrderDetails
                .Include(od => od.Item)
                .Where(orderDetail => orderDetail.OrderId == orderid)
                .ToListAsync();
        }


    }
}
