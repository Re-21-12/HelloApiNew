using HelloApi.Models;
using HelloApi.Models.Dtos;

namespace HelloApi.Repositories
{
    public interface IOrderDetailRepository
    {
        public Task<OrderDetail> AddOrderDetailAsync(int ItemId, int OrderId, decimal total, decimal price, int quantity);
        public Task<IEnumerable<OrderDetail>> GetByOrderItem(int orderId, int itemdId);
    }

}
