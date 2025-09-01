using HelloApi.Models;
using HelloApi.Models.Dtos;

namespace HelloApi.Services
{
    public interface IOrderDetailService
    {
        Task<OrderDetailDto> CreateOrderDetailAsync(int ItemId, int OrderId, int quantity);
        //Task<ReadOrderDetailDto> GetAllOrderDetailAsync();

        Task<IEnumerable<ReadOrderDetailDto>> GetByOrderItem(int orderId, int itemId);
    }
}
